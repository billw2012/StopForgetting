using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using StopForgetting.Model;

namespace StopForgetting.Data
{
    public class TaskAddedEventArgs : EventArgs
    {
        public Task NewTask { get; private set; }

        public TaskAddedEventArgs(Task newTask)
        {
            this.NewTask = newTask;
        }
    }
}
