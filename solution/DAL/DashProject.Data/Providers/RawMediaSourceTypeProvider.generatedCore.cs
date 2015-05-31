using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class RawMediaSourceTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.RawMediaSourceType>
    {
        public static List<DashProject.Data.Item.RawMediaSourceType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.RawMediaSourceType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.RawMediaSourceType>();
            
                DashProject.Data.Item.RawMediaSourceType row = new DashProject.Data.Item.RawMediaSourceType();

                row.Id = (System.Byte)dr[((byte)RawMediaSourceTypeBase.RawMediaSourceTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)RawMediaSourceTypeBase.RawMediaSourceTypeColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.RawMediaSourceType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.RawMediaSourceType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.RawMediaSourceType();
                row.Id = (System.Byte)dr[((byte)RawMediaSourceTypeBase.RawMediaSourceTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)RawMediaSourceTypeBase.RawMediaSourceTypeColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.RawMediaSourceType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.RawMediaSourceType item );        
        

   

     
        public virtual DashProject.Data.Item.RawMediaSourceType GetById(System.Byte Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.RawMediaSourceType GetById(Manitou.Data.Provider.SessionManager sm, System.Byte Id );                       
  

  

 
    
    }                       
}