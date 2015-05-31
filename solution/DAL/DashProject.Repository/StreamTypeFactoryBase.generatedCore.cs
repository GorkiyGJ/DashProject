using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class StreamTypeFactoryBase : EntityProviderBase<DashProject.Entity.StreamType, DashProject.Entity.StreamTypeKey>
    {
        public override List<DashProject.Entity.StreamType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.StreamType> items = Data.DataProvider.Provider.StreamTypeProvider.GetList(sm, count);
            List<DashProject.Entity.StreamType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.StreamType>(items.Count);

                foreach (DashProject.Data.Item.StreamType item in items)
                {
                    DashProject.Entity.StreamType row = new DashProject.Entity.StreamType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.StreamType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.StreamType> items = Data.DataProvider.Provider.StreamTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.StreamType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.StreamType>(items.Count);

                foreach (DashProject.Data.Item.StreamType item in items)
                {
                    DashProject.Entity.StreamType row = new DashProject.Entity.StreamType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.StreamType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.StreamTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.StreamType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.StreamTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.StreamType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.StreamTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.StreamType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.StreamType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.StreamType item = Data.DataProvider.Provider.StreamTypeProvider.GetById(sm,  Id);
            DashProject.Entity.StreamType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.StreamType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}