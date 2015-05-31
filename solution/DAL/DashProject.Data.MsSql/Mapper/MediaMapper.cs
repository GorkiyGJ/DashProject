using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class MediaMapper : MediaMapperBase
    {
        public MediaMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}