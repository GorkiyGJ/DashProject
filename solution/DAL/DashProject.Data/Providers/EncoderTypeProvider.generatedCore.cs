using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class EncoderTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.EncoderType>
    {
        public static List<DashProject.Data.Item.EncoderType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.EncoderType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.EncoderType>();
            
                DashProject.Data.Item.EncoderType row = new DashProject.Data.Item.EncoderType();

                row.Id = (System.Int32)dr[((byte)EncoderTypeBase.EncoderTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)EncoderTypeBase.EncoderTypeColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)EncoderTypeBase.EncoderTypeColumn.Description - 1))) ? null : (System.String)dr[((byte)EncoderTypeBase.EncoderTypeColumn.Description - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.EncoderType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.EncoderType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.EncoderType();
                row.Id = (System.Int32)dr[((byte)EncoderTypeBase.EncoderTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)EncoderTypeBase.EncoderTypeColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)EncoderTypeBase.EncoderTypeColumn.Description - 1))) ? null : (System.String)dr[((byte)EncoderTypeBase.EncoderTypeColumn.Description - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.EncoderType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.EncoderType item );        
        

   

     
        public virtual DashProject.Data.Item.EncoderType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.EncoderType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}