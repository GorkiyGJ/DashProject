using System;
using System.Collections.Generic;

namespace Manitou.Data.Provider
{
    public abstract class ReadOnlyItemProviderBase<Item>
        where Item : Manitou.Data.Item.Base.IBaseItem, new()
    {
        public virtual List<Item> GetList()
        {
            return GetList(null);
        }

        public virtual List<Item> GetList(SessionManager sm)
        {
            return GetList(null, 5000);
        }

        public abstract List<Item> GetList(SessionManager sm, int count);  
        
        #region GetPaged
        public virtual List<Item> GetPaged(Manitou.Data.Provider.SessionManager sm, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(sm, string.Empty, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Item> GetPaged(int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, string.Empty, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Item> GetPaged(Manitou.Data.Provider.SessionManager sm,  string whereClause, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(sm, whereClause, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Item> GetPaged(string whereClause, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, whereClause, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Item> GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, whereClause, orderBy, pageIndex, pageSize, out count);
        }

        public abstract List<Item> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count);
        #endregion      

        #region DataRequesting event
        public delegate void DataRequestingEventHandler(object sender, ItemEventArgs e);
        public event DataRequestingEventHandler DataRequesting;
        protected virtual void OnDataRequesting(ItemEventArgs e)
        {
            if (DataRequesting != null)
            {
                DataRequesting(this, e);
            }
        }
        #endregion

        #region DataRequested event definition code
        public delegate void DataRequestedEventHandler(object sender, ItemEventArgs e);
        public event DataRequestedEventHandler DataRequested;
        protected virtual void OnDataRequested(ItemEventArgs e)
        {
            if (DataRequested != null)
            {
                DataRequested(this, e);
            }
        }
        #endregion 
    }
}