using System;

namespace DashProject.Entity.Custom
{
    public class iMediaInfoBase : Manitou.Entity.Base.BaseEntityReadOnly<DashProject.Data.Item.Custom.iMediaInfo>
    {
        public iMediaInfoBase()
            : base()
        {
        }

        public iMediaInfoBase(DashProject.Data.Item.Custom.iMediaInfo item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32? MediaId
        {
            get { return DataItem.MediaId; }
            set
            {
                DataItem.MediaId = value;
            }
        } 
        public virtual System.Byte? ProgramIndex
        {
            get { return DataItem.ProgramIndex; }
            set
            {
                DataItem.ProgramIndex = value;
            }
        } 
        public virtual System.Int32? RawMediaId
        {
            get { return DataItem.RawMediaId; }
            set
            {
                DataItem.RawMediaId = value;
            }
        } 
        public virtual System.Byte? RawMediaSourceTypeId
        {
            get { return DataItem.RawMediaSourceTypeId; }
            set
            {
                DataItem.RawMediaSourceTypeId = value;
            }
        } 
        #endregion

        public virtual object Clone()
        {
            iMediaInfoBase copy = new iMediaInfoBase();
            
            copy.MediaId = this.MediaId;
            
            copy.ProgramIndex = this.ProgramIndex;
            
            copy.RawMediaId = this.RawMediaId;
            
            copy.RawMediaSourceTypeId = this.RawMediaSourceTypeId;
             
            return copy;
        }
    }
}