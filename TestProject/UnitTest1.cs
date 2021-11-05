using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using TaskProject.Bl;
using TaskProject.Models;

namespace TestProject
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {

            var optionsBuilder = new DbContextOptionsBuilder<TaskContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TasksDb;Trusted_Connection=True;MultipleActiveResultSets=true");
                      
            var _context = new TaskContext(optionsBuilder.Options);
            List<TaskModel> taskList = new List<TaskModel>();


            TasksDal taskBd = new TasksDal(_context);
            bool retorno = taskBd.GetTasks(ref taskList);
        }
    }
}