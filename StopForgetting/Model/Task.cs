using System;
using System.ComponentModel;

namespace StopForgetting.Model
{
    [Serializable]
    public class Task : INotifyPropertyChanged
    {
        private int _taskId;
        private string _what;
        private DateTime? _when;
        private string _where;
        private string _category;
        private bool _isCompleted;
        
        public int TaskId 
        {
            get { return _taskId; }
            set 
            {
                if (_taskId == value)
                    return;
                _taskId = value;
                OnPropertyChanged("TaskId");
            }
        }

        public string What
        {
            get { return _what; }
            set
            {
                if (_what == value)
                    return;
                _what = value;
                OnPropertyChanged("What");
            }
        }

        public DateTime? When
        {
            get { return _when; }
            set
            {
                if (_when == value)
                    return;
                _when = value;
                OnPropertyChanged("When");
            }
        }

        public string Where
        {
            get { return _where; }
            set
            {
                if (_where == value)
                    return;
                _where = value;
                OnPropertyChanged("Where");
            }
        }

        public string Category
        {
            get { return _category; }
            set
            {
                if (_category == value)
                    return;
                _category = value;
                OnPropertyChanged("Category");
            }
        }

        public bool IsCompleted
        {
            get { return _isCompleted; }
            set
            {
                if (_isCompleted == value)
                    return;
                _isCompleted = value;
                OnPropertyChanged("IsCompleted");
            }
        }

        public string BucketName
        {
            get
            {
                return new TaskBucketingStrategy().DetermineBucket(this);
            }
        }


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
