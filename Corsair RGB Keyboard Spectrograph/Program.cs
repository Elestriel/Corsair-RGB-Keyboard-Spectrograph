using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBKeyboardSpectrograph
{
    static class Program
    {
        // Version Number
        public static string VersionNumber = "0.6.0pre1";

        // Application Variables
        public static byte[] MyPositionMap;
        public static float[] MySizeMap;
        public static int MyCanvasWidth;
        public static int ColorModeDivisor = 32;
        public static float ColorsPerChannel = 7;

        // Spectrograph
        public static int RunKeyboardThread = 3;
        public static float SpectroAmplitude;
        public static bool SpectroShowGraphics;
        public static Bitmap SpectroGraphicRender;
        public static EffectSettings SpectroBg = new EffectSettings();
        public static EffectSettings SpectroBars = new EffectSettings();

        // Settings
        public static string SettingsKeyboardName;
        public static uint SettingsKeyboardID;
        public static bool SettingsUsb3Mode;
        public static bool SettingsRestoreOnExit = false;
        public static bool SettingLaunchCueOnExit = false;

        public static bool CSCore_FirstStart = true;
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
        public static string[] VersionCheckData = new string[4];

        // Worker Thread
        public static Thread newWorker = null;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Catch exceptions within the application a bit nicer
//            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Launch the main form
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

    }

    // Settings Classes
    public class ColorCollection {
        public int Red;
        public int Grn;
        public int Blu;
        public void Set(int r, int g, int b)
        {
            this.Red = r;
            this.Grn = g;
            this.Blu = b;
        }
        public void Set(Color c) {
            this.Red = c.R;
            this.Grn = c.G;
            this.Blu = c.B;
        }

        public void SetD(int r, int g, int b)
        {
            this.Red = r / Program.ColorModeDivisor;
            this.Grn = g / Program.ColorModeDivisor;
            this.Blu = b / Program.ColorModeDivisor;
        }
        public void SetD(Color c)
        {
            this.Red = c.R / Program.ColorModeDivisor;
            this.Grn = c.G / Program.ColorModeDivisor;
            this.Blu = c.B / Program.ColorModeDivisor;
        }
    }

    public class EffectSettings
    {
        public ColorCollection Color = new ColorCollection();
        public string Mode;
        public float Width;
        public float Speed;
        public float Step;
        public float Brightness;

        public void Set(string Mode, float Width, float Speed, float Step, float Brightness)
        {
            this.Mode = Mode;
            this.Width = Width;
            this.Speed = Speed;
            this.Step = Step;
            this.Brightness = Brightness;
        }
        public void StepIncrement(double max) 
        {
            this.Step += this.Speed;
            if (this.Step >= max) { this.Step = 1; };
        }
    }
}