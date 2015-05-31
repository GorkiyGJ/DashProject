using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class DashInitSegmentFactoryBase : EntityProviderBase<DashProject.Entity.DashInitSegment, DashProject.Entity.DashInitSegmentKey>
    {
        public override List<DashProject.Entity.DashInitSegment> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.DashInitSegment> items = Data.DataProvider.Provider.DashInitSegmentProvider.GetList(sm, count);
            List<DashProject.Entity.DashInitSegment> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashInitSegment>(items.Count);

                foreach (DashProject.Data.Item.DashInitSegment item in items)
                {
                    DashProject.Entity.DashInitSegment row = new DashProject.Entity.DashInitSegment(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.DashInitSegment> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.DashInitSegment> items = Data.DataProvider.Provider.DashInitSegmentProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.DashInitSegment> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashInitSegment>(items.Count);

                foreach (DashProject.Data.Item.DashInitSegment item in items)
                {
                    DashProject.Entity.DashInitSegment row = new DashProject.Entity.DashInitSegment(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.DashInitSegment entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.DashInitSegmentProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.DashInitSegment entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashInitSegmentProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.DashInitSegment entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashInitSegmentProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.DashInitSegment GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.DashInitSegment GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.DashInitSegment item = Data.DataProvider.Provider.DashInitSegmentProvider.GetById(sm,  Id);
            DashProject.Entity.DashInitSegment row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.DashInitSegment(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}