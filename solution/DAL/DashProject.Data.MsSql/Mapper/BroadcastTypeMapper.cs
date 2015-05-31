using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class BroadcastTypeMapper : BroadcastTypeMapperBase
    {
        public BroadcastTypeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}