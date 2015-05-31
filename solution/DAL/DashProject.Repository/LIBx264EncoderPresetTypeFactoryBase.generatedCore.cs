using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class LIBx264EncoderPresetTypeFactoryBase : EntityProviderBase<DashProject.Entity.LIBx264EncoderPresetType, DashProject.Entity.LIBx264EncoderPresetTypeKey>
    {
        public override List<DashProject.Entity.LIBx264EncoderPresetType> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.LIBx264EncoderPresetType> items = Data.DataProvider.Provider.LIBx264EncoderPresetTypeProvider.GetList(sm, count);
            List<DashProject.Entity.LIBx264EncoderPresetType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.LIBx264EncoderPresetType>(items.Count);

                foreach (DashProject.Data.Item.LIBx264EncoderPresetType item in items)
                {
                    DashProject.Entity.LIBx264EncoderPresetType row = new DashProject.Entity.LIBx264EncoderPresetType(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.LIBx264EncoderPresetType> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.LIBx264EncoderPresetType> items = Data.DataProvider.Provider.LIBx264EncoderPresetTypeProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.LIBx264EncoderPresetType> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.LIBx264EncoderPresetType>(items.Count);

                foreach (DashProject.Data.Item.LIBx264EncoderPresetType item in items)
                {
                    DashProject.Entity.LIBx264EncoderPresetType row = new DashProject.Entity.LIBx264EncoderPresetType(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.LIBx264EncoderPresetType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.LIBx264EncoderPresetTypeProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.LIBx264EncoderPresetType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.LIBx264EncoderPresetTypeProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.LIBx264EncoderPresetType entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.LIBx264EncoderPresetTypeProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.LIBx264EncoderPresetType GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.LIBx264EncoderPresetType GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.LIBx264EncoderPresetType item = Data.DataProvider.Provider.LIBx264EncoderPresetTypeProvider.GetById(sm,  Id);
            DashProject.Entity.LIBx264EncoderPresetType row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.LIBx264EncoderPresetType(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

              
    }
}