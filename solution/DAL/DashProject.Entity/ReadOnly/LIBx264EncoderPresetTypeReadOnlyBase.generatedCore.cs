using System;

namespace DashProject.Entity.ReadOnly
{
    public class LIBx264EncoderPresetTypeReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.LIBx264EncoderPresetType>
    {
        public LIBx264EncoderPresetTypeReadOnlyBase()
            : base()
        {
        }

        public LIBx264EncoderPresetTypeReadOnlyBase(DashProject.Data.Item.LIBx264EncoderPresetType item)
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