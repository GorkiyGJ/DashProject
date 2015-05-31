using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class LIBx264EncoderConfigFactoryBase : EntityProviderBase<DashProject.Entity.LIBx264EncoderConfig, DashProject.Entity.LIBx264EncoderConfigKey>
    {
        public override List<DashProject.Entity.LIBx264EncoderConfig> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.LIBx264EncoderConfig> items = Data.DataProvider.Provider.LIBx264EncoderConfigProvider.GetList(sm, count);
            List<DashProject.Entity.LIBx264EncoderConfig> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.LIBx264EncoderConfig>(items.Count);

                foreach (DashProject.Data.Item.LIBx264EncoderConfig item in items)
                {
                    DashProject.Entity.LIBx264EncoderConfig row = new DashProject.Entity.LIBx264EncoderConfig(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.LIBx264EncoderConfig> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.LIBx264EncoderConfig> items = Data.DataProvider.Provider.LIBx264EncoderConfigProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.LIBx264EncoderConfig> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.LIBx264EncoderConfig>(items.Count);

                foreach (DashProject.Data.Item.LIBx264EncoderConfig item in items)
                {
                    DashProject.Entity.LIBx264EncoderConfig row = new DashProject.Entity.LIBx264EncoderConfig(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.LIBx264EncoderConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.LIBx264EncoderConfigProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.LIBx264EncoderConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.LIBx264EncoderConfigProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.LIBx264EncoderConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.LIBx264EncoderConfigProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.LIBx264EncoderConfig GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.LIBx264EncoderConfig GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.LIBx264EncoderConfig item = Data.DataProvider.Provider.LIBx264EncoderConfigProvider.GetById(sm,  Id);
            DashProject.Entity.LIBx264EncoderConfig row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.LIBx264EncoderConfig(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}