using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class DashTypeFactoryBase : EntityProviderBase<DashProject.Entity.DashType, DashProject.Entity.DashTypeKey>
    {
        public override List<DashProject.Entity.DashType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.DashType> items = Data.DataProvider.Provider.DashTypeProvider.GetList(sm, count);
            List<DashProject.Entity.DashType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashType>(items.Count);

                foreach (DashProject.Data.Item.DashType item in items)
                {
                    DashProject.Entity.DashType row = new DashProject.Entity.DashType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.DashType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.DashType> items = Data.DataProvider.Provider.DashTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.DashType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashType>(items.Count);

                foreach (DashProject.Data.Item.DashType item in items)
                {
                    DashProject.Entity.DashType row = new DashProject.Entity.DashType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.DashType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.DashTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.DashType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.DashType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.DashType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.DashType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.DashType item = Data.DataProvider.Provider.DashTypeProvider.GetById(sm,  Id);
            DashProject.Entity.DashType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.DashType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}