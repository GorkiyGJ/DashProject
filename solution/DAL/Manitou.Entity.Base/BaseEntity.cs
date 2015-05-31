using System;
using Manitou.Data.Item.Base;
using System.ComponentModel;
using System.Xml.Serialization;

namespace Manitou.Entity.Base
{
    [Serializable]
    public abstract class BaseEntityComponentKey<T, TKey, TOriginalKey> : BaseEntity<T, TKey>
        where T : BaseItem, new()
        where TKey : IBaseEntityKey, new()
        where TOriginalKey : IBaseEntityOriginalKey, new()
    {
        public BaseEntityComponentKey()
            :base()
        {
        }

        public BaseEntityComponentKey(T item)
            :base(item)
        {
        }

        public abstract TOriginalKey OriginalKey
        {
            get;
        }
    }

    [Serializable]
    public abstract class BaseEntity<T, TKey> : Manitou.Entity.Base.IBaseEntity<TKey>
        where T : BaseItem, new()
        where TKey : IBaseEntityKey, new()
    {
        public BaseEntity()
        {
            _DataItem = new T();

            EntityState = EntityState.Added;
        }

        public BaseEntity(T item)
        {
            _DataItem = item;
        }

        protected T _DataItem = null;
        protected internal T DataItem
        {
            get { return _DataItem; }
        }

        public abstract TKey Key { get; }

        private EntityState _EntityState = EntityState.Unchanged;
        public EntityState EntityState
        {
            get { return _EntityState; }
            set { _EntityState = value; }
        }

        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public virtual bool IsDeleted
        {
            get { return EntityState == EntityState.Deleted; }
        }

        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public virtual bool IsDirty
        {
            get { return EntityState != EntityState.Unchanged; }
        }

        [BrowsableAttribute(false), XmlIgnoreAttribute()]
        public virtual bool IsNew
        {
            get { return EntityState == EntityState.Added; }
        }

        public abstract object Clone();
        public abstract int CompareTo(object obj);


        public abstract void AcceptChanges();
    }
}
