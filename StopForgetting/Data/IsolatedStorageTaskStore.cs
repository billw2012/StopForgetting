using System;
using System.Collections.Generic;
using System.Linq;
using System.IO.IsolatedStorage;
using System.IO;
using System.Xml.Serialization;
using System.Xml;

using StopForgetting.Model;


namespace StopForgetting.Data
{
    class IsolatedStorageTaskStore : InMemoryTaskStore
    {
        public const string TasksFileName = "tasks.xml";

        public IsolatedStorageTaskStore()
        {
        }

        protected override void LoadTasks()
        {
            var file = IsolatedStorageFile.GetUserStoreForAssembly();
            _tasks = null;
            using(var stream = new IsolatedStorageFileStream(
                TasksFileName, FileMode.OpenOrCreate, FileAccess.Read, file))
            {
                var reader = new XmlTextReader(stream);
                var serializer = new XmlSerializer(typeof(List<Task>));
                try
                {
                    _tasks= serializer.Deserialize(reader) as List<Task>;
                }
                catch (Exception)
                {
                    _tasks = new List<Task>();
                }
                finally
                {
                    reader.Close();
                }
                if (_tasks.Count == 0)
                    _lastId = 0;
                else
                    _lastId = _tasks.Max(t => t.TaskId);
            }
        }
        
        #region ITaskStore Members


        public override void SaveChanges()
        {
            var file = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream stream =
                new IsolatedStorageFileStream(TasksFileName, FileMode.Create, file))
            {
                var serializer = new XmlSerializer(typeof(List<Task>));
                serializer.Serialize(stream, this.Tasks.ToList());

            }
        }

        #endregion
    }
}
