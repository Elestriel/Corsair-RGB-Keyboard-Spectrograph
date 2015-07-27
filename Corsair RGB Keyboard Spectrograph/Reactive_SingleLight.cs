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
    public class Reactive_SingleLight
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);

        static SingleKeyFade[] keyMatrix = new SingleKeyFade[144];
        static StaticColorCollection[] sendMatrix = new StaticColorCollection[144];
        static RawInputKeyCodes keys = new RawInputKeyCodes();

        Random rnd = new Random();

        public void KeyboardControl()
        {
            if (Program.RunKeyboardThread != 10) { return; };

            UpdateStatusMessage.ShowStatusMessage(2, "Starting Reactive Typing");

            // Raw Input Hook
            // http://www.codeproject.com/Articles/558413/Minimal-Key-Logger-Using-RAWINPUT
            //Program.InputHook = new RawInputHook();
            Program.InputHook.OnRawInputFromKeyboard += InputFromKeyboard_SingleLight;

            KeyboardWriter keyWriter = new KeyboardWriter();

            InitiateReactiveBackground();

            while (Program.RunKeyboardThread == 10)
            {
                for (int i = 0; i < 144; i++)
                {
                    sendMatrix[i].SetD(keyMatrix[i].KeyColor);
                    keyMatrix[i].IncrementStep();
                }
                
                keyWriter.Write(sendMatrix, true);

                Thread.Sleep(Program.ReactSettings.Frequency);
            }

            //Program.InputHook.OnRawInputFromKeyboard -= InputFromKeyboard_SingleLight;

            UpdateStatusMessage.ShowStatusMessage(2, "Stopping Reactive Typing");
        }

        public void InitiateReactiveBackground()
        {

            for (int i = 0; i < 144; i++)
            {
                if (Program.StaticKeyColors[i] == Color.Transparent)
                {
                    keyMatrix[i] = new SingleKeyFade(
                        20,
                        (byte)0,
                        (byte)0,
                        (byte)0,
                        (byte)0,
                        (byte)0,
                        (byte)0);
                }
                else
                {
                    keyMatrix[i] = new SingleKeyFade(
                        20,
                        (byte)0,
                        (byte)0,
                        (byte)0,
                        (byte)Program.StaticKeyColors[i].R,
                        (byte)Program.StaticKeyColors[i].G,
                        (byte)Program.StaticKeyColors[i].B);
                }
                sendMatrix[i] = new StaticColorCollection();
            }
        }

        public void InputFromKeyboard_SingleLight(RAWINPUTHEADER riHeader, RAWKEYBOARD riKeyboard)
        {
            if (riKeyboard.Flags == 0x0) { return; };
            if (riKeyboard.Flags == 0x2 && Control.IsKeyLocked(Keys.NumLock)) { return; };
            
            /*
            string s = "";
            s = s + "0x" + riKeyboard.MakeCode.ToString("X4");
            s = s + "  0x" + riKeyboard.VKey.ToString("X4");
            //            s = s + "  Mssg: 0x" + riKeyboard.Message.ToString("X4");
            s = s + "  0x" + riKeyboard.Flags.ToString("X4");
            //            s = s + "   Rsrvd: 0x" + riKeyboard.Reserved.ToString("X4");
            //            s = s + "   ExInf: 0x" + riKeyboard.ExtraInformation.ToString("X4");
            //            s = s + "  Devc: 0x" + riHeader.hDevice.ToString("X4");
            //            s = s + "   .Size: 0x" + riHeader.dwSize.ToString("X4");
            //            s = s + "   .Type: 0x" + riHeader.dwType.ToString("X4");
            //            s = s + "   wPara: 0x" + riHeader.wParam.ToString("X4");
            System.Diagnostics.Debug.Write(s);
            UpdateStatusMessage.ShowStatusMessage(5, s);
             * */

            int currentKey = keys.GetKeyCode(riKeyboard.MakeCode, riKeyboard.VKey, riKeyboard.Flags);
            int sR = 0; int sG = 0; int sB = 0; 
            int eR = 0; int eG = 0; int eB = 0;

            switch (Program.ReactTypeStart)
            {
                case 0:
                    sR = Program.ReactColors.StartR;
                    sG = Program.ReactColors.StartG;
                    sB = Program.ReactColors.StartB;
                    break;
                case 1:
                    //Figure out how to make a rainbow here, probably going to need to rewrite SingleKeyFade classs
                    break;
                case 2:
                    sR = rnd.Next(Program.ReactColors.SRandRLow, Program.ReactColors.SRandRHigh);
                    sG = rnd.Next(Program.ReactColors.SRandGLow, Program.ReactColors.SRandGHigh);
                    sB = rnd.Next(Program.ReactColors.SRandBLow, Program.ReactColors.SRandBHigh);
                    break;
                default:
                    break;
            }

            switch (Program.ReactTypeEnd)
            {
                case 0:
                    eR = Program.ReactColors.EndR;
                    eG = Program.ReactColors.EndG;
                    eB = Program.ReactColors.EndB;
                    break;
                case 1:
                    if (Program.StaticKeyColors[currentKey] != Color.Transparent)
                    {
                        eR = Program.StaticKeyColors[currentKey].R;
                        eG = Program.StaticKeyColors[currentKey].G;
                        eB = Program.StaticKeyColors[currentKey].B;
                    }
                    break;
                case 2:
                    eR = rnd.Next(Program.ReactColors.ERandRLow, Program.ReactColors.ERandRHigh);
                    eG = rnd.Next(Program.ReactColors.ERandGLow, Program.ReactColors.ERandGHigh);
                    eB = rnd.Next(Program.ReactColors.ERandBLow, Program.ReactColors.ERandBHigh);
                    break;
                default:
                    break;
            }

            keyMatrix[currentKey] = new SingleKeyFade(
                    Program.ReactSettings.Duration,
                    (byte)sR,
                    (byte)sG,
                    (byte)sB,
                    (byte)eR,
                    (byte)eG,
                    (byte)eB);
        }

    }

    public class RawInputKeyCodes
    {
        public int GetKeyCode(int mcode, int vkey, int flag)
        {
            // Letters
            if (mcode == 0x001E && vkey == 0x0041 && flag == 0x0001) { return 15; } //A
            else if (mcode == 0x0030 && vkey == 0x0042 && flag == 0x0001) { return 76; } //B
            else if (mcode == 0x002E && vkey == 0x0043 && flag == 0x0001) { return 52; } //C
            else if (mcode == 0x0020 && vkey == 0x0044 && flag == 0x0001) { return 39; } //D
            else if (mcode == 0x0012 && vkey == 0x0045 && flag == 0x0001) { return 38; } //E
            else if (mcode == 0x0021 && vkey == 0x0046 && flag == 0x0001) { return 51; } //F
            else if (mcode == 0x0022 && vkey == 0x0047 && flag == 0x0001) { return 63; } //G
            else if (mcode == 0x0023 && vkey == 0x0048 && flag == 0x0001) { return 75; } //H
            else if (mcode == 0x0017 && vkey == 0x0049 && flag == 0x0001) { return 98; } //I
            else if (mcode == 0x0024 && vkey == 0x004A && flag == 0x0001) { return 87; } //J
            else if (mcode == 0x0025 && vkey == 0x004B && flag == 0x0001) { return 99; } //K
            else if (mcode == 0x0026 && vkey == 0x004C && flag == 0x0001) { return 111; } //L
            else if (mcode == 0x0032 && vkey == 0x004D && flag == 0x0001) { return 100; } //M
            else if (mcode == 0x0031 && vkey == 0x004E && flag == 0x0001) { return 88; } //N
            else if (mcode == 0x0018 && vkey == 0x004F && flag == 0x0001) { return 110; } //O
            else if (mcode == 0x0019 && vkey == 0x0050 && flag == 0x0001) { return 122; } //P
            else if (mcode == 0x0010 && vkey == 0x0051 && flag == 0x0001) { return 14; } //Q
            else if (mcode == 0x0013 && vkey == 0x0052 && flag == 0x0001) { return 50; } //R
            else if (mcode == 0x001F && vkey == 0x0053 && flag == 0x0001) { return 27; } //S
            else if (mcode == 0x0014 && vkey == 0x0054 && flag == 0x0001) { return 62; } //T
            else if (mcode == 0x0016 && vkey == 0x0055 && flag == 0x0001) { return 86; } //U
            else if (mcode == 0x002F && vkey == 0x0056 && flag == 0x0001) { return 64; } //V
            else if (mcode == 0x0011 && vkey == 0x0057 && flag == 0x0001) { return 26; } //W
            else if (mcode == 0x002D && vkey == 0x0058 && flag == 0x0001) { return 40; } //X
            else if (mcode == 0x0015 && vkey == 0x0059 && flag == 0x0001) { return 74; } //Y
            else if (mcode == 0x002C && vkey == 0x005A && flag == 0x0001) { return 28; } //Z

            // Number Row
            else if (mcode == 0x0002 && vkey == 0x0031 && flag == 0x0001) { return 13; } //1
            else if (mcode == 0x0003 && vkey == 0x0032 && flag == 0x0001) { return 25; } //2
            else if (mcode == 0x0004 && vkey == 0x0033 && flag == 0x0001) { return 37; } //3
            else if (mcode == 0x0005 && vkey == 0x0034 && flag == 0x0001) { return 49; } //4
            else if (mcode == 0x0006 && vkey == 0x0035 && flag == 0x0001) { return 61; } //5
            else if (mcode == 0x0007 && vkey == 0x0036 && flag == 0x0001) { return 73; } //6
            else if (mcode == 0x0008 && vkey == 0x0037 && flag == 0x0001) { return 85; } //7
            else if (mcode == 0x0009 && vkey == 0x0038 && flag == 0x0001) { return 97; } //8
            else if (mcode == 0x000A && vkey == 0x0039 && flag == 0x0001) { return 109; } //9
            else if (mcode == 0x000B && vkey == 0x0030 && flag == 0x0001) { return 121; } //0

            // F Keys
            else if (mcode == 0x003B && vkey == 0x0070 && flag == 0x0001) { return 12; } //F1
            else if (mcode == 0x003C && vkey == 0x0071 && flag == 0x0001) { return 24; } //F2
            else if (mcode == 0x003D && vkey == 0x0072 && flag == 0x0001) { return 36; } //F3
            else if (mcode == 0x003E && vkey == 0x0073 && flag == 0x0001) { return 48; } //F4
            else if (mcode == 0x003F && vkey == 0x0074 && flag == 0x0001) { return 60; } //F5
            else if (mcode == 0x0040 && vkey == 0x0075 && flag == 0x0001) { return 72; } //F6
            else if (mcode == 0x0041 && vkey == 0x0076 && flag == 0x0001) { return 84; } //F7
            else if (mcode == 0x0042 && vkey == 0x0077 && flag == 0x0001) { return 96; } //F8
            else if (mcode == 0x0043 && vkey == 0x0078 && flag == 0x0001) { return 108; } //F9
            else if (mcode == 0x0044 && vkey == 0x0079 && flag == 0x0001) { return 120; } //F10
            else if (mcode == 0x0057 && vkey == 0x007A && flag == 0x0001) { return 132; } //F11
            else if (mcode == 0x0058 && vkey == 0x007B && flag == 0x0001) { return 6; } //F12

            // Keys around letters
            else if (mcode == 0x0001 && vkey == 0x001B && flag == 0x0001) { return 0; } //Escape
            else if (mcode == 0x0029 && vkey == 0x00C0 && flag == 0x0001) { return 1; } //Tilde
            else if (mcode == 0x000F && vkey == 0x0009 && flag == 0x0001) { return 2; } //Tab
            else if (mcode == 0x003A && vkey == 0x0014 && flag == 0x0001) { return 3; } //Caps Lock
            else if (mcode == 0x002A && vkey == 0x0010 && flag == 0x0001) { return 4; } //Left Shift
            else if (mcode == 0x001D && vkey == 0x0011 && flag == 0x0001) { return 5; } //Left Control
            else if (mcode == 0x005B && vkey == 0x005B && flag == 0x0003) { return 17; } //Left Win
            else if (mcode == 0x0038 && vkey == 0x0012 && flag == 0x0001) { return 29; } //Left Alt
            else if (mcode == 0x0039 && vkey == 0x0020 && flag == 0x0001) { return 53; } //Space
            else if (mcode == 0x0038 && vkey == 0x0012 && flag == 0x0003) { return 89; } //Right Alt
            else if (mcode == 0x005C && vkey == 0x005C && flag == 0x0003) { return 101; } //Right Win
            else if (mcode == 0x005D && vkey == 0x005D && flag == 0x0003) { return 113; } //Right Apps
            else if (mcode == 0x001D && vkey == 0x0011 && flag == 0x0003) { return 91; } //Right Control
            else if (mcode == 0x0036 && vkey == 0x0010 && flag == 0x0001) { return 79; } //Right Shift
            else if (mcode == 0x001C && vkey == 0x000D && flag == 0x0001) { return 126; } //Enter
            else if (mcode == 0x002B && vkey == 0x00DC && flag == 0x0001) { return 102; } //Pipe
            else if (mcode == 0x000E && vkey == 0x0008 && flag == 0x0001) { return 31; } //Backspace
            else if (mcode == 0x000C && vkey == 0x00BD && flag == 0x0001) { return 133; } // -
            else if (mcode == 0x000D && vkey == 0x00BB && flag == 0x0001) { return 7; } // =
            else if (mcode == 0x001A && vkey == 0x00DB && flag == 0x0001) { return 134; } // [
            else if (mcode == 0x001B && vkey == 0x00DD && flag == 0x0001) { return 90; } // ]
            else if (mcode == 0x0027 && vkey == 0x00BA && flag == 0x0001) { return 123; } // ;
            else if (mcode == 0x0028 && vkey == 0x00DE && flag == 0x0001) { return 135; } // '
            else if (mcode == 0x0033 && vkey == 0x00BC && flag == 0x0001) { return 112; } // ,
            else if (mcode == 0x0034 && vkey == 0x00BE && flag == 0x0001) { return 124; } // .
            else if (mcode == 0x0035 && vkey == 0x00BF && flag == 0x0001) { return 136; } // /
            else if (mcode == 0x002B && vkey == 0x00E2 && flag == 0x0001) { return 16; } //EU \

            // System Keys
            else if (mcode == 0x002A && vkey == 0x00FF && flag == 0x0003) { return 18; } //Print Screen
            else if (mcode == 0x0037 && vkey == 0x002C && flag == 0x0003) { return 18; } //Print Screen
            else if (mcode == 0x0037 && vkey == 0x002C && flag == 0x0002) { return 18; } //Print Screen
            else if (mcode == 0x0046 && vkey == 0x0091 && flag == 0x0001) { return 30; } //Scroll Lock
            else if (mcode == 0x001D && vkey == 0x0013 && flag == 0x0005) { return 42; } //Pause
            else if (mcode == 0x001D && vkey == 0x0013 && flag == 0x0004) { return 42; } //Pause
            else if (mcode == 0x0045 && vkey == 0x00FF && flag == 0x0001) { return 42; } //Pause

            // Navigation with NumLock ON
            else if (mcode == 0x0052 && vkey == 0x002D && flag == 0x0003) { return 54; } //Insert
            else if (mcode == 0x0047 && vkey == 0x0024 && flag == 0x0003) { return 66; } //Home
            else if (mcode == 0x0049 && vkey == 0x0021 && flag == 0x0003) { return 78; } //Page Up
            else if (mcode == 0x0053 && vkey == 0x002E && flag == 0x0003) { return 43; } //Delete
            else if (mcode == 0x004F && vkey == 0x0023 && flag == 0x0003) { return 55; } //End
            else if (mcode == 0x0051 && vkey == 0x0022 && flag == 0x0003) { return 67; } //Page Down

            // Navigation with NumLock OFF
            else if (mcode == 0x0052 && vkey == 0x002D && flag == 0x0002) { return 54; } //Insert
            else if (mcode == 0x0047 && vkey == 0x0024 && flag == 0x0002) { return 66; } //Home
            else if (mcode == 0x0049 && vkey == 0x0021 && flag == 0x0002) { return 78; } //Page Up
            else if (mcode == 0x0053 && vkey == 0x002E && flag == 0x0002) { return 43; } //Delete
            else if (mcode == 0x004F && vkey == 0x0023 && flag == 0x0002) { return 55; } //End
            else if (mcode == 0x0051 && vkey == 0x0022 && flag == 0x0002) { return 67; } //Page Down

            // Arrows with NumLock ON
            else if (mcode == 0x0048 && vkey == 0x0026 && flag == 0x0003) { return 103; } //Up
            else if (mcode == 0x004B && vkey == 0x0025 && flag == 0x0003) { return 115; } //Left
            else if (mcode == 0x0050 && vkey == 0x0028 && flag == 0x0003) { return 127; } //Down
            else if (mcode == 0x004D && vkey == 0x0027 && flag == 0x0003) { return 139; } //Right

            // Arrows with NumLock OFF
            else if (mcode == 0x0048 && vkey == 0x0026 && flag == 0x0002) { return 103; } //Up
            else if (mcode == 0x004B && vkey == 0x0025 && flag == 0x0002) { return 115; } //Left
            else if (mcode == 0x0050 && vkey == 0x0028 && flag == 0x0002) { return 127; } //Down
            else if (mcode == 0x004D && vkey == 0x0027 && flag == 0x0002) { return 139; } //Right

            // NumPad Operators
            else if (mcode == 0x0045 && vkey == 0x0090 && flag == 0x0001) { return 80; } //NumLock
            else if (mcode == 0x0035 && vkey == 0x006F && flag == 0x0003) { return 92; } // /
            else if (mcode == 0x0035 && vkey == 0x006F && flag == 0x0002) { return 92; } // /
            else if (mcode == 0x0037 && vkey == 0x006A && flag == 0x0001) { return 104; } // *
            else if (mcode == 0x004A && vkey == 0x006D && flag == 0x0001) { return 116; } // -
            else if (mcode == 0x004E && vkey == 0x006B && flag == 0x0001) { return 128; } // +
            else if (mcode == 0x001C && vkey == 0x000D && flag == 0x0003) { return 140; } //Enter
            else if (mcode == 0x001C && vkey == 0x000D && flag == 0x0002) { return 140; } //Enter

            // NumPad with NumLock ON
            else if (mcode == 0x004F && vkey == 0x0061 && flag == 0x0001) { return 93; } //1
            else if (mcode == 0x0050 && vkey == 0x0062 && flag == 0x0001) { return 105; } //2
            else if (mcode == 0x0051 && vkey == 0x0063 && flag == 0x0001) { return 117; } //3
            else if (mcode == 0x004B && vkey == 0x0064 && flag == 0x0001) { return 57; } //4
            else if (mcode == 0x004C && vkey == 0x0065 && flag == 0x0001) { return 69; } //5
            else if (mcode == 0x004D && vkey == 0x0066 && flag == 0x0001) { return 81; } //6
            else if (mcode == 0x0047 && vkey == 0x0067 && flag == 0x0001) { return 9; } //7
            else if (mcode == 0x0048 && vkey == 0x0068 && flag == 0x0001) { return 21; } //8
            else if (mcode == 0x0049 && vkey == 0x0069 && flag == 0x0001) { return 33; } //9
            else if (mcode == 0x0052 && vkey == 0x0060 && flag == 0x0001) { return 129; } //0
            else if (mcode == 0x0053 && vkey == 0x006E && flag == 0x0001) { return 141; } //Decimal

            // NumPad with NumLock OFF
            else if (mcode == 0x004F && vkey == 0x0023 && flag == 0x0001) { return 93; } //1
            else if (mcode == 0x0050 && vkey == 0x0028 && flag == 0x0001) { return 105; } //2
            else if (mcode == 0x0051 && vkey == 0x0022 && flag == 0x0001) { return 117; } //3
            else if (mcode == 0x004B && vkey == 0x0025 && flag == 0x0001) { return 57; } //4
            else if (mcode == 0x004C && vkey == 0x000C && flag == 0x0001) { return 69; } //5
            else if (mcode == 0x004D && vkey == 0x0027 && flag == 0x0001) { return 81; } //6
            else if (mcode == 0x0047 && vkey == 0x0024 && flag == 0x0001) { return 9; } //7
            else if (mcode == 0x0048 && vkey == 0x0026 && flag == 0x0001) { return 21; } //8
            else if (mcode == 0x0049 && vkey == 0x0021 && flag == 0x0001) { return 33; } //9
            else if (mcode == 0x0052 && vkey == 0x002D && flag == 0x0001) { return 129; } //0
            else if (mcode == 0x0053 && vkey == 0x002E && flag == 0x0001) { return 141; } //Decimal

            // Media Keys
            else if (mcode == 0x0000 && vkey == 0x00B2 && flag == 0x0003) { return 32; } //Stop
            else if (mcode == 0x0000 && vkey == 0x00B1 && flag == 0x0003) { return 44; } //Previous
            else if (mcode == 0x0000 && vkey == 0x00B3 && flag == 0x0003) { return 56; } //Play
            else if (mcode == 0x0000 && vkey == 0x00B0 && flag == 0x0003) { return 68; } //Next
            else if (mcode == 0x0000 && vkey == 0x00AD && flag == 0x0003) { return 20; } //Mute


            else { return 1; }
        }

    }
}

/* Thread Status Index
-2: Initiation Failed
-1: Not yet created
 0: Destroyed
 1: Test Mode
 2: Spectro Running
 3: Effect - Random Lights
 4: Effect - Rainfall
 10: Reactive - Single Keys
 11: Reactive - Heatmap
 */