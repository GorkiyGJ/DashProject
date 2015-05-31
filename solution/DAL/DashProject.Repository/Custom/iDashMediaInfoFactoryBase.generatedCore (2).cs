using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository.Custom
{
    public abstract class iDashMediaInfoFactoryBase : EntityReadOnlyProviderBase<DashProject.Entity.Custom.iDashMediaInfo>
    {
        public override List<DashProject.Entity.Custom.iDashMediaInfo> GetList(SessionManager sm, int count)
        {
            return null;
        }
        
        public override List<DashProject.Entity.Custom.iDashMediaInfo> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
   
    public virtual List<DashProject.Entity.Custom.iDashMediaInfo> Get_By_MainDashMediaId( System.Int32? DashMediaId)
    {               
return Get_By_MainDashMediaId(null , DashMediaId);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iDashMediaInfo> Get_By_MainDashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_By_MainDashMediaId"));

            List<DashProject.Data.Item.Custom.iDashMediaInfo> items = Data.DataProvider.Provider.iDashMediaInfoProvider.Get_By_MainDashMediaId(sm, DashMediaId);
            List<DashProject.Entity.Custom.iDashMediaInfo> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iDashMediaInfo>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iDashMediaInfo item in items)
                {
                    DashProject.Entity.Custom.iDashMediaInfo row = new DashProject.Entity.Custom.iDashMediaInfo(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_By_MainDashMediaId", rows));

            return rows;                                     
            
   
        }
        
   
    public virtual List<DashProject.Entity.Custom.iDashMediaInfo> Get_IsMain_By_MediaId( System.Int32? MediaId)
    {               
return Get_IsMain_By_MediaId(null , MediaId);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iDashMediaInfo> Get_IsMain_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_IsMain_By_MediaId"));

            List<DashProject.Data.Item.Custom.iDashMediaInfo> items = Data.DataProvider.Provider.iDashMediaInfoProvider.Get_IsMain_By_MediaId(sm, MediaId);
            List<DashProject.Entity.Custom.iDashMediaInfo> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iDashMediaInfo>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iDashMediaInfo item in items)
                {
                    DashProject.Entity.Custom.iDashMediaInfo row = new DashProject.Entity.Custom.iDashMediaInfo(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_IsMain_By_MediaId", rows));

            return rows;                                     
            
   
        }
        
                     
    }
}