using System;

namespace DashProject.Entity.ReadOnly
{
    public class CodecMediaTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.CodecMediaType>
    {
        public CodecMediaTypeReadOnlyBase()
            : base()
        {
        }

        public CodecMediaTypeReadOnlyBase(DashProject.Data.Item.CodecMediaType item)
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