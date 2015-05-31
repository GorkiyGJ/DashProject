using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository.Custom
{
    public abstract class iTranscoderConfigFactoryBase : EntityReadOnlyProviderBase<DashProject.Entity.Custom.iTranscoderConfig>
    {
        public override List<DashProject.Entity.Custom.iTranscoderConfig> GetList(SessionManager sm, int count)
        {
            return null;
        }
        
        public override List<DashProject.Entity.Custom.iTranscoderConfig> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
   
    public virtual List<DashProject.Entity.Custom.iTranscoderConfig> Get_By_DashMediaId( System.Int32? DashMediaId)
    {               
return Get_By_DashMediaId(null , DashMediaId);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iTranscoderConfig> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_By_DashMediaId"));

            List<DashProject.Data.Item.Custom.iTranscoderConfig> items = Data.DataProvider.Provider.iTranscoderConfigProvider.Get_By_DashMediaId(sm, DashMediaId);
            List<DashProject.Entity.Custom.iTranscoderConfig> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iTranscoderConfig>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iTranscoderConfig item in items)
                {
                    DashProject.Entity.Custom.iTranscoderConfig row = new DashProject.Entity.Custom.iTranscoderConfig(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_By_DashMediaId", rows));

            return rows;                                     
            
   
        }
        
                     
    }
}