using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class AspectRatioFactoryBase : EntityProviderBase<DashProject.Entity.AspectRatio, DashProject.Entity.AspectRatioKey>
    {
        public override List<DashProject.Entity.AspectRatio> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.AspectRatio> items = Data.DataProvider.Provider.AspectRatioProvider.GetList(sm, count);
            List<DashProject.Entity.AspectRatio> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.AspectRatio>(items.Count);

                foreach (DashProject.Data.Item.AspectRatio item in items)
                {
                    DashProject.Entity.AspectRatio row = new DashProject.Entity.AspectRatio(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.AspectRatio> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.AspectRatio> items = Data.DataProvider.Provider.AspectRatioProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.AspectRatio> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.AspectRatio>(items.Count);

                foreach (DashProject.Data.Item.AspectRatio item in items)
                {
                    DashProject.Entity.AspectRatio row = new DashProject.Entity.AspectRatio(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.AspectRatio entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.AspectRatioProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.AspectRatio entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.AspectRatioProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.AspectRatio entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.AspectRatioProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.AspectRatio GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.AspectRatio GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.AspectRatio item = Data.DataProvider.Provider.AspectRatioProvider.GetById(sm,  Id);
            DashProject.Entity.AspectRatio row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.AspectRatio(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}