using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class DashInitSegmentProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.DashInitSegment>
    {
        public static List<DashProject.Data.Item.DashInitSegment> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.DashInitSegment> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.DashInitSegment>();
            
                DashProject.Data.Item.DashInitSegment row = new DashProject.Data.Item.DashInitSegment();

                row.Id = (System.Int32)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.Id - 1)];
                row.ContainerFormatId = (System.Int32)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.ContainerFormatId - 1)];
                row.FileName = (System.String)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.FileName - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.DateTimeCreated - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.DashInitSegment FillItem(IDataReader dr)
        {
            DashProject.Data.Item.DashInitSegment row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.DashInitSegment();
                row.Id = (System.Int32)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.Id - 1)];
                row.ContainerFormatId = (System.Int32)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.ContainerFormatId - 1)];
                row.FileName = (System.String)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.FileName - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)DashInitSegmentBase.DashInitSegmentColumn.DateTimeCreated - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.DashInitSegment item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.DashInitSegment item );        
        

   

     
        public virtual DashProject.Data.Item.DashInitSegment GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.DashInitSegment GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}