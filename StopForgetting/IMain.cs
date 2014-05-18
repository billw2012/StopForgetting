using System;
using StopForgetting.Model;

namespace StopForgetting
{
    public interface IMain
    {
        void AddGroupedTaskView(string heading, System.Collections.Generic.IList<Task> tasks);
        void AddTaskToTaskView(string heading, Task task);
        string Category { get; }
        void ClearTasks();
        void ShowErrorPrompt(string message);
        string What { get;  }
        string When { get;  }
        string Where { get; }
        void AddToDateList(string text, string value);
        void ClearDateList();
        void InitialFocus();
        void ResetInput();

        void HighlightNewTask();
    }
}
