using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StopForgetting.Data;
using StopForgetting.Model;

namespace StopForgetting.Tests.Stubs
{
    public class StubTaskStore : InMemoryTaskStore
    {
        protected override void LoadTasks()
        {
            AddTask(new Task()
            {
                TaskId = 1,
                What = "Pick up Erika from work.",
                When = DateTime.Now.AddDays(1),
                Where = "Timberline Knolls",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 2,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(1),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 3,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(3),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 4,
                What = "Pick up Erika from work.",
                When = DateTime.Now,
                Where = "Timberline Knolls",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 5,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now,
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 6,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(3),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 7,
                What = "Pick up Erika from work.",
                When = DateTime.Now.AddDays(1),
                Where = "Timberline Knolls",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 8,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(10),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Erika from work.",
                When = DateTime.Now.AddDays(10),
                Where = "Timberline Knolls",
                IsCompleted = false,
                Category = "Family"
            });

        }
    }
}
