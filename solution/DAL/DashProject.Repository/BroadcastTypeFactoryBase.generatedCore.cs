using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class BroadcastTypeFactoryBase : EntityProviderBase<DashProject.Entity.BroadcastType, DashProject.Entity.BroadcastTypeKey>
    {
        public override List<DashProject.Entity.BroadcastType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.BroadcastType> items = Data.DataProvider.Provider.BroadcastTypeProvider.GetList(sm, count);
            List<DashProject.Entity.BroadcastType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.BroadcastType>(items.Count);

                foreach (DashProject.Data.Item.BroadcastType item in items)
                {
                    DashProject.Entity.BroadcastType row = new DashProject.Entity.BroadcastType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.BroadcastType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.BroadcastType> items = Data.DataProvider.Provider.BroadcastTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.BroadcastType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.BroadcastType>(items.Count);

                foreach (DashProject.Data.Item.BroadcastType item in items)
                {
                    DashProject.Entity.BroadcastType row = new DashProject.Entity.BroadcastType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.BroadcastType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.BroadcastTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.BroadcastType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.BroadcastTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.BroadcastType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.BroadcastTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.BroadcastType GetById(System.Byte Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.BroadcastType GetById(SessionManager sm, System.Byte Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.BroadcastType item = Data.DataProvider.Provider.BroadcastTypeProvider.GetById(sm,  Id);
            DashProject.Entity.BroadcastType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.BroadcastType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}