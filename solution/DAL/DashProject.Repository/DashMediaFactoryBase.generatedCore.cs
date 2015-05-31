using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class DashMediaFactoryBase : EntityProviderBase<DashProject.Entity.DashMedia, DashProject.Entity.DashMediaKey>
    {
        public override List<DashProject.Entity.DashMedia> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.DashMedia> items = Data.DataProvider.Provider.DashMediaProvider.GetList(sm, count);
            List<DashProject.Entity.DashMedia> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashMedia>(items.Count);

                foreach (DashProject.Data.Item.DashMedia item in items)
                {
                    DashProject.Entity.DashMedia row = new DashProject.Entity.DashMedia(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.DashMedia> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.DashMedia> items = Data.DataProvider.Provider.DashMediaProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.DashMedia> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.DashMedia>(items.Count);

                foreach (DashProject.Data.Item.DashMedia item in items)
                {
                    DashProject.Entity.DashMedia row = new DashProject.Entity.DashMedia(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.DashMedia entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.DashMediaProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.DashMedia entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashMediaProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.DashMedia entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.DashMediaProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.DashMedia GetById(System.Int32 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.DashMedia GetById(SessionManager sm, System.Int32 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.DashMedia item = Data.DataProvider.Provider.DashMediaProvider.GetById(sm,  Id);
            DashProject.Entity.DashMedia row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.DashMedia(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
 

 

   
    public virtual void Get_DashType_ById( System.Int32? DashMediaId, ref System.Int32? DashTypeId)
    {               
Get_DashType_ById(null , DashMediaId, ref DashTypeId);
      
    }
    
        public virtual void Get_DashType_ById(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Int32? DashTypeId)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Get_DashType_ById"));

            Data.DataProvider.Provider.DashMediaProvider.Get_DashType_ById(sm, DashMediaId, ref DashTypeId);
                       
            OnDataRequested(new EntityEventArgs(sm, "Get_DashType_ById"));                                  
            
   
        }
        
   
    public virtual void Get_MediaId_ById( System.Int32? DashMediaId, ref System.Int32? MediaId)
    {               
Get_MediaId_ById(null , DashMediaId, ref MediaId);
      
    }
    
        public virtual void Get_MediaId_ById(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Int32? MediaId)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Get_MediaId_ById"));

            Data.DataProvider.Provider.DashMediaProvider.Get_MediaId_ById(sm, DashMediaId, ref MediaId);
                       
            OnDataRequested(new EntityEventArgs(sm, "Get_MediaId_ById"));                                  
            
   
        }
        
              
    }
}