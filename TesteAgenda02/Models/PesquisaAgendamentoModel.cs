using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgenda02.Models
{
    public class PesquisaAgendamentoModel
    {
        public PesquisaAgendamentoModel()
        {           
            ListaAgendamentosConsolidados = new List<AgendamentoConsolidadoModel>();
        }

        [Display(Name = "De:")]
        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime DataInicial { get; set; }

        [Display(Name = "Até")]
        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime DataFinal { get; set; }                
       
        [NotMapped]
        public List<AgendamentoConsolidadoModel> ListaAgendamentosConsolidados { get; set; }
    }
}
