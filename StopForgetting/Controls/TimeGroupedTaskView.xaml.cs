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
using System.Windows.Navigation;
using System.Windows.Shapes;

using StopForgetting.Data;
using StopForgetting.Model;

namespace StopForgetting.Controls
{
    /// <summary>
    /// Interaction logic for TimeGroupedTaskView.xaml
    /// </summary>
    public partial class TimeGroupedTaskView : UserControl
    {

        
        public TimeGroupedTaskView()
        {
            InitializeComponent();

        }

        
        public string Heading
        {
            get { return (string)GetValue(HeadingProperty); }
            set { SetValue(HeadingProperty, value);  }
        }

        // Using a DependencyProperty as the backing store for Heading.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HeadingProperty =
            DependencyProperty.Register("Heading", typeof(string), typeof(TimeGroupedTaskView), new UIPropertyMetadata("Value not set"));



        public IList<Task> Tasks
        {
            get { return (IList<Task>)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); this.taskList.ItemsSource = value; }
        }

        // Using a DependencyProperty as the backing store for Tasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(IList<Task>), typeof(TimeGroupedTaskView));


        public void CompleteTask(int taskid)
        {
            var toComplete = (from t in this.Tasks
                            where t.TaskId == taskid
                            select t).Take(1).ToList()[0];
            toComplete.IsCompleted = true;
            foreach (var item in taskList.Items)
            {
                var test = item;
            }
            this.taskList.ItemsSource = null;
            this.taskList.ItemsSource = Tasks;
            //var index = this.taskList.Items.IndexOf(toRemove);
            //var uiItem = this.taskList.ItemContainerGenerator.ContainerFromItem(toRemove) as ListBoxItem;
            //var template = uiItem.ContentTemplate;
            //var element = VisualTreeHelper.GetChild(uiItem, 0) as Border;
            //this.Tasks.Remove(toComplete);
        }
    }
}
