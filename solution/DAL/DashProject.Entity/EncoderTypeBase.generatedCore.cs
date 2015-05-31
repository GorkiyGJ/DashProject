using System;

namespace DashProject.Entity
{
    public class EncoderTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.EncoderType, EncoderTypeKey, EncoderTypeOriginalKey>
    {
        public EncoderTypeBase()
            : base()
        {
            _OriginalKey = new EncoderTypeOriginalKey(DataItem);
            _Key = new EncoderTypeKey(DataItem);
        }

        public EncoderTypeBase(DashProject.Data.Item.EncoderType item)
            : base(item)
        {
            _OriginalKey = new EncoderTypeOriginalKey(item);
            _Key = new EncoderTypeKey(item);
        }

        private EncoderTypeKey _Key = null;
        public override EncoderTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private EncoderTypeOriginalKey _OriginalKey = null;
        public override EncoderTypeOriginalKey OriginalKey
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
        public virtual System.String Description
        {
            get { return DataItem.Description; }
            set
            {
                if (DataItem.Description == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Description = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            EncoderTypeBase copy = new EncoderTypeBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Name = this.Name;
            
            copy.Description = this.Description;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new EncoderTypeOriginalKey(DataItem);
        }
    }

    public class EncoderTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.EncoderType>
    {
        public EncoderTypeKey()
        {
        }

        public EncoderTypeKey(DashProject.Data.Item.EncoderType value)
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

    public class EncoderTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.EncoderType>
    {
        public EncoderTypeOriginalKey()
        {
        }

        public EncoderTypeOriginalKey(DashProject.Data.Item.EncoderType value)
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
            EncoderTypeOriginalKey obj = new EncoderTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.EncoderType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}