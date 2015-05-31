using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class LIBx264EncoderPresetTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.LIBx264EncoderPresetType>
    {
        public static List<DashProject.Data.Item.LIBx264EncoderPresetType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.LIBx264EncoderPresetType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.LIBx264EncoderPresetType>();
            
                DashProject.Data.Item.LIBx264EncoderPresetType row = new DashProject.Data.Item.LIBx264EncoderPresetType();

                row.Id = (System.Int32)dr[((byte)LIBx264EncoderPresetTypeBase.LIBx264EncoderPresetTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)LIBx264EncoderPresetTypeBase.LIBx264EncoderPresetTypeColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.LIBx264EncoderPresetType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.LIBx264EncoderPresetType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.LIBx264EncoderPresetType();
                row.Id = (System.Int32)dr[((byte)LIBx264EncoderPresetTypeBase.LIBx264EncoderPresetTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)LIBx264EncoderPresetTypeBase.LIBx264EncoderPresetTypeColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.LIBx264EncoderPresetType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.LIBx264EncoderPresetType item );        
        

   

     
        public virtual DashProject.Data.Item.LIBx264EncoderPresetType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.LIBx264EncoderPresetType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}