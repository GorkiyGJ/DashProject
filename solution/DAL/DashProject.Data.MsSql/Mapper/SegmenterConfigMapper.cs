using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class SegmenterConfigMapper : SegmenterConfigMapperBase
    {
        public SegmenterConfigMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}