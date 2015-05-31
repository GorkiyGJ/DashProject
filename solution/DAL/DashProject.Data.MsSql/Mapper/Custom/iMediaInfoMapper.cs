using System;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public sealed class iMediaInfoMapper : iMediaInfoMapperBase
    {
        public iMediaInfoMapper(string connectionString) 
            : base(connectionString) 
        { 
        }
    }
}