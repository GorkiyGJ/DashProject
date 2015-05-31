using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class ApplicationConfigurationMapper : ApplicationConfigurationMapperBase
    {
        public ApplicationConfigurationMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}