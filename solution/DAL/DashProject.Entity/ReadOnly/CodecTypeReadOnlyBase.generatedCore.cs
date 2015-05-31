using System;

namespace DashProject.Entity.ReadOnly
{
    public class CodecTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.CodecType>
    {
        public CodecTypeReadOnlyBase()
            : base()
        {
        }

        public CodecTypeReadOnlyBase(DashProject.Data.Item.CodecType item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 StreamTypeId
        {
            get { return DataItem.StreamTypeId; }
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