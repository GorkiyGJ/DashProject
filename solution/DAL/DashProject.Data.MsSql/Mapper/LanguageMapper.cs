using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class LanguageMapper : LanguageMapperBase
    {
        public LanguageMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}