using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iDashMediaInfoProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iDashMediaInfo>
    {
        public static List<DashProject.Data.Item.Custom.iDashMediaInfo> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iDashMediaInfo> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iDashMediaInfo>();
                    
                DashProject.Data.Item.Custom.iDashMediaInfo row = new DashProject.Data.Item.Custom.iDashMediaInfo();

                row.Id = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.Id))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.Id)];
                row.DashTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iDashMediaInfo FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iDashMediaInfo row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iDashMediaInfo();
                row.Id = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.Id))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.Id)];
                row.DashTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_MainDashMediaId(ref System.Int32? DashMediaId)
    {               
return Get_By_MainDashMediaId(null , DashMediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_MainDashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId);
        
   
    public virtual List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_IsMain_By_MediaId(ref System.Int32? MediaId)
    {               
return Get_IsMain_By_MediaId(null , MediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_IsMain_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId);
        
        
    }                       
}