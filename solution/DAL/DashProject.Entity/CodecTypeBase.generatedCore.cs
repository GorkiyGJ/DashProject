using System;

namespace DashProject.Entity
{
    public class CodecTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.CodecType, CodecTypeKey, CodecTypeOriginalKey>
    {
        public CodecTypeBase()
            : base()
        {
            _OriginalKey = new CodecTypeOriginalKey(DataItem);
            _Key = new CodecTypeKey(DataItem);
        }

        public CodecTypeBase(DashProject.Data.Item.CodecType item)
            : base(item)
        {
            _OriginalKey = new CodecTypeOriginalKey(item);
            _Key = new CodecTypeKey(item);
        }

        private CodecTypeKey _Key = null;
        public override CodecTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private CodecTypeOriginalKey _OriginalKey = null;
        public override CodecTypeOriginalKey OriginalKey
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
        public virtual System.Int32 StreamTypeId
        {
            get { return DataItem.StreamTypeId; }
            set
            {
                if (DataItem.StreamTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.StreamTypeId = value;
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
            CodecTypeBase copy = new CodecTypeBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.StreamTypeId = this.StreamTypeId;
            
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

            _OriginalKey = new CodecTypeOriginalKey(DataItem);
        }
    }

    public class CodecTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.CodecType>
    {
        public CodecTypeKey()
        {
        }

        public CodecTypeKey(DashProject.Data.Item.CodecType value)
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

    public class CodecTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.CodecType>
    {
        public CodecTypeOriginalKey()
        {
        }

        public CodecTypeOriginalKey(DashProject.Data.Item.CodecType value)
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
            CodecTypeOriginalKey obj = new CodecTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.CodecType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}