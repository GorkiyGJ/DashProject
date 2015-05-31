using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class StreamProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.Stream>
    {
        public static List<DashProject.Data.Item.Stream> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Stream> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Stream>();
            
                DashProject.Data.Item.Stream row = new DashProject.Data.Item.Stream();

                row.Id = (System.Int32)dr[((byte)StreamBase.StreamColumn.Id - 1)];
                row.RawMediaId = (System.Int32)dr[((byte)StreamBase.StreamColumn.RawMediaId - 1)];
                row.StreamTypeId = (System.Int32)dr[((byte)StreamBase.StreamColumn.StreamTypeId - 1)];
                row.Index = (System.Byte)dr[((byte)StreamBase.StreamColumn.Index - 1)];
                row.CodecTypeId = (System.Int32)dr[((byte)StreamBase.StreamColumn.CodecTypeId - 1)];
                row.Channels = (dr.IsDBNull(((byte)StreamBase.StreamColumn.Channels - 1))) ? null : (System.Byte?)dr[((byte)StreamBase.StreamColumn.Channels - 1)];
                row.LanguageId = (dr.IsDBNull(((byte)StreamBase.StreamColumn.LanguageId - 1))) ? null : (System.Int32?)dr[((byte)StreamBase.StreamColumn.LanguageId - 1)];
                row.Width = (dr.IsDBNull(((byte)StreamBase.StreamColumn.Width - 1))) ? null : (System.Int16?)dr[((byte)StreamBase.StreamColumn.Width - 1)];
                row.Height = (dr.IsDBNull(((byte)StreamBase.StreamColumn.Height - 1))) ? null : (System.Int16?)dr[((byte)StreamBase.StreamColumn.Height - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Stream FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Stream row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.Stream();
                row.Id = (System.Int32)dr[((byte)StreamBase.StreamColumn.Id - 1)];
                row.RawMediaId = (System.Int32)dr[((byte)StreamBase.StreamColumn.RawMediaId - 1)];
                row.StreamTypeId = (System.Int32)dr[((byte)StreamBase.StreamColumn.StreamTypeId - 1)];
                row.Index = (System.Byte)dr[((byte)StreamBase.StreamColumn.Index - 1)];
                row.CodecTypeId = (System.Int32)dr[((byte)StreamBase.StreamColumn.CodecTypeId - 1)];
                row.Channels = (dr.IsDBNull(((byte)StreamBase.StreamColumn.Channels - 1))) ? null : (System.Byte?)dr[((byte)StreamBase.StreamColumn.Channels - 1)];
                row.LanguageId = (dr.IsDBNull(((byte)StreamBase.StreamColumn.LanguageId - 1))) ? null : (System.Int32?)dr[((byte)StreamBase.StreamColumn.LanguageId - 1)];
                row.Width = (dr.IsDBNull(((byte)StreamBase.StreamColumn.Width - 1))) ? null : (System.Int16?)dr[((byte)StreamBase.StreamColumn.Width - 1)];
                row.Height = (dr.IsDBNull(((byte)StreamBase.StreamColumn.Height - 1))) ? null : (System.Int16?)dr[((byte)StreamBase.StreamColumn.Height - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.Stream item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.Stream item );        
        

   

     
        public virtual DashProject.Data.Item.Stream GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.Stream GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}