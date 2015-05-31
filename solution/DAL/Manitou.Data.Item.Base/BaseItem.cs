using System;

namespace Manitou.Data.Item.Base
{
    [Serializable]
    public abstract class BaseItem : Manitou.Data.Item.Base.IBaseItem
    {
        public BaseItem()
        { 
        }

        public abstract object Clone();
        public abstract int CompareTo(object obj);
    }
}
