using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class CodecMediaTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.CodecMediaType>
    {
        public static List<DashProject.Data.Item.CodecMediaType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.CodecMediaType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.CodecMediaType>();
            
                DashProject.Data.Item.CodecMediaType row = new DashProject.Data.Item.CodecMediaType();

                row.Id = (System.Int32)dr[((byte)CodecMediaTypeBase.CodecMediaTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)CodecMediaTypeBase.CodecMediaTypeColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.CodecMediaType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.CodecMediaType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.CodecMediaType();
                row.Id = (System.Int32)dr[((byte)CodecMediaTypeBase.CodecMediaTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)CodecMediaTypeBase.CodecMediaTypeColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.CodecMediaType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.CodecMediaType item );        
        

   

     
        public virtual DashProject.Data.Item.CodecMediaType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.CodecMediaType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}