using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgenda02.Models
{
    public class AgendamentoConsolidadoModel
    {
        [NotMapped]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [NotMapped]       
        public string Horas { get; set; }

        [NotMapped]
        public int TotalTarefas { get; set; }

        [NotMapped]
        public string MediaHoras { get; set; }

        [NotMapped]
        public double PercentualTarefasConcluidas { get; set; }


    }
}
