using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class CodecToEncoderFactoryBase : EntityProviderBase<DashProject.Entity.CodecToEncoder, DashProject.Entity.CodecToEncoderKey>
    {
        public override List<DashProject.Entity.CodecToEncoder> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.CodecToEncoder> items = Data.DataProvider.Provider.CodecToEncoderProvider.GetList(sm, count);
            List<DashProject.Entity.CodecToEncoder> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.CodecToEncoder>(items.Count);

                foreach (DashProject.Data.Item.CodecToEncoder item in items)
                {
                    DashProject.Entity.CodecToEncoder row = new DashProject.Entity.CodecToEncoder(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.CodecToEncoder> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.CodecToEncoder> items = Data.DataProvider.Provider.CodecToEncoderProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.CodecToEncoder> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.CodecToEncoder>(items.Count);

                foreach (DashProject.Data.Item.CodecToEncoder item in items)
                {
                    DashProject.Entity.CodecToEncoder row = new DashProject.Entity.CodecToEncoder(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.CodecToEncoder entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.CodecToEncoderProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.CodecToEncoder entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.CodecToEncoderProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.CodecToEncoder entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.CodecToEncoderProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.CodecToEncoder GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.CodecToEncoder GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.CodecToEncoder item = Data.DataProvider.Provider.CodecToEncoderProvider.GetById(sm,  Id);
            DashProject.Entity.CodecToEncoder row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.CodecToEncoder(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}