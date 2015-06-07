using DashProject.Service.Factory.AVprocessors.FFmpeg;
using DashProject.Service.Factory.DataEntities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.AVprocessors.Segmenter
{
    public class Segmenter : FFmpegProcess
    {
        private FileSystemWatcher fileWatcher;
        private Queue<string> segmentsFilesQueue;

        public Segmenter(FFmpegSetting ffmpegSettings)
            : base(ffmpegSettings)
        {
            string pathToWatch = Path.GetDirectoryName(ffmpegSettings.OutputMedia);
            fileWatcher = new FileSystemWatcher(pathToWatch);
            fileWatcher.NotifyFilter = NotifyFilters.CreationTime | NotifyFilters.FileName;
            fileWatcher.Filter = "*.*";
            fileWatcher.Created += fileWatcher_Created;
            segmentsFilesQueue = new Queue<string>();
        }

        public bool Start()
        {
            fileWatcher.EnableRaisingEvents = true;
            bool isStarted = base.Start();
            return isStarted;
        }

        public void Stop()
        {
            fileWatcher.EnableRaisingEvents = false;
            fileWatcher.Dispose();
            base.Stop(2000);
        }

        private void fileWatcher_Created(object sender, FileSystemEventArgs e)
        {
            segmentsFilesQueue.Enqueue(e.FullPath);

            if (segmentsFilesQueue.Count == 1)
                return;

            string filePath = segmentsFilesQueue.Dequeue();

            FileOutputReceived(new FileData(new FileInfo(filePath)));
        }

        public delegate void FileOutputReceivedEventHandler(FileData file);
        public event FileOutputReceivedEventHandler FileOutputReceived = delegate { }; // add empty delegate!;
    }
}
