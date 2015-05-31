using System;
using System.Collections.Generic;
using System.Text;
using Manitou.Data.Provider;

namespace DashProject.Repository.Custom
{
    public abstract class iLIBx264EncoderConfigFactoryBase : EntityReadOnlyProviderBase<DashProject.Entity.Custom.iLIBx264EncoderConfig>
    {
        public override List<DashProject.Entity.Custom.iLIBx264EncoderConfig> GetList(SessionManager sm, int count)
        {
            return null;
        }
        
        public override List<DashProject.Entity.Custom.iLIBx264EncoderConfig> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
   
    public virtual List<DashProject.Entity.Custom.iLIBx264EncoderConfig> Get_By_DashMediaId( System.Int32? DashMediaId)
    {               
return Get_By_DashMediaId(null , DashMediaId);
      
    }
    
        public virtual List<DashProject.Entity.Custom.iLIBx264EncoderConfig> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId)
        {
            OnDataRequesting(new EntityReadOnlyEventArgs(sm, "Get_By_DashMediaId"));

            List<DashProject.Data.Item.Custom.iLIBx264EncoderConfig> items = Data.DataProvider.Provider.iLIBx264EncoderConfigProvider.Get_By_DashMediaId(sm, DashMediaId);
            List<DashProject.Entity.Custom.iLIBx264EncoderConfig> rows = null;
            
            if(items != null)
            {
                rows = new List<DashProject.Entity.Custom.iLIBx264EncoderConfig>(items.Count);            

                foreach (DashProject.Data.Item.Custom.iLIBx264EncoderConfig item in items)
                {
                    DashProject.Entity.Custom.iLIBx264EncoderConfig row = new DashProject.Entity.Custom.iLIBx264EncoderConfig(item);
                    rows.Add(row);
                }      
            }      
            
            OnDataRequested(new EntityReadOnlyEventArgs(sm, "Get_By_DashMediaId", rows));

            return rows;                                     
            
   
        }
        
                     
    }
}