using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class DecoderMapper : DecoderMapperBase
    {
        public DecoderMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}