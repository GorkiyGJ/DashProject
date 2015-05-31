using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class DashMediaSegmentFactoryBase : EntityProviderBase<DashProject.Entity.DashMediaSegment, DashProject.Entity.DashMediaSegmentKey>
    {
        public override List<DashProject.Entity.DashMediaSegment> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.DashMediaSegment> items = Data.DataProvider.Provider.DashMediaSegmentProvider.GetList(sm, count);
            List<DashProject.Entity.DashMediaSegment> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashMediaSegment>(items.Count);

                foreach (DashProject.Data.Item.DashMediaSegment item in items)
                {
                    DashProject.Entity.DashMediaSegment row = new DashProject.Entity.DashMediaSegment(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.DashMediaSegment> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.DashMediaSegment> items = Data.DataProvider.Provider.DashMediaSegmentProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.DashMediaSegment> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashMediaSegment>(items.Count);

                foreach (DashProject.Data.Item.DashMediaSegment item in items)
                {
                    DashProject.Entity.DashMediaSegment row = new DashProject.Entity.DashMediaSegment(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.DashMediaSegment entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.DashMediaSegmentProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.DashMediaSegment entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashMediaSegmentProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.DashMediaSegment entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashMediaSegmentProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.DashMediaSegment GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.DashMediaSegment GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.DashMediaSegment item = Data.DataProvider.Provider.DashMediaSegmentProvider.GetById(sm,  Id);
            DashProject.Entity.DashMediaSegment row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.DashMediaSegment(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}