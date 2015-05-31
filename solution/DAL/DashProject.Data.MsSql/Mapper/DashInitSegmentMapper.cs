using System;

namespace DashProject.Data.MsSql.Mapper
{
    public sealed class DashInitSegmentMapper : DashInitSegmentMapperBase
    {
        public DashInitSegmentMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}