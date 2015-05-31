using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iTranscoderConfigProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iTranscoderConfig>
    {
        public static List<DashProject.Data.Item.Custom.iTranscoderConfig> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iTranscoderConfig> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iTranscoderConfig>();
                    
                DashProject.Data.Item.Custom.iTranscoderConfig row = new DashProject.Data.Item.Custom.iTranscoderConfig();

                row.DashMediaCodecId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.DashMediaCodecId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.DashMediaCodecId)];
                row.RawMediaCodecId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.RawMediaCodecId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.RawMediaCodecId)];
                row.StreamIndex = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamIndex))) ? null : (System.Byte?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamIndex)];
                row.StreamTypeId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamTypeId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamTypeId)];
                row.InputContainerId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.InputContainerId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.InputContainerId)];
                row.OutputContainerId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.OutputContainerId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.OutputContainerId)];
                row.ProgramIndex = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.ProgramIndex))) ? null : (System.Byte?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.ProgramIndex)];
                row.FragmentDurationS = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.FragmentDurationS))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.FragmentDurationS)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iTranscoderConfig FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iTranscoderConfig row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iTranscoderConfig();
                row.DashMediaCodecId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.DashMediaCodecId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.DashMediaCodecId)];
                row.RawMediaCodecId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.RawMediaCodecId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.RawMediaCodecId)];
                row.StreamIndex = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamIndex))) ? null : (System.Byte?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamIndex)];
                row.StreamTypeId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamTypeId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.StreamTypeId)];
                row.InputContainerId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.InputContainerId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.InputContainerId)];
                row.OutputContainerId = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.OutputContainerId))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.OutputContainerId)];
                row.ProgramIndex = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.ProgramIndex))) ? null : (System.Byte?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.ProgramIndex)];
                row.FragmentDurationS = (dr.IsDBNull(((byte)iTranscoderConfigBase.iTranscoderConfigColumn.FragmentDurationS))) ? null : (System.Int32?)dr[((byte)iTranscoderConfigBase.iTranscoderConfigColumn.FragmentDurationS)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iTranscoderConfig> Get_By_DashMediaId(ref System.Int32? DashMediaId)
    {               
return Get_By_DashMediaId(null , DashMediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iTranscoderConfig> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId);
        
        
    }                       
}