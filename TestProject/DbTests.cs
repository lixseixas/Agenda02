using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Configuration;
using TaskProject.Bl;
using TaskProject.Models;

namespace TestProject
{
    public class Dbests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTasksTest()
        {
                       
            List<TaskModel> taskList = new List<TaskModel>();
            TasksDal taskBd = new TasksDal();
            bool methodReturn = taskBd.GetTasks(ref taskList);

            Assert.IsTrue(methodReturn);
        }
    }
}