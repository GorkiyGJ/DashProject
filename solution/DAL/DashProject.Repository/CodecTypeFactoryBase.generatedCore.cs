using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class CodecTypeFactoryBase : EntityProviderBase<DashProject.Entity.CodecType, DashProject.Entity.CodecTypeKey>
    {
        public override List<DashProject.Entity.CodecType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.CodecType> items = Data.DataProvider.Provider.CodecTypeProvider.GetList(sm, count);
            List<DashProject.Entity.CodecType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.CodecType>(items.Count);

                foreach (DashProject.Data.Item.CodecType item in items)
                {
                    DashProject.Entity.CodecType row = new DashProject.Entity.CodecType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.CodecType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.CodecType> items = Data.DataProvider.Provider.CodecTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.CodecType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.CodecType>(items.Count);

                foreach (DashProject.Data.Item.CodecType item in items)
                {
                    DashProject.Entity.CodecType row = new DashProject.Entity.CodecType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.CodecType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.CodecTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.CodecType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.CodecTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.CodecType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.CodecTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.CodecType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.CodecType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.CodecType item = Data.DataProvider.Provider.CodecTypeProvider.GetById(sm,  Id);
            DashProject.Entity.CodecType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.CodecType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}