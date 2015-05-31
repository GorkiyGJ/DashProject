using System;

namespace DashProject.Entity
{
    public class DashMediaBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.DashMedia, DashMediaKey, DashMediaOriginalKey>
    {
        public DashMediaBase()
            : base()
        {
            _OriginalKey = new DashMediaOriginalKey(DataItem);
            _Key = new DashMediaKey(DataItem);
        }

        public DashMediaBase(DashProject.Data.Item.DashMedia item)
            : base(item)
        {
            _OriginalKey = new DashMediaOriginalKey(item);
            _Key = new DashMediaKey(item);
        }

        private DashMediaKey _Key = null;
        public override DashMediaKey Key
        {
            get
            {
                return _Key;
            }
        }

        private DashMediaOriginalKey _OriginalKey = null;
        public override DashMediaOriginalKey OriginalKey
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
        public virtual System.Int32 MediaId
        {
            get { return DataItem.MediaId; }
            set
            {
                if (DataItem.MediaId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.MediaId = value;
            }
        } 
        public virtual System.Int32 StreamId
        {
            get { return DataItem.StreamId; }
            set
            {
                if (DataItem.StreamId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.StreamId = value;
            }
        } 
        public virtual System.Int32? DashInitSegmentId
        {
            get { return DataItem.DashInitSegmentId; }
            set
            {
                if (DataItem.DashInitSegmentId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DashInitSegmentId = value;
            }
        } 
        public virtual System.Int32 DashTypeId
        {
            get { return DataItem.DashTypeId; }
            set
            {
                if (DataItem.DashTypeId == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.DashTypeId = value;
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
        public virtual System.Int32 BitrateKbps
        {
            get { return DataItem.BitrateKbps; }
            set
            {
                if (DataItem.BitrateKbps == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.BitrateKbps = value;
            }
        } 
        public virtual System.Boolean IsActive
        {
            get { return DataItem.IsActive; }
            set
            {
                if (DataItem.IsActive == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.IsActive = value;
            }
        } 
        public virtual System.Int32 FragmentDurationS
        {
            get { return DataItem.FragmentDurationS; }
            set
            {
                if (DataItem.FragmentDurationS == value)
                    return;

                if (EntityState == Manitou.Entity.Base.EntityState.Unchanged)
                    EntityState = Manitou.Entity.Base.EntityState.Changed;

                DataItem.FragmentDurationS = value;
            }
        } 
        #endregion

        public override object Clone()
        {
            DashMediaBase copy = new DashMediaBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.MediaId = this.MediaId;
            
            copy.StreamId = this.StreamId;
            
            copy.DashInitSegmentId = this.DashInitSegmentId;
            
            copy.DashTypeId = this.DashTypeId;
            
            copy.CodecTypeId = this.CodecTypeId;
            
            copy.Width = this.Width;
            
            copy.Height = this.Height;
            
            copy.Channels = this.Channels;
            
            copy.BitrateKbps = this.BitrateKbps;
            
            copy.IsActive = this.IsActive;
            
            copy.FragmentDurationS = this.FragmentDurationS;
             
            return copy;
        }

        public override int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public override void AcceptChanges()
        {
            EntityState = Manitou.Entity.Base.EntityState.Unchanged;

            _OriginalKey = new DashMediaOriginalKey(DataItem);
        }
    }

    public class DashMediaKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.DashMedia>
    {
        public DashMediaKey()
        {
        }

        public DashMediaKey(DashProject.Data.Item.DashMedia value)
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

    public class DashMediaOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.DashMedia>
    {
        public DashMediaOriginalKey()
        {
        }

        public DashMediaOriginalKey(DashProject.Data.Item.DashMedia value)
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
            DashMediaOriginalKey obj = new DashMediaOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.DashMedia value)
        {
            
            _Id = value.Id;        
         
        }
    }
}