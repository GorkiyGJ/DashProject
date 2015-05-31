using System;
using Manitou.Data.Item.Base;

namespace Manitou.Entity.Base
{
    [Serializable]
    public abstract class BaseEntityKey<Entity> : IBaseEntityKey
        where Entity : Manitou.Data.Item.Base.IBaseItem, new()
    {
        public BaseEntityKey()
        { 
        }

        protected Entity _item;
        public BaseEntityKey(Entity value)
        {
            _item = value;
        }

        public abstract object Clone();
    }

    public interface IBaseEntityKey : ICloneable
    {
    }
}
