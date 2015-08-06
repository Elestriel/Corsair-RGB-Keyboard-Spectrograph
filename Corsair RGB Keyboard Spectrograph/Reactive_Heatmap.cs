using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RGBKeyboardSpectrograph
{
    public class Reactive_Heatmap
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        static HeatmapKey[] keyMatrix = new HeatmapKey[144];
        static StaticColorCollection[] sendMatrix = new StaticColorCollection[144];
        static RawInputKeyCodes keys = new RawInputKeyCodes();

        public void KeyboardControl()
        {
            if (Program.RunKeyboardThread != 11) { return; };

            UpdateStatusMessage.ShowStatusMessage(2, "Starting Heatmap");

            // Raw Input Hook
            // http://www.codeproject.com/Articles/558413/Minimal-Key-Logger-Using-RAWINPUT
            //Program.InputHook = new RawInputHook();
            Program.InputHook.OnRawInputFromKeyboard += InputFromKeyboard_Heatmap;

            KeyboardWriter keyWriter = new KeyboardWriter();

            int sR = 0; int sG = 0; int sB = 0;
            int eR = 0; int eG = 0; int eB = 0;

            sR = Program.HeatmapColors.StartR;
            sG = Program.HeatmapColors.StartG;
            sB = Program.HeatmapColors.StartB;

            eR = Program.HeatmapColors.EndR;
            eG = Program.HeatmapColors.EndG;
            eB = Program.HeatmapColors.EndB;

            for (int i = 0; i < 144; i++)
            {
                keyMatrix[i] = new HeatmapKey(
                    (byte)sR,
                    (byte)sG,
                    (byte)sB,
                    (byte)eR,
                    (byte)eG,
                    (byte)eB);
                sendMatrix[i] = new StaticColorCollection();
            }


            while (Program.RunKeyboardThread == 11)
            {
                for (int i = 0; i < 144; i++)
                {
                    sendMatrix[i].SetD(keyMatrix[i].KeyColor);
                }

                keyWriter.Write(sendMatrix, true);

                Thread.Sleep(100);
            }

            Program.InputHook.OnRawInputFromKeyboard -= InputFromKeyboard_Heatmap;

            UpdateStatusMessage.ShowStatusMessage(2, "Stopping Heatmap");
        }

        public void InputFromKeyboard_Heatmap(RAWINPUTHEADER riHeader, RAWKEYBOARD riKeyboard)
        {
            if (riKeyboard.Flags == 0x0) { return; };
            if (riKeyboard.Flags == 0x2 && Control.IsKeyLocked(Keys.NumLock)) { return; };

            int currentKey = keys.GetKeyCode(riKeyboard.MakeCode, riKeyboard.VKey, riKeyboard.Flags, Control.IsKeyLocked(Keys.NumLock));

            keyMatrix[currentKey].NewStrike();
        }

        public void ResetKeyStrikeCounts()
        {
            for (int i = 0; i < 144; i++)
            {
                keyMatrix[i].ResetCount();
            }
        }
    }

    class HeatmapKey
    {
        private byte R;
        private byte G;
        private byte B;
        private int strikes;
        public Color KeyColor
        {
            get
            {
                ReloadIntensity(
                    Program.HeatmapColors.StartR,
                    Program.HeatmapColors.StartG,
                    Program.HeatmapColors.StartB,
                    Program.HeatmapColors.EndR,
                    Program.HeatmapColors.EndG,
                    Program.HeatmapColors.EndB);
                return Color.FromArgb(255, this.R, this.G, this.B); }
        }

        private byte RMin, GMin, BMin, RMax, GMax, BMax;

        public HeatmapKey(byte RMin, byte GMin, byte BMin, byte RMax, byte GMax, byte BMax)
        {
            this.RMin = RMin;
            this.GMin = GMin;
            this.BMin = BMin;
            this.RMax = RMax;
            this.GMax = GMax;
            this.BMax = BMax;
            this.R = RMin;
            this.G = GMin;
            this.B = BMin;
        }

        public void NewStrike()
        {
            this.strikes += 1;
            if (this.strikes > Program.HighestStrikeCount) { Program.HighestStrikeCount = this.strikes; };

            ReloadIntensity();
        }

        public void ResetCount()
        {
            strikes = 0;
        }

        public void ReloadIntensity(byte RMin, byte GMin, byte BMin, byte RMax, byte GMax, byte BMax)
        {
            this.RMin = RMin;
            this.GMin = GMin;
            this.BMin = BMin;
            this.RMax = RMax;
            this.GMax = GMax;
            this.BMax = BMax;
            ReloadIntensity();
        }

        public void ReloadIntensity()
        {
            double intensity;
            if (Program.HighestStrikeCount == 0) { intensity = 1; }
            else { intensity = 1 - ((double)this.strikes / (double)Program.HighestStrikeCount); };

            // Make sure that keys can't turn completely off.
            if (intensity > .85 && intensity != 1) { intensity = .85; };

            this.R = (byte)(RMax - ((RMax - RMin) * intensity));
            this.G = (byte)(GMax - ((GMax - GMin) * intensity));
            this.B = (byte)(BMax - ((BMax - BMin) * intensity));
        }
    }
}
