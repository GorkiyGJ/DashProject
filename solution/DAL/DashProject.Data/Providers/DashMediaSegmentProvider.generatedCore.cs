using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class DashMediaSegmentProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.DashMediaSegment>
    {
        public static List<DashProject.Data.Item.DashMediaSegment> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.DashMediaSegment> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.DashMediaSegment>();
            
                DashProject.Data.Item.DashMediaSegment row = new DashProject.Data.Item.DashMediaSegment();

                row.Id = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.Id - 1)];
                row.DashMediaId = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DashMediaId - 1)];
                row.TimeScale = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.TimeScale - 1)];
                row.DecodeTimeTS = (System.Int64)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DecodeTimeTS - 1)];
                row.DurationTS = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DurationTS - 1)];
                row.DurationS = (System.Decimal)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DurationS - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DateTimeCreated - 1)];
                row.GlobalStartTimeS = (System.Decimal)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.GlobalStartTimeS - 1)];
                row.GlobalEndTimeS = (System.Decimal)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.GlobalEndTimeS - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.DashMediaSegment FillItem(IDataReader dr)
        {
            DashProject.Data.Item.DashMediaSegment row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.DashMediaSegment();
                row.Id = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.Id - 1)];
                row.DashMediaId = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DashMediaId - 1)];
                row.TimeScale = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.TimeScale - 1)];
                row.DecodeTimeTS = (System.Int64)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DecodeTimeTS - 1)];
                row.DurationTS = (System.Int32)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DurationTS - 1)];
                row.DurationS = (System.Decimal)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DurationS - 1)];
                row.DateTimeCreated = (System.DateTime)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.DateTimeCreated - 1)];
                row.GlobalStartTimeS = (System.Decimal)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.GlobalStartTimeS - 1)];
                row.GlobalEndTimeS = (System.Decimal)dr[((byte)DashMediaSegmentBase.DashMediaSegmentColumn.GlobalEndTimeS - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.DashMediaSegment item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.DashMediaSegment item );        
        

   

     
        public virtual DashProject.Data.Item.DashMediaSegment GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.DashMediaSegment GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

   
    public virtual void GetId_By_DashMediaId_DecodeTimeTS(ref System.Int32? DashMediaId, ref System.Int64? DecodeTimeTS, ref System.Int32? DashMediaSegmentId)
    {               
GetId_By_DashMediaId_DecodeTimeTS(null , DashMediaId, DecodeTimeTS, ref DashMediaSegmentId);
      
    }
    
    public abstract void GetId_By_DashMediaId_DecodeTimeTS(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, System.Int64? DecodeTimeTS, ref System.Int32? DashMediaSegmentId);
        
 
    
    }                       
}