using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class X264ProfileFactoryBase : EntityProviderBase<DashProject.Entity.X264Profile, DashProject.Entity.X264ProfileKey>
    {
        public override List<DashProject.Entity.X264Profile> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.X264Profile> items = Data.DataProvider.Provider.X264ProfileProvider.GetList(sm, count);
            List<DashProject.Entity.X264Profile> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.X264Profile>(items.Count);

                foreach (DashProject.Data.Item.X264Profile item in items)
                {
                    DashProject.Entity.X264Profile row = new DashProject.Entity.X264Profile(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.X264Profile> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.X264Profile> items = Data.DataProvider.Provider.X264ProfileProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.X264Profile> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.X264Profile>(items.Count);

                foreach (DashProject.Data.Item.X264Profile item in items)
                {
                    DashProject.Entity.X264Profile row = new DashProject.Entity.X264Profile(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.X264Profile entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.X264ProfileProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.X264Profile entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.X264ProfileProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.X264Profile entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.X264ProfileProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.X264Profile GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.X264Profile GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.X264Profile item = Data.DataProvider.Provider.X264ProfileProvider.GetById(sm,  Id);
            DashProject.Entity.X264Profile row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.X264Profile(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}