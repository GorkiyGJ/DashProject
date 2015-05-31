using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class SegmenterConfigFactoryBase : EntityProviderBase<DashProject.Entity.SegmenterConfig, DashProject.Entity.SegmenterConfigKey>
    {
        public override List<DashProject.Entity.SegmenterConfig> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.SegmenterConfig> items = Data.DataProvider.Provider.SegmenterConfigProvider.GetList(sm, count);
            List<DashProject.Entity.SegmenterConfig> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.SegmenterConfig>(items.Count);

                foreach (DashProject.Data.Item.SegmenterConfig item in items)
                {
                    DashProject.Entity.SegmenterConfig row = new DashProject.Entity.SegmenterConfig(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.SegmenterConfig> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.SegmenterConfig> items = Data.DataProvider.Provider.SegmenterConfigProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.SegmenterConfig> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.SegmenterConfig>(items.Count);

                foreach (DashProject.Data.Item.SegmenterConfig item in items)
                {
                    DashProject.Entity.SegmenterConfig row = new DashProject.Entity.SegmenterConfig(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.SegmenterConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.SegmenterConfigProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.SegmenterConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.SegmenterConfigProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.SegmenterConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.SegmenterConfigProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.SegmenterConfig GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.SegmenterConfig GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.SegmenterConfig item = Data.DataProvider.Provider.SegmenterConfigProvider.GetById(sm,  Id);
            DashProject.Entity.SegmenterConfig row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.SegmenterConfig(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}