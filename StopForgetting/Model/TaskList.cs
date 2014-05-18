using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace StopForgetting.Model
{
    public class TaskList : ObservableCollection<Task>
    {
        public TaskList()
        {
        }

        public TaskList(IList<Task> tasks)
        {
            foreach (var task in tasks)
                this.Add(task);
        }
    }
}
