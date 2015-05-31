using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class RawSegmentStreamMapper : RawSegmentStreamMapperBase
    {
        public RawSegmentStreamMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}