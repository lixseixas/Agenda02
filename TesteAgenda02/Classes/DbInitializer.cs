﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAgenda02.Models;

namespace TesteAgenda02.Bl
{
    public class DbInitializer
    {       
      
        public static void Initialize(TaskContext context)
        {
            context.Database.EnsureCreated();

            // procura por qualquer agendamento
            if (context.Tasks.Any())
            {              
                return;  //O banco foi inicializado
            }                

        }
    }
}
