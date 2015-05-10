using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBKeyboardSpectrograph
{
    using NAudio;
    using NAudio.Wave;
    using NAudio.Dsp;
    using NAudio.CoreAudioApi;
    
    class SampleAggregator
    {
        // FFT
        public event EventHandler<FftEventArgs> FftCalculated;
        public bool PerformFFT { get; set; }

        // This Complex is NAudio's own! 
        private Complex[] fftBuffer;
        private FftEventArgs fftArgs;
        private int fftPos;
        private int fftLength;
        private int m;

        public SampleAggregator(int fftLength)
        {
            if (!IsPowerOfTwo(fftLength))
            {
                throw new ArgumentException("FFT Length must be a power of two");
            }
            this.m = (int)Math.Log(fftLength, 2.0);
            this.fftLength = fftLength;
            this.fftBuffer = new Complex[fftLength];
            this.fftArgs = new FftEventArgs(fftBuffer);
        }

        bool IsPowerOfTwo(int x)
        {
            return (x & (x - 1)) == 0;
        }

        public bool Add(float value)
        {
            if (PerformFFT && FftCalculated != null)
            {
                // Remember the window function! There are many others as well.
                fftBuffer[fftPos].X = (float)(value * FastFourierTransform.HammingWindow(fftPos, fftLength));
                fftBuffer[fftPos].Y = 0; // This is always zero with audio.
                fftPos++;
                if (fftPos >= fftLength)
                {
                    fftPos = 0;
                    FastFourierTransform.FFT(true, m, fftBuffer);
                    FftCalculated(this, fftArgs);
                    return true;
                }
            }
            return false;
        }
    }

    public class FftEventArgs : EventArgs
    {
        [DebuggerStepThrough]
        public FftEventArgs(Complex[] result)
        {
            this.Result = result;
        }
        public Complex[] Result { get; private set; }
    }

    class KBControl
    {
        private static IWaveIn waveIn; // = Program.NAudioWaveIn;
        private static KeyboardWriter keyWriter; // = new KeyboardWriter();

        // More NAudio Stuff
        private static int fftLength = 1024; // NAudio fft wants powers of two!

        // There might be a sample aggregator in NAudio somewhere but I made a variation for my needs
        private static SampleAggregator sampleAggregator = new SampleAggregator(fftLength);

        #region NAudio
        private static void NAudio_CreateDeviceHandles()
        {
            if (Program.NAudio_FirstStart == false)
            {
                // Clear out the old event subscriptions
                sampleAggregator.FftCalculated -= new EventHandler<FftEventArgs>(FftCalculated);
                waveIn.DataAvailable -= NAudio_OnDataAvailable;
                waveIn.RecordingStopped -= NAudio_OnRecordingStopped;
            }

            sampleAggregator.PerformFFT = true;
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);

            waveIn.DataAvailable += NAudio_OnDataAvailable;
            waveIn.RecordingStopped += NAudio_OnRecordingStopped;
        }

        private static void NAudio_StartCapture()
        {
            waveIn.StartRecording();
        }

        private static void NAudio_OnRecordingStopped(object sender, StoppedEventArgs e)
        {
            Program.NAudio_DeviceAlive = false;
            UpdateStatusMessage.ShowStatusMessage(10, "Stopped");
        }

        private static void NAudio_StopCapture()
        {
            if (waveIn != null) { waveIn.StopRecording(); };
        }

        private static void NAudio_OnDataAvailable(object sender, WaveInEventArgs e)
        {
            if (Program.RunKeyboardThread != 2) { NAudio_StopCapture(); };
            byte[] buffer = e.Buffer;
            int bytesRecorded = e.BytesRecorded;
            int bufferIncrement = waveIn.WaveFormat.BlockAlign;
            
            for (int index = 0; index < bytesRecorded; index = index + bufferIncrement)
            {
                float sample32 = BitConverter.ToSingle(buffer, index);
                if (sampleAggregator.Add(sample32) == true) {
                    break; 
                };
            }
             
        }

        private static void FftCalculated(object sender, FftEventArgs e)
        {
            int CanvasWidth = Program.MyCanvasWidth;

            byte[] fftData = new byte[1024];
            KeyboardWriter KeyWriter = keyWriter;

            for (int i = 0; i < 1024; i++)
            {
                e.Result[i].X = e.Result[i].X * 100 * Program.MyAmplitude;
                e.Result[i].Y = e.Result[i].Y * 100 * Program.MyAmplitude;
                double fftmag = Math.Sqrt((e.Result[i].X * e.Result[i].X) + (e.Result[i].Y * e.Result[i].Y));
                fftData[i] = (byte)(fftmag);
            }
            keyWriter.Write(1, fftData, CanvasWidth);
            Thread.Sleep(Program.RefreshDelay);
        }
        #endregion NAudio

        public static void KeyboardControl()
        {
            waveIn = Program.NAudioWaveIn;
//            if (Program.NAudio_FirstStart == true)
//            {
                NAudio_CreateDeviceHandles();
                Program.NAudio_DeviceAlive = true;
                Program.NAudio_NewDevice = false;
//            };

            keyWriter = new KeyboardWriter();
            if (Program.RunKeyboardThread != 0)
            {
                UpdateStatusMessage.ShowStatusMessage(2, "Starting Capture");
                waveIn.StartRecording();
            }
            Program.NAudio_FirstStart = false;
        }
    }
}

/* Thread Status Index
 * 0: Destroyed
 * 1: Initiation Failed
 * 2: Running
 * 3: Not yet created
 * 4: Test Mode
 */