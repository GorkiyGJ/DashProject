using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class LIBx264EncoderConfigProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.LIBx264EncoderConfig>
    {
        public static List<DashProject.Data.Item.LIBx264EncoderConfig> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.LIBx264EncoderConfig> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.LIBx264EncoderConfig>();
            
                DashProject.Data.Item.LIBx264EncoderConfig row = new DashProject.Data.Item.LIBx264EncoderConfig();

                row.Id = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.Id - 1)];
                row.DashMediaId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.DashMediaId - 1)];
                row.LIBx264EncoderPresetTypeId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.LIBx264EncoderPresetTypeId - 1)];
                row.X264ProfileId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.X264ProfileId - 1)];
                row.X264ProfileLevelId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.X264ProfileLevelId - 1)];
                row.ThreadsCount = (System.Byte)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.ThreadsCount - 1)];
                row.BitrateKbps = (dr.IsDBNull(((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.BitrateKbps - 1))) ? null : (System.Int32?)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.BitrateKbps - 1)];
                row.IsUseConstantBitRate = (System.Boolean)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.IsUseConstantBitRate - 1)];
                row.ConstantRateFactor = (System.Byte)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.ConstantRateFactor - 1)];
                row.isUseConstantRateFactorForQualityManagement = (System.Boolean)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.isUseConstantRateFactorForQualityManagement - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.LIBx264EncoderConfig FillItem(IDataReader dr)
        {
            DashProject.Data.Item.LIBx264EncoderConfig row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.LIBx264EncoderConfig();
                row.Id = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.Id - 1)];
                row.DashMediaId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.DashMediaId - 1)];
                row.LIBx264EncoderPresetTypeId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.LIBx264EncoderPresetTypeId - 1)];
                row.X264ProfileId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.X264ProfileId - 1)];
                row.X264ProfileLevelId = (System.Int32)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.X264ProfileLevelId - 1)];
                row.ThreadsCount = (System.Byte)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.ThreadsCount - 1)];
                row.BitrateKbps = (dr.IsDBNull(((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.BitrateKbps - 1))) ? null : (System.Int32?)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.BitrateKbps - 1)];
                row.IsUseConstantBitRate = (System.Boolean)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.IsUseConstantBitRate - 1)];
                row.ConstantRateFactor = (System.Byte)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.ConstantRateFactor - 1)];
                row.isUseConstantRateFactorForQualityManagement = (System.Boolean)dr[((byte)LIBx264EncoderConfigBase.LIBx264EncoderConfigColumn.isUseConstantRateFactorForQualityManagement - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.LIBx264EncoderConfig item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.LIBx264EncoderConfig item );        
        

   

     
        public virtual DashProject.Data.Item.LIBx264EncoderConfig GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.LIBx264EncoderConfig GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}