using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class ScaleVideoFilterProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.ScaleVideoFilter>
    {
        public static List<DashProject.Data.Item.ScaleVideoFilter> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.ScaleVideoFilter> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.ScaleVideoFilter>();
            
                DashProject.Data.Item.ScaleVideoFilter row = new DashProject.Data.Item.ScaleVideoFilter();

                row.Id = (System.Int32)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.Id - 1)];
                row.DashMediaId = (System.Int32)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.DashMediaId - 1)];
                row.Width = (System.Int16)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.Width - 1)];
                row.Height = (System.Int16)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.Height - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.ScaleVideoFilter FillItem(IDataReader dr)
        {
            DashProject.Data.Item.ScaleVideoFilter row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.ScaleVideoFilter();
                row.Id = (System.Int32)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.Id - 1)];
                row.DashMediaId = (System.Int32)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.DashMediaId - 1)];
                row.Width = (System.Int16)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.Width - 1)];
                row.Height = (System.Int16)dr[((byte)ScaleVideoFilterBase.ScaleVideoFilterColumn.Height - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.ScaleVideoFilter item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.ScaleVideoFilter item );        
        

   

     
        public virtual DashProject.Data.Item.ScaleVideoFilter GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.ScaleVideoFilter GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}