using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StopForgetting.Model
{
    public class TaskCategory
    {
        public string CategoryName { get; set; }
        public string Color { get; set; }

        public TaskCategory(string categoryName, string color)
        {
            this.CategoryName = categoryName;
            this.Color = color;
        }

        public override string ToString()
        {
            return CategoryName;
        }
    }
}
