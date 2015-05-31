using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class CodecMediaTypeFactoryBase : EntityProviderBase<DashProject.Entity.CodecMediaType, DashProject.Entity.CodecMediaTypeKey>
    {
        public override List<DashProject.Entity.CodecMediaType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.CodecMediaType> items = Data.DataProvider.Provider.CodecMediaTypeProvider.GetList(sm, count);
            List<DashProject.Entity.CodecMediaType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.CodecMediaType>(items.Count);

                foreach (DashProject.Data.Item.CodecMediaType item in items)
                {
                    DashProject.Entity.CodecMediaType row = new DashProject.Entity.CodecMediaType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.CodecMediaType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.CodecMediaType> items = Data.DataProvider.Provider.CodecMediaTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.CodecMediaType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.CodecMediaType>(items.Count);

                foreach (DashProject.Data.Item.CodecMediaType item in items)
                {
                    DashProject.Entity.CodecMediaType row = new DashProject.Entity.CodecMediaType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.CodecMediaType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.CodecMediaTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.CodecMediaType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.CodecMediaTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.CodecMediaType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.CodecMediaTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.CodecMediaType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.CodecMediaType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.CodecMediaType item = Data.DataProvider.Provider.CodecMediaTypeProvider.GetById(sm,  Id);
            DashProject.Entity.CodecMediaType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.CodecMediaType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}