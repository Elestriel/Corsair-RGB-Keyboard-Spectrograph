using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
*/

namespace RGBKeyboardSpectrograph
{
    static class Program
    {
        // Version Number
        public static string VersionNumber = "0.5.2";

        // Application Variables
        public static int RunKeyboardThread = 3;
        public static float MyAmplitude;
        public static int MyBarsRed;
        public static int MyBarsGreen;
        public static int MyBarsBlue;
        public static int MyBgRed;
        public static int MyBgGreen;
        public static int MyBgBlue;
        public static byte[] MyPositionMap;
        public static float[] MySizeMap;
        public static string MyKeyboardName;
        public static uint MyKeyboardID;
        public static int MyCanvasWidth;
        public static bool MyShowGraphics;
        public static Bitmap MyGraphicRender;
        public static bool MyUsb3Mode;
        public static bool MyViewSettings = false;
        public static bool MyViewDebug = true;

        public static string MyBackgroundMode;
        public static float MyEffectWidth = 10f;
        public static float MyEffectSpeed = 1f;
        public static float MyEffectStep = 1f;
        public static float MyBackgroundBrightness;

        public static string MyBarsMode;
        public static float MyBarsWidth = 10f;
        public static float MyBarsSpeed = 1f;
        public static float MyBarsStep = 1f;
        public static float MyBarsBrightness;

        public static bool CSCore_FirstStart = true;
       // public static bool CSCore_DeviceAlive = false;
        public static bool CSCore_NewDevice = true;
        public static int CSCore_DeviceType = 0;
        public static bool CSCore_CaptureStarted = false;

        // Debug Stuff
        public static int TestLed;
        public static int LogLevel = 4;
        public static int RefreshDelay = 20;
        public static int ThreadStatus = 0;
        public static bool FailedPacketLogWritten = false;
        public static bool DevMode = false;
        public static int ColorModeDivisor = 32;
        public static float ColorsPerChannel = 7;
        public static string[] VersionCheckData = new string[4];

        // Worker Thread
        public static Thread newWorker = null;

        // NAudio Capture
//        public static IWaveIn NAudioWaveIn;
        //public static WaveFileWriter NAudioWriter;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Catch exceptions within the application a bit nicer
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Launch the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }
}