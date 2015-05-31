using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class EncoderTypeFactoryBase : EntityProviderBase<DashProject.Entity.EncoderType, DashProject.Entity.EncoderTypeKey>
    {
        public override List<DashProject.Entity.EncoderType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.EncoderType> items = Data.DataProvider.Provider.EncoderTypeProvider.GetList(sm, count);
            List<DashProject.Entity.EncoderType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.EncoderType>(items.Count);

                foreach (DashProject.Data.Item.EncoderType item in items)
                {
                    DashProject.Entity.EncoderType row = new DashProject.Entity.EncoderType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.EncoderType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.EncoderType> items = Data.DataProvider.Provider.EncoderTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.EncoderType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.EncoderType>(items.Count);

                foreach (DashProject.Data.Item.EncoderType item in items)
                {
                    DashProject.Entity.EncoderType row = new DashProject.Entity.EncoderType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.EncoderType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.EncoderTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.EncoderType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.EncoderTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.EncoderType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.EncoderTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.EncoderType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.EncoderType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.EncoderType item = Data.DataProvider.Provider.EncoderTypeProvider.GetById(sm,  Id);
            DashProject.Entity.EncoderType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.EncoderType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}