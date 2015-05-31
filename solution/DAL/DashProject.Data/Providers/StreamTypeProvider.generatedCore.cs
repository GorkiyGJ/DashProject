using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class StreamTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.StreamType>
    {
        public static List<DashProject.Data.Item.StreamType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.StreamType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.StreamType>();
            
                DashProject.Data.Item.StreamType row = new DashProject.Data.Item.StreamType();

                row.Id = (System.Int32)dr[((byte)StreamTypeBase.StreamTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)StreamTypeBase.StreamTypeColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.StreamType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.StreamType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.StreamType();
                row.Id = (System.Int32)dr[((byte)StreamTypeBase.StreamTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)StreamTypeBase.StreamTypeColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.StreamType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.StreamType item );        
        

   

     
        public virtual DashProject.Data.Item.StreamType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.StreamType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}