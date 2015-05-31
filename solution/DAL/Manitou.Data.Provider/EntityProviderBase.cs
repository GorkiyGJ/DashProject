using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Entity.Base;

namespace Manitou.Data.Provider
{
    public abstract class EntityProviderBase<Entity, EntityKey>
        where Entity : Manitou.Entity.Base.IBaseEntity<EntityKey>, new()
        where EntityKey : Manitou.Entity.Base.IBaseEntityKey, new()
    {
        public virtual List<Entity> GetList()
        {
            return GetList(null);
        }

        public virtual List<Entity> GetList(int count)
        {
            return GetList(null, count);
        }

        public virtual List<Entity> GetList(SessionManager sm)
        {
            return GetList(null, 1000);
        }

        public abstract List<Entity> GetList(SessionManager sm, int count);

        #region GetPaged
        public virtual List<Entity> GetPaged(Manitou.Data.Provider.SessionManager sm, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(sm, string.Empty, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Entity> GetPaged(int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, string.Empty, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Entity> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(sm, whereClause, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Entity> GetPaged(string whereClause, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, whereClause, string.Empty, pageIndex, pageSize, out count);
        }

        public virtual List<Entity> GetPaged(string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            return GetPaged(null, whereClause, orderBy, pageIndex, pageSize, out count);
        }

        public abstract List<Entity> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count);
        #endregion

        #region Insert
        public virtual bool Insert(Entity entity)
        {
            return Insert(null, entity);
        }

        public virtual int Insert(List<Entity> entities)
        {
            return Insert(null, entities);
        }

        public virtual int Insert(SessionManager sm, List<Entity> entities)
        {
            int count = 0;
            foreach (Entity entity in entities)
            {
                if (entity.EntityState == EntityState.Added)
                    if (Insert(sm, entity))
                        count++;
            }

            return count;
        }

        public abstract bool Insert(SessionManager sm, Entity entity);
        #endregion

        #region Update
        public virtual bool Update(Entity entity)
        {
            return Update(null, entity);
        }

        public virtual int Update(List<Entity> entities)
        {
            return Update(null, entities);
        }

        public virtual int Update(SessionManager sm, List<Entity> entities)
        {
            int count = 0;
            foreach (Entity entity in entities)
            {
                if (entity.EntityState == EntityState.Changed)
                    if (Update(sm, entity))
                        count++;
            }

            return count;
        }

        public abstract bool Update(SessionManager sm, Entity entity);
        #endregion

        #region Delete
        public virtual bool Delete(Entity entity)
        {
            return Delete(null, entity);
        }

        public virtual int Delete(List<Entity> entities)
        {
            return Delete(null, entities);
        }

        public virtual int Delete(SessionManager sm, List<Entity> entities)
        {
            int count = 0;
            foreach (Entity entity in entities)
            {
                if (entity.EntityState == EntityState.Deleted)
                    if (Delete(sm, entity))
                        count++;
            }

            return count;
        }

        public abstract bool Delete(SessionManager sm, Entity entity);
        #endregion

        #region Save
        public virtual Entity Save(Entity entity)
        {
            return Save(null, entity);
        }

        public virtual Entity Save(SessionManager sm, Entity entity)
        {
            switch (entity.EntityState)
            {
                case EntityState.Deleted:
                    Delete(sm, entity);
                    break;

                case EntityState.Changed:
                    Update(sm, entity);
                    break;

                case EntityState.Added:
                    Insert(sm, entity);
                    break;
            }

            return entity;
        }
        #endregion

        #region DataRequesting event
        public delegate void DataRequestingEventHandler(object sender, EntityEventArgs e);
        public event DataRequestingEventHandler DataRequesting;
        protected virtual void OnDataRequesting(EntityEventArgs e)
        {
            if (DataRequesting != null)
            {
                DataRequesting(this, e);
            }
        }
        #endregion

        #region DataRequested event definition code
        public delegate void DataRequestedEventHandler(object sender, EntityEventArgs e);
        public event DataRequestedEventHandler DataRequested;
        protected virtual void OnDataRequested(EntityEventArgs e)
        {
            if (DataRequested != null)
            {
                DataRequested(this, e);
            }
        }
        #endregion 
    }
}
