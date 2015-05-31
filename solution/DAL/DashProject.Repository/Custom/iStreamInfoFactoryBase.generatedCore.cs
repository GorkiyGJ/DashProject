using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository.Custom
{
    public abstract class iStreamInfoFactoryBase : EntityReadOnlyProviderBase<DashProject.Entity.Custom.iStreamInfo>
    {
        public override List<DashProject.Entity.Custom.iStreamInfo> GetList(SessionManager sm, int count)
        {
            return null;
        }
        
        public override List<DashProject.Entity.Custom.iStreamInfo> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
   
    public virtual List<DashProject.Entity.Custom.iStreamInfo> Get_By_MediaId_StreamIndex( System.Int32? MediaId,  System.Int32? StreamIndex)
    {               
return Get_By_MediaId_StreamIndex(null , MediaId, StreamIndex);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iStreamInfo> Get_By_MediaId_StreamIndex(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId, System.Int32? StreamIndex)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_By_MediaId_StreamIndex"));

            List<DashProject.Data.Item.Custom.iStreamInfo> items = Data.DataProvider.Provider.iStreamInfoProvider.Get_By_MediaId_StreamIndex(sm, MediaId, StreamIndex);
            List<DashProject.Entity.Custom.iStreamInfo> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iStreamInfo>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iStreamInfo item in items)
                {
                    DashProject.Entity.Custom.iStreamInfo row = new DashProject.Entity.Custom.iStreamInfo(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_By_MediaId_StreamIndex", rows));

            return rows;                                     
            
   
        }
        
                     
    }
}