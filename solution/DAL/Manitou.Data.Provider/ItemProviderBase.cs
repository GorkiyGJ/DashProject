using System;
using System.Collections.Generic;

namespace Manitou.Data.Provider
{
    public abstract class ItemProviderBase<Item> : ReadOnlyItemProviderBase<Item>
        where Item : Manitou.Data.Item.Base.IBaseItem, new()
    {
        #region Insert
        public virtual bool Insert(Item item)
        {
            return Insert(null, item);
        }

        public abstract bool Insert(SessionManager sm, Item item);
        #endregion

        //#region Update
        //public virtual bool Update(Item item)
        //{
        //    return Update(null, item);
        //}

        //public abstract bool Update(SessionManager sm, Item item);
        //#endregion

        #region Delete
        public virtual bool Delete(Item item)
        {
            return Delete(null, item);
        }

        public abstract bool Delete(SessionManager sm, Item item);
        #endregion
    }
}