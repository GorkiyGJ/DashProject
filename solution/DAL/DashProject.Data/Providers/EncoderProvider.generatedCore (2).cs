using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class EncoderProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.Encoder>
    {
        public static List<DashProject.Data.Item.Encoder> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Encoder> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Encoder>();
            
                DashProject.Data.Item.Encoder row = new DashProject.Data.Item.Encoder();

                row.Id = (System.Int32)dr[((byte)EncoderBase.EncoderColumn.Id - 1)];
                row.EncoderTypeId = (System.Int32)dr[((byte)EncoderBase.EncoderColumn.EncoderTypeId - 1)];
                row.Name = (System.String)dr[((byte)EncoderBase.EncoderColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)EncoderBase.EncoderColumn.Description - 1))) ? null : (System.String)dr[((byte)EncoderBase.EncoderColumn.Description - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Encoder FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Encoder row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.Encoder();
                row.Id = (System.Int32)dr[((byte)EncoderBase.EncoderColumn.Id - 1)];
                row.EncoderTypeId = (System.Int32)dr[((byte)EncoderBase.EncoderColumn.EncoderTypeId - 1)];
                row.Name = (System.String)dr[((byte)EncoderBase.EncoderColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)EncoderBase.EncoderColumn.Description - 1))) ? null : (System.String)dr[((byte)EncoderBase.EncoderColumn.Description - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.Encoder item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.Encoder item );        
        

   

     
        public virtual DashProject.Data.Item.Encoder GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.Encoder GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}