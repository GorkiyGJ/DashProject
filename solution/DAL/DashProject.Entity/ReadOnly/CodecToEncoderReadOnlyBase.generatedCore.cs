using System;

namespace DashProject.Entity.ReadOnly
{
    public class CodecToEncoderReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.CodecToEncoder>
    {
        public CodecToEncoderReadOnlyBase()
            : base()
        {
        }

        public CodecToEncoderReadOnlyBase(DashProject.Data.Item.CodecToEncoder item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 CodecTypeId
        {
            get { return DataItem.CodecTypeId; }
        }
        public virtual System.Int32 EncoderTypeId
        {
            get { return DataItem.EncoderTypeId; }
        }
        public virtual System.Boolean IsMain
        {
            get { return DataItem.IsMain; }
        }
        
        #endregion
    }
}