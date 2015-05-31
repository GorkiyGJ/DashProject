using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class AACTranscoderConfigProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.AACTranscoderConfig>
    {
        public static List<DashProject.Data.Item.AACTranscoderConfig> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.AACTranscoderConfig> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.AACTranscoderConfig>();
            
                DashProject.Data.Item.AACTranscoderConfig row = new DashProject.Data.Item.AACTranscoderConfig();

                row.Id = (System.Int32)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.Id - 1)];
                row.BitrateKbps = (dr.IsDBNull(((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.BitrateKbps - 1))) ? null : (System.Int32?)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.BitrateKbps - 1)];
                row.IsUseConstrainedBitRate = (dr.IsDBNull(((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.IsUseConstrainedBitRate - 1))) ? null : (System.Boolean?)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.IsUseConstrainedBitRate - 1)];
                row.Channels = (dr.IsDBNull(((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.Channels - 1))) ? null : (System.Byte?)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.Channels - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.AACTranscoderConfig FillItem(IDataReader dr)
        {
            DashProject.Data.Item.AACTranscoderConfig row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.AACTranscoderConfig();
                row.Id = (System.Int32)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.Id - 1)];
                row.BitrateKbps = (dr.IsDBNull(((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.BitrateKbps - 1))) ? null : (System.Int32?)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.BitrateKbps - 1)];
                row.IsUseConstrainedBitRate = (dr.IsDBNull(((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.IsUseConstrainedBitRate - 1))) ? null : (System.Boolean?)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.IsUseConstrainedBitRate - 1)];
                row.Channels = (dr.IsDBNull(((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.Channels - 1))) ? null : (System.Byte?)dr[((byte)AACTranscoderConfigBase.AACTranscoderConfigColumn.Channels - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.AACTranscoderConfig item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.AACTranscoderConfig item );        
        

   

     
        public virtual DashProject.Data.Item.AACTranscoderConfig GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.AACTranscoderConfig GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}