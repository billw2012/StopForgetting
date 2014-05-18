using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

using StopForgetting.Model;
using StopForgetting.Data;
using StopForgetting.ViewModels;
using StopForgetting;

namespace StopForgetting
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow window = new MainWindow();
            var repository = new TaskRepository(new InMemoryTaskStore());
            var viewModel = new TaskListViewModel(repository);

            window.DataContext = viewModel;
            window.Show();
        }
    }
}
