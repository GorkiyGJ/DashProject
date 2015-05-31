using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class StreamTypeMapper : StreamTypeMapperBase
    {
        public StreamTypeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}