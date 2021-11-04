using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAgenda02.Models;

namespace TesteAgenda02.Bl
{
    public class TasksDal
    {
        public bool AddTask(TaskContext context, TaskModel agendamentoModel)
        {
            try
            {
                if (agendamentoModel.Inclusion == "edition")
                {
                    TaskModel agendamentoObtidoModel = new TaskModel();

                    ObterAgendamento(context, agendamentoModel.Id, ref agendamentoObtidoModel);

                    agendamentoObtidoModel.Description = agendamentoModel.Description;
                    agendamentoObtidoModel.Date = agendamentoModel.Date;
                    agendamentoObtidoModel.Title = agendamentoModel.Title;
                    agendamentoObtidoModel.InitialHour = agendamentoModel.InitialHour;
                    agendamentoObtidoModel.FinalHour = agendamentoModel.FinalHour;
                    agendamentoObtidoModel.Priority = agendamentoModel.Priority;
                    agendamentoObtidoModel.Ended = agendamentoModel.Ended;

                    context.SaveChanges();
                }
                else
                {
                    context.Tasks.Add(agendamentoModel);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

           

        }

        public bool GetTasks(TaskContext context, ref List<TaskModel> listaTasks)
        {
            try
            {
                listaTasks = context.Tasks.OrderBy(p => p.Date).ToList();

                foreach (var item in listaTasks)
                {
                    switch (item.Priority)
                    {
                        case 3:
                            item.PriorityName = "High";
                            break;
                        case 2:
                            item.PriorityName = "Medium";
                            break;
                        case 1:
                            item.PriorityName = "Low";
                            break;

                        default:
                            break;
                    }
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }

            

        }

        public bool ObterTasksConsolidados(TaskContext context, DateTime dataInicial, DateTime dataFinal, ref List<SummarizedTasksModel> listaConsolidados)
        {
            try
            {
                dataFinal = dataFinal.AddHours(23).AddMinutes(59);

                List<TaskModel> listaTasks = context.Tasks.Where(p => p.Date >= dataInicial
                                                                   && p.Date <= dataFinal)
                                                        .OrderBy(p => p.Date)
                                                        .ToList();


                //Total de horas por dia, 
                var listaAgrupadaPorDia = listaTasks.GroupBy(p => p.Date).ToList();

                foreach (var listaTarefas in listaAgrupadaPorDia)
                {
                    SummarizedTasksModel consolidado = new SummarizedTasksModel();

                    TimeSpan totalHoras = new TimeSpan();
                    TimeSpan totalHorasConcluidas = new TimeSpan();

                    foreach (var tarefa in listaTarefas)
                    {
                        TimeSpan horasTarefa = DateTime.Parse(tarefa.FinalHour.ToShortTimeString()).Subtract(DateTime.Parse(tarefa.InitialHour.ToShortTimeString()));
                        totalHoras = totalHoras + horasTarefa;

                        if (tarefa.Ended == true)
                        {
                            totalHorasConcluidas = totalHorasConcluidas + horasTarefa;
                        }
                    }

                    consolidado.Date = listaTarefas.FirstOrDefault().Date;
                    consolidado.Hours = totalHoras.ToString();
                    consolidado.TotalTasks = listaTarefas.Count();
                    consolidado.AverageHours = Convert.ToString(totalHoras / listaTarefas.Count());

                    //calculando o percentual
                    double minutosTotais = totalHoras.TotalMinutes;
                    double minutosConcluidos = totalHorasConcluidas.TotalMinutes;
                    double diferenca = minutosConcluidos / minutosTotais;

                    consolidado.PercentualConcludedTasks = diferenca = Math.Round(diferenca * 100);

                    listaConsolidados.Add(consolidado);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }


        public bool ObterAgendamento(TaskContext context, Guid id, ref TaskModel agendamentoModel)
        {
            var listaTasks = context.Tasks.Where(p => p.Id == id).ToList();

            if (listaTasks.Count > 0)
            {
                agendamentoModel = listaTasks.FirstOrDefault();
                return true;
            }

            else
            {
                return false;
            }
          

        }

        public bool ValidarSobreposicaoTasks(TaskContext context, Guid idAgendamento, DateTime data, DateTime dataInicial, DateTime dataFinal)
        {
            TaskModel itemRetornoBanco = new TaskModel();

            //filtra todos os agendamentos da mesma data e com id diferente
            var listaFiltrada = context.Tasks.Where(p => p.Date >= data && p.Id != idAgendamento)
                                                                .OrderBy(p => p.Date).ToList();

                       
            if (listaFiltrada == null) //--> se nao tiver nada no banco
            {
                return true;
            }

            // --> tenta encontrar algum agendamento que contenha a hora inicial
            itemRetornoBanco = listaFiltrada.Where(p => p.InitialHour <= dataInicial
                                 && p.FinalHour >= dataInicial).FirstOrDefault();

            if (itemRetornoBanco != null) //--> se já tiver cadastrado
            {               
                return false;
            }
            else
            {
                // --> tenta encontrar alguma config. que contenha a hora final
                itemRetornoBanco = listaFiltrada.Where(p => p.InitialHour <= dataFinal
                                 && p.FinalHour >= dataFinal).FirstOrDefault();
            }

            if (itemRetornoBanco != null)  //--> se já tiver cadastrado
            {                
                return false;
            }
            else
            {
                // ---> Tenta encontrar uma hora que contenha a hora adicionada
                itemRetornoBanco = listaFiltrada.Where(p => p.InitialHour <= dataInicial
                    && p.FinalHour >= dataFinal ).FirstOrDefault();
            }
            if (itemRetornoBanco != null)  //--> se houver
            {               
                return false;
            }
            else
            {
                // ---> Tenta encontrar uma hora que esteja contida dentro da hora adicionada
                itemRetornoBanco = listaFiltrada.Where(p => p.InitialHour >= dataInicial
                    && p.FinalHour <= dataFinal ).FirstOrDefault();

            }
            if (itemRetornoBanco != null)  //--> se houver
            {               
                return false;
            }

            return true;

        }

    }
}

