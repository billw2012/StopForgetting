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

namespace StopForgetting.Controls
{
    /// <summary>
    /// Interaction logic for TaskGroupHeaderControl.xaml
    /// </summary>
    public partial class TaskGroupHeaderControl : UserControl
    {
        public TaskGroupHeaderControl()
        {
            InitializeComponent();
        }



        public int ItemCount
        {
            get { return (int)GetValue(ItemCountProperty); }
            set { SetValue(ItemCountProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemCount.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemCountProperty =
            DependencyProperty.Register("ItemCount", typeof(int), typeof(TaskGroupHeaderControl), new UIPropertyMetadata(0));





        public string GroupName
        {
            get { return (string)GetValue(GroupNameProperty); }
            set { SetValue(GroupNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GroupNameProperty =
            DependencyProperty.Register("GroupName", typeof(string), typeof(TaskGroupHeaderControl));


    }
}
