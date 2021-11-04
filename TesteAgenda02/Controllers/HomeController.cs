using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TesteAgenda02.Bl;
using TesteAgenda02.Models;

namespace TesteAgenda02.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TaskContext _context;

        public HomeController(ILogger<HomeController> logger, TaskContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<TaskModel> taskList = new List<TaskModel>();
            TasksDal agendamentoBd = new TasksDal();
            bool retorno = agendamentoBd.GetTasks(_context, ref taskList);

            if (retorno == false)
            {
                return View("Error");
            }

            return View("List", taskList);
        }

        public IActionResult ListHoursPerDay()
        {
            List<SummarizedTasksModel> listaTasks = new List<SummarizedTasksModel>();

            SearchTaskModel pesquisaModel = new SearchTaskModel();
            pesquisaModel.ListTasksSummarized = listaTasks;
            pesquisaModel.InitialDate = DateTime.Now.AddDays(-7);
            pesquisaModel.FinalDate = DateTime.Now.AddDays(7);

            return View(pesquisaModel);
        }


        [HttpPost]
        public IActionResult ListHoursPerDay(SearchTaskModel agendamentoModel)
        {

            List<SummarizedTasksModel> listaTasks = new List<SummarizedTasksModel>();
            TasksDal agendamentoBd = new TasksDal();
            bool retorno = agendamentoBd.ObterTasksConsolidados(_context, agendamentoModel.InitialDate,
                                                        agendamentoModel.FinalDate, ref listaTasks);

            if (retorno == false)
            {
                return View("Error");
            }

            agendamentoModel.ListTasksSummarized = listaTasks;
            return Json(agendamentoModel);

        }


        public IActionResult Include()
        {
            TaskModel agendamentoModel = new TaskModel();
            agendamentoModel.Id = Guid.NewGuid();
            agendamentoModel.Date = DateTime.Now;
            agendamentoModel.Priority = 1;
            return View(agendamentoModel);
        }

        bool ValidarAgendamento(TaskModel agendamentoModel, ref string mensagemErro)
        {

            if (agendamentoModel.InitialHour == agendamentoModel.FinalHour)
            {
                mensagemErro = "A hora final e a hora inicial são iguais.";
                return false;
            }

            DateTime dataInicioTarefa = agendamentoModel.Date.AddHours(agendamentoModel.InitialHour.Hour)
                .AddMinutes(agendamentoModel.InitialHour.Minute);

            DateTime dataAgora = DateTime.Now;
            if (dataInicioTarefa < dataAgora)
            {
                mensagemErro = "A data inicial é menor que a data atual.";
                return false;
            }

            DateTime dataFimTarefa = agendamentoModel.Date.AddHours(agendamentoModel.FinalHour.Hour)
               .AddMinutes(agendamentoModel.FinalHour.Minute);

            if (dataFimTarefa < dataAgora)
            {
                mensagemErro = "A data final é menor que a data atual.";
                return false;
            }

            if (dataFimTarefa < dataInicioTarefa)
            {
                mensagemErro = "A data final deve ser maior que a data atual.";
                return false;
            }

            TimeSpan horasTarefa = DateTime.Parse(agendamentoModel.FinalHour.ToShortTimeString()).Subtract(DateTime.Parse(agendamentoModel.InitialHour.ToShortTimeString()));

            double minutosTotais = horasTarefa.TotalMinutes;

            if (minutosTotais > 300)
            {
                mensagemErro = "O tempo da tarefa é maior que 5 horas.";
                return false;
            }

            TasksDal agendamentoBd = new TasksDal();
            bool retornoSobreposicao = agendamentoBd.ValidarSobreposicaoTasks(_context,
                                                                                    agendamentoModel.Id,
                                                                                    agendamentoModel.Date,
                                                                                    dataInicioTarefa, dataFimTarefa);
            if (retornoSobreposicao == false)
            {
                mensagemErro = "Sobreposição de tarefa, por favor selecione outro horário.";
                return false;
            }

            return true;
        }

        [HttpPost]
        public IActionResult Include(TaskModel agendamentoModel)
        {
            if (!ModelState.IsValid)
            {
                return View(agendamentoModel);
            }

            string mensagemErro = "";

            if (!ValidarAgendamento(agendamentoModel, ref mensagemErro))
            {
                ModelState.AddModelError("", mensagemErro);
                return View(agendamentoModel);
            }


            agendamentoModel.Id = Guid.NewGuid();
            agendamentoModel.InitialHour = agendamentoModel.Date.AddHours(agendamentoModel.InitialHour.Hour).AddMinutes(agendamentoModel.InitialHour.Minute);
            agendamentoModel.FinalHour = agendamentoModel.Date.AddHours(agendamentoModel.FinalHour.Hour).AddMinutes(agendamentoModel.FinalHour.Minute); ;

            TasksDal agendamentoBd = new TasksDal();
            bool retorno = agendamentoBd.AddTask(_context, agendamentoModel);

            if (retorno == false)
            {
                return View("Error");
            }

            return List();
        }

        public IActionResult Edit(Guid id)
        {
            TaskModel agendamentoModel = new TaskModel();

            TasksDal agendamentoBd = new TasksDal();
            bool retorno = agendamentoBd.ObterAgendamento(_context, id, ref agendamentoModel);

            if (retorno == false)
            {
                return View("Error");
            }

            return View("Inclusao", agendamentoModel);
        }


        [HttpPost]
        public IActionResult Edit(TaskModel agendamentoModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Include", agendamentoModel);
            }

            string mensagemErro = "";

            if (!ValidarAgendamento(agendamentoModel, ref mensagemErro))
            {
                ModelState.AddModelError("", mensagemErro);
                return View("Include", agendamentoModel);
            }


            agendamentoModel.Inclusion = "edit";
            TasksDal agendamentoBd = new TasksDal();

            agendamentoModel.InitialHour = agendamentoModel.Date.AddHours(agendamentoModel.InitialHour.Hour).AddMinutes(agendamentoModel.InitialHour.Minute);
            agendamentoModel.FinalHour = agendamentoModel.Date.AddHours(agendamentoModel.FinalHour.Hour).AddMinutes(agendamentoModel.FinalHour.Minute); ;

            bool retorno = agendamentoBd.AddTask(_context, agendamentoModel);
            if (retorno == false)
            {
                return View("Error");
            }

            return List();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
