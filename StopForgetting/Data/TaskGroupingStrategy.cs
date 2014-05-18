using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Linq.Expressions;

using StopForgetting.Model;

using StopForgetting.Common;

namespace StopForgetting.Data
{
    public class TaskGroupingStrategy
    {
        private Dictionary<string, Expression<Func<Task, bool>>> _buckets;

        public TaskGroupingStrategy()
        {
            _buckets = new Dictionary<string, Expression<Func<Task, bool>>>();
            _buckets.Add("Today", 
                t => t.When.Value.Date == DateTime.Now.Date);
            _buckets.Add("Tomorrow", 
                t=>t.When.Value.Date == DateTime.Now.Date.AddDays(1));
            _buckets.Add("This Week",
                t=>t.When.Value.Date > DateTime.Now.Date.AddDays(1) 
                    && t.When.Value.Date < DateTime.Now.Date.AddDays(
                    DateHelper.CalculateNumDaysUntilStartOfNextWeek()));
            _buckets.Add("Next Week",
                t=>t.When.Value.Date >= DateTime.Now.Date.AddDays(
                    DateHelper.CalculateNumDaysUntilStartOfNextWeek()));

        }

        public Expression<Func<Task, bool>> GetQueryForBucket(string bucketName)
        {
            return _buckets[bucketName];
        }

        public IList<string> GetApplicableBuckets()
        {
            List<string> bucketKeys = _buckets.Keys.ToList();
            //if tomorrow is the last day of the week, 'This Week' is not applicable
            if (DateHelper.CalculateNumDaysLeftInThisWeek() == 1)
                bucketKeys.Remove("This Week");
            //if today is the last day of the week, Tomorrow and This week do not apply
            if(DateHelper.CalculateNumDaysLeftInThisWeek() == 0)
            {
                bucketKeys.Remove("Tomorrow");
                bucketKeys.Remove("This Week");
            }
            return bucketKeys;
        }
    }
}
