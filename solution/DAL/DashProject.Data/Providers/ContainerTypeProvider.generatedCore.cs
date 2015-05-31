using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class ContainerTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.ContainerType>
    {
        public static List<DashProject.Data.Item.ContainerType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.ContainerType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.ContainerType>();
            
                DashProject.Data.Item.ContainerType row = new DashProject.Data.Item.ContainerType();

                row.Id = (System.Int32)dr[((byte)ContainerTypeBase.ContainerTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)ContainerTypeBase.ContainerTypeColumn.Name - 1)];
                row.Description = (System.String)dr[((byte)ContainerTypeBase.ContainerTypeColumn.Description - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.ContainerType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.ContainerType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.ContainerType();
                row.Id = (System.Int32)dr[((byte)ContainerTypeBase.ContainerTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)ContainerTypeBase.ContainerTypeColumn.Name - 1)];
                row.Description = (System.String)dr[((byte)ContainerTypeBase.ContainerTypeColumn.Description - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.ContainerType item , System.Int32 OriginalId)
        {
            return Update(null, item , OriginalId);
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.ContainerType item , System.Int32 OriginalId);        
        

   

     
        public virtual DashProject.Data.Item.ContainerType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.ContainerType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}