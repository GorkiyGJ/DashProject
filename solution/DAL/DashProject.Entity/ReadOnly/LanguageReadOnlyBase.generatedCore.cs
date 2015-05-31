using System;

namespace DashProject.Entity.ReadOnly
{
    public class LanguageReadOnlyBase: Manitou.Entity.Base.BaseEntityReadOnly<Data.Item.Language>
    {
        public LanguageReadOnlyBase()
            : base()
        {
        }

        public LanguageReadOnlyBase(DashProject.Data.Item.Language item)
            : base(item)
        {
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
        }
        public virtual System.String Code1
        {
            get { return DataItem.Code1; }
        }
        public virtual System.String Code2
        {
            get { return DataItem.Code2; }
        }
        public virtual System.String Code3
        {
            get { return DataItem.Code3; }
        }
        public virtual System.String Name
        {
            get { return DataItem.Name; }
        }
        
        #endregion
    }
}