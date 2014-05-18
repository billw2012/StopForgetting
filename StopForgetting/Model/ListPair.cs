using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StopForgetting.Model
{
    public class ListPair 
    {
        public string DisplayText { get; set; }
        public string Value { get; set; }

        public ListPair(string displayText, string value)
        {
            this.DisplayText = displayText;
            this.Value = value;
        }
    }
}
