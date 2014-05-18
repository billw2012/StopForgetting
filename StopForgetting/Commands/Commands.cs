using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace StopForgetting.Commands
{
    public class ApplicationCommands
    {
        public static RoutedUICommand TaskDeletedCommand = new RoutedUICommand();
        public static RoutedUICommand TaskCompletedCommand = new RoutedUICommand();
        public static RoutedUICommand TaskSavedCommand = new RoutedUICommand();
        public static RoutedUICommand TaskUpdatedCommand = new RoutedUICommand();
        public static RoutedUICommand WindowClosedCommand = new RoutedUICommand();
        public static RoutedUICommand ShowCalendarCommand = new RoutedUICommand();

    }
}
