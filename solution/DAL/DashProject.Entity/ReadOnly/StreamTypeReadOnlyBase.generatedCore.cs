using System;

namespace DashProject.Entity.ReadOnly
{
    public class StreamTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.StreamType>
    {
        public StreamTypeReadOnlyBase()
            : base()
        {
        }

        public StreamTypeReadOnlyBase(DashProject.Data.Item.StreamType item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.String Name
        {
            get { return DataItem.Name; }
        }
        
        #endregion
    }
}