using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StopForgetting.Common;

namespace StopForgetting.Model
{
    public class TaskBucketingStrategy
    {
        List<TaskBucket> buckets;

        public TaskBucketingStrategy()
        {
            buckets = new List<TaskBucket>()
            {
                new TodayTaskBucket(),
                new TomorrowTaskBucket(),
                new ThisWeekTaskBucket(),
                new NextWeekTaskBucket()
            };
        }

        public string DetermineBucket(Task t)
        {
            foreach(var bucket in this.buckets)
                if(bucket.IsInBucket(t))
                    return bucket.GetBucketName();
            return string.Empty;
        }
    }

    public class TaskBucket
    {
        protected Func<Task, bool> isInBucketFunc;
        protected string bucketName;

        public TaskBucket(string bucketName, Func<Task, bool>isInBucket)
        {
            this.isInBucketFunc = isInBucket;
            this.bucketName = bucketName;
        }

        public virtual bool IsInBucket(Task task)
        {
            return isInBucketFunc(task);
        }

        public virtual string GetBucketName()
        {
            return this.bucketName;
        }
    }

    public class TodayTaskBucket : TaskBucket
    {
        public TodayTaskBucket() : base("Today",
            (t) => t.When.Value.Date == DateTime.Now.Date)
        {
        }
    }

    public class TomorrowTaskBucket : TaskBucket
    {
        public TomorrowTaskBucket()
            : base("Tomorrow",
                (t) => t.When.Value.Date == DateTime.Now.Date.AddDays(1))
        {
        }
    }

    public class ThisWeekTaskBucket : TaskBucket
    {
        public ThisWeekTaskBucket()
            : base("This Week",
            (t) => t.When.Value.Date > DateTime.Now.Date.AddDays(1) 
                    && t.When.Value.Date < 
                    DateTime.Now.Date.AddDays(
                    DateHelper.CalculateNumDaysUntilStartOfNextWeek()
                    ))
        {
        }
    }

    public class NextWeekTaskBucket : TaskBucket
    {
        public NextWeekTaskBucket()
            : base("Next Week", 
                (t) => t.When.Value.Date >= DateTime.Now.Date.AddDays(
                DateHelper.CalculateNumDaysUntilStartOfNextWeek()))
        {

        }
    }
}
