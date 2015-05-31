using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class DecoderProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.Decoder>
    {
        public static List<DashProject.Data.Item.Decoder> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Decoder> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Decoder>();
            
                DashProject.Data.Item.Decoder row = new DashProject.Data.Item.Decoder();

                row.Id = (System.Int32)dr[((byte)DecoderBase.DecoderColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)DecoderBase.DecoderColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)DecoderBase.DecoderColumn.Description - 1))) ? null : (System.String)dr[((byte)DecoderBase.DecoderColumn.Description - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Decoder FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Decoder row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.Decoder();
                row.Id = (System.Int32)dr[((byte)DecoderBase.DecoderColumn.Id - 1)];
                row.Name = (System.String)dr[((byte)DecoderBase.DecoderColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)DecoderBase.DecoderColumn.Description - 1))) ? null : (System.String)dr[((byte)DecoderBase.DecoderColumn.Description - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.Decoder item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.Decoder item );        
        

   

     
        public virtual DashProject.Data.Item.Decoder GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.Decoder GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}