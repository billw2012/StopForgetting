using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using StopForgetting.Data;
using StopForgetting.Model;


namespace StopForgetting.TemplateSelectors
{
    /// <summary>
    /// the correct solution would be to use a DataTrigger
    /// </summary>
    public class TaskTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item != null && item is Task)
            {
                var task = item as Task;
                Window window = Application.Current.MainWindow;

                if (task.IsCompleted)
                    return window.FindResource("CompletedTaskItemTemplate") as DataTemplate;
                else
                    return window.FindResource("TaskItemTemplate") as DataTemplate;
            }
            return null;
        }
    }
}
