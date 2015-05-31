using System;

namespace DashProject.Entity.ReadOnly
{
    public class DecoderReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.Decoder>
    {
        public DecoderReadOnlyBase()
            : base()
        {
        }

        public DecoderReadOnlyBase(DashProject.Data.Item.Decoder item)
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