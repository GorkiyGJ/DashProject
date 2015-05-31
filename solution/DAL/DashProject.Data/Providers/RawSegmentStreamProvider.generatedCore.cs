using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class RawSegmentStreamProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.RawSegmentStream>
    {
        public static List<DashProject.Data.Item.RawSegmentStream> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.RawSegmentStream> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.RawSegmentStream>();
            
                DashProject.Data.Item.RawSegmentStream row = new DashProject.Data.Item.RawSegmentStream();

                row.Id = (System.Int64)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.Id - 1)];
                row.SegmentId = (System.Int64)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.SegmentId - 1)];
                row.MediaId = (System.Int32)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.MediaId - 1)];
                row.StreamId = (System.Int32)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.StreamId - 1)];
                row.FileName = (System.String)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.FileName - 1)];
                row.DurationS = (System.Decimal)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.DurationS - 1)];
                row.GlobalStartTimeS = (System.Decimal)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.GlobalStartTimeS - 1)];
                row.GlobalEndTimeS = (System.Decimal)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.GlobalEndTimeS - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.DateTimeCreated - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.RawSegmentStream FillItem(IDataReader dr)
        {
            DashProject.Data.Item.RawSegmentStream row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.RawSegmentStream();
                row.Id = (System.Int64)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.Id - 1)];
                row.SegmentId = (System.Int64)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.SegmentId - 1)];
                row.MediaId = (System.Int32)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.MediaId - 1)];
                row.StreamId = (System.Int32)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.StreamId - 1)];
                row.FileName = (System.String)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.FileName - 1)];
                row.DurationS = (System.Decimal)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.DurationS - 1)];
                row.GlobalStartTimeS = (System.Decimal)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.GlobalStartTimeS - 1)];
                row.GlobalEndTimeS = (System.Decimal)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.GlobalEndTimeS - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)RawSegmentStreamBase.RawSegmentStreamColumn.DateTimeCreated - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.RawSegmentStream item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.RawSegmentStream item );        
        

   

     
        public virtual DashProject.Data.Item.RawSegmentStream GetById(System.Int64 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.RawSegmentStream GetById(Manitou.Data.Provider.SessionManager sm, System.Int64 Id );                       
    
        public virtual DashProject.Data.Item.RawSegmentStream GetByIdMediaIdSegmentIdStreamIdFileName(System.Int64 Id, System.Int32 MediaId, System.Int64 SegmentId, System.Int32 StreamId, System.String FileName )
        {
            return GetByIdMediaIdSegmentIdStreamIdFileName(null,  Id,  MediaId,  SegmentId,  StreamId,  FileName );
        }                     
        
        public abstract DashProject.Data.Item.RawSegmentStream GetByIdMediaIdSegmentIdStreamIdFileName(Manitou.Data.Provider.SessionManager sm, System.Int64 Id, System.Int32 MediaId, System.Int64 SegmentId, System.Int32 StreamId, System.String FileName );                       
  

  

   
    public virtual void Get_GlobalEndTimeS_By_DashMediaId(ref System.Int32? DashMediaId, ref System.Decimal? GlobalEndTimeS)
    {               
Get_GlobalEndTimeS_By_DashMediaId(null , DashMediaId, ref GlobalEndTimeS);
      
    }
    
    public abstract void Get_GlobalEndTimeS_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Decimal? GlobalEndTimeS);
        
   
    public virtual void Get_GlobalStartTimeS_By_DashMediaId(ref System.Int32? DashMediaId, ref System.Decimal? GlobalStartTimeS)
    {               
Get_GlobalStartTimeS_By_DashMediaId(null , DashMediaId, ref GlobalStartTimeS);
      
    }
    
    public abstract void Get_GlobalStartTimeS_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Decimal? GlobalStartTimeS);
        
 
    
    }                       
}