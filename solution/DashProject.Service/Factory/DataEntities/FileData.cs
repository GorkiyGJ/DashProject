using DashProject.Api.Enum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.DataEntities
{
    public class FileData : IData
    {
        public FileInfo File;

        protected FileInfo FileCopy
        {
            get
            {
                return new FileInfo(File.FullName);
            }
        }

        public FileData(FileInfo fileInfo)
        {
            File = fileInfo;
        }

        public DataType Type
        {
            get { return DataType.file; }
        }

        public object Clone()
        {
            return new FileData(FileCopy);
        }
    }
}
