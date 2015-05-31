using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class ApplicationConfigurationFactoryBase : EntityProviderBase<DashProject.Entity.ApplicationConfiguration, DashProject.Entity.ApplicationConfigurationKey>
    {
        public override List<DashProject.Entity.ApplicationConfiguration> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.ApplicationConfiguration> items = Data.DataProvider.Provider.ApplicationConfigurationProvider.GetList(sm, count);
            List<DashProject.Entity.ApplicationConfiguration> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.ApplicationConfiguration>(items.Count);

                foreach (DashProject.Data.Item.ApplicationConfiguration item in items)
                {
                    DashProject.Entity.ApplicationConfiguration row = new DashProject.Entity.ApplicationConfiguration(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.ApplicationConfiguration> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.ApplicationConfiguration> items = Data.DataProvider.Provider.ApplicationConfigurationProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.ApplicationConfiguration> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.ApplicationConfiguration>(items.Count);

                foreach (DashProject.Data.Item.ApplicationConfiguration item in items)
                {
                    DashProject.Entity.ApplicationConfiguration row = new DashProject.Entity.ApplicationConfiguration(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.ApplicationConfiguration entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.ApplicationConfigurationProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.ApplicationConfiguration entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.ApplicationConfigurationProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.ApplicationConfiguration entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.ApplicationConfigurationProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.ApplicationConfiguration GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.ApplicationConfiguration GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.ApplicationConfiguration item = Data.DataProvider.Provider.ApplicationConfigurationProvider.GetById(sm,  Id);
            DashProject.Entity.ApplicationConfiguration row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.ApplicationConfiguration(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}