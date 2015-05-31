using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class DashTypeMapper : DashTypeMapperBase
    {
        public DashTypeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}