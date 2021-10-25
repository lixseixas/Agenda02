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
        private readonly AgendaContexto _context;

        public HomeController(ILogger<HomeController> logger, AgendaContexto context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Listagem()
        {
            List<AgendamentoModel> listaAgendamentos = new List<AgendamentoModel>();
            AgendamentoBd agendamentoBd = new AgendamentoBd();
            string filtros = "";
            agendamentoBd.ObterAgendamentos(_context, filtros, ref listaAgendamentos);

            return View(listaAgendamentos);
        }

        public IActionResult ListagemHorasDia()
        {
            List<AgendamentoConsolidadoModel> listaAgendamentos = new List<AgendamentoConsolidadoModel>();

            PesquisaAgendamentoModel pesquisaModel = new PesquisaAgendamentoModel();
            pesquisaModel.ListaAgendamentosConsolidados = listaAgendamentos;
            pesquisaModel.DataInicial = DateTime.Now.AddDays(-7);
            pesquisaModel.DataFinal = DateTime.Now.AddDays(7);

            return View(pesquisaModel);
        }


        [HttpPost]
        public IActionResult ListagemHorasDia(PesquisaAgendamentoModel agendamentoModel)
        {

            List<AgendamentoConsolidadoModel> listaAgendamentos = new List<AgendamentoConsolidadoModel>();
            AgendamentoBd agendamentoBd = new AgendamentoBd();
            agendamentoBd.ObterAgendamentosConsolidados(_context, agendamentoModel.DataInicial,
                                                        agendamentoModel.DataFinal, ref listaAgendamentos);

            agendamentoModel.ListaAgendamentosConsolidados = listaAgendamentos;
            return Json(agendamentoModel);
            
        }


        public IActionResult Inclusao()
        {
            AgendamentoModel agendamentoModel = new AgendamentoModel();
            agendamentoModel.Id = Guid.NewGuid();
            agendamentoModel.Data = DateTime.Now;        
            return View(agendamentoModel);
        }

        bool ValidarAgendamento(AgendamentoModel agendamentoModel, ref string mensagemErro)
        {

            if (agendamentoModel.HoraInicio == agendamentoModel.HoraFim)
            {
                mensagemErro= "A hora final e a hora inicial são iguais.";
                return false;
            }

            DateTime dataTarefa = agendamentoModel.Data.AddHours(agendamentoModel.HoraInicio.Hour)
                .AddMinutes(agendamentoModel.HoraInicio.Minute);

            DateTime dataAgora = DateTime.Now;
            if (dataTarefa < dataAgora)
            {
                mensagemErro = "A data inicial é menor que a data atual.";
                return false;
            }

            DateTime dataFimTarefa = agendamentoModel.Data.AddHours(agendamentoModel.HoraFim.Hour)
               .AddMinutes(agendamentoModel.HoraFim.Minute);

            if (dataFimTarefa < dataAgora)
            {
                mensagemErro = "A data final é menor que a data atual.";
                return false;
            }

            if (dataFimTarefa < dataTarefa)
            {
                mensagemErro = "A data final deve ser maior que a data atual.";
                return false;
            }

            TimeSpan horasTarefa = DateTime.Parse(agendamentoModel.HoraFim.ToShortTimeString()).Subtract(DateTime.Parse(agendamentoModel.HoraInicio.ToShortTimeString()));

            double minutosTotais = horasTarefa.TotalMinutes;

            if (minutosTotais > 300)
            {
                mensagemErro = "O tempo da tarefa é maior que 5 horas.";
                return false;
            }

            return true;
        }

        [HttpPost]
        public IActionResult Inclusao(AgendamentoModel agendamentoModel)
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

            AgendamentoBd agendamentoBd = new AgendamentoBd();
            agendamentoBd.IncluirAgendamento(_context, agendamentoModel);

            return View("Index");
        }

        public IActionResult Edicao(Guid id)
        {
            AgendamentoModel agendamentoModel = new AgendamentoModel();

            AgendamentoBd agendamentoBd = new AgendamentoBd();
            agendamentoBd.ObterAgendamento(_context, id, ref agendamentoModel);

            return View("Inclusao", agendamentoModel);
        }


        [HttpPost]
        public IActionResult Edicao(AgendamentoModel agendamentoModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Inclusao", agendamentoModel);
            }

            string mensagemErro = "";

            if (!ValidarAgendamento(agendamentoModel, ref mensagemErro))
            {
                ModelState.AddModelError("", mensagemErro);
                return View("Inclusao", agendamentoModel);
            }

           
            agendamentoModel.Inclusao = "edicao";
            AgendamentoBd agendamentoBd = new AgendamentoBd();
            agendamentoBd.IncluirAgendamento(_context, agendamentoModel);

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
