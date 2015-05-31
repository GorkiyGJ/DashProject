using System;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public sealed class iStreamInfoMapper : iStreamInfoMapperBase
    {
        public iStreamInfoMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}