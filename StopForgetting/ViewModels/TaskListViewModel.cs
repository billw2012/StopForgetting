using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

using StopForgetting.Data;
using StopForgetting.Model;
using System.Windows.Input;
using StopForgetting.Commands;
using StopForgetting.Common;
using System.Windows.Data;


namespace StopForgetting.ViewModels
{
    public class TaskListViewModel : INotifyPropertyChanged
    {
        TaskRepository _repository;

        private string _what;
        private ListPair _selectedWhen;
        private string _where;
        private string _category;
        private ObservableCollection<string> _whatHistory;
        private ObservableCollection<string> _whereHistory;
        private ObservableCollection<TaskCategory> _categories;
        private ObservableCollection<ListPair> _dateValues;
        private CollectionViewSource _tasksViewSource;
        private TaskCategory _selectedCategory;
        private TaskList _tasks;
        ICommand _saveTaskCommand;
        ICommand _completeTaskCommand;


        public TaskListViewModel(TaskRepository repository)
        {
            this._repository = repository;
            LoadTasks();
            this.Where = "Where.";
        }
        
        public TaskListViewModel()
        {
            _repository = new TaskRepository(
                new IsolatedStorageTaskStore());
            
        }

        private void LoadTasks()
        {
            this.Tasks = new TaskList(_repository.GetAllTasks());
            this.Categories = new ObservableCollection<TaskCategory>(_repository.GetCategories());
            this.DateValues = GetDateValues();
            this._tasksViewSource = new CollectionViewSource();
            this._tasksViewSource.Source = this.Tasks;
            var groupDescription = new PropertyGroupDescription();
            groupDescription.Converter = new StopForgetting.Converters.TaskGroupConverter();

            this._tasksViewSource.GroupDescriptions.Add(groupDescription);
            
        }

        private ObservableCollection<ListPair> GetDateValues()
        {

            List<ListPair> list = new List<ListPair>();
            list.Add(new ListPair(Constants.WhenDefaultValue, string.Empty));
            IList<DateTime> dates = DateHelper.GetNextSevenDays();
            list.Add(new ListPair("Today", dates[0].Date.ToShortDateString()));
            list.Add(new ListPair("Tomorrow", dates[1].Date.ToShortDateString()));
            for (int i = 2; i < 7; i++)
                list.Add(new ListPair(
                    dates[i].DayOfWeek.ToString(), 
                    dates[i].Date.ToShortDateString()));
            list.Add(new ListPair("Select a Date.", "other"));
            return new ObservableCollection<ListPair>(list);
        }

        public ObservableCollection<ListPair> DateValues
        {
            get { return _dateValues; }
            set
            {
                if (value != _dateValues)
                {
                    _dateValues = value;
                    RaisePropertyChanged("DateValues");
                }
            }
        }

        public TaskCategory SelectedCategory
        {
            get { return _selectedCategory; }
            set
            {
                if (value != _selectedCategory)
                {
                    _selectedCategory = value;
                    RaisePropertyChanged("SelectedCategory");
                }
            }
        }

        public TaskList Tasks
        {
            get { return _tasks; }
            set
            {
                if (value != _tasks)
                {
                    _tasks = value;
                    RaisePropertyChanged("Tasks");
                }
            }
        }

        public ObservableCollection<TaskCategory> Categories
        {
            get { return this._categories; }
            set
            {
                if (value != _categories)
                {
                    _categories = value;
                    RaisePropertyChanged("Categories");
                }
            }
        }

        public CollectionViewSource TasksViewSource
        {
            get { return this._tasksViewSource; }
        }

        public string What
        {
            get {
                if (_what == Constants.WhatDefaultValue)
                    return string.Empty;
                return _what; 
            }
            set
            {
                if (value != _what)
                {
                    _what = value;
                    RaisePropertyChanged("What");
                }
            }
        }

        public ListPair SelectedWhen
        {
            get { return _selectedWhen; }
            set
            {
                if (value != _selectedWhen)
                {
                    _selectedWhen = value;
                    RaisePropertyChanged("When");
                }
            }
        }

        public string Where
        {
            get {
                if (_where == Constants.WhereDefaultValue)
                    return string.Empty;
                return _where; 
            }
            set
            {
                if (value != _where)
                {
                    _where = value;
                    RaisePropertyChanged("Where");
                }
            }
        }

        public DateTime When
        {
            get
            {
                var selectedWhen = this.SelectedWhen;
                if (selectedWhen.Value != "other")
                    return Convert.ToDateTime(selectedWhen.Value);
                return GetDateFromDatePicker();
            }
        }

        private DateTime GetDateFromDatePicker()
        {
            return DateTime.Now.AddDays(8);
        }

        public ICommand SaveCommand
        {
            get
            {
                if (_saveTaskCommand == null)
                {
                    _saveTaskCommand = new RelayCommand(
                        param => this.SaveTask(),
                        param => this.CanSaveTask());
                }
                return _saveTaskCommand;
            }
        }

        public ICommand CompleteTaskCommand
        {
            get
            {
                if (_completeTaskCommand == null)
                {
                    _completeTaskCommand = new RelayCommand(
                        param => this.CompleteTask(param));
                }
                return _completeTaskCommand;
            }
        }

        public void CompleteTask(object taskId)
        {
            int id = Convert.ToInt32(taskId);
            var task = this.Tasks.First(t => t.TaskId == id);
            _repository.CompleteTask(id);
            this.Tasks.Remove(task);
        }
        

        public void SaveTask()
        {
            var task = new Task()
            {
                What = this.What,
                Where = this.Where,
                When = this.When
            };
            _repository.AddTask(task);
            this.Tasks.Add(task);
            
        }

        public bool CanSaveTask()
        {
            return !string.IsNullOrEmpty(What);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if(propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
