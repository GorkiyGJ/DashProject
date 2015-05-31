using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DashProject.Entity;
using DashProject.Repository;
using MatrixIO.IO.Bmff.Boxes;
using MatrixIO.IO;
using MatrixIO.IO.Bmff;

namespace DashProject.Api
{
    public static class DashMediaSegmentApi
    {
        #region DashMediaSegment_Save
        public static DashMediaSegment DashMediaSegment_Save(DashMediaSegment item)
        {
            return Factory.DashMediaSegment.Save(item);
        }
        #endregion

        /*#region DashMediaSegment_GetLast_GlobalEndTimeS_By_DashMediaId
        public static decimal DashMediaSegment_GetLast_GlobalEndTimeS_By_DashMediaId(int dashMediaId)
        {
            decimal? gst = null;
            Factory.DashMediaSegment.GetLast_GlobalEndTimeS_By_DashMediaId(dashMediaId, ref gst);
            return gst.HasValue ? gst.Value : 0;
        }
        #endregion*/

        public class DashInitSegment
        {
            public FileTypeBox FtypBox;
            public MovieBox MoovBox;

            public DashInitSegment() { }

            public DashInitSegment(FileTypeBox ftypBox, MovieBox moovBox)
            {
                FtypBox = ftypBox;
                MoovBox = moovBox;
            }
        }

        public class DashSegment
        {
            public MovieFragmentBox MoofBox;
            public MovieDataBox MdatBox;
            public uint TimeScale;

            public DashSegment() { }

            public DashSegment(MovieFragmentBox moofBox, MovieDataBox mdatBox)
            {
                MoofBox = moofBox;
                MdatBox = mdatBox;
            }
        }
    }
}
