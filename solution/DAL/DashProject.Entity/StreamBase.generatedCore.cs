using System;

namespace DashProject.Entity
{
    public class StreamBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.Stream, StreamKey, StreamOriginalKey>
    {
        public StreamBase()
            : base()
        {
            _OriginalKey = new StreamOriginalKey(DataItem);
            _Key = new StreamKey(DataItem);
        }

        public StreamBase(DashProject.Data.Item.Stream item)
            : base(item)
        {
            _OriginalKey = new StreamOriginalKey(item);
            _Key = new StreamKey(item);
        }

        private StreamKey _Key = null;
        public override StreamKey Key
        {
            get
            {
                return _Key;
            }
        }

        private StreamOriginalKey _OriginalKey = null;
        public override StreamOriginalKey OriginalKey
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
        public virtual System.Int32 RawMediaId
        {
            get { return DataItem.RawMediaId; }
            set
            {
                if (DataItem.RawMediaId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.RawMediaId = value;
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
        public virtual System.Byte Index
        {
            get { return DataItem.Index; }
            set
            {
                if (DataItem.Index == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Index = value;
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
        public virtual System.Byte? Channels
        {
            get { return DataItem.Channels; }
            set
            {
                if (DataItem.Channels == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Channels = value;
            }
        } 
        public virtual System.Int32? LanguageId
        {
            get { return DataItem.LanguageId; }
            set
            {
                if (DataItem.LanguageId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.LanguageId = value;
            }
        } 
        public virtual System.Int16? Width
        {
            get { return DataItem.Width; }
            set
            {
                if (DataItem.Width == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Width = value;
            }
        } 
        public virtual System.Int16? Height
        {
            get { return DataItem.Height; }
            set
            {
                if (DataItem.Height == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.Height = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            StreamBase copy = new StreamBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.RawMediaId = this.RawMediaId;
            
            copy.StreamTypeId = this.StreamTypeId;
            
            copy.Index = this.Index;
            
            copy.CodecTypeId = this.CodecTypeId;
            
            copy.Channels = this.Channels;
            
            copy.LanguageId = this.LanguageId;
            
            copy.Width = this.Width;
            
            copy.Height = this.Height;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new StreamOriginalKey(DataItem);
        }
    }

    public class StreamKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.Stream>
    {
        public StreamKey()
        {
        }

        public StreamKey(DashProject.Data.Item.Stream value)
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

    public class StreamOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.Stream>
    {
        public StreamOriginalKey()
        {
        }

        public StreamOriginalKey(DashProject.Data.Item.Stream value)
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
            StreamOriginalKey obj = new StreamOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.Stream value)
        {
            
            _Id = value.Id;        
         
        }
    }
}