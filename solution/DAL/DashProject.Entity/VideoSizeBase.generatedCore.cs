using System;

namespace DashProject.Entity
{
    public class VideoSizeBase : Manitou.Entity.Base.BaseEntityComponentKey<DashProject.Data.Item.VideoSize, VideoSizeKey, VideoSizeOriginalKey>
    {
        public VideoSizeBase()
            : base()
        {
            _OriginalKey = new VideoSizeOriginalKey(DataItem);
            _Key = new VideoSizeKey(DataItem);
        }

        public VideoSizeBase(DashProject.Data.Item.VideoSize item)
            : base(item)
        {
            _OriginalKey = new VideoSizeOriginalKey(item);
            _Key = new VideoSizeKey(item);
        }

        private VideoSizeKey _Key = null;
        public override VideoSizeKey Key
        {
            get
            {
                return _Key;
            }
        }

        private VideoSizeOriginalKey _OriginalKey = null;
        public override VideoSizeOriginalKey OriginalKey
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
        public virtual System.Int16 Width
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
        public virtual System.Int16 Height
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
            VideoSizeBase copy = new VideoSizeBase();
            
            copy.Id = this.Id;
              copy.OriginalKey.Id = this.OriginalKey.Id;
            
            copy.Name = this.Name;
            
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

            _OriginalKey = new VideoSizeOriginalKey(DataItem);
        }
    }

    public class VideoSizeKey : Manitou.Entity.Base.BaseEntityKey<DashProject.Data.Item.VideoSize>
    {
        public VideoSizeKey()
        {
        }

        public VideoSizeKey(DashProject.Data.Item.VideoSize value)
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

    public class VideoSizeOriginalKey : Manitou.Entity.Base.BaseEntityOriginalKey<DashProject.Data.Item.VideoSize>
    {
        public VideoSizeOriginalKey()
        {
        }

        public VideoSizeOriginalKey(DashProject.Data.Item.VideoSize value)
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
            VideoSizeOriginalKey obj = new VideoSizeOriginalKey();
            
            
            obj.Id = Id;        
                         
            return obj;
        }

        protected override void SetValue(DashProject.Data.Item.VideoSize value)
        {
            
            _Id = value.Id;        
         
        }
    }
}