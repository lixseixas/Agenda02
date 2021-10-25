using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAgenda02.Models;

namespace TesteAgenda02.Bl
{
    public class AgendamentoBd
    {
        public void IncluirAgendamento(AgendaContexto context, AgendamentoModel agendamentoModel)
        {
            


            if (agendamentoModel.Inclusao == "edicao")
            {
                AgendamentoModel agendamentoObtidoModel = new AgendamentoModel();

                ObterAgendamento(context, agendamentoModel.Id, ref agendamentoObtidoModel);

                agendamentoObtidoModel.Descricao = agendamentoModel.Descricao;
                agendamentoObtidoModel.Data = agendamentoModel.Data;
                agendamentoObtidoModel.Titulo = agendamentoModel.Titulo;
                agendamentoObtidoModel.HoraInicio = agendamentoModel.HoraInicio;
                agendamentoObtidoModel.HoraFim = agendamentoModel.HoraFim;
                agendamentoObtidoModel.Prioridade = agendamentoModel.Prioridade;
                agendamentoObtidoModel.Finalizada = agendamentoModel.Finalizada;

                context.SaveChanges();
            }
            else
            {
                context.Agendamentos.Add(agendamentoModel);
                context.SaveChanges();
            }

        }

        public void ObterAgendamentos(AgendaContexto context, string filtros, ref List<AgendamentoModel> listaAgendamentos)
        {
            listaAgendamentos = context.Agendamentos.OrderBy(p => p.Data).ToList();

            foreach (var item in listaAgendamentos)
            {
                switch (item.Prioridade)
                {
                    case 3:
                        item.NomePrioridade = "Alta";
                        break;
                    case 2:
                        item.NomePrioridade = "Média";
                        break;
                    case 1:
                        item.NomePrioridade = "Baixa";
                        break;

                    default:
                        break;
                }
            }

        }

        public void ObterAgendamentosConsolidados(AgendaContexto context, DateTime dataInicial, DateTime dataFinal, ref List<AgendamentoConsolidadoModel> listaConsolidados)
        {
            dataFinal = dataFinal.AddHours(23).AddMinutes(59);

            List<AgendamentoModel> listaAgendamentos = context.Agendamentos.Where(p => p.Data >= dataInicial
                                                               && p.Data <= dataFinal)
                                                    .OrderBy(p => p.Data)
                                                    .ToList();


            //Total de horas por dia, 
            var listaAgrupadaPorDia = listaAgendamentos.GroupBy(p => p.Data).ToList();

            foreach (var listaTarefas in listaAgrupadaPorDia)
            {
                AgendamentoConsolidadoModel consolidado = new AgendamentoConsolidadoModel();

                TimeSpan totalHoras = new TimeSpan();
                TimeSpan totalHorasConcluidas = new TimeSpan();

                foreach (var tarefa in listaTarefas)
                {
                    TimeSpan horasTarefa = DateTime.Parse(tarefa.HoraFim.ToShortTimeString()).Subtract(DateTime.Parse(tarefa.HoraInicio.ToShortTimeString()));
                    totalHoras = totalHoras + horasTarefa;

                    if (tarefa.Finalizada == true)
                    {
                        totalHorasConcluidas = totalHorasConcluidas + horasTarefa;
                    }
                }
              //  teste

                consolidado.Data = listaTarefas.FirstOrDefault().Data;
                consolidado.Horas = totalHoras.ToString();
                consolidado.TotalTarefas = listaTarefas.Count();
                consolidado.MediaHoras = Convert.ToString(totalHoras / listaTarefas.Count());

                //calculando o percentual
                double minutosTotais = totalHoras.TotalMinutes;
                double minutosConcluidos = totalHorasConcluidas.TotalMinutes;
                double diferenca = minutosConcluidos/ minutosTotais;
                
                consolidado.PercentualTarefasConcluidas = diferenca = Math.Round(diferenca *100);

                listaConsolidados.Add(consolidado);
            }

           
        }


        public void ObterAgendamento(AgendaContexto context, Guid id, ref AgendamentoModel agendamentoModel)
        {
            var listaAgendamentos = context.Agendamentos.Where(p => p.Id == id).ToList();

            if (listaAgendamentos.Count > 0)
            {
                agendamentoModel = listaAgendamentos.FirstOrDefault();
            }

        }
    }
}

