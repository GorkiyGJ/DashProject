using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class AACTranscoderConfigFactoryBase : EntityProviderBase<DashProject.Entity.AACTranscoderConfig, DashProject.Entity.AACTranscoderConfigKey>
    {
        public override List<DashProject.Entity.AACTranscoderConfig> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.AACTranscoderConfig> items = Data.DataProvider.Provider.AACTranscoderConfigProvider.GetList(sm, count);
            List<DashProject.Entity.AACTranscoderConfig> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.AACTranscoderConfig>(items.Count);

                foreach (DashProject.Data.Item.AACTranscoderConfig item in items)
                {
                    DashProject.Entity.AACTranscoderConfig row = new DashProject.Entity.AACTranscoderConfig(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.AACTranscoderConfig> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.AACTranscoderConfig> items = Data.DataProvider.Provider.AACTranscoderConfigProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.AACTranscoderConfig> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.AACTranscoderConfig>(items.Count);

                foreach (DashProject.Data.Item.AACTranscoderConfig item in items)
                {
                    DashProject.Entity.AACTranscoderConfig row = new DashProject.Entity.AACTranscoderConfig(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.AACTranscoderConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.AACTranscoderConfigProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.AACTranscoderConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.AACTranscoderConfigProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.AACTranscoderConfig entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.AACTranscoderConfigProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.AACTranscoderConfig GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.AACTranscoderConfig GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.AACTranscoderConfig item = Data.DataProvider.Provider.AACTranscoderConfigProvider.GetById(sm,  Id);
            DashProject.Entity.AACTranscoderConfig row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.AACTranscoderConfig(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}