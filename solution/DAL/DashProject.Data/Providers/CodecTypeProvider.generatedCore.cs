using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class CodecTypeProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.CodecType>
    {
        public static List<DashProject.Data.Item.CodecType> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.CodecType> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.CodecType>();
            
                DashProject.Data.Item.CodecType row = new DashProject.Data.Item.CodecType();

                row.Id = (System.Int32)dr[((byte)CodecTypeBase.CodecTypeColumn.Id - 1)];
                row.StreamTypeId = (System.Int32)dr[((byte)CodecTypeBase.CodecTypeColumn.StreamTypeId - 1)];
                row.Name = (System.String)dr[((byte)CodecTypeBase.CodecTypeColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)CodecTypeBase.CodecTypeColumn.Description - 1))) ? null : (System.String)dr[((byte)CodecTypeBase.CodecTypeColumn.Description - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.CodecType FillItem(IDataReader dr)
        {
            DashProject.Data.Item.CodecType row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.CodecType();
                row.Id = (System.Int32)dr[((byte)CodecTypeBase.CodecTypeColumn.Id - 1)];
                row.StreamTypeId = (System.Int32)dr[((byte)CodecTypeBase.CodecTypeColumn.StreamTypeId - 1)];
                row.Name = (System.String)dr[((byte)CodecTypeBase.CodecTypeColumn.Name - 1)];
                row.Description = (dr.IsDBNull(((byte)CodecTypeBase.CodecTypeColumn.Description - 1))) ? null : (System.String)dr[((byte)CodecTypeBase.CodecTypeColumn.Description - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.CodecType item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.CodecType item );        
        

   

     
        public virtual DashProject.Data.Item.CodecType GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.CodecType GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}