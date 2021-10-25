using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteAgenda02.Models;

namespace TesteAgenda02.Bl
{
    public class AgendaContexto : DbContext
    {
        public AgendaContexto(DbContextOptions<AgendaContexto> options) : base(options)
        {
        }
        public DbSet<AgendamentoModel> Agendamentos { get; set; }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AgendamentoModel>().ToTable("Agendamentos");
            //modelBuilder.Entity<Matricula>().ToTable("Matricula");
            //modelBuilder.Entity<Estudante>().ToTable("Estudante");
        }
    }
}
