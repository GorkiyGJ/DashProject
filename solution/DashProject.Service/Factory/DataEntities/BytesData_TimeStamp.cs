using DashProject.Api.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.DataEntities
{
    public class BytesDataTimeStamp : IData
    {
        public byte[] Bytes { get { return BoxedData == null ? new byte[0] : this.BoxedData as byte[]; } }

        protected object BoxedData;
        public decimal StreamStartTs;

        public BytesDataTimeStamp(byte[] bytes, decimal streamStartTs)
        {
            BoxedData = bytes;
            StreamStartTs = streamStartTs;
        }

        protected byte[] BytesCopy
        {
            get
            {
                byte[] bytes = Bytes;
                byte[] newBytes = new byte[bytes.Length];
                bytes.CopyTo(newBytes, 0);
                return newBytes;
            }
        }

        public DataType Type
        {
            get { return DataType.bytes_ts; }
        }

        public object Clone()
        {
            return new BytesDataTimeStamp(BytesCopy, StreamStartTs);
        }
    }
}
