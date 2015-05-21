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
    using CSCore;
    using CSCore.SoundIn;
    using CSCore.DSP;
    using CSCore.Utils;
    using CSCore.CoreAudioAPI;

    class SampleAggregator
    {
        // FFT
        public event EventHandler<FftEventArgs> FftCalculated;
        public bool PerformFFT { get; set; }

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
                fftBuffer[fftPos].Real = value * FastFourierTransformation.HammingWindowF(fftPos, fftLength);
                fftBuffer[fftPos].Imaginary = 0; // This is always zero with audio.
                fftPos++;
                if (fftPos >= fftLength)
                {
                    fftPos = 0;
                    FastFourierTransformation.Fft(fftBuffer, m, FftMode.Forward);
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

    class SpectroControl
    {
        private static WasapiCapture capture;
        private static KeyboardWriter keyWriter;

        private static int fftLength;
        private static SampleAggregator sampleAggregator;
        
        // StopWatch for loop speed
        private static Stopwatch sw;

        private static void CreateDeviceHandles()
        {
            if (Program.CSCore_FirstStart == false)
            {
                // Clear out the old event subscriptions
                sampleAggregator.FftCalculated -= new EventHandler<FftEventArgs>(FftCalculated);
                capture.DataAvailable -= new EventHandler<DataAvailableEventArgs>(CSCore_DataAvailable);
            }

            sampleAggregator.PerformFFT = true;
            sampleAggregator.FftCalculated += new EventHandler<FftEventArgs>(FftCalculated);

            capture.DataAvailable += new EventHandler<DataAvailableEventArgs>(CSCore_DataAvailable);
        }

        private static void CSCore_DataAvailable(object sender, DataAvailableEventArgs e)
        {
            if (Program.CSCore_CaptureStarted != true) { Program.CSCore_CaptureStarted = true; };
            if (Program.RunKeyboardThread != 2) { CSCore_StopCapture(); };
            byte[] buffer = e.Data;
            int bytesRecorded = e.ByteCount;
            int bufferIncrement = capture.WaveFormat.BlockAlign;


            for (int index = 0; index < bytesRecorded; index += bufferIncrement)
            {
                float sample32 = BitConverter.ToSingle(buffer, index);
                if (sampleAggregator.Add(sample32 * Program.SpectroAmplitude * 50) == true)
                {
                    break;
                };
            }
        }

        private static void CSCore_StopCapture()
        {
            try { capture.Stop(); }
            catch { }
            CSCore_Cleanup();
        }

        private static void CSCore_Cleanup()
        {
            if (capture != null)
            {
                capture.Dispose();
                capture = null;
            }
        }

        private static void FftCalculated(object sender, FftEventArgs e)
        {
            int CanvasWidth = Program.MyCanvasWidth;

            byte[] fftData = new byte[fftLength];
            KeyboardWriter KeyWriter = keyWriter;

            for (int i = 0; i < fftLength; i++)
            {
                e.Result[i].Real = e.Result[i].Real;
                e.Result[i].Imaginary = e.Result[i].Imaginary;
                double fftmag = Math.Sqrt((e.Result[i].Real * e.Result[i].Real) + (e.Result[i].Imaginary * e.Result[i].Imaginary));
                fftData[i] = (byte)(fftmag);
            }
            keyWriter.Write(1, fftData, CanvasWidth);
            if (Program.LogLevel == 5)
            {
                UpdateStatusMessage.ShowStatusMessage(10, "Loop Time: " + sw.ElapsedMilliseconds);
                sw.Restart();
            };
            if (Program.RefreshDelay > 0) { Thread.Sleep(Program.RefreshDelay); };
        }
        
        public static void KeyboardControl(int captureType, MMDevice captureDevice)
        {
            if (Program.RunKeyboardThread == 4)
            {
                keyWriter = new KeyboardWriter();
                while (Program.RunKeyboardThread == 4) {
                    keyWriter.Write(-1, null, Program.TestLed);
                    Thread.Sleep(20);
                }
            }
            else
            {
                Program.CSCore_CaptureStarted = false;

                switch (captureType)
                {
                    case 0:
                        capture = new WasapiLoopbackCapture();
                        break;
                    case 1:
                        capture = new WasapiCapture();
                        capture.Device = captureDevice;
                        break;
                    default:
                        capture = new WasapiLoopbackCapture();
                        break;
                }

                capture.Initialize();
                int captureSampleRate = capture.WaveFormat.SampleRate;
                switch (captureSampleRate)
                {
                    case 48000:
                        fftLength = 1024;
                        break;
                    case 96000:
                        fftLength = 2048;
                        break;
                    case 192000:
                        fftLength = 4096;
                        break;
                    default:
                        fftLength = 1024;
                        break;
                }

                sampleAggregator = new SampleAggregator(fftLength);

                CreateDeviceHandles();
                Program.CSCore_NewDevice = false;

                keyWriter = new KeyboardWriter();

                sw = new Stopwatch();
                sw.Start(); // Start loop counting stopwatch

                if (Program.RunKeyboardThread != 0)
                {
                    UpdateStatusMessage.ShowStatusMessage(2, "Starting Capture");
                    capture.Start();
                }
                Program.CSCore_FirstStart = false;


                while (Program.CSCore_CaptureStarted == false)
                {
                    if (Program.RunKeyboardThread != 2)
                    {
                        CSCore_StopCapture();
                        break;
                    };
                }
            }
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