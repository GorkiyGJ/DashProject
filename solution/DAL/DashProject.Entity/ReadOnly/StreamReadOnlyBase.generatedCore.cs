using System;

namespace DashProject.Entity.ReadOnly
{
    public class StreamReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.Stream>
    {
        public StreamReadOnlyBase()
            : base()
        {
        }

        public StreamReadOnlyBase(DashProject.Data.Item.Stream item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32 RawMediaId
        {
            get { return DataItem.RawMediaId; }
        }
        public virtual System.Int32 StreamTypeId
        {
            get { return DataItem.StreamTypeId; }
        }
        public virtual System.Byte Index
        {
            get { return DataItem.Index; }
        }
        public virtual System.Int32 CodecTypeId
        {
            get { return DataItem.CodecTypeId; }
        }
        public virtual System.Byte? Channels
        {
            get { return DataItem.Channels; }
        }
        public virtual System.Int32? LanguageId
        {
            get { return DataItem.LanguageId; }
        }
        public virtual System.Int16? Width
        {
            get { return DataItem.Width; }
        }
        public virtual System.Int16? Height
        {
            get { return DataItem.Height; }
        }
        
        #endregion
    }
}