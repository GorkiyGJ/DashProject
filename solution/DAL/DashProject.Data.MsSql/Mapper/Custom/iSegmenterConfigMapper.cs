using System;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public sealed class iSegmenterConfigMapper : iSegmenterConfigMapperBase
    {
        public iSegmenterConfigMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}