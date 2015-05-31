using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository.Custom
{
    public abstract class iMediaInfoFactoryBase : EntityReadOnlyProviderBase<DashProject.Entity.Custom.iMediaInfo>
    {
        public override List<DashProject.Entity.Custom.iMediaInfo> GetList(SessionManager sm, int count)
        {
            return null;
        }
        
        public override List<DashProject.Entity.Custom.iMediaInfo> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
   
    public virtual List<DashProject.Entity.Custom.iMediaInfo> Get_By_MediaId( System.Int32? MediaId)
    {               
return Get_By_MediaId(null , MediaId);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iMediaInfo> Get_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_By_MediaId"));

            List<DashProject.Data.Item.Custom.iMediaInfo> items = Data.DataProvider.Provider.iMediaInfoProvider.Get_By_MediaId(sm, MediaId);
            List<DashProject.Entity.Custom.iMediaInfo> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iMediaInfo>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iMediaInfo item in items)
                {
                    DashProject.Entity.Custom.iMediaInfo row = new DashProject.Entity.Custom.iMediaInfo(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_By_MediaId", rows));

            return rows;                                     
            
   
        }
        
   
    public virtual List<DashProject.Entity.Custom.iMediaInfo> Get()
    {               
return Get(null );
      
    }
    
        public virtual List<DashProject.Entity.Custom.iMediaInfo> Get(Manitou.Data.Provider.SessionManager sm )
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get"));

            List<DashProject.Data.Item.Custom.iMediaInfo> items = Data.DataProvider.Provider.iMediaInfoProvider.Get(sm);
            List<DashProject.Entity.Custom.iMediaInfo> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iMediaInfo>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iMediaInfo item in items)
                {
                    DashProject.Entity.Custom.iMediaInfo row = new DashProject.Entity.Custom.iMediaInfo(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get", rows));

            return rows;                                     
            
   
        }
        
                     
    }
}