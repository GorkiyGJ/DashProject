using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class X264ProfileLevelFactoryBase : EntityProviderBase<DashProject.Entity.X264ProfileLevel, DashProject.Entity.X264ProfileLevelKey>
    {
        public override List<DashProject.Entity.X264ProfileLevel> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.X264ProfileLevel> items = Data.DataProvider.Provider.X264ProfileLevelProvider.GetList(sm, count);
            List<DashProject.Entity.X264ProfileLevel> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.X264ProfileLevel>(items.Count);

                foreach (DashProject.Data.Item.X264ProfileLevel item in items)
                {
                    DashProject.Entity.X264ProfileLevel row = new DashProject.Entity.X264ProfileLevel(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.X264ProfileLevel> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.X264ProfileLevel> items = Data.DataProvider.Provider.X264ProfileLevelProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.X264ProfileLevel> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.X264ProfileLevel>(items.Count);

                foreach (DashProject.Data.Item.X264ProfileLevel item in items)
                {
                    DashProject.Entity.X264ProfileLevel row = new DashProject.Entity.X264ProfileLevel(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.X264ProfileLevel entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.X264ProfileLevelProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.X264ProfileLevel entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.X264ProfileLevelProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.X264ProfileLevel entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.X264ProfileLevelProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.X264ProfileLevel GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.X264ProfileLevel GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.X264ProfileLevel item = Data.DataProvider.Provider.X264ProfileLevelProvider.GetById(sm,  Id);
            DashProject.Entity.X264ProfileLevel row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.X264ProfileLevel(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}