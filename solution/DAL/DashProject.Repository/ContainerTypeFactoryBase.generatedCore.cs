using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class ContainerTypeFactoryBase : EntityProviderBase<DashProject.Entity.ContainerType, DashProject.Entity.ContainerTypeKey>
    {
        public override List<DashProject.Entity.ContainerType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.ContainerType> items = Data.DataProvider.Provider.ContainerTypeProvider.GetList(sm, count);
            List<DashProject.Entity.ContainerType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.ContainerType>(items.Count);

                foreach (DashProject.Data.Item.ContainerType item in items)
                {
                    DashProject.Entity.ContainerType row = new DashProject.Entity.ContainerType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.ContainerType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.ContainerType> items = Data.DataProvider.Provider.ContainerTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.ContainerType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.ContainerType>(items.Count);

                foreach (DashProject.Data.Item.ContainerType item in items)
                {
                    DashProject.Entity.ContainerType row = new DashProject.Entity.ContainerType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.ContainerType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.ContainerTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.ContainerType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.ContainerTypeProvider.Update(sm, entity.DataItem, entity.OriginalKey.Id);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.ContainerType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.ContainerTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.ContainerType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.ContainerType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.ContainerType item = Data.DataProvider.Provider.ContainerTypeProvider.GetById(sm,  Id);
            DashProject.Entity.ContainerType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.ContainerType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}