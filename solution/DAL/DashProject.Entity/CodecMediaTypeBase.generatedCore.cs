using System;

namespace DashProject.Entity
{
    public class CodecMediaTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.CodecMediaType, CodecMediaTypeKey, CodecMediaTypeOriginalKey>
    {
        public CodecMediaTypeBase()
            : base()
        {
            _OriginalKey = new CodecMediaTypeOriginalKey(DataItem);
            _Key = new CodecMediaTypeKey(DataItem);
        }

        public CodecMediaTypeBase(DashProject.Data.Item.CodecMediaType item)
            : base(item)
        {
            _OriginalKey = new CodecMediaTypeOriginalKey(item);
            _Key = new CodecMediaTypeKey(item);
        }

        private CodecMediaTypeKey _Key = null;
        public override CodecMediaTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private CodecMediaTypeOriginalKey _OriginalKey = null;
        public override CodecMediaTypeOriginalKey OriginalKey
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
        #endregion

        public override object Clone()
        {
            CodecMediaTypeBase copy = new CodecMediaTypeBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
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

            _OriginalKey = new CodecMediaTypeOriginalKey(DataItem);
        }
    }

    public class CodecMediaTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.CodecMediaType>
    {
        public CodecMediaTypeKey()
        {
        }

        public CodecMediaTypeKey(DashProject.Data.Item.CodecMediaType value)
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

    public class CodecMediaTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.CodecMediaType>
    {
        public CodecMediaTypeOriginalKey()
        {
        }

        public CodecMediaTypeOriginalKey(DashProject.Data.Item.CodecMediaType value)
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
            CodecMediaTypeOriginalKey obj = new CodecMediaTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.CodecMediaType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}