using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class BroadcastTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.BroadcastType>
    {
        public static List<DashProject.Data.Item.BroadcastType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.BroadcastType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.BroadcastType>();
            
                DashProject.Data.Item.BroadcastType row = new DashProject.Data.Item.BroadcastType();

                row.Id = (System.Byte)dr[((byte)BroadcastTypeBase.BroadcastTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)BroadcastTypeBase.BroadcastTypeColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.BroadcastType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.BroadcastType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.BroadcastType();
                row.Id = (System.Byte)dr[((byte)BroadcastTypeBase.BroadcastTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)BroadcastTypeBase.BroadcastTypeColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.BroadcastType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.BroadcastType item );        
        

   

     
        public virtual DashProject.Data.Item.BroadcastType GetById(System.Byte Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.BroadcastType GetById(Manitou.Data.Provider.SessionManager sm, System.Byte Id );                       
  

  

 
    
    }                       
}