using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class RawMediaProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.RawMedia>
    {
        public static List<DashProject.Data.Item.RawMedia> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.RawMedia> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.RawMedia>();
            
                DashProject.Data.Item.RawMedia row = new DashProject.Data.Item.RawMedia();

                row.Id = (System.Int32)dr[((byte)RawMediaBase.RawMediaColumn.Id - 1)];
                row.ContainerTypeId = (System.Int32)dr[((byte)RawMediaBase.RawMediaColumn.ContainerTypeId - 1)];
                row.InputMedia = (System.String)dr[((byte)RawMediaBase.RawMediaColumn.InputMedia - 1)];
                row.RawMediaSourceTypeId = (System.Byte)dr[((byte)RawMediaBase.RawMediaColumn.RawMediaSourceTypeId - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.RawMedia FillItem(IDataReader dr)
        {
            DashProject.Data.Item.RawMedia row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.RawMedia();
                row.Id = (System.Int32)dr[((byte)RawMediaBase.RawMediaColumn.Id - 1)];
                row.ContainerTypeId = (System.Int32)dr[((byte)RawMediaBase.RawMediaColumn.ContainerTypeId - 1)];
                row.InputMedia = (System.String)dr[((byte)RawMediaBase.RawMediaColumn.InputMedia - 1)];
                row.RawMediaSourceTypeId = (System.Byte)dr[((byte)RawMediaBase.RawMediaColumn.RawMediaSourceTypeId - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.RawMedia item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.RawMedia item );        
        

   

     
        public virtual DashProject.Data.Item.RawMedia GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.RawMedia GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}