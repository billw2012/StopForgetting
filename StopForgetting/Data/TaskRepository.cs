using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using StopForgetting.Model;


namespace StopForgetting.Data
{
    public class TaskRepository
    {
        private ITaskStore _taskStore;

        public event EventHandler<TaskAddedEventArgs> TaskAdded;

        public TaskRepository()
        {
            _taskStore = new XmlTaskStore();
        }

        public TaskRepository(ITaskStore taskStore)
        {
            this._taskStore = taskStore;
        }
        
        public IList<Task> GetTasks(Expression<Func<Task, bool>> predicate)
        {
            return _taskStore.Tasks.Select(t => t)
                .Where(predicate)
                .ToList();
        }

        public IList<Task> GetAllTasks()
        {
            return _taskStore.Tasks.ToList();
        }

        public IList<Task> GetCompletedTasks()
        {
            return GetTasks(t => t.IsCompleted == true);
        }

        public IList<Task> GetIncompleteTasks()
        {
            return GetTasks(t => t.IsCompleted == false);
        }

        public void AddTask(Task task)
        {
            this._taskStore.AddTask(task);

            if (this.TaskAdded != null)
                this.TaskAdded(this, new TaskAddedEventArgs(task));
        }

        public void UpdateTask(Task task)
        {

        }

        public void DeleteTask(int taskId)
        {
            var task = GetTasks(t=>t.TaskId == taskId)[0];
            this._taskStore.DeleteTask(task);
        }

        public void SaveChanges()
        {
            this._taskStore.SaveChanges();
        }

        public void CompleteTask(int taskId)
        {
            //this.DeleteTask(taskId);
            var task = GetTasks(t => t.TaskId == taskId)[0];
            task.IsCompleted = true;

        }

        public IEnumerable<TaskCategory> GetCategories()
        {
            return new List<TaskCategory>()
            {
                new TaskCategory("Work", "AliceBlue"),
                new TaskCategory("Family", "BlueViolet"),
                new TaskCategory("School", "DarkOrange"),
                new TaskCategory("Bills", "Yellow")
            };
        }
    }
}
