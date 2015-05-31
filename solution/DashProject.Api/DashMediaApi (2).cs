using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashProject.Repository;
using DashProject.Entity;
using DashProject.Entity.Custom;

namespace DashProject.Api
{
    public static class DashMediaApi
    {
        /*#region DashEntityMedia_Insert_InitSegment
        public static void DashEntityMedia_Insert_InitSegment(int dashEntityMediaId, DashInitSegment initSegment)
        {
            Factory.DashEntityMedia.Insert_InitSegment(dashEntityMediaId, initSegment.ContainerFormatId, initSegment.FileName, initSegment.DateTimeCreated);
        }
        #endregion

        #region DashMediaSegment_Insert
        public static bool DashMediaSegment_Insert(DashMediaSegment item)
        {
            return Factory.DashMediaSegment.Insert(item);
        }
        #endregion

        #region DashMediaSegment_Delete
        public static void DashMediaSegment_Delete(int id)
        {
            Factory.DashMediaSegment.Delete(id);
        }
        #endregion

        #region DashMediaSegment_Insert_GetId
        public static int? DashMediaSegment_Insert_GetId(DashMediaSegment item)
        {
            int? id = null;
            Factory.DashMediaSegment.Insert(item.DashEntityMediaId, item.ContainerFormatId, item.FileName, item.TimeScale, item.DecodeTimeTS, item.DurationS, item.DurationTS, item.DateTimeCreated, ref id);
            return id;
        }
        #endregion
        */
        /*
        #region
        public static int[] DashMedia_GetId_By_MediaId_IsMain(int mediaId)
        {
            List<int> dashMediaIds = null;
            using (System.Data.IDataReader idr = Factory.DashMedia.Get_Id_By_MediaId_IsMain(mediaId))
            {
                while (idr.Read())
                {
                    int? id = Manitou.Helper.Converter.ToInt32Nullable(idr[0]);
                    if (id.HasValue)
                    {
                        if (dashMediaIds == null)
                            dashMediaIds = new List<int>();
                        dashMediaIds.Add(id.Value);
                    }

                }
            }
            return (dashMediaIds != null) ? dashMediaIds.ToArray() : null;
        }
        #endregion

        #region
        public static int[] DashMedia_GetId_By_MainDashMediaId(int dashMediaId)
        {
            List<int> dashMediaIds = null;
            using (System.Data.IDataReader idr = Factory.DashMedia.Get_Id_By_MainDashMediaId(dashMediaId))
            {
                while (idr.Read())
                {
                    int? id = Manitou.Helper.Converter.ToInt32Nullable(idr[0]);
                    if (id.HasValue)
                    {
                        if (dashMediaIds == null)
                            dashMediaIds = new List<int>();
                        dashMediaIds.Add(id.Value);
                    }

                }
            }
            return (dashMediaIds != null) ? dashMediaIds.ToArray() : null;
        }
        #endregion
         */

        #region DashMedia_Get_IsMain
        public static bool DashMedia_Get_IsMain(int dashMediaId)
        {
            bool? isMain = null;
            Factory.DashMedia.Get_IsMain(dashMediaId, ref isMain);
            return (isMain.HasValue) ? true : false;
        }
        #endregion

        #region DashMedia_Get_DashType_By_DashMediaId
        public static DashProject.Api.Enum.DashType Get_DashType_By_DashMediaId(int dashMediaId)
        {
            int? dashTypeId = null;
            Factory.DashMedia.Get_DashType_ById(dashMediaId, ref dashTypeId);
            return (DashProject.Api.Enum.DashType) dashTypeId;   
        }
        #endregion

        #region iDashMediaInfo_Get_IsMain_By_MediaId
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

       /* #region DashMedia_Get_IsHasInitSegment
        public static bool DashMedia_Get_IsHasInitSegment(int dashMediaId)
        {
            bool? has = null;
            Factory.DashMedia.Get_IsHasInitSegment(dashMediaId, ref has);
            return (has.HasValue && has.Value) ? true : false;
        }
        #endregion
         */
    }
}
