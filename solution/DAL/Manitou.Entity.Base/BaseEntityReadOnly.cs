using System;
using Manitou.Data.Item.Base;

namespace Manitou.Entity.Base
{
    [Serializable]
    public abstract class BaseEntityReadOnly<T> : IBaseReadOnlyEntity
        where T : BaseItem, new()
    {
        public BaseEntityReadOnly()
        {
            _DataItem = new T();
        }

        public BaseEntityReadOnly(T item)
        {
            _DataItem = item;
        }

        private T _DataItem = null;
        protected T DataItem
        {
            get { return _DataItem; }
        }
    }
}
