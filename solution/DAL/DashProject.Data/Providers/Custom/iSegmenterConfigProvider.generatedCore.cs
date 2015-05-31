using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iSegmenterConfigProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iSegmenterConfig>
    {
        public static List<DashProject.Data.Item.Custom.iSegmenterConfig> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iSegmenterConfig> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iSegmenterConfig>();
                    
                DashProject.Data.Item.Custom.iSegmenterConfig row = new DashProject.Data.Item.Custom.iSegmenterConfig();

                row.InputMedia = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.InputMedia))) ? null : (System.String)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.InputMedia)];
                row.ProgramIndex = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ProgramIndex))) ? null : (System.Byte?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ProgramIndex)];
                row.IsForceKeyFrames = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsForceKeyFrames))) ? null : (System.Boolean?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsForceKeyFrames)];
                row.SegmentTime = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTime))) ? null : (System.Byte?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTime)];
                row.ResetTimeStamps = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ResetTimeStamps))) ? null : (System.Boolean?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ResetTimeStamps)];
                row.IsUseSegmentTimeDelta = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsUseSegmentTimeDelta))) ? null : (System.Boolean?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsUseSegmentTimeDelta)];
                row.SegmentTimeDelta = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTimeDelta))) ? null : (System.Single?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTimeDelta)];
                row.StartNumber = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.StartNumber))) ? null : (System.Int64?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.StartNumber)];
                row.RawMediaContainerTypeId = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.RawMediaContainerTypeId))) ? null : (System.Int32?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.RawMediaContainerTypeId)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iSegmenterConfig FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iSegmenterConfig row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iSegmenterConfig();
                row.InputMedia = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.InputMedia))) ? null : (System.String)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.InputMedia)];
                row.ProgramIndex = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ProgramIndex))) ? null : (System.Byte?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ProgramIndex)];
                row.IsForceKeyFrames = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsForceKeyFrames))) ? null : (System.Boolean?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsForceKeyFrames)];
                row.SegmentTime = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTime))) ? null : (System.Byte?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTime)];
                row.ResetTimeStamps = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ResetTimeStamps))) ? null : (System.Boolean?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.ResetTimeStamps)];
                row.IsUseSegmentTimeDelta = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsUseSegmentTimeDelta))) ? null : (System.Boolean?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.IsUseSegmentTimeDelta)];
                row.SegmentTimeDelta = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTimeDelta))) ? null : (System.Single?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.SegmentTimeDelta)];
                row.StartNumber = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.StartNumber))) ? null : (System.Int64?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.StartNumber)];
                row.RawMediaContainerTypeId = (dr.IsDBNull(((byte)iSegmenterConfigBase.iSegmenterConfigColumn.RawMediaContainerTypeId))) ? null : (System.Int32?)dr[((byte)iSegmenterConfigBase.iSegmenterConfigColumn.RawMediaContainerTypeId)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iSegmenterConfig> Get_By_MediaId(ref System.Int32? MediaId)
    {               
return Get_By_MediaId(null , MediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iSegmenterConfig> Get_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId);
        
        
    }                       
}