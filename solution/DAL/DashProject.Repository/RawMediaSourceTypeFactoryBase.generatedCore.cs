using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class RawMediaSourceTypeFactoryBase : EntityProviderBase<DashProject.Entity.RawMediaSourceType, DashProject.Entity.RawMediaSourceTypeKey>
    {
        public override List<DashProject.Entity.RawMediaSourceType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.RawMediaSourceType> items = Data.DataProvider.Provider.RawMediaSourceTypeProvider.GetList(sm, count);
            List<DashProject.Entity.RawMediaSourceType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.RawMediaSourceType>(items.Count);

                foreach (DashProject.Data.Item.RawMediaSourceType item in items)
                {
                    DashProject.Entity.RawMediaSourceType row = new DashProject.Entity.RawMediaSourceType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.RawMediaSourceType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.RawMediaSourceType> items = Data.DataProvider.Provider.RawMediaSourceTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.RawMediaSourceType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.RawMediaSourceType>(items.Count);

                foreach (DashProject.Data.Item.RawMediaSourceType item in items)
                {
                    DashProject.Entity.RawMediaSourceType row = new DashProject.Entity.RawMediaSourceType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.RawMediaSourceType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.RawMediaSourceTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.RawMediaSourceType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.RawMediaSourceTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.RawMediaSourceType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.RawMediaSourceTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.RawMediaSourceType GetById(System.Byte Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.RawMediaSourceType GetById(SessionManager sm, System.Byte Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.RawMediaSourceType item = Data.DataProvider.Provider.RawMediaSourceTypeProvider.GetById(sm,  Id);
            DashProject.Entity.RawMediaSourceType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.RawMediaSourceType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}