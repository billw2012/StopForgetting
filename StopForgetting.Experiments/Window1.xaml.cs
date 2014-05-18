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
using StopForgetting.Controls;
using StopForgetting.Model;


namespace StopForgetting.Experiments
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        TaskRepository repo = new TaskRepository(new InMemoryTaskStore());

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            BindTasks();
            //this.TaskList.DataContext = this.Tasks;
            //this.TaskList.ItemsSource = Tasks;
        }

        private void BindTasks()
        {
            var tasks = repo.GetTasks
                (t => t.When.Value.Date == DateTime.Now.Date);
            this.Tasks = new TaskList(tasks);
        }



        public TaskList Tasks
        {
            get { return (TaskList)GetValue(TasksProperty); }
            set { SetValue(TasksProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tasks.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TasksProperty =
            DependencyProperty.Register("Tasks", typeof(TaskList), typeof(Window1));

        private void DeleteCommandCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            var source = e.Source;
            var originalSource = e.OriginalSource as CheckBox;
            var param = Convert.ToInt32(e.Parameter);
            repo.DeleteTask(param);
            BindTasks();

            
        }


    }
}
