using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DashProject.Api.Enum;
using Manitou.Helper;
using Newtonsoft.Json;

namespace DashProject.Api
{
    public static class FFprobeApi
    {
        private static readonly string argsStringTmpl = "-v quiet -print_format json -show_entries format=format_name,duration:stream=index,time_base,start_pts,duration_ts,codec_type,codec_name,channels,width,height:disposition= {0}";
        private static readonly string argsStringTmplStream = "-v quiet -print_format json -select_streams {0} -show_entries format=format_name,duration:stream=index,time_base,start_pts,duration_ts,codec_type,codec_name,channels,width,height:disposition= {1}";
        private static readonly string argsStringTmplProgram = "-v quiet -print_format json -select_streams p:{0} -show_entries format=format_name,duration:stream=index,time_base,start_pts,duration_ts,codec_type,codec_name,channels,width,height:disposition= {1}";
        private static readonly string argsStringTmplProgramStream = "-v quiet -print_format json -select_streams p:{0}:{1} -show_entries format=format_name,duration:stream=index,time_base,start_pts,duration_ts,codec_type,codec_name,channels,width,height:disposition= {2}";

        public static MediaInfo GetMediaInfo(string filePath)
        {
            string arguments = string.Format(argsStringTmpl, filePath);
            return FFprobe_Get_MediaInfo(arguments);
        }

        public static MediaInfo GetMediaInfo(string filePath, int? programIndex = null)
        {
            if (!programIndex.HasValue)
                return GetMediaInfo(filePath);

            string arguments = string.Format(argsStringTmplProgram, programIndex.Value, filePath);
            return FFprobe_Get_MediaInfo(arguments);
        }

        public static MediaInfo GetMediaInfo(string filePath, int streamIndex, int? programIndex = null)
        {
            string arguments = (programIndex.HasValue) ? string.Format(argsStringTmplProgramStream, programIndex, streamIndex, filePath) : string.Format(argsStringTmplStream, streamIndex, filePath);
            return FFprobe_Get_MediaInfo(arguments);
        }

        private static MediaInfo FFprobe_Get_MediaInfo(string arguments)
        {
            FFprobeProcess probeProcess;
            try
            {
                probeProcess = new FFprobeProcess(arguments);
            }
            catch
            {
                return null;
            }
            if (!probeProcess.Start())
                return null;
            probeProcess.WaitForExit();
            if (probeProcess.ExitCode == (int)FFmpegProcessExitCode.Error)
                return null;
            StringBuilder jsonString = new StringBuilder();
            while (probeProcess.StandardOutput.Peek() != -1)
            {
                jsonString.Append(probeProcess.StandardOutput.ReadLine());
            }
            if (jsonString.Length == 0)
                return null;
            return JsonConvert.DeserializeObject<MediaInfo>(jsonString.ToString());
        }

        private class FFprobeProcess : Process
        {
            public FFprobeProcess(string arguments)
                : base()
            {
                this.StartInfo.Arguments = arguments;
                this.StartInfo.FileName = CoreApi.FFprobeFilePath;
                if (!File.Exists(this.StartInfo.FileName))
                    throw new FileNotFoundException("File not found", this.StartInfo.FileName);

                this.StartInfo.CreateNoWindow = true;
                this.StartInfo.ErrorDialog = false;
                this.StartInfo.UseShellExecute = false;
                this.StartInfo.RedirectStandardOutput = true;
                this.EnableRaisingEvents = true;
            }

            public new bool Start()
            {
                return base.Start();
            }
        }

        [JsonObject]
        public class MediaInfo
        {
            [JsonIgnore]
            public ContainerType? ContainerType
            {
                get
                {
                    string container_format = format.Format_name.Split(',')[0];
                    ContainerType container;
                    if (!System.Enum.TryParse<ContainerType>(container_format, out container))
                        return null;
                    return container;
                }
            }
            [JsonIgnore]
            public decimal? DurationS { get { return format.Duration; } }

            [JsonProperty]
            private Format format { get; set; }

            [JsonObject(MemberSerialization.OptIn)]
            private class Format
            {
                public string Format_name { get { return format_name; } }
                [JsonProperty]
                private string format_name { get; set; }

                public decimal? Duration { get { return duration; } }
                [JsonProperty]
                private decimal? duration { get; set; }
            }

            public IList<Program> Programs { get { return programs; } }

            [JsonProperty]
            private IList<Program> programs { get; set; }

            [JsonObject(MemberSerialization.OptIn)]
            public class Program
            {
                public int Program_num { get { return program_num; } }

                [JsonProperty]
                private int program_num { get; set; }


                public IList<StreamInfo> Streams { get { return streams; } }

                [JsonProperty]
                private IList<StreamInfo> streams { get; set; }
            }

            public IList<StreamInfo> Streams { get { return streams; } }
            [JsonProperty]
            private IList<StreamInfo> streams { get; set; }

            [JsonObject(MemberSerialization.OptIn)]
            public class StreamInfo
            {
                public byte Index { get { return index; } }
                [JsonProperty]
                private byte index { get; set; }

                public StreamType? StreamType
                {
                    get
                    {
                        StreamType type;
                        if (!System.Enum.TryParse<StreamType>(codec_type, out type))
                            return null;
                        return type;
                    }
                }
                [JsonProperty]
                private string codec_type { get; set; }

                private int? timeScale
                {
                    get
                    {
                        int? timeScale = Converter.ToInt32Nullable(Regex.Match(time_base, @"(?<=^1/)\d*$").Value);
                        return timeScale;
                    }
                }
                [JsonProperty]
                private string time_base { get; set; }

                public decimal? DurationS
                {
                    get
                    {
                        if (!duration_ts.HasValue || !timeScale.HasValue)
                            return null;
                        return (decimal)(duration_ts) / timeScale.Value;
                        /*decimal d;
                        if(decimal.TryParse(duration.Replace('.',','), out d))
                            return d;
                        else
                            return null;*/
                    }
                }

                [JsonProperty]
                private int? start_pts { get; set; }

                /*[JsonProperty]
                private string duration { get; set; }*/

                [JsonProperty]
                private int? duration_ts { get; set; }

                public CodecType? Codec
                {
                    get
                    {
                        CodecType codec;
                        if (!System.Enum.TryParse<CodecType>(codec_name, out codec))
                            return null;
                        return codec;
                    }
                }
                [JsonProperty]
                private string codec_name { get; set; }

                public int? Channels { get { return channels; } }
                [JsonProperty]
                private int? channels { get; set; }

                public short? Width { get { return width; } }
                [JsonProperty]
                private short? width { get; set; }

                public short? Height { get { return height; } }
                [JsonProperty]
                private short? height { get; set; }

                /*public Api.Enum.Language? Language
                {
                    get
                    {
                        Api.Enum.Language lang;
                        if (!System.Enum.TryParse<Api.Enum.Language>(language, out lang))
                            return null;
                        return lang;
                    }
                }
                private string language { get; set; }*/
            }
        }
    }
}
