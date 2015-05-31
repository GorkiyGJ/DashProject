using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iStreamInfoProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iStreamInfo>
    {
        public static List<DashProject.Data.Item.Custom.iStreamInfo> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iStreamInfo> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iStreamInfo>();
                    
                DashProject.Data.Item.Custom.iStreamInfo row = new DashProject.Data.Item.Custom.iStreamInfo();

                row.Id = (dr.IsDBNull(((byte)iStreamInfoBase.iStreamInfoColumn.Id))) ? null : (System.Int32?)dr[((byte)iStreamInfoBase.iStreamInfoColumn.Id)];
                row.Index = (dr.IsDBNull(((byte)iStreamInfoBase.iStreamInfoColumn.Index))) ? null : (System.Byte?)dr[((byte)iStreamInfoBase.iStreamInfoColumn.Index)];
                row.GlobalEndTimeS = (dr.IsDBNull(((byte)iStreamInfoBase.iStreamInfoColumn.GlobalEndTimeS))) ? null : (System.Decimal?)dr[((byte)iStreamInfoBase.iStreamInfoColumn.GlobalEndTimeS)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iStreamInfo FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iStreamInfo row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iStreamInfo();
                row.Id = (dr.IsDBNull(((byte)iStreamInfoBase.iStreamInfoColumn.Id))) ? null : (System.Int32?)dr[((byte)iStreamInfoBase.iStreamInfoColumn.Id)];
                row.Index = (dr.IsDBNull(((byte)iStreamInfoBase.iStreamInfoColumn.Index))) ? null : (System.Byte?)dr[((byte)iStreamInfoBase.iStreamInfoColumn.Index)];
                row.GlobalEndTimeS = (dr.IsDBNull(((byte)iStreamInfoBase.iStreamInfoColumn.GlobalEndTimeS))) ? null : (System.Decimal?)dr[((byte)iStreamInfoBase.iStreamInfoColumn.GlobalEndTimeS)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iStreamInfo> Get_By_MediaId_StreamIndex(ref System.Int32? MediaId, ref System.Int32? StreamIndex)
    {               
return Get_By_MediaId_StreamIndex(null , MediaId, StreamIndex);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iStreamInfo> Get_By_MediaId_StreamIndex(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId, System.Int32? StreamIndex);
        
        
    }                       
}