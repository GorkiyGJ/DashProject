using System;

namespace DashProject.Entity.ReadOnly
{
    public class DecoderTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.DecoderType>
    {
        public DecoderTypeReadOnlyBase()
            : base()
        {
        }

        public DecoderTypeReadOnlyBase(DashProject.Data.Item.DecoderType item)
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
        public virtual System.String Description
        {
            get { return DataItem.Description; }
        }
        
        #endregion
    }
}