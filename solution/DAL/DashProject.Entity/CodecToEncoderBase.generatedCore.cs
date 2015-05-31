using System;

namespace DashProject.Entity
{
    public class CodecToEncoderBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.CodecToEncoder, CodecToEncoderKey, CodecToEncoderOriginalKey>
    {
        public CodecToEncoderBase()
            : base()
        {
            _OriginalKey = new CodecToEncoderOriginalKey(DataItem);
            _Key = new CodecToEncoderKey(DataItem);
        }

        public CodecToEncoderBase(DashProject.Data.Item.CodecToEncoder item)
            : base(item)
        {
            _OriginalKey = new CodecToEncoderOriginalKey(item);
            _Key = new CodecToEncoderKey(item);
        }

        private CodecToEncoderKey _Key = null;
        public override CodecToEncoderKey Key
        {
            get
            {
                return _Key;
            }
        }

        private CodecToEncoderOriginalKey _OriginalKey = null;
        public override CodecToEncoderOriginalKey OriginalKey
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
        public virtual System.Int32 CodecTypeId
        {
            get { return DataItem.CodecTypeId; }
            set
            {
                if (DataItem.CodecTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.CodecTypeId = value;
            }
        } 
        public virtual System.Int32 EncoderTypeId
        {
            get { return DataItem.EncoderTypeId; }
            set
            {
                if (DataItem.EncoderTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.EncoderTypeId = value;
            }
        } 
        public virtual System.Boolean IsMain
        {
            get { return DataItem.IsMain; }
            set
            {
                if (DataItem.IsMain == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsMain = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            CodecToEncoderBase copy = new CodecToEncoderBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.CodecTypeId = this.CodecTypeId;
            
            copy.EncoderTypeId = this.EncoderTypeId;
            
            copy.IsMain = this.IsMain;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new CodecToEncoderOriginalKey(DataItem);
        }
    }

    public class CodecToEncoderKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.CodecToEncoder>
    {
        public CodecToEncoderKey()
        {
        }

        public CodecToEncoderKey(DashProject.Data.Item.CodecToEncoder value)
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

    public class CodecToEncoderOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.CodecToEncoder>
    {
        public CodecToEncoderOriginalKey()
        {
        }

        public CodecToEncoderOriginalKey(DashProject.Data.Item.CodecToEncoder value)
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
            CodecToEncoderOriginalKey obj = new CodecToEncoderOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.CodecToEncoder value)
        {
            
            _Id = value.Id;        
         
        }
    }
}