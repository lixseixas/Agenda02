using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAgenda02.Models;

namespace TesteAgenda02.Bl
{
    public class DbInitializer
    {
       // public static AgendaContexto contextPublico;

      
        public static void Initialize(AgendaContexto context)
        {
            context.Database.EnsureCreated();

            // procura por qualquer agendamento
            if (context.Agendamentos.Any())
            {
              
                return;  //O banco foi inicializado
            }

            //var agendamentos = new AgendamentoModel[]
            //{
            //new AgendamentoModel{Descricao="Carlos",
            //    Data=DateTime.Parse("2020-09-01"
            //    )
            //},
            //new AgendamentoModel{
            //    Descricao="Maria",
            //    Data=DateTime.Parse("2012-09-01")
            //},

            //};
            //foreach (AgendamentoModel s in agendamentos)
            //{
            //    context.Agendamentos.Add(s);
            //}
            //context.SaveChanges();

            //contextPublico = context;


        }
    }
}
