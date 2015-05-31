using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class VideoSizeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.VideoSize>
    {
        public static List<DashProject.Data.Item.VideoSize> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.VideoSize> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.VideoSize>();
            
                DashProject.Data.Item.VideoSize row = new DashProject.Data.Item.VideoSize();

                row.Id = (System.Int32)dr[((byte)VideoSizeBase.VideoSizeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)VideoSizeBase.VideoSizeColumn.Name - 1)];
                row.Width = (System.Int16)dr[((byte)VideoSizeBase.VideoSizeColumn.Width - 1)];
                row.Height = (System.Int16)dr[((byte)VideoSizeBase.VideoSizeColumn.Height - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.VideoSize FillItem(IDataReader dr)
        {
            DashProject.Data.Item.VideoSize row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.VideoSize();
                row.Id = (System.Int32)dr[((byte)VideoSizeBase.VideoSizeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)VideoSizeBase.VideoSizeColumn.Name - 1)];
                row.Width = (System.Int16)dr[((byte)VideoSizeBase.VideoSizeColumn.Width - 1)];
                row.Height = (System.Int16)dr[((byte)VideoSizeBase.VideoSizeColumn.Height - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.VideoSize item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.VideoSize item );        
        

   

     
        public virtual DashProject.Data.Item.VideoSize GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.VideoSize GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}