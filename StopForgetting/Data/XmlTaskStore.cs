using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StopForgetting.Model;

namespace StopForgetting.Data
{
    public class XmlTaskStore : ITaskStore
    {
        #region ITaskStore Members

        public int AddTask(Task t)
        {
            throw new NotImplementedException();
        }

        public void UpdateTask(Task t)
        {
            throw new NotImplementedException();
        }

        public void DeleteTask(Task t)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
        }

        public IQueryable<Task> Tasks
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
