using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Diagnostics;
using System.IO;

using System.Text.RegularExpressions;
using System.ComponentModel;
using DashProject.Utils;


namespace DashProject.Utils
{
    public static class FFmpegUtils
    {
        //public static readonly string AppBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;

        /*

        public class FFmpegStandartOutputProcessor
        {
            public event BytesOutputReceivedEventHandler BytesOutputReceived;
            
            private bool partially;
            private List<byte> buffer = new List<byte>();
            private Process process;

            public FFmpegStandartOutputProcessor(Process process, bool partially = true)
            {
                this.partially = partially;
                this.process = process;
                process.Exited += OnWorkDone;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.StandardOutputEncoding = new FFmpegOutputEncoding(dataReceived);
            }

            private void dataReceived(byte[] bytes)
            {
                if (!partially)
                    buffer.AddRange(bytes);
                else
                    BytesOutputReceived(this.process, bytes);
            }

            private void OnWorkDone(Object sender, EventArgs e)
            {
                if (!partially)
                    BytesOutputReceived(this.process, buffer.ToArray());
            }

            public class FFmpegOutputEncoding : Encoding
            {
                private Action<byte[]> action;

                public FFmpegOutputEncoding() { }
                public FFmpegOutputEncoding(Action<byte[]> action) { this.action = action; }

                #region NotImplemented
                public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) { throw new NotImplementedException(); }
                public override byte[] GetBytes(string s) { throw new NotImplementedException(); }
                public override string GetString(byte[] bytes) { throw new NotImplementedException(); }
                public override int GetByteCount(char[] chars, int index, int count) { throw new NotImplementedException(); }
                public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex) { throw new NotImplementedException(); }
                public override int GetCharCount(byte[] bytes, int index, int count) { throw new NotImplementedException(); }
                public override int GetMaxByteCount(int charCount) { throw new NotImplementedException(); }
                #endregion

                public override int GetMaxCharCount(int byteCount) { return 1; }

                public virtual byte[] GetPreamble()
                {
                    return new byte[0];
                }

                public override Decoder GetDecoder()
                {
                    return new FFmpegOutputDecoder(this.action);
                }

                public class FFmpegOutputDecoder : Decoder
                {
                    Action<byte[]> action;

                    public FFmpegOutputDecoder(Action<byte[]> action)
                    {
                        this.action = action;
                    }

                    public override int GetCharCount(byte[] bytes, int index, int count)
                    {
                        throw new NotImplementedException();
                    }

                    public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex)
                    {
                        byte[] newBytes = new byte[byteCount];

                        for (int n = 0; n < byteCount; n++)
                            newBytes[n] = bytes[n];

                        action(newBytes);

                        return 1;
                    }
                }
            }
        }*/
    }
}
