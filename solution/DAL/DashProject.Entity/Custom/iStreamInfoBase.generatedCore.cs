using System;

namespace DashProject.Entity.Custom
{
    public class iStreamInfoBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iStreamInfo>
    {
        public iStreamInfoBase()
            : base()
        {
        }

        public iStreamInfoBase(DashProject.Data.Item.Custom.iStreamInfo item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32? Id
        {
            get { return DataItem.Id; }
            set
            {
                DataItem.Id = value;
            }
        } 
        public virtual System.Byte? Index
        {
            get { return DataItem.Index; }
            set
            {
                DataItem.Index = value;
            }
        } 
        public virtual System.Decimal? GlobalEndTimeS
        {
            get { return DataItem.GlobalEndTimeS; }
            set
            {
                DataItem.GlobalEndTimeS = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iStreamInfoBase copy = new iStreamInfoBase();
            
            copy.Id = this.Id;
            
            copy.Index = this.Index;
            
            copy.GlobalEndTimeS = this.GlobalEndTimeS;
             
            return copy;
        }
    }
}