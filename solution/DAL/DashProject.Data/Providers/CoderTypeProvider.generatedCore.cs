using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class CoderTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.CoderType>
    {
        public static List<DashProject.Data.Item.CoderType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.CoderType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.CoderType>();
            
                DashProject.Data.Item.CoderType row = new DashProject.Data.Item.CoderType();

                row.Id = (System.Int32)dr[((byte)CoderTypeBase.CoderTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)CoderTypeBase.CoderTypeColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.CoderType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.CoderType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.CoderType();
                row.Id = (System.Int32)dr[((byte)CoderTypeBase.CoderTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)CoderTypeBase.CoderTypeColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.CoderType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.CoderType item );        
        

   

     
        public virtual DashProject.Data.Item.CoderType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.CoderType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}