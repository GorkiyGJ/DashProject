using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class SegmenterConfigProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.SegmenterConfig>
    {
        public static List<DashProject.Data.Item.SegmenterConfig> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.SegmenterConfig> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.SegmenterConfig>();
            
                DashProject.Data.Item.SegmenterConfig row = new DashProject.Data.Item.SegmenterConfig();

                row.Id = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.Id - 1)];
                row.MediaId = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.MediaId - 1)];
                row.IsForceKeyFrames = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsForceKeyFrames - 1)];
                row.SegmentTime = (System.Byte)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.SegmentTime - 1)];
                row.ResetTimeStamps = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.ResetTimeStamps - 1)];
                row.IsUseSegmentTimeDelta = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsUseSegmentTimeDelta - 1)];
                row.SegmentTimeDelta = (System.Single)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.SegmentTimeDelta - 1)];
                row.IsUseFastStart = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsUseFastStart - 1)];
                row.FastStartDurationS = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.FastStartDurationS - 1)];
                row.DurationSLimit = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.DurationSLimit - 1)];
                row.UseDurationSLimit = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.UseDurationSLimit - 1)];
                row.IsDone = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsDone - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.SegmenterConfig FillItem(IDataReader dr)
        {
            DashProject.Data.Item.SegmenterConfig row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.SegmenterConfig();
                row.Id = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.Id - 1)];
                row.MediaId = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.MediaId - 1)];
                row.IsForceKeyFrames = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsForceKeyFrames - 1)];
                row.SegmentTime = (System.Byte)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.SegmentTime - 1)];
                row.ResetTimeStamps = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.ResetTimeStamps - 1)];
                row.IsUseSegmentTimeDelta = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsUseSegmentTimeDelta - 1)];
                row.SegmentTimeDelta = (System.Single)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.SegmentTimeDelta - 1)];
                row.IsUseFastStart = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsUseFastStart - 1)];
                row.FastStartDurationS = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.FastStartDurationS - 1)];
                row.DurationSLimit = (System.Int32)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.DurationSLimit - 1)];
                row.UseDurationSLimit = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.UseDurationSLimit - 1)];
                row.IsDone = (System.Boolean)dr[((byte)SegmenterConfigBase.SegmenterConfigColumn.IsDone - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.SegmenterConfig item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.SegmenterConfig item );        
        

   

     
        public virtual DashProject.Data.Item.SegmenterConfig GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.SegmenterConfig GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}