using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Manitou.Data.Provider;
using DashProject.Repository;
using DashProject.Entity;

namespace DashProject.Api
{
    public class StreamApi
    {
        #region Stream_Insert
        public static bool Stream_Insert(Stream stream)
        {
            return Factory.Stream.Insert(stream);
        }
        #endregion
    }
}
