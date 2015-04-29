using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RGBKeyboardSpectrograph
{
    public class KeyboardWriter
    {
        #region pInvoke Imports

        [DllImport("hid.dll", SetLastError = true)]
        public static extern bool HidD_SetFeature(IntPtr HidDeviceObject, ref Byte lpReportBuffer, int ReportBufferLength);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SetupDiGetClassDevs(           // 1st form using a ClassGUID only, with null Enumerator
           ref Guid ClassGuid,
           IntPtr Enumerator,
           IntPtr hwndParent,
           int Flags
        );

        [DllImport("setupapi.dll", SetLastError = true)]
        static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, uint MemberIndex, ref SP_DEVINFO_DATA DeviceInfoData);

        [DllImport("setupapi.dll", CharSet = CharSet.Auto)]
        static extern int CM_Get_Device_ID(
           UInt32 dnDevInst,
           IntPtr buffer,
           int bufferLen,
           int flags
        );

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Boolean SetupDiEnumDeviceInterfaces(
           IntPtr hDevInfo,
           ref SP_DEVINFO_DATA devInfo,
           ref Guid interfaceClassGuid,
           UInt32 memberIndex,
           ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData
        );

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Boolean SetupDiGetDeviceInterfaceDetail(
           IntPtr hDevInfo,
           ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
           ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData,
           UInt32 deviceInterfaceDetailDataSize,
           out UInt32 requiredSize,
           ref SP_DEVINFO_DATA deviceInfoData
        );

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Boolean SetupDiGetDeviceInterfaceDetail(
           IntPtr hDevInfo,
           ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
           ref SP_DEVICE_INTERFACE_DETAIL_DATA deviceInterfaceDetailData,
           UInt32 deviceInterfaceDetailDataSize,
           IntPtr requiredSize,                     // Allow null
           IntPtr deviceInfoData                    // Allow null
        );

        [DllImport(@"setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern Boolean SetupDiGetDeviceInterfaceDetail(
           IntPtr hDevInfo,
           ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData,
           IntPtr deviceInterfaceDetailData,        // Allow null
           UInt32 deviceInterfaceDetailDataSize,
           out UInt32 requiredSize,
           IntPtr deviceInfoData                    // Allow null
        );

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile
        );

        [DllImport("setupapi.dll", SetLastError = true)]
        public static extern bool SetupDiDestroyDeviceInfoList
        (
             IntPtr DeviceInfoSet
        );

        #endregion

        #region Types to support pInvoke methods

        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVINFO_DATA
        {
            public uint cbSize;
            public Guid classGuid;
            public uint devInst;
            public IntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct SP_DEVICE_INTERFACE_DATA
        {
            public uint cbSize;
            public Guid interfaceClassGuid;
            public uint flags;
            private UIntPtr reserved;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        struct SP_DEVICE_INTERFACE_DETAIL_DATA
        {
            public uint cbSize;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = BUFFER_SIZE)]
            public string DevicePath;
        }

        #endregion

        #region Flags to support pInvoke methods

        const Int64 INVALID_HANDLE_VALUE = -1;

        const int DIGCF_DEFAULT = 0x1;
        const int DIGCF_PRESENT = 0x2;
        const int DIGCF_ALLCLASSES = 0x4;
        const int DIGCF_PROFILE = 0x8;
        const int DIGCF_DEVICEINTERFACE = 0x10;

        // Used for CreateFile
        public const short FILE_ATTRIBUTE_NORMAL = 0x80;
        //public const short INVALID_HANDLE_VALUE = -1;
        public const uint GENERIC_READ = 0x80000000;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint CREATE_NEW = 1;
        public const uint CREATE_ALWAYS = 2;
        public const uint OPEN_EXISTING = 3;

        // Used for CreateFile
        public const uint FILE_SHARE_NONE = 0x00;
        public const uint FILE_SHARE_READ = 0x01;
        public const uint FILE_SHARE_WRITE = 0x02;
        public const uint FILE_SHARE_DELETE = 0x04;

        // Used for CreateFile
        public const uint FILE_FLAG_OVERLAPPED = 0x40000000;

        static Guid GUID_DEVINTERFACE_HID = new Guid(0x4D1E55B2, 0xF16F, 0x11CF, 0x88, 0xCB, 0x00, 0x11, 0x11, 0x00, 0x00, 0x30);

        const int BUFFER_SIZE = 128;
        const int MAX_DEVICE_ID_LEN = 200;

        #endregion

        private IntPtr keyboardUsbDevice;

        /* The bands of FFT data that will be used in the spectrograph.
         * This roughly equates to 60Hz to about 17KHz. */
        private int[] fftLookup = new int[]
        {
            4,5,6,7,8,9,10,11,12,14,16,18,20,22,25,28,31,34,38,42,46,50,
            54,59,64,69,74,79,85,91,97,103,109,115,122,129,136,143,150,158,
            166,174,182,190,198,206,214,222,230,238,246,254,263,272,281,290,
            299,308,317,326,335,344,353,362,371,380,389,399,409,419,429,439,
            449,459,470,481,492,503,514,525,536,547,558,570,582,594,606,618,
            630,642,654,666,678,690,703,716,729,742,755,768,781,794,807,820,
            833,850
        };

        private byte[,] ledMatrix = new byte[7, 104];

        private byte[] redValues = new byte[144];
        private byte[] greenValues = new byte[144];
        private byte[] blueValues = new byte[144];

        private byte[][] dataPacket = new byte[5][]; // 2nd dimension initialized to size 64

        byte red, grn, blu;

        public KeyboardWriter()
        {
            if (InitKeyboard(Program.MyKeyboardID, Program.MyKeyboardName) == 1)
            {
                Program.RunKeyboardThread = 1;
                return;
            }

            for (int i = 0; i < dataPacket.Length; i++)
            {
                this.dataPacket[i] = new byte[64];
            }
            UpdateStatusMessage.ShowStatusMessage(10, "Running");
            return;
        }

        public void Write(int iter, byte[] fftData, int CanvasWidth)
        {
            if (iter == -1)
            {
                SetTestLed(CanvasWidth);
                UpdateKeyboard();
                return;
            }
            int cWidth1 = CanvasWidth;
            float cWidth2 = CanvasWidth - 1;
            // Rainbow to key lights
            for (int x = 0; x < cWidth1; x++)
            {
                for (int y = 0; y < 7; y++)
                {
                    this.red = (byte)((Program.MyBackgroundBrightness / 10) * (Math.Sin((x / cWidth2) * 2 * 3.14f) + 1));
                    this.grn = (byte)((Program.MyBackgroundBrightness / 10) * (Math.Sin(((x / cWidth2) * 2 * 3.14f) - (6.28f / 3)) + 1));
                    this.blu = (byte)((Program.MyBackgroundBrightness / 10) * (Math.Sin(((x / cWidth2) * 2 * 3.14f) + (6.28f / 3)) + 1));
                    
                    this.SetLed((x + iter) % (int)cWidth2, y, red, grn, blu);
                }
            }

            // FFT Data to key lights;
            float fftBandAverage;

            for (int i = 0; i < cWidth1; i++)
            {
                for (int k = 0; k < 7; k++)
                {
                    // Use the average from the band below, above, and including the current, to smooth out data a bit.
                    if (i < 1)
                    {
                        fftBandAverage = fftData[fftLookup[i]];
                    }
                    else
                    {
                        fftBandAverage = ((fftData[fftLookup[i] - 1] + fftData[fftLookup[i]] + fftData[fftLookup[i] + 1]) / 3);
                    }

                    /* Boost the higher stuff, since it comes in lower. The highest (~15KHz+) ends up
                     * being boosted roughly 2.145 times, thanks to the stacking effect below.
                     * This makes a more accurate representation of what we're hearing. */
                    if (i > 4 && i < 20) { fftBandAverage /= 2f; };
                    if (i > 19 && i < 40) { fftBandAverage /= 1.5f; };
                    if (i > 70) { fftBandAverage *= 1.1f; };
                    if (i > 90) { fftBandAverage *= 1.3f; };
                    //if (i > 98) { fftBandAverage *= 1.5f; };

                    // Volume requirement curve
                    if ((int)fftBandAverage > ((128 / (1 + (i * .8))) * (7 - k)))
                    {
                        this.SetLed(i, k, Program.MyBarsRed, Program.MyBarsGreen, Program.MyBarsBlue);
                    }
                }
            }

            UpdateKeyboard();
        }

        private void SetTestLed(int led)
        {
            for (int i = 0; i < 144; i++)
            {
                this.redValues[i] = (byte)7;
                this.greenValues[i] = (byte)7;
                this.blueValues[i] = (byte)7;
            }
            this.redValues[led] = (byte)0;
            this.greenValues[led] = (byte)0;
            this.blueValues[led] = (byte)0;

            UpdateKeyboard();
        }
        private void SetLed(int x, int y, int r, int g, int b)
        {
            int led = this.ledMatrix[y, x];

            if (led >= 144)
            {
                return;
            }

            if (r > 7) r = 7;
            if (g > 7) g = 7;
            if (b > 7) b = 7;

            /* The keyboard considers 7 as off, and 0 as maximum brightness, so invert values.
             * The selected M key, however, ignores this rule. Led 23 is M1, so apply this rule
             * to all keys but that one, and make sure that you have M1 selected during operation. */

            if (led != 23)
            {
                r = 7 - r;
                g = 7 - g;
                b = 7 - b;
            }

            if (r > 7 || r < 0 ||
                g > 7 || g < 0 ||
                b > 7 || g < 0)
            {
                UpdateStatusMessage.ShowStatusMessage(3, "RGB Incorrect! (" + r + ", " + g + ", " + b + ")");
            }
            this.redValues[led] = (byte)r;
            this.greenValues[led] = (byte)g;
            this.blueValues[led] = (byte)b;
        }

        private int InitKeyboard(uint KeyboardID, string KeyboardName)
        {
            UpdateStatusMessage.ShowStatusMessage(4, "Searching for " + KeyboardName + " (" + KeyboardID.ToString("X") + ")");
            // 0x1B11 - K95 RGB
            // 0x1B13 - K70 RGB
            // 0x1B17 - K65 RGB
            this.keyboardUsbDevice = this.GetDeviceHandle(0x1B1C, KeyboardID, 0x3);

            if (this.keyboardUsbDevice == IntPtr.Zero)
            {
                UpdateStatusMessage.ShowStatusMessage(3, KeyboardName + " not found");
                return 1;
            }

            UpdateStatusMessage.ShowStatusMessage(4, KeyboardName + " Found");

            // Construct XY lookup table
            if (InitiateLookupTable() == false)
            {
                UpdateStatusMessage.ShowStatusMessage(3, "An error occurred when attempting to initiate the keyboard");
                return 1;
            }
            return 0;
        }

        private bool InitiateLookupTable()
        {
            var keys = Program.MyPositionMap.GetEnumerator();
            keys.MoveNext();
            var sizes = Program.MySizeMap.GetEnumerator();
            sizes.MoveNext();

            for (int y = 0; y < 7; y++)
            {
                byte key = 0x00;
                int size = 0;

                for (int x = 0; x < Program.MyCanvasWidth; x++)
                {
                    if (size == 0)
                    {
                        try
                        {

                            float sizef = (float)sizes.Current;
                            sizes.MoveNext();
                            if (sizef < 0)
                            {
                                size = (int)(-sizef * 4);
                                key = 255;
                            }
                            else
                            {
                                UpdateStatusMessage.ShowStatusMessage(6, "x: " + x + " y: " + y + " key: " + keys.Current);
                                key = (byte)keys.Current;
                                keys.MoveNext();
                                size = (int)(sizef * 4);
                            }
                        } //try
                        catch
                        {
                            UpdateStatusMessage.ShowStatusMessage(3, "Enumeration Failed");
                            return false;
                        } //catch
                    }

                    ledMatrix[y, x] = key;
                    size--;
                }
                if ((byte)keys.Current != 255 || (float)sizes.Current != 0f)
                {
                    //Console.WriteLine("Bad line: " + keys.Current + ", " + sizes.Current + " Key " + key, y);
                    UpdateStatusMessage.ShowStatusMessage(4, "Bad line: " + keys.Current + ", " + sizes.Current + " Key " + key + y);
                }
                else
                {
                    UpdateStatusMessage.ShowStatusMessage(5, "Row Okay: " + keys.Current + ", " + sizes.Current + " Key " + key);
                }

                keys.MoveNext();
                sizes.MoveNext();
            }
            UpdateStatusMessage.ShowStatusMessage(4, "InitializeLookupTable Done");
            return true;
        }

        /// <summary>
        /// C Code by http://www.reddit.com/user/chrisgzy
        /// Converted to C# by http://www.reddit.com/user/billism
        /// </summary>
        private IntPtr GetDeviceHandle(uint uiVID, uint uiPID, uint uiMI)
        {
            IntPtr deviceInfo = SetupDiGetClassDevs(ref GUID_DEVINTERFACE_HID, IntPtr.Zero, IntPtr.Zero, DIGCF_PRESENT | DIGCF_DEVICEINTERFACE);
            if (deviceInfo.ToInt64() == INVALID_HANDLE_VALUE)
            {
                return IntPtr.Zero;
            }

            IntPtr returnPointer = IntPtr.Zero;

            SP_DEVINFO_DATA deviceData = new SP_DEVINFO_DATA();
            deviceData.cbSize = (uint)Marshal.SizeOf(deviceData);

            for (uint i = 0; SetupDiEnumDeviceInfo(deviceInfo, i, ref deviceData); ++i)
            {
                IntPtr deviceId = Marshal.AllocHGlobal(MAX_DEVICE_ID_LEN); // was wchar_t[] type
                // CM_Get_Device_ID was CM_Get_Device_IDW in C++ code
                if (CM_Get_Device_ID(deviceData.devInst, deviceId, MAX_DEVICE_ID_LEN, 0) != 0)
                {
                    continue;
                }

                if (!IsMatchingDevice(deviceId, uiVID, uiPID, uiMI))
                    continue;

                SP_DEVICE_INTERFACE_DATA interfaceData = new SP_DEVICE_INTERFACE_DATA(); // C code used SP_INTERFACE_DEVICE_DATA
                interfaceData.cbSize = (uint)Marshal.SizeOf(interfaceData);

                if (!SetupDiEnumDeviceInterfaces(deviceInfo, ref deviceData, ref GUID_DEVINTERFACE_HID, 0, ref interfaceData))
                {
                    break;
                }

                uint requiredSize = 0;
                SetupDiGetDeviceInterfaceDetail(deviceInfo, ref interfaceData, IntPtr.Zero, 0, out requiredSize, IntPtr.Zero);
                // var lastError = Marshal.GetLastWin32Error();

                SP_DEVICE_INTERFACE_DETAIL_DATA interfaceDetailData = new SP_DEVICE_INTERFACE_DETAIL_DATA();
                if (IntPtr.Size == 8) // for 64 bit operating systems
                {
                    interfaceDetailData.cbSize = 8;
                }
                else
                {
                    interfaceDetailData.cbSize = 4 + (uint)Marshal.SystemDefaultCharSize; // for 32 bit systems
                }

                if (!SetupDiGetDeviceInterfaceDetail(deviceInfo, ref interfaceData, ref interfaceDetailData, requiredSize, IntPtr.Zero, IntPtr.Zero))
                {
                    break;
                }

                var deviceHandle = CreateFile(interfaceDetailData.DevicePath, GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE, IntPtr.Zero, OPEN_EXISTING, FILE_FLAG_OVERLAPPED, IntPtr.Zero);
                if (deviceHandle.ToInt64() == INVALID_HANDLE_VALUE)
                {
                    break;
                }

                returnPointer = deviceHandle;
                break;
            }

            SetupDiDestroyDeviceInfoList(deviceInfo);
            return returnPointer;
        }

        /// <summary>
        /// C Code by http://www.reddit.com/user/chrisgzy
        /// Converted to C# by http://www.reddit.com/user/billism
        /// </summary>
        private bool IsMatchingDevice(IntPtr pDeviceID, uint uiVID, uint uiPID, uint uiMI)
        {
            var deviceString = Marshal.PtrToStringAuto(pDeviceID);
            if (deviceString == null)
            {
                return false;
            }

            bool isMatch = deviceString.Contains(string.Format("VID_{0:X4}", uiVID));
            isMatch &= deviceString.Contains(string.Format("PID_{0:X4}", uiPID));
            isMatch &= deviceString.Contains(string.Format("MI_{0:X2}", uiMI));

            return isMatch;
        }

        private void UpdateKeyboard()
        {
            // Perform USB control message to keyboard
            //
            // Request Type:  0x21
            // Request:       0x09
            // Value          0x0300
            // Index:         0x03
            // Size:          64

            this.dataPacket[0][0] = 0x7F;
            this.dataPacket[0][1] = 0x01;
            this.dataPacket[0][2] = 0x3C;

            this.dataPacket[1][0] = 0x7F;
            this.dataPacket[1][1] = 0x02;
            this.dataPacket[1][2] = 0x3C;

            this.dataPacket[2][0] = 0x7F;
            this.dataPacket[2][1] = 0x03;
            this.dataPacket[2][2] = 0x3C;

            this.dataPacket[3][0] = 0x7F;
            this.dataPacket[3][1] = 0x04;
            this.dataPacket[3][2] = 0x24;

            this.dataPacket[4][0] = 0x07;
            this.dataPacket[4][1] = 0x27;
            this.dataPacket[4][4] = 0xD8;
            /*
            for (int i = 0; i < 60; i++)
            {
                this.dataPacket[0][i + 4] = (byte)7;
                this.dataPacket[1][i + 4] = (byte)7;
                this.dataPacket[2][i + 4] = (byte)7;
                this.dataPacket[3][i + 4] = (byte)7;
                this.dataPacket[4][i + 4] = (byte)7;
            }

            this.SendUsbMessage(dataPacket[0]);
            this.SendUsbMessage(dataPacket[1]);
            this.SendUsbMessage(dataPacket[2]);
            this.SendUsbMessage(dataPacket[3]);
            this.SendUsbMessage(dataPacket[4]);
            */

            
            for (int i = 0; i < 60; i++)
            {
                this.dataPacket[0][i + 4] = (byte)(this.redValues[i * 2 + 1] << 4 | this.redValues[i * 2]);
            }

            for (int i = 0; i < 12; i++)
            {
                this.dataPacket[1][i + 4] = (byte)(this.redValues[i * 2 + 121] << 4 | this.redValues[i * 2 + 120]);
            }

            for (int i = 0; i < 48; i++)
            {
                this.dataPacket[1][i + 16] = (byte)(this.greenValues[i * 2 + 1] << 4 | this.greenValues[i * 2]);
            }

            for (int i = 0; i < 24; i++)
            {
                this.dataPacket[2][i + 4] = (byte)(this.greenValues[i * 2 + 97] << 4 | this.greenValues[i * 2 + 96]);
            }

            for (int i = 0; i < 36; i++)
            {
                this.dataPacket[2][i + 28] = (byte)(this.blueValues[i * 2 + 1] << 4 | this.blueValues[i * 2]);
            }

            for (int i = 0; i < 36; i++)
            {
                this.dataPacket[3][i + 4] = (byte)(this.blueValues[i * 2 + 73] << 4 | this.blueValues[i * 2 + 72]);
            }
            for (int i = 36; i < 60; i++)
            {
                this.dataPacket[3][i + 4] = (byte)0;
            }
            for (int i = 0; i < 60; i++)
            {
                this.dataPacket[4][i + 4] = (byte)0;
            }
                // Remove this from finished code; it's for debugging whatever might be wrong with USB
                for (int i = 4; i < 64; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (this.dataPacket[j][i] > 127)
                        {
                            this.dataPacket[j][i] = 127;
                            UpdateStatusMessage.ShowStatusMessage(3, "Packet over 127:" + i + ", " + j);
                        }
                        if (this.dataPacket[j][i] < 0)
                        {
                            this.dataPacket[j][i] = 0;
                            UpdateStatusMessage.ShowStatusMessage(3, "Packet under 0:" + i + ", " + j);
                        }
                    }
                }

            //    Console.WriteLine("");
            // To here

            for (int p = 0; p < 5; p++ )
            {
                if (this.SendUsbMessage(dataPacket[p]) == false)
                {
                    UpdateStatusMessage.ShowStatusMessage(3, "Packet " + p + " Failed");
                    WritePacketToLog(dataPacket[p], dataPacket[p]);
                };
            }
        }

        private void WritePacketToLog(byte[] CurrentPacket, byte[] PreviousPacket)
        {
            if (Program.FailedPacketLogWritten == true) return;
            string strOutput = "Previous Packet" + System.Environment.NewLine +
                                BitConverter.ToString(PreviousPacket) + System.Environment.NewLine + 
                                "Current Packet" + System.Environment.NewLine + 
                                BitConverter.ToString(CurrentPacket);
            strOutput = strOutput.Replace("-", System.Environment.NewLine);

            string timeNow = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            string outputPath = Directory.GetCurrentDirectory() + "log-" + timeNow + ".txt";
            File.WriteAllText(outputPath, strOutput);
            Program.FailedPacketLogWritten = true;
        }

        private bool SendUsbMessage(byte[] data_pkt)
        {
            byte[] usb_pkt = new byte[65];
            for (int i = 1; i < 65; i++)
            {
                usb_pkt[i] = data_pkt[i - 1];
            }

            return HidD_SetFeature(this.keyboardUsbDevice, ref usb_pkt[0], 65);
        }
    }
}