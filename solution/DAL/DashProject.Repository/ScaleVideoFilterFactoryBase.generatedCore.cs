using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class ScaleVideoFilterFactoryBase : EntityProviderBase<DashProject.Entity.ScaleVideoFilter, DashProject.Entity.ScaleVideoFilterKey>
    {
        public override List<DashProject.Entity.ScaleVideoFilter> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.ScaleVideoFilter> items = Data.DataProvider.Provider.ScaleVideoFilterProvider.GetList(sm, count);
            List<DashProject.Entity.ScaleVideoFilter> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.ScaleVideoFilter>(items.Count);

                foreach (DashProject.Data.Item.ScaleVideoFilter item in items)
                {
                    DashProject.Entity.ScaleVideoFilter row = new DashProject.Entity.ScaleVideoFilter(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.ScaleVideoFilter> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.ScaleVideoFilter> items = Data.DataProvider.Provider.ScaleVideoFilterProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.ScaleVideoFilter> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.ScaleVideoFilter>(items.Count);

                foreach (DashProject.Data.Item.ScaleVideoFilter item in items)
                {
                    DashProject.Entity.ScaleVideoFilter row = new DashProject.Entity.ScaleVideoFilter(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.ScaleVideoFilter entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.ScaleVideoFilterProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.ScaleVideoFilter entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.ScaleVideoFilterProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.ScaleVideoFilter entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.ScaleVideoFilterProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.ScaleVideoFilter GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.ScaleVideoFilter GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.ScaleVideoFilter item = Data.DataProvider.Provider.ScaleVideoFilterProvider.GetById(sm,  Id);
            DashProject.Entity.ScaleVideoFilter row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.ScaleVideoFilter(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}