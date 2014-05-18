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

namespace StopForgetting.Controls
{
    /// <summary>
    /// Interaction logic for TaskControl.xaml
    /// </summary>
    public partial class TaskControl : UserControl
    {
        public TaskControl()
        {
            InitializeComponent();
        }



        public int TaskId
        {
            get { return (int)GetValue(TaskIdProperty); }
            set { SetValue(TaskIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TaskId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaskIdProperty =
            DependencyProperty.Register("TaskId", typeof(int), typeof(TaskControl));



        public string Where
        {
            get { return (string)GetValue(WhereProperty); }
            set { SetValue(WhereProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Where.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WhereProperty =
            DependencyProperty.Register("Where", typeof(string), typeof(TaskControl), new UIPropertyMetadata(string.Empty));

        public string When
        {
            get { return (string)GetValue(WhenProperty); }
            set { SetValue(WhenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for When.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WhenProperty =
            DependencyProperty.Register("When", typeof(string), typeof(TaskControl), new UIPropertyMetadata(string.Empty));


        public string What
        {
            get { return (string)GetValue(WhatProperty); }
            set { SetValue(WhatProperty, value); }
        }

        // Using a DependencyProperty as the backing store for What.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WhatProperty =
            DependencyProperty.Register("What", typeof(string), typeof(TaskControl), new UIPropertyMetadata(string.Empty));
        
        
    }
}
