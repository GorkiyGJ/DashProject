using System;
using Manitou.Entity.Base;
using System.Collections.Generic;

namespace Manitou.Data.Provider
{
    public abstract class EntityReadOnlyProviderBase<EntityReadOnly>
        where EntityReadOnly : IBaseReadOnlyEntity, new()
    {
        public virtual List<EntityReadOnly> GetList()
        {
            return GetList(null);
        }

        public virtual List<EntityReadOnly> GetList(SessionManager sm)
        {
            return GetList(null, 1000);
        }

        public abstract List<EntityReadOnly> GetList(SessionManager sm, int count);

        #region GetPaged
        public virtual List<EntityReadOnly> GetPaged(Manitou.Data.Provider.SessionManager sm, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(sm, string.Empty, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<EntityReadOnly> GetPaged(int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, string.Empty, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<EntityReadOnly> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(sm, whereClause, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<EntityReadOnly> GetPaged(string whereClause, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, whereClause, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<EntityReadOnly> GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, whereClause, orderBy, pageIndex, pageSize, out count);
        }

        public virtual List<EntityReadOnly> GetPaged(string whereClause, string orderBy, out int count)
        {
            return GetPaged(null, whereClause, orderBy, 0, int.MaxValue, out count);
        }

        public virtual List<EntityReadOnly> GetPaged(string whereClause, string orderBy)
        {
            int count;
            return GetPaged(null, whereClause, orderBy, 0, int.MaxValue, out count);
        }

        public abstract List<EntityReadOnly> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count);
        #endregion

        #region DataRequesting event
        public delegate void DataRequestingEventHandler(object sender, EntityReadOnlyEventArgs e);
        public event DataRequestingEventHandler DataRequesting;
        protected virtual void OnDataRequesting(EntityReadOnlyEventArgs e)
        {
            if (DataRequesting != null)
            {
                DataRequesting(this, e);
            }
        }
        #endregion

        #region DataRequested event definition code
        public delegate void DataRequestedEventHandler(object sender, EntityReadOnlyEventArgs e);
        public event DataRequestedEventHandler DataRequested;
        protected virtual void OnDataRequested(EntityReadOnlyEventArgs e)
        {
            if (DataRequested != null)
            {
                DataRequested(this, e);
            }
        }
        #endregion
    }
}
