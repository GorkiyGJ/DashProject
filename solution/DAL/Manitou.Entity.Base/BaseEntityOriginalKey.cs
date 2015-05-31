using System;
using Manitou.Data.Item.Base;

namespace Manitou.Entity.Base
{
    [Serializable]
    public abstract class BaseEntityOriginalKey<Entity> : IBaseEntityOriginalKey
        where Entity : Manitou.Data.Item.Base.IBaseItem, new()
    {
        public BaseEntityOriginalKey()
        {
        }

        public BaseEntityOriginalKey(Entity value)
        {
            SetValue(value);
        }

        public abstract object Clone();
        protected abstract void SetValue(Entity value);
    }

    public interface IBaseEntityOriginalKey : IBaseEntityKey
    {
    }
}
