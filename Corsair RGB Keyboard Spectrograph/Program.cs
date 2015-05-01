using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Audio;
using OpenTK.Audio.OpenAL;

namespace RGBKeyboardSpectrograph
{
    static class Program
    {
        // Version Number
        public static string VersionNumber = "0.5.0";

        // Application Variables
        public static int RunKeyboardThread = 3;
        public static float MyAmplitude;
        public static int MyBarsRed;
        public static int MyBarsGreen;
        public static int MyBarsBlue;
        public static int MyBgRed;
        public static int MyBgGreen;
        public static int MyBgBlue;
        public static float MyBackgroundBrightness;
        public static byte[] MyPositionMap;
        public static float[] MySizeMap;
        public static string MyKeyboardName;
        public static uint MyKeyboardID;
        public static int MyCanvasWidth;
        public static bool MyShowGraphics;
        public static Bitmap MyGraphicRender;
        public static bool MyUsb3Mode;
        public static string MyBackgroundMode;
        public static float MyEffectWidth = 10f;
        public static float MyEffectSpeed = 1f;
        public static float MyEffectStep = 1f;
        public static bool MyViewSettings = false;
        public static bool MyViewDebug = true;

        // Debug Stuff
        public static int TestLed;
        public static int LogLevel = 4;
        public static int RefreshDelay = 20;
        public static int ThreadStatus = 0;
        public static bool FailedPacketLogWritten = false;
        public static bool DevMode = false;
        public static float ColorsPerChannel = 7;

        // Worker Thread
        public static Thread newWorker = null;

        // Create OpenAL audio capture
        //public static AudioCapture myAudioCapture = new AudioCapture(AudioCapture.DefaultDevice, 44100, ALFormat.Mono8, 1024);
        public static AudioCapture myAudioCapture = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                myAudioCapture = new AudioCapture(AudioCapture.DefaultDevice, 44100, ALFormat.Mono8, 1024);
            }
            catch (Exception)
            {
                DialogResult result = MessageBox.Show("No audio input devices could be found. \n\n" +
                "Continuing will result in instability of this program. \n" +
                "Would you like to continue anyway?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                switch (result)
                {
                    case DialogResult.Yes:
                        break;
                    case DialogResult.No:
                        return;
                    default:
                        throw;
                }
            }
            // Initialize the worker thread
            newWorker = new Thread(KBControl.KeyboardControl);

            // Catch exceptions within the application a bit nicer
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Launch the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}