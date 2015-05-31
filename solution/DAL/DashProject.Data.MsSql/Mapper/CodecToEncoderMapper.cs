using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class CodecToEncoderMapper : CodecToEncoderMapperBase
    {
        public CodecToEncoderMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}