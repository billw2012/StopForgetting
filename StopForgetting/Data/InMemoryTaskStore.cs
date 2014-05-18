using System;
using System.Collections.Generic;
using System.Linq;


using StopForgetting.Model;

namespace StopForgetting.Data
{
    public class InMemoryTaskStore : ITaskStore
    {
        protected List<Task> _tasks;
        protected int _lastId = 0;

        public InMemoryTaskStore()
        {
            _tasks = new List<Task>();
            LoadTasks();
        }

        protected virtual void LoadTasks()
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
                When = DateTime.Now.AddDays(1),
                Where = "Timberline Knolls",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 5,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(1),
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
                When = DateTime.Now.AddDays(1),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(2),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(2),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 9,
                What = "Pay Mortgage.",
                When = DateTime.Now.AddDays(7),
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
            AddTask(new Task()
            {
                TaskId = 10,
                What = "Pick up Timmy from Karate.",
                When = DateTime.Now.AddDays(7),
                Where = "Ninja Training",
                IsCompleted = false,
                Category = "Family"
            });
            AddTask(new Task()
            {
                TaskId = 11,
                What = "Pay Mortgage.",
                When = DateTime.Now,
                Where = "Wells Fargo",
                IsCompleted = false,
                Category = "Money"
            });
        }
        
        #region ITaskStore Members

        public IQueryable<Task> Tasks
        {
            get { return this._tasks.AsQueryable(); }
        }

        public virtual int AddTask(Task t)
        {
            t.TaskId = ++this._lastId;
            _tasks.Add(t);
            return this._lastId;
        }

        public virtual void UpdateTask(Task task)
        {
            var toUpdate = GetById(task.TaskId);
            toUpdate.IsCompleted = task.IsCompleted;
            toUpdate.Category = task.Category;
            toUpdate.What = task.What;
            toUpdate.When = task.When;
            toUpdate.Where = task.Where;
        }

        private Task GetById(int taskId)
        {
            return (from t in this.Tasks
                    where t.TaskId == taskId
                    select t).Take(1).ToList()[0];
        }

        public virtual void DeleteTask(Task t)
        {
            var toDelete = GetById(t.TaskId);
            this._tasks.Remove(toDelete);
            toDelete = null;
        }

        public virtual void SaveChanges()
        {

        }

        #endregion
    }
}
