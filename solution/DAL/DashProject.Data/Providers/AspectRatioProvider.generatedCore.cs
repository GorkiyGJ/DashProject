using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class AspectRatioProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.AspectRatio>
    {
        public static List<DashProject.Data.Item.AspectRatio> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.AspectRatio> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.AspectRatio>();
            
                DashProject.Data.Item.AspectRatio row = new DashProject.Data.Item.AspectRatio();

                row.Id = (System.Int32)dr[((byte)AspectRatioBase.AspectRatioColumn.Id - 1)];
                row.Type1 = (dr.IsDBNull(((byte)AspectRatioBase.AspectRatioColumn.Type1 - 1))) ? null : (System.String)dr[((byte)AspectRatioBase.AspectRatioColumn.Type1 - 1)];
                row.Type2 = (dr.IsDBNull(((byte)AspectRatioBase.AspectRatioColumn.Type2 - 1))) ? null : (System.Double?)dr[((byte)AspectRatioBase.AspectRatioColumn.Type2 - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.AspectRatio FillItem(IDataReader dr)
        {
            DashProject.Data.Item.AspectRatio row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.AspectRatio();
                row.Id = (System.Int32)dr[((byte)AspectRatioBase.AspectRatioColumn.Id - 1)];
                row.Type1 = (dr.IsDBNull(((byte)AspectRatioBase.AspectRatioColumn.Type1 - 1))) ? null : (System.String)dr[((byte)AspectRatioBase.AspectRatioColumn.Type1 - 1)];
                row.Type2 = (dr.IsDBNull(((byte)AspectRatioBase.AspectRatioColumn.Type2 - 1))) ? null : (System.Double?)dr[((byte)AspectRatioBase.AspectRatioColumn.Type2 - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.AspectRatio item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.AspectRatio item );        
        

   

     
        public virtual DashProject.Data.Item.AspectRatio GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.AspectRatio GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}