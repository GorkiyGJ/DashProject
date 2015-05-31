using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class VideoSizeFactoryBase : EntityProviderBase<DashProject.Entity.VideoSize, DashProject.Entity.VideoSizeKey>
    {
        public override List<DashProject.Entity.VideoSize> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.VideoSize> items = Data.DataProvider.Provider.VideoSizeProvider.GetList(sm, count);
            List<DashProject.Entity.VideoSize> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.VideoSize>(items.Count);

                foreach (DashProject.Data.Item.VideoSize item in items)
                {
                    DashProject.Entity.VideoSize row = new DashProject.Entity.VideoSize(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.VideoSize> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.VideoSize> items = Data.DataProvider.Provider.VideoSizeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.VideoSize> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.VideoSize>(items.Count);

                foreach (DashProject.Data.Item.VideoSize item in items)
                {
                    DashProject.Entity.VideoSize row = new DashProject.Entity.VideoSize(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.VideoSize entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.VideoSizeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.VideoSize entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.VideoSizeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.VideoSize entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.VideoSizeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.VideoSize GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.VideoSize GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.VideoSize item = Data.DataProvider.Provider.VideoSizeProvider.GetById(sm,  Id);
            DashProject.Entity.VideoSize row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.VideoSize(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}