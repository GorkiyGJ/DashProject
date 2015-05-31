using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class X264ProfileProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.X264Profile>
    {
        public static List<DashProject.Data.Item.X264Profile> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.X264Profile> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.X264Profile>();
            
                DashProject.Data.Item.X264Profile row = new DashProject.Data.Item.X264Profile();

                row.Id = (System.Int32)dr[((byte)X264ProfileBase.X264ProfileColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)X264ProfileBase.X264ProfileColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.X264Profile FillItem(IDataReader dr)
        {
            DashProject.Data.Item.X264Profile row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.X264Profile();
                row.Id = (System.Int32)dr[((byte)X264ProfileBase.X264ProfileColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)X264ProfileBase.X264ProfileColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.X264Profile item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.X264Profile item );        
        

   

     
        public virtual DashProject.Data.Item.X264Profile GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.X264Profile GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}