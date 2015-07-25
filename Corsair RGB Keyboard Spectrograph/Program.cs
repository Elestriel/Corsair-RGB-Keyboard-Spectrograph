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
        public static string VersionNumber = "0.6.3pre1";

        // Application Variables
        public static byte[] MyPositionMap;
        public static float[] MySizeMap;
        public static Color[] StaticKeyColors = new Color[144];
        public static StaticColorCollection[] StaticKeyColorsBytes = new StaticColorCollection[144];
        public static MouseColorCollection[] MouseColors = new MouseColorCollection[4];
        public static int MyCanvasWidth;
        public static int ColorModeDivisor = 32;
        public static float ColorsPerChannel = 7;
        public static string StaticProfilesPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Profiles\\";

        // Cross-thread variables
        public volatile static int RunKeyboardThread = -1;
        public volatile static bool WatchForInactivity = false;
        public volatile static int InactivityTimeTrigger = 0;
        public volatile static string InactivityResumeAction;
        public volatile static bool IgnoreUpdateLastProfile = false;
        public volatile static bool IncludeMouseInEffects = false;

        // Spectrograph
        public static float SpectroAmplitude;
        public static bool SpectroShowGraphics;
        public static Bitmap SpectroGraphicRender;
        public static SpectroSettings SpectroBg = new SpectroSettings();
        public static SpectroSettings SpectroBars = new SpectroSettings();

        // Effects
        public static EffectSettings EfSettings = new EffectSettings();
        public static EffectColorSettings EfColors = new EffectColorSettings();
        public static bool AnimationsUseStaticKeys = false;

        // Settings
        public static string SettingsKeyboardModel;
        public static string SettingsKeyboardLayout;
        public static uint SettingsKeyboardID;
        public static uint SettingsMouseID;
        public static string SettingsMouseModel;
        public static bool SettingsUsb3Mode;
        public static bool SettingsRestoreOnExit = false;
        public static bool SettingLaunchCueOnExit = false;
        public static string SettingsLastUsedProfile;
        public static bool StaticKeysNeedRedraw = false;

        public static bool CSCore_FirstStart = true;
        public static bool CSCore_NewDevice = true;
        public static int CSCore_DeviceType = 0;
        public static bool CSCore_CaptureStarted = false;

        // Debug Stuff
        public static int TestLed;
        public static int LogLevel = 3;
        public static int RefreshDelay = 10;
        public static int ThreadStatus = 0;
        public static bool FailedPacketLogWritten = false;
        public static bool DevMode = true;
        public static string[] VersionCheckData = new string[4];

        // Worker Thread
        public volatile static Thread newWorker = null;
        public volatile static Thread idleThread = null;
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Catch exceptions within the application a bit nicer, disabled for dev mode
            if (DevMode == false)
            {
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }

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

    public class SpectroSettings
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

    public class StaticColorCollection
    {
        public bool Transparent;
        public int Red;
        public int Grn;
        public int Blu;
        public Color KeyColor
        {
            get
            {
                return Color.FromArgb(255, Red, Grn, Blu);
            }
        }

        public void Set(Color c)
        {
            if (c == Color.Transparent)
            {
                this.Transparent = true;
            }
            else
            {
                this.Transparent = false;
                this.Red = c.R;
                this.Grn = c.G;
                this.Blu = c.B;
            }
        }

        public void SetD(Color c)
        {
            if (c == Color.Transparent)
            {
                this.Transparent = true;
            }
            else
            {
                this.Transparent = false;
                this.Red = c.R / Program.ColorModeDivisor;
                this.Grn = c.G / Program.ColorModeDivisor;
                this.Blu = c.B / Program.ColorModeDivisor;
            }
        }
    }

    public class EffectSettings {
        public int Duration;
        public int Frequency;
        public int Speed;

        public void Set(int duration, int frequency, int speed)
        {
            this.Speed = speed;
            this.Duration = duration;
            this.Frequency = frequency;
        }
    }

    public class EffectColorSettings
    {
        public int Mode;
        public byte StartR, StartG, StartB;
        public byte EndR, EndG, EndB;
        public int SRandRLow, SRandRHigh;
        public int SRandGLow, SRandGHigh;
        public int SRandBLow, SRandBHigh;
        public int ERandRLow, ERandRHigh;
        public int ERandGLow, ERandGHigh;
        public int ERandBLow, ERandBHigh;

        public void SetStart(byte sR, byte sG, byte sB,
                        int mode)
        {
            this.Mode = mode;
            this.StartR = sR; this.StartG = sG; this.StartB = sB;
        }

        public void SetStart(int SrrLow, int SrrHigh,
                int SrgLow, int SrgHigh,
                int SrbLow, int SrbHigh,
                int mode)
        {
            this.Mode = mode;
            this.SRandRLow = SrrLow; this.SRandRHigh = SrrHigh;
            this.SRandGLow = SrgLow; this.SRandGHigh = SrgHigh;
            this.SRandBLow = SrbLow; this.SRandBHigh = SrbHigh;
        }

        public void SetEnd(byte eR, byte eG, byte eB,
                        int mode)
        {
            this.Mode = mode;
            this.EndR = eR; this.EndG = eG; this.EndB = eB;
        }

        public void SetEnd(int ErrLow, int ErrHigh,
                int ErgLow, int ErgHigh,
                int ErbLow, int ErbHigh,
                int mode)
        {
            this.Mode = mode;
            this.ERandRLow = ErrLow; this.ERandRHigh = ErrHigh;
            this.ERandGLow = ErgLow; this.ERandGHigh = ErgHigh;
            this.ERandBLow = ErbLow; this.ERandBHigh = ErbHigh;
        }
    }

    public class MouseColorCollection
    {
        public bool Transparent;
        public int Red;
        public int Grn;
        public int Blu;
        public Color KeyColor
        {
            get
            {
                return Color.FromArgb(255, Red, Grn, Blu);
            }
        }

        public void Set(Color c)
        {
            if (c == Color.Transparent)
            {
                this.Transparent = true;
                this.Red = 0;
                this.Grn = 0;
                this.Blu = 0;
            }
            else
            {
                this.Transparent = false;
                this.Red = c.R;
                this.Grn = c.G;
                this.Blu = c.B;
            }
        }

        public void SetD(Color c)
        {
            if (c == Color.Transparent)
            {
                this.Transparent = true;
            }
            else
            {
                this.Transparent = false;
                this.Red = c.R / Program.ColorModeDivisor;
                this.Grn = c.G / Program.ColorModeDivisor;
                this.Blu = c.B / Program.ColorModeDivisor;
            }
        }
    }
}