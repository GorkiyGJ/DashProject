using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iLIBx264EncoderConfigProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iLIBx264EncoderConfig>
    {
        public static List<DashProject.Data.Item.Custom.iLIBx264EncoderConfig> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iLIBx264EncoderConfig> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iLIBx264EncoderConfig>();
                    
                DashProject.Data.Item.Custom.iLIBx264EncoderConfig row = new DashProject.Data.Item.Custom.iLIBx264EncoderConfig();

                row.DashMediaId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.DashMediaId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.DashMediaId)];
                row.ThreadsCount = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ThreadsCount))) ? null : (System.Byte?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ThreadsCount)];
                row.BitrateKbps = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.BitrateKbps))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.BitrateKbps)];
                row.LIBx264EncoderPresetTypeId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.LIBx264EncoderPresetTypeId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.LIBx264EncoderPresetTypeId)];
                row.X264ProfileId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileId)];
                row.X264ProfileLevelId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileLevelId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileLevelId)];
                row.IsUseConstantBitRate = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantBitRate))) ? null : (System.Boolean?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantBitRate)];
                row.IsUseConstantRateFactorForQualityManagement = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantRateFactorForQualityManagement))) ? null : (System.Boolean?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantRateFactorForQualityManagement)];
                row.ConstantRateFactor = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ConstantRateFactor))) ? null : (System.Byte?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ConstantRateFactor)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iLIBx264EncoderConfig FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iLIBx264EncoderConfig row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iLIBx264EncoderConfig();
                row.DashMediaId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.DashMediaId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.DashMediaId)];
                row.ThreadsCount = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ThreadsCount))) ? null : (System.Byte?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ThreadsCount)];
                row.BitrateKbps = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.BitrateKbps))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.BitrateKbps)];
                row.LIBx264EncoderPresetTypeId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.LIBx264EncoderPresetTypeId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.LIBx264EncoderPresetTypeId)];
                row.X264ProfileId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileId)];
                row.X264ProfileLevelId = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileLevelId))) ? null : (System.Int32?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.X264ProfileLevelId)];
                row.IsUseConstantBitRate = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantBitRate))) ? null : (System.Boolean?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantBitRate)];
                row.IsUseConstantRateFactorForQualityManagement = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantRateFactorForQualityManagement))) ? null : (System.Boolean?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.IsUseConstantRateFactorForQualityManagement)];
                row.ConstantRateFactor = (dr.IsDBNull(((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ConstantRateFactor))) ? null : (System.Byte?)dr[((byte)iLIBx264EncoderConfigBase.iLIBx264EncoderConfigColumn.ConstantRateFactor)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iLIBx264EncoderConfig> Get_By_DashMediaId(ref System.Int32? DashMediaId)
    {               
return Get_By_DashMediaId(null , DashMediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iLIBx264EncoderConfig> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId);
        
        
    }                       
}