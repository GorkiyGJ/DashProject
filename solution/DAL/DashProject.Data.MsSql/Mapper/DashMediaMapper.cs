using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class DashMediaMapper : DashMediaMapperBase
    {
        public DashMediaMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}