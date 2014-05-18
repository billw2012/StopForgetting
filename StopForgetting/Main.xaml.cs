using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StopForgetting.Common;
using System.Windows.Interop;

using StopForgetting.Data;
using StopForgetting.Controls;
using StopForgetting.Model;


namespace StopForgetting
{
    
    
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : GlassWindow, StopForgetting.IMain
    {
        MainPresenter presenter;

        public string What
        {
            get { return this.tbWhat.Text; }
        }

        public string When
        {
            get 
            { 
                var comboBoxItem = this.cbWhen.SelectedValue as ComboBoxItem;
                if (comboBoxItem != null)
                    return comboBoxItem.Tag.ToString();
                throw new Exception("Expecting a ComboBoxItem");
            }
        }

        public string Where
        {
            get { return this.tbWhere.Text; }
        }

        public string Category
        {
            get { return this.cbCategory.SelectedValue.ToString(); }
        }

        
        public Main()
        {
            InitializeComponent();
            InitialFocus();
            presenter = new MainPresenter(this);
            presenter.InitializeData();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
        }


        public void AddGroupedTaskView(string heading, IList<Task> tasks)
        {
            TimeGroupedTaskView view = new TimeGroupedTaskView();
            view.Name = heading.Replace(" ", "_");
            view.Heading = heading;
            view.Tasks = tasks;
            this.taskPanel.Children.Add(view);
        }

        public void ClearTasks()
        {
            this.taskPanel.Children.Clear();
        }

        public void AddTaskToTaskView(string heading, Task task)
        {
            //var groupView = this.taskPanel.FindName(
            //    heading.Replace(" ", "_"))
            //    as TimeGroupedTaskView;

            var groupView = (from c in taskPanel.Children.Cast<TimeGroupedTaskView>()
                           where c.Name == heading.Replace(" ", "_")
                           select c).SingleOrDefault();

            groupView = this.taskPanel.Children[0] as TimeGroupedTaskView;
            var tasks = groupView.Tasks;
            tasks.Add(task);
            //groupView.Tasks = null;
            //groupView.Tasks = tasks;
        }

        public void AddToDateList(string text, string value)
        {
            this.cbWhen.Items.Add(
                new ComboBoxItem() 
                { Content = text, Tag = value });

        }

        public void ClearDateList()
        {
            this.cbWhen.Items.Clear();
            this.cbWhen.Items.Refresh();
        }

        public void InitialFocus()
        {
            this.tbWhat.Focus();
        }

        public void ResetInput()
        {
            this.tbWhat.Text = Constants.WhatDefaultValue;
            this.tbWhere.Text = Constants.WhereDefaultValue;
            this.cbCategory.SelectedIndex = 0;
            this.cbWhen.SelectedIndex = 0;
        }

       
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddTask();
        }

        private void OnInputTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var tb = e.OriginalSource as TextBox;
            if (tb != null)
                ResetTextBox(tb);
        }

        private void OnInputTextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            var tb = e.OriginalSource as TextBox;
            if (tb != null)
                ClearTextBox(tb);
        }

        private void ResetTextBox(TextBox tb)
        {
            if (tb.Name == "tbWhat")
                if (string.IsNullOrEmpty(tb.Text))
                    tb.Text = "What.";
            if (tb.Name == "tbWhere")
                if (string.IsNullOrEmpty(tb.Text))
                    tb.Text = "Where.";
        }

        private void ClearTextBox(TextBox tb)
        {
            if (tb.Name == "tbWhat")
                if (tb.Text == "What.")
                    tb.Text = string.Empty;
            if (tb.Name == "tbWhere")
                if (tb.Text == "Where.")
                    tb.Text = string.Empty;
        }


        public void ShowErrorPrompt(string message)
        {
            MessageBox.Show(message);
        }

        public void HighlightNewTask()
        {
            
        }

        private void cbWhen_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.SelectedDateChanged();
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            base.OnClosing(e);
            presenter.OnClosing();
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void DeleteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var source = e.Source as TimeGroupedTaskView;
            var originalSource = e.OriginalSource as CheckBox;
            var param = Convert.ToInt32(e.Parameter);
            source.CompleteTask(param);
            presenter.TaskCompleted(param);
        }
    }
}
