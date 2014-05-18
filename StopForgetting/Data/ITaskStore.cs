using System;
using System.Collections.Generic;
using System.Linq;

using StopForgetting.Model;

namespace StopForgetting.Data
{
    public interface ITaskStore
    {
        IQueryable<Task> Tasks { get; }
        int AddTask(Task t);
        void UpdateTask(Task t);
        void DeleteTask(Task t);
        void SaveChanges();
    }
}
