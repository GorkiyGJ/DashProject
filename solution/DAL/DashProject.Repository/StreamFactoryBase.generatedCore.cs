using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class StreamFactoryBase : EntityProviderBase<DashProject.Entity.Stream, DashProject.Entity.StreamKey>
    {
        public override List<DashProject.Entity.Stream> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.Stream> items = Data.DataProvider.Provider.StreamProvider.GetList(sm, count);
            List<DashProject.Entity.Stream> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.Stream>(items.Count);

                foreach (DashProject.Data.Item.Stream item in items)
                {
                    DashProject.Entity.Stream row = new DashProject.Entity.Stream(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.Stream> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.Stream> items = Data.DataProvider.Provider.StreamProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.Stream> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.Stream>(items.Count);

                foreach (DashProject.Data.Item.Stream item in items)
                {
                    DashProject.Entity.Stream row = new DashProject.Entity.Stream(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.Stream entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.StreamProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.Stream entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.StreamProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.Stream entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.StreamProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.Stream GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.Stream GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.Stream item = Data.DataProvider.Provider.StreamProvider.GetById(sm,  Id);
            DashProject.Entity.Stream row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.Stream(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}