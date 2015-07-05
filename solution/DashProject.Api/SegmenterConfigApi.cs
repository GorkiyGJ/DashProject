using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashProject.Repository;
using DashProject.Entity.Custom;
using DashProject.Entity;
using Manitou.Data.Provider;
using System.IO;
using DashProject.Api.Extension;

namespace DashProject.Api
{
    public static class SegmenterConfigApi
    {

        #region SegmenterConfig_Get_By_MediaId
        public static iSegmenterConfig SegmenterConfig_Get_By_MediaId(int mediaId)
        {
            List<iSegmenterConfig> config = Factory.iSegmenterConfig.Get_By_MediaId(mediaId);
            return config != null ? config[0] : null;
        }
        #endregion 

        /*
        #region iStreamInfo_Get_By_MediaId_StreamIndex
        public static iStreamInfo iStreamInfo_Get_By_MediaId_StreamIndex(int mediaId, int index)
        {
            List<iStreamInfo> items = Factory.iStreamInfo.Get_By_MediaId_StreamIndex(mediaId, index);
            return (items != null && items.Count > 0) ? items[0] : null;
        }
        #endregion

        #region
        public static void RawSegmentStream_Insert(RawSegmentStream item)
        {
            Factory.RawSegmentStream.Insert(item);
        }
        #endregion

        */
    }
}
