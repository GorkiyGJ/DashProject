using DashProject.Api.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.DataEntities
{
    public class FileDataTimeStamps : IData
    {
        public FileInfo File;

        protected FileInfo FileCopy
        {
            get
            {
                return new FileInfo(File.FullName);
            }
        }
        public FileDataTimeStamps(FileInfo fileInfo, Dictionary<int, decimal> streamsStartTs)
        {
            File = fileInfo;
            StreamsStartTs = streamsStartTs;
        }

        public Dictionary<int, decimal> StreamsStartTs;

        public DataType Type
        {
            get { return DataType.file_streams_ts; }
        }

        public object Clone()
        {
            Dictionary<int, decimal> newStreamsStartTs = new Dictionary<int, decimal>();
            foreach (KeyValuePair<int, decimal> item in StreamsStartTs)
                newStreamsStartTs.Add(item.Key, item.Value);

            return new FileDataTimeStamps(FileCopy, newStreamsStartTs);
        }
    }
}
