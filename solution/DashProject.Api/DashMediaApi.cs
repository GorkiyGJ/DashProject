using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashProject.Repository;
using DashProject.Entity;
using DashProject.Entity.Custom;
using DashProject.Api.Enum;

namespace DashProject.Api
{
    public static class DashMediaApi
    {
       /*#region DashMedia_Get_IsMain
        public static bool DashMedia_Get_IsMain(int dashMediaId)
        {
            bool? isMain = null;
            Factory.DashMedia.Get_IsMain(dashMediaId, ref isMain);
            return (isMain.HasValue) ? true : false;
        }
        #endregion*/

        #region DashMedia_Get_DashType_By_DashMediaId
        public static DashProject.Api.Enum.DashType Get_DashType_By_DashMediaId(int dashMediaId)
        {
            int? dashTypeId = null;
            Factory.DashMedia.Get_DashType_ById(dashMediaId, ref dashTypeId);
            return (DashProject.Api.Enum.DashType) dashTypeId;   
        }
        #endregion

        /*#region iDashMediaInfo_Get_IsMain_By_MediaId
        public static List<iDashMediaInfo> iDashMediaInfo_Get_IsMain_By_MediaId(int mediaId)
        {
            return Factory.iDashMediaInfo.Get_IsMain_By_MediaId(mediaId);
        }
        #endregion

        #region iDashMediaInfo_Get_By_MainDashMediaId
        public static List<iDashMediaInfo> iDashMediaInfo_Get_By_MainDashMediaId(int m_dashMediaId)
        {
            return Factory.iDashMediaInfo.Get_By_MainDashMediaId(m_dashMediaId);
        }
        #endregion*/

        #region iDashMediaInfo_Get_By_MediaId
        public static List<iDashMediaInfo> iDashMediaInfo_Get_By_MediaId(int mediaId)
        {
            return Factory.iDashMediaInfo.Get_By_MediaId(mediaId);
        }
        #endregion

        #region DashMedia_Save_InitSegment
        public static void DashMedia_Save_InitSegment(int dashMediaId, DashInitSegment segment)
        {
            segment = Factory.DashInitSegment.Save(segment);
            DashMedia dashMedia = Factory.DashMedia.GetById(dashMediaId);
            dashMedia.DashInitSegmentId = segment.Id;
            Factory.DashMedia.Update(dashMedia);
        }
        #endregion

        #region
        public static iDashMediaInfo iDashMediaInfo_Get_By_DashMediaId(int dashMediaId)
        {
            List<iDashMediaInfo> iDashMediaInfoList = Factory.iDashMediaInfo.Get_By_DashMediaId(dashMediaId);
            return iDashMediaInfoList != null && iDashMediaInfoList.Count > 0 ? iDashMediaInfoList[0] : null;
        }
        #endregion

        /*#region iDashMediaInfo_Get_By_MediaId_RawMediaSourceType
        public static List<iDashMediaInfo> iDashMediaInfo_Get_By_MediaId_RawMediaSourceType(int mediaId, Api.Enum.RawMediaSourceType type)
        {
            return Factory.iDashMediaInfo.Get_By_MediaId_RawMediaSourceType(mediaId, (byte)type);
        }
        #endregion*/

        /*#region iDashMediaInfo_Get_By_DashMediaId
        public static iDashMediaInfo iDashMediaInfo_Get_By_DashMediaId(int dashMediaId)
        {
            return Factory.iDashMediaInfo.Get_By_DashMediaId(dashMediaId);
        }
        #endregion*/

        /* #region DashMedia_Get_IsHasInitSegment
        public static bool DashMedia_Get_IsHasInitSegment(int dashMediaId)
        {
            bool? has = null;
            Factory.DashMedia.Get_IsHasInitSegment(dashMediaId, ref has);
            return (has.HasValue && has.Value) ? true : false;
        }
        #endregion*/
    }
}
