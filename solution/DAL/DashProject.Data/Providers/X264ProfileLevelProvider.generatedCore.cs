using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class X264ProfileLevelProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.X264ProfileLevel>
    {
        public static List<DashProject.Data.Item.X264ProfileLevel> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.X264ProfileLevel> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.X264ProfileLevel>();
            
                DashProject.Data.Item.X264ProfileLevel row = new DashProject.Data.Item.X264ProfileLevel();

                row.Id = (System.Int32)dr[((byte)X264ProfileLevelBase.X264ProfileLevelColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)X264ProfileLevelBase.X264ProfileLevelColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.X264ProfileLevel FillItem(IDataReader dr)
        {
            DashProject.Data.Item.X264ProfileLevel row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.X264ProfileLevel();
                row.Id = (System.Int32)dr[((byte)X264ProfileLevelBase.X264ProfileLevelColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)X264ProfileLevelBase.X264ProfileLevelColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.X264ProfileLevel item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.X264ProfileLevel item );        
        

   

     
        public virtual DashProject.Data.Item.X264ProfileLevel GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.X264ProfileLevel GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}