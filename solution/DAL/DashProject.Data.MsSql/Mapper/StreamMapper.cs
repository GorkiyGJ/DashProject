using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class StreamMapper : StreamMapperBase
    {
        public StreamMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}