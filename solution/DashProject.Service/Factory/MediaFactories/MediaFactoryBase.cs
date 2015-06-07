using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DashProject.Service.Factory.DashFactories;
using System.Threading.Tasks.Dataflow;
using DashProject.Service.Factory.DataEntities;
using DashProject.Api.Enum;
using System.Diagnostics;

namespace DashProject.Service.Factory.MediaFactories
{
    public abstract class MediaFactoryBase : FactoryBase, IEnumerable
    {
        public int MediaId;
        public int? ProgramIndex;
        protected FactoryCollection<DashFactory> DashFactories = new FactoryCollection<DashFactory>();
        public BroadcastBlock<IData> InputDataBuffer = new BroadcastBlock<IData>(data => {
            return data.Clone() as IData;
        });

        public MediaFactoryBase(int mediaId, int? programIndex = null)
        {
            MediaId = mediaId;
            ProgramIndex = programIndex;
        }

        public override void Start()
        {
            foreach (DashFactory dashFactory in DashFactories)
                dashFactory.Start();

            this.Status = FactoryStatus.Running;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (DashFactory dashFactory in DashFactories)
            {
                yield return dashFactory;
            }
        }

        public override void Stop(bool isWaitForTasksDone = true)
        {
            if (isWaitForTasksDone)
            {
                InputDataBuffer.Complete();
                InputDataBuffer.Completion.Wait();
            }

            foreach (DashFactory dashFactory in DashFactories)
                dashFactory.Stop(isWaitForTasksDone);
        }

        protected override void OnStatusChanged(FactoryStatus status)
        {
            //throw new NotImplementedException();
        }

        protected override void OnLog(string message, EventLogEntryType logLevel)
        {
            //throw new NotImplementedException();
        }
    }
}
