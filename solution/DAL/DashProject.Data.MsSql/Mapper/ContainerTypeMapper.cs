using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class ContainerTypeMapper : ContainerTypeMapperBase
    {
        public ContainerTypeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}