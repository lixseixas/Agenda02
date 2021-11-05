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
                       
            List<TaskModel> taskList = new List<TaskModel>();
            TasksDal taskBd = new TasksDal();

            bool returno = taskBd.GetTasks(ref taskList);

            Assert.IsTrue(returno);
        }
    }
}