using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DashProject.Api.Enum;
using MatrixIO.IO.Bmff;
using MatrixIO.IO.Bmff.Boxes;

namespace DashProject.Api  
{
    public abstract class Data : ICloneable
    {
        public abstract DataType Type { get; }
        public abstract object Clone();
    };

    public class BytesData_TimeStamp : Data
    {
        public byte[] Bytes { get { return BoxedData == null ? new byte[0] : this.BoxedData as byte[]; } }

        protected object BoxedData;
        public decimal StreamStartTs;

        public BytesData_TimeStamp(byte[] bytes, decimal streamStartTs)
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

        public override DataType Type
        {
            get { return DataType.bytes_ts; }
        }

        public override object Clone()
        {
            return new BytesData_TimeStamp(BytesCopy, StreamStartTs);
        }
    }

    public class FileData : Data
    {
        public FileInfo File;
        
        protected FileInfo FileCopy {
            get
            {
                return new FileInfo(File.FullName);
            }
        }

        public FileData(FileInfo fileInfo)
        {
            File = fileInfo;
        }

        public override DataType Type
        {
            get { return DataType.file; }
        }

        public override object Clone()
        {
            return new FileData(FileCopy);
        }
    }

    public class FileData_TimeStamps : Data
    {
        public FileInfo File;

        protected FileInfo FileCopy
        {
            get
            {
                return new FileInfo(File.FullName);
            }
        }

        public FileData_TimeStamps(FileInfo fileInfo, Dictionary<int, decimal> streamsStartTs)
        {
            File = fileInfo;
            StreamsStartTs = streamsStartTs;
        }

        public Dictionary<int, decimal> StreamsStartTs;

        public override DataType Type
        {
            get { return DataType.file_streams_ts; }
        }

        public override object Clone()
        {
            Dictionary<int, decimal> newStreamsStartTs = new Dictionary<int, decimal>();
            foreach (KeyValuePair<int, decimal> item in StreamsStartTs)
                newStreamsStartTs.Add(item.Key, item.Value);

            return new FileData_TimeStamps(FileCopy, newStreamsStartTs);
        }
    }

}
