using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository.Custom
{
    public abstract class iSegmenterConfigFactoryBase : EntityReadOnlyProviderBase<DashProject.Entity.Custom.iSegmenterConfig>
    {
        public override List<DashProject.Entity.Custom.iSegmenterConfig> GetList(SessionManager sm, int count)
        {
            return null;
        }
        
        public override List<DashProject.Entity.Custom.iSegmenterConfig> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
   
    public virtual List<DashProject.Entity.Custom.iSegmenterConfig> Get_By_MediaId( System.Int32? MediaId)
    {               
return Get_By_MediaId(null , MediaId);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iSegmenterConfig> Get_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_By_MediaId"));

            List<DashProject.Data.Item.Custom.iSegmenterConfig> items = Data.DataProvider.Provider.iSegmenterConfigProvider.Get_By_MediaId(sm, MediaId);
            List<DashProject.Entity.Custom.iSegmenterConfig> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iSegmenterConfig>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iSegmenterConfig item in items)
                {
                    DashProject.Entity.Custom.iSegmenterConfig row = new DashProject.Entity.Custom.iSegmenterConfig(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_By_MediaId", rows));

            return rows;                                     
            
   
        }
        
                     
    }
}