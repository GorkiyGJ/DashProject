using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class MediaProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.Media>
    {
        public static List<DashProject.Data.Item.Media> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Media> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Media>();
            
                DashProject.Data.Item.Media row = new DashProject.Data.Item.Media();

                row.Id = (System.Int32)dr[((byte)MediaBase.MediaColumn.Id - 1)];
                row.RawMediaId = (System.Int32)dr[((byte)MediaBase.MediaColumn.RawMediaId - 1)];
                row.ProgramIndex = (dr.IsDBNull(((byte)MediaBase.MediaColumn.ProgramIndex - 1))) ? null : (System.Byte?)dr[((byte)MediaBase.MediaColumn.ProgramIndex - 1)];
                row.Name = (System.String)dr[((byte)MediaBase.MediaColumn.Name - 1)];
                row.IsActive = (System.Boolean)dr[((byte)MediaBase.MediaColumn.IsActive - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)MediaBase.MediaColumn.DateTimeCreated - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Media FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Media row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.Media();
                row.Id = (System.Int32)dr[((byte)MediaBase.MediaColumn.Id - 1)];
                row.RawMediaId = (System.Int32)dr[((byte)MediaBase.MediaColumn.RawMediaId - 1)];
                row.ProgramIndex = (dr.IsDBNull(((byte)MediaBase.MediaColumn.ProgramIndex - 1))) ? null : (System.Byte?)dr[((byte)MediaBase.MediaColumn.ProgramIndex - 1)];
                row.Name = (System.String)dr[((byte)MediaBase.MediaColumn.Name - 1)];
                row.IsActive = (System.Boolean)dr[((byte)MediaBase.MediaColumn.IsActive - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)MediaBase.MediaColumn.DateTimeCreated - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.Media item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.Media item );        
        

   

     
        public virtual DashProject.Data.Item.Media GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.Media GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}