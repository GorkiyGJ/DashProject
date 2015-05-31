using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class VideoSizeMapper : VideoSizeMapperBase
    {
        public VideoSizeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}