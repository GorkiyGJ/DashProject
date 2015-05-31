using System;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public sealed class iTranscoderConfigMapper : iTranscoderConfigMapperBase
    {
        public iTranscoderConfigMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}