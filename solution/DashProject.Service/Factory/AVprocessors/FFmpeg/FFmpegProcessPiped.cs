using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashProject.Service.Factory.AVprocessors.FFmpeg
{
    public abstract class FFmpegProcessPiped : FFmpegProcess
    {
        private NamedPipeServerStream pipeOutput;
        private NamedPipeServerStream pipeInput;
        private string pipeName;
        private bool isUsePipeIn;
        private bool isUsePipeOut;
        private bool isPartillyOuput;
        private string pipeFullNameTmpl = @"\\.\pipe\{0}";
        private string pipeInNameTmpl = @"{0}_in";
        private string pipeOutNameTmpl = @"{0}_out";
        private string pipeInName;
        private string pipeOutName;

        public FFmpegProcessPiped(FFmpegSetting ffmpegSetting, bool isUsePipeIn, bool isUsePipeOut, bool isPartillyOuput)
            : base(ffmpegSetting)
        {
            this.pipeName = Guid.NewGuid().ToString();
            this.isUsePipeIn = isUsePipeIn;
            this.isUsePipeOut = isUsePipeOut;
            this.isPartillyOuput = isPartillyOuput;

            pipeInName = string.Format(pipeInNameTmpl, pipeName);
            pipeOutName = string.Format(pipeOutNameTmpl, pipeName);

            if (isUsePipeIn)
                this.InputMedia = string.Format(pipeFullNameTmpl, pipeInName);

            if (isUsePipeOut)
                this.OutputMedia = string.Format(pipeFullNameTmpl, pipeOutName);
        }

        public new bool Start()
        {
            bool isStarted = true;

            if (isUsePipeIn)
                pipeInput = new NamedPipeServerStream(pipeInName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            if (isUsePipeOut)
                pipeOutput = new NamedPipeServerStream(pipeOutName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous);

            isStarted = base.Start();

            if (isStarted)
            {
                if (isUsePipeIn && !pipeInput.IsConnected)
                    pipeInput.WaitForConnection();

                if (isUsePipeOut)
                    pipeOutput.BeginWaitForConnection(new AsyncCallback(asyncResult =>
                    {
                        pipeOutput.EndWaitForConnection(asyncResult);
                        BeginReadPipeOut();
                    }), null);

            }
            return isStarted;
        }

        Queue<byte> bufferQueue;

        private const int bufferSize = 4096;
        private byte[] buffer = new byte[bufferSize];

        public void BeginReadPipeOut()
        {
            int bytesCount = pipeOutput.Read(buffer, 0, bufferSize);

            if (bytesCount == 0)
            {
                if (!isPartillyOuput)
                {
                    byte[] bytes = bufferQueue.ToArray();
                    BytesOutputReceived(ref bytes);
                }
                bufferQueue = null;

                pipeOutput.Close();
                pipeOutput = null;

                WorkDoneHandle.Set();
                return;
            }

            byte[] bytesReaded = new byte[bytesCount];
            Array.Copy(buffer, 0, bytesReaded, 0, bytesCount);

            if (isPartillyOuput)
                BytesOutputReceived(ref bytesReaded);

            if (!isPartillyOuput)
            {
                if (bufferQueue == null)
                    bufferQueue = new Queue<byte>();

                for (int n = 0; n < bytesCount; n++)
                    bufferQueue.Enqueue(bytesReaded[n]);
            }
            BeginReadPipeOut();
        }

        public void BeginWriteToPipeInput(byte[] bytes)
        {
            pipeInput.Write(bytes, 0, bytes.Length);
            pipeInput.WaitForPipeDrain();
            pipeInput.Close();
            pipeInput = null;
        }

        public new void Stop(bool disposing = true)
        {
            base.Stop(disposing);
        }

        public new void Stop(int? waitForExitS, bool disposing = true)
        {
            base.Stop(waitForExitS, disposing);
        }

        public new string ToString()
        {
            return base.ToString();
        }

        protected abstract void BytesOutputReceived(ref byte[] bytes);
    }
}
