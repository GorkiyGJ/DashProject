using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class CodecTypeMapper : CodecTypeMapperBase
    {
        public CodecTypeMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}