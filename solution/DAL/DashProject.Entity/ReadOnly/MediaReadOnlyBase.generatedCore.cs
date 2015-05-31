using System;

namespace DashProject.Entity.ReadOnly
{
    public class MediaReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.Media>
    {
        public MediaReadOnlyBase()
            : base()
        {
        }

        public MediaReadOnlyBase(DashProject.Data.Item.Media item)
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
        public virtual System.Byte? ProgramIndex
        {
            get { return DataItem.ProgramIndex; }
        }
        public virtual System.String Name
        {
            get { return DataItem.Name; }
        }
        public virtual System.Boolean IsActive
        {
            get { return DataItem.IsActive; }
        }
        public virtual System.DateTime DateTimeCreated
        {
            get { return DataItem.DateTimeCreated; }
        }
        
        #endregion
    }
}