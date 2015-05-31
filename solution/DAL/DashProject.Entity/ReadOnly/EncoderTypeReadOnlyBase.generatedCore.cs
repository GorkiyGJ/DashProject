using System;

namespace DashProject.Entity.ReadOnly
{
    public class EncoderTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.EncoderType>
    {
        public EncoderTypeReadOnlyBase()
            : base()
        {
        }

        public EncoderTypeReadOnlyBase(DashProject.Data.Item.EncoderType item)
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