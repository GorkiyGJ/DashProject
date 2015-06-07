using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using DashProject.Api.Enum;
using DashProject.Utils;

namespace DashProject.Service.Factory
{
    public class FactoryCollection<T> : IEnumerable
    {
        private ConcurrentDictionary<int, T> collection = new ConcurrentDictionary<int, T>();

        public bool Add(int key, T value)
        {
            return collection.TryAdd(key, value);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (KeyValuePair<int, T> kvp in collection)
            {
                yield return kvp.Value;
            }
        }
    }

    public abstract class FactoryBase
    {
        public FactoryStatus Status
        {
            get { return status; }
            set
            {
                StatusChanged(value);
                if (this.status == value)
                    return;
                status = value;
            }
        }

        private FactoryStatus status = FactoryStatus.Stopped;

        private delegate void LogEventHandler(/*FactoryBase sender, */string message, EventLogEntryType logLevel);
        protected LogEventHandler LogEvent = delegate { };

        public delegate void StatusChangedHandler(/*FactoryBase sender, */FactoryStatus status);
        public event StatusChangedHandler StatusChanged = delegate { };

        public abstract void Stop(bool isWaitForTasksDone = true);
       
        public abstract void Start();

        public FactoryBase()
        {
            
            this.StatusChanged += this.OnStatusChanged;
            this.LogEvent += this.OnLog;
        }
        protected abstract void OnStatusChanged(/*FactoryBase sender, */FactoryStatus status);
        protected abstract void OnLog(/*FactoryBase sender, */string message, EventLogEntryType logLevel); 
    }
}
