using System;
using System.Collections.Generic;
using DashProject.Entity.Custom;
using DashProject.Repository;

namespace DashProject.Api
{
    public static class MediaApi
    {
        #region iMediaInfo_Get
        public static List<iMediaInfo> iMediaInfo_Get()
        {
            return Factory.iMediaInfo.Get();
        }

        
        #endregion

        #region iMediaInfo_Get_By_MediaId
        public static iMediaInfo iMediaInfo_Get_By_MediaId(int mediaId)
        {
            List<iMediaInfo> items = Factory.iMediaInfo.Get_By_MediaId(mediaId);
            return items != null && items.Count > 0 ? items[0] : null;
        }
        #endregion
    }
}
