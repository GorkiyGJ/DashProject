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
    }
}
