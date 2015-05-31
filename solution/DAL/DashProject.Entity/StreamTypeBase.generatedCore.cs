using System;

namespace DashProject.Entity
{
    public class StreamTypeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.StreamType, StreamTypeKey, StreamTypeOriginalKey>
    {
        public StreamTypeBase()
            : base()
        {
            _OriginalKey = new StreamTypeOriginalKey(DataItem);
            _Key = new StreamTypeKey(DataItem);
        }

        public StreamTypeBase(DashProject.Data.Item.StreamType item)
            : base(item)
        {
            _OriginalKey = new StreamTypeOriginalKey(item);
            _Key = new StreamTypeKey(item);
        }

        private StreamTypeKey _Key = null;
        public override StreamTypeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private StreamTypeOriginalKey _OriginalKey = null;
        public override StreamTypeOriginalKey OriginalKey
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
            StreamTypeBase copy = new StreamTypeBase();
            
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

            _OriginalKey = new StreamTypeOriginalKey(DataItem);
        }
    }

    public class StreamTypeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.StreamType>
    {
        public StreamTypeKey()
        {
        }

        public StreamTypeKey(DashProject.Data.Item.StreamType value)
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

    public class StreamTypeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.StreamType>
    {
        public StreamTypeOriginalKey()
        {
        }

        public StreamTypeOriginalKey(DashProject.Data.Item.StreamType value)
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
            StreamTypeOriginalKey obj = new StreamTypeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.StreamType value)
        {
            
            _Id = value.Id;        
         
        }
    }
}