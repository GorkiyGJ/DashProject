using DashProject.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.DataEntities
{
    public interface IData : ICloneable
    {
        public abstract DataType Type { get; }
    };
}
