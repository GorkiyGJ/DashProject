using System;

namespace DashProject.Entity
{
    public class LanguageBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.Language, LanguageKey, LanguageOriginalKey>
    {
        public LanguageBase()
            : base()
        {
            _OriginalKey = new LanguageOriginalKey(DataItem);
            _Key = new LanguageKey(DataItem);
        }

        public LanguageBase(DashProject.Data.Item.Language item)
            : base(item)
        {
            _OriginalKey = new LanguageOriginalKey(item);
            _Key = new LanguageKey(item);
        }

        private LanguageKey _Key = null;
        public override LanguageKey Key
        {
            get
            {
                return _Key;
            }
        }

        private LanguageOriginalKey _OriginalKey = null;
        public override LanguageOriginalKey OriginalKey
        {
            get
            {
                return _OriginalKey;
            }
        }

        #region Properties
                public virtual System.Int32 Id
        {
            get { return DataItem.Id; }
            set
            {
                if (DataItem.Id == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Id = value;
            }
        } 
        public virtual System.String Code1
        {
            get { return DataItem.Code1; }
            set
            {
                if (DataItem.Code1 == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Code1 = value;
            }
        } 
        public virtual System.String Code2
        {
            get { return DataItem.Code2; }
            set
            {
                if (DataItem.Code2 == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Code2 = value;
            }
        } 
        public virtual System.String Code3
        {
            get { return DataItem.Code3; }
            set
            {
                if (DataItem.Code3 == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Code3 = value;
            }
        } 
        public virtual System.String Name
        {
            get { return DataItem.Name; }
            set
            {
                if (DataItem.Name == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Name = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            LanguageBase copy = new LanguageBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Code1 = this.Code1;
            
            copy.Code2 = this.Code2;
            
            copy.Code3 = this.Code3;
            
            copy.Name = this.Name;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new LanguageOriginalKey(DataItem);
        }
    }

    public class LanguageKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.Language>
    {
        public LanguageKey()
        {
        }

        public LanguageKey(DashProject.Data.Item.Language value)
            : base(value)
        {
        }

            
        public System.Int32 Id
        {
            get
            {
                return _item.Id;
            }
        }
        

        public override object Clone()
        {
                            
            object[] obj = new object[1];
            
            obj[0] = Id;        
                         
            return obj;
        }
    }

    public class LanguageOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.Language>
    {
        public LanguageOriginalKey()
        {
        }

        public LanguageOriginalKey(DashProject.Data.Item.Language value)
            : base(value)
        {
        }

         
        private System.Int32 _Id;   
        public System.Int32 Id
        {
            get
            {
                return _Id;
            }
            
            internal set { _Id = value; }
        }
 

        public override object Clone()
        {
            LanguageOriginalKey obj = new LanguageOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.Language value)
        {
            
            _Id = value.Id;        
         
        }
    }
}