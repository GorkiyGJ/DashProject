using System;

namespace DashProject.Entity.ReadOnly
{
    public class AACTranscoderConfigReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.AACTranscoderConfig>
    {
        public AACTranscoderConfigReadOnlyBase()
            : base()
        {
        }

        public AACTranscoderConfigReadOnlyBase(DashProject.Data.Item.AACTranscoderConfig item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.Int32? BitrateKbps
        {
            get { return DataItem.BitrateKbps; }
        }
        public virtual System.Boolean? IsUseConstrainedBitRate
        {
            get { return DataItem.IsUseConstrainedBitRate; }
        }
        public virtual System.Byte? Channels
        {
            get { return DataItem.Channels; }
        }
        
        #endregion
    }
}