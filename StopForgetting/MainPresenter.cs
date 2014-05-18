using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StopForgetting.Data;
using StopForgetting.Controls;
using StopForgetting.Common;
using StopForgetting.Model;

namespace StopForgetting
{
    public class MainPresenter
    {
        
        IMain window;

        private TaskRepository _repository = new TaskRepository(
                new IsolatedStorageTaskStore());

        public MainPresenter(IMain windowIn)
        {
            this.window = windowIn;
        }

        public void InitializeData()
        {
            PopulateDateList();
            LoadTasks();
        }

        private void PopulateDateList()
        {
            window.ClearTasks();
            window.AddToDateList(Constants.WhenDefaultValue, string.Empty);
            IList<DateTime> dates = DateHelper.GetNextSevenDays();
            window.AddToDateList("Today", dates[0].Date.ToShortDateString());
            window.AddToDateList("Tomorrow", dates[1].Date.ToShortDateString());
            for (int i = 2; i < 7; i++)
                window.AddToDateList(
                    dates[i].DayOfWeek.ToString(), 
                    dates[i].Date.ToShortDateString());
            window.AddToDateList("Select a Date.", "other");
        }

        private void LoadTasks()
        {
            var manager = new TaskGroupingStrategy();
            foreach (var bucketName in manager.GetApplicableBuckets())
            {
                var query = manager.GetQueryForBucket(bucketName);
                var tasks = _repository.GetTasks(query);
                window.AddGroupedTaskView(bucketName, new TaskList(tasks));
            }
        }

        public void AddTask()
        {
            if (IsValid(window))
            {
                Task task = new Task()
                { 
                    IsCompleted = false,
                    When = ToDateTime(window.When),
                    Where = window.Where,
                    What = window.What,
                    Category = window.Category
                };
                this._repository.AddTask(task);
                window.AddTaskToTaskView(GetGroupHeading(task.When), task);
                window.ResetInput();
                window.InitialFocus();
                window.HighlightNewTask();
            }
            else
            {
                window.ShowErrorPrompt("Please enter all of the required fields.");
            }
        }

        private string GetGroupHeading(DateTime? nullable)
        {
            return "Today";
        }

        private DateTime? ToDateTime(string p)
        {
            DateTime theDate = DateTime.Now;
            switch (p.ToUpper())
            {
                case "TOMORROW":
                    theDate = DateTime.Now.Date.AddDays(1);
                    break;
            }
            return theDate;
        }

        private bool IsValid(IMain window)
        {
            if (window.Where == Constants.WhereDefaultValue)
                return false;
            if (window.What == Constants.WhatDefaultValue)
                return false;
            return true;
        }



        public void SelectedDateChanged()
        {
            var value = window.When;
        }

        public void OnClosing()
        {
            _repository.SaveChanges();
        }

        public void TaskCompleted(int taskId)
        {
            _repository.CompleteTask(taskId);
        }
    }
}
