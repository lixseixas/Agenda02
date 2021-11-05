﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskProject.Models;

namespace TaskProject.Bl
{
    public class TasksDal
    {
        public bool AddTask(TaskContext context, TaskModel taskModel)
        {
            try
            {
                if (taskModel.Inclusion == "edit")
                {
                    TaskModel obtainedTaskModel = new TaskModel();

                    GetTask(context, taskModel.Id, ref obtainedTaskModel);

                    obtainedTaskModel.Description = taskModel.Description;
                    obtainedTaskModel.Date = taskModel.Date;
                    obtainedTaskModel.Title = taskModel.Title;
                    obtainedTaskModel.InitialHour = taskModel.InitialHour;
                    obtainedTaskModel.FinalHour = taskModel.FinalHour;
                    obtainedTaskModel.Priority = taskModel.Priority;
                    obtainedTaskModel.Ended = taskModel.Ended;

                    context.SaveChanges();
                }
                else
                {
                    context.Tasks.Add(taskModel);
                    context.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }           

        }

        public bool GetTasks(TaskContext context, ref List<TaskModel> taskList)
        {
            try
            {
                taskList = context.Tasks.OrderBy(p => p.Date).ToList();

                foreach (var item in taskList)
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

        public bool GetSummarizedTasks(TaskContext context, DateTime dataInicial, DateTime dataFinal, ref List<SummarizedTasksModel> consolidatedList)
        {
            try
            {
                dataFinal = dataFinal.AddHours(23).AddMinutes(59);

                List<TaskModel> taskList = context.Tasks.Where(p => p.Date >= dataInicial
                                                                   && p.Date <= dataFinal)
                                                        .OrderBy(p => p.Date)
                                                        .ToList();


                //daily total hours
                var listaAgrupadaPorDia = taskList.GroupBy(p => p.Date).ToList();

                foreach (var item in listaAgrupadaPorDia)
                {
                    SummarizedTasksModel summarized = new SummarizedTasksModel();

                    TimeSpan totalHours = new TimeSpan();
                    TimeSpan totalHoursConcluded = new TimeSpan();

                    foreach (var tarefa in item)
                    {
                        TimeSpan hoursTarefa = DateTime.Parse(tarefa.FinalHour.ToShortTimeString()).Subtract(DateTime.Parse(tarefa.InitialHour.ToShortTimeString()));
                        totalHours = totalHours + hoursTarefa;

                        if (tarefa.Ended == true)
                        {
                            totalHoursConcluded = totalHoursConcluded + hoursTarefa;
                        }
                    }

                    summarized.Date = item.FirstOrDefault().Date;
                    summarized.Hours = totalHours.ToString();
                    summarized.TotalTasks = item.Count();
                    summarized.AverageHours = Convert.ToString(totalHours / item.Count());

                    //calculating percentual
                    double minutesTotal = totalHours.TotalMinutes;
                    double minutesConcluded = totalHoursConcluded.TotalMinutes;
                    double diference = minutesConcluded / minutesTotal;

                    summarized.PercentualConcludedTasks = diference = Math.Round(diference * 100);

                    consolidatedList.Add(summarized);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }


        public bool GetTask(TaskContext context, Guid id, ref TaskModel taskModel)
        {
            var taskList = context.Tasks.Where(p => p.Id == id).ToList();

            if (taskList.Count > 0)
            {
                taskModel = taskList.FirstOrDefault();
                return true;
            }

            else
            {
                return false;
            }
          

        }

        public bool ValidateTaskSuperposition(TaskContext context, Guid idAgendamento, DateTime data, DateTime dataInicial, DateTime dataFinal)
        {
            TaskModel itemFound = new TaskModel();
            
            //filter all of tasks with the same date and diferente id
            var listaFiltrada = context.Tasks.Where(p => p.Date >= data && p.Id != idAgendamento)
                                                                .OrderBy(p => p.Date).ToList();
                       
            if (listaFiltrada == null) 
            {
                return true;
            }

            // find task with initial hour
            itemFound = listaFiltrada.Where(p => p.InitialHour <= dataInicial
                                 && p.FinalHour >= dataInicial).FirstOrDefault();

            if (itemFound != null) 
            {               
                return false;
            }
            else
            {
                // find task with final hour
                itemFound = listaFiltrada.Where(p => p.InitialHour <= dataFinal
                                 && p.FinalHour >= dataFinal).FirstOrDefault();
            }

            if (itemFound != null) 
            {                
                return false;
            }
            else
            {
                // find task in the database
                itemFound = listaFiltrada.Where(p => p.InitialHour <= dataInicial
                    && p.FinalHour >= dataFinal ).FirstOrDefault();
            }
            if (itemFound != null)  
            {               
                return false;
            }
            else
            {
                // find task between other test
                itemFound = listaFiltrada.Where(p => p.InitialHour >= dataInicial
                    && p.FinalHour <= dataFinal ).FirstOrDefault();

            }
            if (itemFound != null)  
            {               
                return false;
            }

            return true;

        }

    }
}

