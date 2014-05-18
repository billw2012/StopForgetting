using System;
using System.Collections.Generic;


namespace StopForgetting.Common
{
    public class DateHelper
    {
        public static int CalculateNumDaysLeftInThisWeek()
        {
            int numDaysTillStartOfNextWeek = CalculateNumDaysUntilStartOfNextWeek();
            return numDaysTillStartOfNextWeek - 1;
        }
        
        public static int CalculateNumDaysUntilStartOfNextWeek()
        {
            int numDaysTillStartOfNextWeek = 0;
            DayOfWeek day = DateTime.Now.DayOfWeek;
            switch (day)
            {
                case DayOfWeek.Sunday:
                    numDaysTillStartOfNextWeek = 7;
                    break;
                case DayOfWeek.Monday:
                    numDaysTillStartOfNextWeek = 6;
                    break;
                case DayOfWeek.Tuesday:
                    numDaysTillStartOfNextWeek = 5;
                    break;
                case DayOfWeek.Wednesday:
                    numDaysTillStartOfNextWeek = 4;
                    break;
                case DayOfWeek.Thursday:
                    numDaysTillStartOfNextWeek = 3;
                    break;
                case DayOfWeek.Friday:
                    numDaysTillStartOfNextWeek = 2;
                    break;
                case DayOfWeek.Saturday:
                    numDaysTillStartOfNextWeek = 1;
                    break;
            }
            return numDaysTillStartOfNextWeek;
        }

        public static DateTime GetStartOfNextWeek()
        {
            DayOfWeek day = DateTime.Now.DayOfWeek;
            int numDaysTillStartOfNextWeek = DateHelper.CalculateNumDaysUntilStartOfNextWeek();
            return DateTime.Now.AddDays(numDaysTillStartOfNextWeek);
        }

        public static IList<DateTime> GetNextSevenDays()
        {
            List<DateTime> dates = new List<DateTime>();
            for(int i=0;i<7;i++)
                dates.Add(DateTime.Now.AddDays(i));
            return dates;
        }
    }
}
