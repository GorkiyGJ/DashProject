using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class CodecToEncoderProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.CodecToEncoder>
    {
        public static List<DashProject.Data.Item.CodecToEncoder> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.CodecToEncoder> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.CodecToEncoder>();
            
                DashProject.Data.Item.CodecToEncoder row = new DashProject.Data.Item.CodecToEncoder();

                row.Id = (System.Int32)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.Id - 1)];
                row.CodecTypeId = (System.Int32)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.CodecTypeId - 1)];
                row.EncoderTypeId = (System.Int32)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.EncoderTypeId - 1)];
                row.IsMain = (System.Boolean)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.IsMain - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.CodecToEncoder FillItem(IDataReader dr)
        {
            DashProject.Data.Item.CodecToEncoder row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.CodecToEncoder();
                row.Id = (System.Int32)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.Id - 1)];
                row.CodecTypeId = (System.Int32)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.CodecTypeId - 1)];
                row.EncoderTypeId = (System.Int32)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.EncoderTypeId - 1)];
                row.IsMain = (System.Boolean)dr[((byte)CodecToEncoderBase.CodecToEncoderColumn.IsMain - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.CodecToEncoder item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.CodecToEncoder item );        
        

   

     
        public virtual DashProject.Data.Item.CodecToEncoder GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.CodecToEncoder GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}