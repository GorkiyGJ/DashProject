using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iMediaInfoProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iMediaInfo>
    {
        public static List<DashProject.Data.Item.Custom.iMediaInfo> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iMediaInfo> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iMediaInfo>();
                    
                DashProject.Data.Item.Custom.iMediaInfo row = new DashProject.Data.Item.Custom.iMediaInfo();

                row.MediaId = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.MediaId))) ? null : (System.Int32?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.MediaId)];
                row.ProgramIndex = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.ProgramIndex))) ? null : (System.Byte?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.ProgramIndex)];
                row.RawMediaId = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaId))) ? null : (System.Int32?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaId)];
                row.RawMediaSourceTypeId = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaSourceTypeId))) ? null : (System.Byte?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaSourceTypeId)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iMediaInfo FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iMediaInfo row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iMediaInfo();
                row.MediaId = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.MediaId))) ? null : (System.Int32?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.MediaId)];
                row.ProgramIndex = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.ProgramIndex))) ? null : (System.Byte?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.ProgramIndex)];
                row.RawMediaId = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaId))) ? null : (System.Int32?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaId)];
                row.RawMediaSourceTypeId = (dr.IsDBNull(((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaSourceTypeId))) ? null : (System.Byte?)dr[((byte)iMediaInfoBase.iMediaInfoColumn.RawMediaSourceTypeId)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iMediaInfo> Get_By_MediaId(ref System.Int32? MediaId)
    {               
return Get_By_MediaId(null , MediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iMediaInfo> Get_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId);
        
   
    public virtual List<DashProject.Data.Item.Custom.iMediaInfo> Get()
    {               
return Get(null );
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iMediaInfo> Get(Manitou.Data.Provider.SessionManager sm );
        
        
    }                       
}