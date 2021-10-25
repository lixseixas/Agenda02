using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesteAgenda02.Models
{
    public class AgendamentoModel
    {
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }

        [Required]
        [Display(Name = "Hora inicial")]
        [DataType(DataType.Time)]
        public DateTime HoraInicio { get; set; }

        [Required]
        [Display(Name = "Hora final")]
        [DataType(DataType.Time)]
        public DateTime HoraFim { get; set; }

        [Required]
        [Display(Name = "Prioridade")]
        public int Prioridade { get; set; }

        [Display(Name = "Prioridade")]
        [NotMapped]
        public string NomePrioridade { get; set; }

        [Required]
        [Display(Name = "Finalizada")]
        public bool Finalizada { get; set; }

        [NotMapped]
        public string Inclusao { get; set; }
    }
}
