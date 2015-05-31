using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository
{
    public abstract class RawSegmentStreamFactoryBase : EntityProviderBase<DashProject.Entity.RawSegmentStream, DashProject.Entity.RawSegmentStreamKey>
    {
        public override List<DashProject.Entity.RawSegmentStream> GetList(SessionManager sm, int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetList"));

            List<DashProject.Data.Item.RawSegmentStream> items = Data.DataProvider.Provider.RawSegmentStreamProvider.GetList(sm, count);
            List<DashProject.Entity.RawSegmentStream> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.RawSegmentStream>(items.Count);

                foreach (DashProject.Data.Item.RawSegmentStream item in items)
                {
                    DashProject.Entity.RawSegmentStream row = new DashProject.Entity.RawSegmentStream(item);
                    rows.Add(row);
                }                                        
            }

            OnDataRequested(new EntityEventArgs(sm, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Entity.RawSegmentStream> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetPaged"));

            List<DashProject.Data.Item.RawSegmentStream> items = Data.DataProvider.Provider.RawSegmentStreamProvider.GetPaged(sm, whereClause, orderBy, pageIndex, pageSize, out count);
            List<DashProject.Entity.RawSegmentStream> rows = null;
            if(items != null)
            {                            
                rows = new List<DashProject.Entity.RawSegmentStream>(items.Count);

                foreach (DashProject.Data.Item.RawSegmentStream item in items)
                {
                    DashProject.Entity.RawSegmentStream row = new DashProject.Entity.RawSegmentStream(item);
                    rows.Add(row);
                }            
            }

            OnDataRequested(new EntityEventArgs(sm, "GetPaged", rows));

            return rows;
        }

        public override bool Insert(SessionManager sm, DashProject.Entity.RawSegmentStream entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Insert"));
        
            bool isOk = DashProject.Data.DataProvider.Provider.RawSegmentStreamProvider.Insert(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Insert", entity.DataItem));

            return isOk;
        }
        
        

        public override bool Update(SessionManager sm, DashProject.Entity.RawSegmentStream entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Update"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.RawSegmentStreamProvider.Update(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Update", entity.DataItem));

            return isOk;
        }

        public override bool Delete(SessionManager sm, DashProject.Entity.RawSegmentStream entity)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Delete"));
            
            bool isOk = DashProject.Data.DataProvider.Provider.RawSegmentStreamProvider.Delete(sm, entity.DataItem);
            entity.AcceptChanges();
            
            OnDataRequested(new EntityEventArgs(sm, "Delete", entity.DataItem));

            return isOk;
        }                
        
       

  

            
        public virtual DashProject.Entity.RawSegmentStream GetById(System.Int64 Id)
        {
            return GetById(null,  Id);
        }

        public virtual DashProject.Entity.RawSegmentStream GetById(SessionManager sm, System.Int64 Id)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetById"));

            DashProject.Data.Item.RawSegmentStream item = Data.DataProvider.Provider.RawSegmentStreamProvider.GetById(sm,  Id);
            DashProject.Entity.RawSegmentStream row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.RawSegmentStream(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetById", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetById"));

            return row;
        }  
            
        public virtual DashProject.Entity.RawSegmentStream GetByIdMediaIdSegmentIdStreamIdFileName(System.Int64 Id, System.Int32 MediaId, System.Int64 SegmentId, System.Int32 StreamId, System.String FileName)
        {
            return GetByIdMediaIdSegmentIdStreamIdFileName(null,  Id,  MediaId,  SegmentId,  StreamId,  FileName);
        }

        public virtual DashProject.Entity.RawSegmentStream GetByIdMediaIdSegmentIdStreamIdFileName(SessionManager sm, System.Int64 Id, System.Int32 MediaId, System.Int64 SegmentId, System.Int32 StreamId, System.String FileName)
        {
            OnDataRequesting(new EntityEventArgs(sm, "GetByIdMediaIdSegmentIdStreamIdFileName"));

            DashProject.Data.Item.RawSegmentStream item = Data.DataProvider.Provider.RawSegmentStreamProvider.GetByIdMediaIdSegmentIdStreamIdFileName(sm,  Id,  MediaId,  SegmentId,  StreamId,  FileName);
            DashProject.Entity.RawSegmentStream row = null;
            
            if(item != null)
            {
                row = new DashProject.Entity.RawSegmentStream(item);            

                OnDataRequested(new EntityEventArgs(sm, "GetByIdMediaIdSegmentIdStreamIdFileName", row.DataItem));
            }else
                OnDataRequested(new EntityEventArgs(sm, "GetByIdMediaIdSegmentIdStreamIdFileName"));

            return row;
        }  
 

 

   
    public virtual void Get_GlobalEndTimeS_By_DashMediaId( System.Int32? DashMediaId, ref System.Decimal? GlobalEndTimeS)
    {               
Get_GlobalEndTimeS_By_DashMediaId(null , DashMediaId, ref GlobalEndTimeS);
      
    }
    
        public virtual void Get_GlobalEndTimeS_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Decimal? GlobalEndTimeS)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Get_GlobalEndTimeS_By_DashMediaId"));

            Data.DataProvider.Provider.RawSegmentStreamProvider.Get_GlobalEndTimeS_By_DashMediaId(sm, DashMediaId, ref GlobalEndTimeS);
                       
            OnDataRequested(new EntityEventArgs(sm, "Get_GlobalEndTimeS_By_DashMediaId"));                                  
            
   
        }
        
   
    public virtual void Get_GlobalStartTimeS_By_DashMediaId( System.Int32? DashMediaId, ref System.Decimal? GlobalStartTimeS)
    {               
Get_GlobalStartTimeS_By_DashMediaId(null , DashMediaId, ref GlobalStartTimeS);
      
    }
    
        public virtual void Get_GlobalStartTimeS_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Decimal? GlobalStartTimeS)
        {
            OnDataRequesting(new EntityEventArgs(sm, "Get_GlobalStartTimeS_By_DashMediaId"));

            Data.DataProvider.Provider.RawSegmentStreamProvider.Get_GlobalStartTimeS_By_DashMediaId(sm, DashMediaId, ref GlobalStartTimeS);
                       
            OnDataRequested(new EntityEventArgs(sm, "Get_GlobalStartTimeS_By_DashMediaId"));                                  
            
   
        }
        
              
    }
}