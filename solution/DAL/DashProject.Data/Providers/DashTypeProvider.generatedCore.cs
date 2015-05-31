using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class DashTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.DashType>
    {
        public static List<DashProject.Data.Item.DashType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.DashType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.DashType>();
            
                DashProject.Data.Item.DashType row = new DashProject.Data.Item.DashType();

                row.Id = (System.Int32)dr[((byte)DashTypeBase.DashTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)DashTypeBase.DashTypeColumn.Name - 1)];
                row.ContainerTypeId = (System.Int32)dr[((byte)DashTypeBase.DashTypeColumn.ContainerTypeId - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.DashType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.DashType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.DashType();
                row.Id = (System.Int32)dr[((byte)DashTypeBase.DashTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)DashTypeBase.DashTypeColumn.Name - 1)];
                row.ContainerTypeId = (System.Int32)dr[((byte)DashTypeBase.DashTypeColumn.ContainerTypeId - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.DashType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.DashType item );        
        

   

     
        public virtual DashProject.Data.Item.DashType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.DashType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}