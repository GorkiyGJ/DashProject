using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class DecoderTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.DecoderType>
    {
        public static List<DashProject.Data.Item.DecoderType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.DecoderType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.DecoderType>();
            
                DashProject.Data.Item.DecoderType row = new DashProject.Data.Item.DecoderType();

                row.Id = (System.Int32)dr[((byte)DecoderTypeBase.DecoderTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)DecoderTypeBase.DecoderTypeColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)DecoderTypeBase.DecoderTypeColumn.Description - 1))) ? null : (System.String)dr[((byte)DecoderTypeBase.DecoderTypeColumn.Description - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.DecoderType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.DecoderType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.DecoderType();
                row.Id = (System.Int32)dr[((byte)DecoderTypeBase.DecoderTypeColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)DecoderTypeBase.DecoderTypeColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)DecoderTypeBase.DecoderTypeColumn.Description - 1))) ? null : (System.String)dr[((byte)DecoderTypeBase.DecoderTypeColumn.Description - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.DecoderType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.DecoderType item );        
        

   

     
        public virtual DashProject.Data.Item.DecoderType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.DecoderType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}