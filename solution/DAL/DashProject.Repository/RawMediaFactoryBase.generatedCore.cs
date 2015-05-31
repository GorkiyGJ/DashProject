using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class RawMediaFactoryBase : EntityProviderBase<DashProject.Entity.RawMedia, DashProject.Entity.RawMediaKey>
    {
        public override List<DashProject.Entity.RawMedia> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.RawMedia> items = Data.DataProvider.Provider.RawMediaProvider.GetList(sm, count);
            List<DashProject.Entity.RawMedia> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.RawMedia>(items.Count);

                foreach (DashProject.Data.Item.RawMedia item in items)
                {
                    DashProject.Entity.RawMedia row = new DashProject.Entity.RawMedia(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.RawMedia> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.RawMedia> items = Data.DataProvider.Provider.RawMediaProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.RawMedia> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.RawMedia>(items.Count);

                foreach (DashProject.Data.Item.RawMedia item in items)
                {
                    DashProject.Entity.RawMedia row = new DashProject.Entity.RawMedia(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.RawMedia entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.RawMediaProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.RawMedia entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.RawMediaProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.RawMedia entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.RawMediaProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.RawMedia GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.RawMedia GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.RawMedia item = Data.DataProvider.Provider.RawMediaProvider.GetById(sm,  Id);
            DashProject.Entity.RawMedia row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.RawMedia(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}