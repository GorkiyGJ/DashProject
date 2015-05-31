using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class RawMediaSourceTypeMapper : RawMediaSourceTypeMapperBase
    {
        public RawMediaSourceTypeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}