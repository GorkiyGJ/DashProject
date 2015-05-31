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

                row.DashMediaId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashMediaId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashMediaId)];
                row.DashTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId)];
                row.DashContainerTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashContainerTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashContainerTypeId)];
                row.CodecTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.CodecTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.CodecTypeId)];
                row.MediaId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.MediaId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.MediaId)];

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
                row.DashMediaId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashMediaId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashMediaId)];
                row.DashTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashTypeId)];
                row.DashContainerTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashContainerTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.DashContainerTypeId)];
                row.CodecTypeId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.CodecTypeId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.CodecTypeId)];
                row.MediaId = (dr.IsDBNull(((byte)iDashMediaInfoBase.iDashMediaInfoColumn.MediaId))) ? null : (System.Int32?)dr[((byte)iDashMediaInfoBase.iDashMediaInfoColumn.MediaId)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_DashMediaId(ref System.Int32? DashMediaId)
    {               
return Get_By_DashMediaId(null , DashMediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId);
        
   
    public virtual List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_MediaId(ref System.Int32? MediaId)
    {               
return Get_By_MediaId(null , MediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId);
        
        
    }                       
}