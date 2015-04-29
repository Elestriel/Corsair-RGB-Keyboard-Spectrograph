using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBKeyboardSpectrograph
{
    using Lomont;
    using OpenTK.Audio;
    using OpenTK.Audio.OpenAL;
    class KBControl
    {
        public static void KeyboardControl()
        {
            var audioBuffer = new byte[1024];
            var fftData = new byte[1024];
            var fft = new double[1024];

            var fftTransformer = new LomontFFT();

            var writer = new KeyboardWriter();
            if (Program.RunKeyboardThread == 1) 
            {
                UpdateWorkerThread.UpdateAction("Stop");
                return;
            };

            AudioCapture audioCapture = Program.myAudioCapture;
            try
            {
                if (Program.RunKeyboardThread != 4)
                {
                    audioCapture.Start();
                    audioCapture.ReadSamples(audioBuffer, 1024);
                }
            }
            catch (NullReferenceException)
            {
                UpdateStatusMessage.ShowStatusMessage(3, "Audio capture couldn't be started.");
                UpdateWorkerThread.UpdateAction("Stop");
                return;
            }
            catch (Exception)
            {

            }

            int CanvasWidth = Program.MyCanvasWidth;

            while (true)
            {
                for (int j = 0; j < (Program.MyCanvasWidth - 1); j++)
                {
                    if (Program.RunKeyboardThread == 0) 
                    {
                        try
                        {
                            audioCapture.Stop();
                        }
                        catch { }
                        return;
                    };
                    if (Program.RunKeyboardThread == 4)
                    {
                        writer.Write(-1, fftData, Program.TestLed);
                        Thread.Sleep(20);
                    }
                    if (Program.RunKeyboardThread == 2)
                    {
                        if (Program.ThreadStatus != 1) { Program.ThreadStatus = 1; };
                        // reset mem
                        for (int i = 0; i < 1024; i++)
                        {
                            audioBuffer[i] = 0;
                            fftData[i] = 0;
                            fft[i] = 0;
                        }

                        audioCapture.ReadSamples(audioBuffer, 1024);

                        for (int i = 0; i < 1024; i++)
                        {
                            fft[i] = (audioBuffer[i]) * Program.MyAmplitude;
                        }

                        fftTransformer.RealFFT(fft, true);

                        for (int i = 0; i < 1024; i += 2)
                        {
                            double fftmag = Math.Sqrt((fft[i] * fft[i]) + (fft[i + 1] * fft[i + 1]));
                            fftData[i] = (byte)(fftmag / 32);
                            fftData[i + 1] = fftData[i];
                        }
                        writer.Write(j, fftData, CanvasWidth);

                        Thread.Sleep(Program.RefreshDelay);
                    }
                }
            }
        }
    }
}

/* Thread Status Index
 * 0: Destroyed
 * 1: Initiation Failed
 * 2: Running
 * 3: Created but not started
 * 4: Test Mode
 */