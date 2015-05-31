using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class RawMediaMapper : RawMediaMapperBase
    {
        public RawMediaMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}