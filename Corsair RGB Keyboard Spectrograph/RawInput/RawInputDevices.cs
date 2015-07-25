
public class RawInputDevices : RawInputNativeMethods
{
    private const int RIDEV_INPUTSINK = 0x100;
    private const int RID_INPUT = 0x10000003;
    private const int FAPPCOMMAND_MASK = 0xf000;
    private const int FAPPCOMMAND_MOUSE = 0x8000;
    private const int FAPPCOMMAND_OEM = 0x1000;
    private const int RIM_TYPEMOUSE = 0;
    private const int RIM_TYPEKEYBOARD = 1;
    private const int RIM_TYPEHID = 2;
    private const int RIDI_DEVICENAME = 0x20000007;
    private const int RIDI_DEVICEINFO = 0x2000000b;
    private const int WM_KEYDOWN = 0x100;
    private const int WM_SYSKEYDOWN = 0x104;
    private const int WM_INPUT = 0xff;
    private const int VK_OEM_CLEAR = 0xfe;
    //this is a made up value used as a sentinel
    private const int VK_LAST_KEY = VK_OEM_CLEAR;
    private System.Collections.Hashtable m_deviceNameList = new System.Collections.Hashtable();
    private System.Collections.Hashtable m_deviceInfoList = new System.Collections.Hashtable();

    private System.Collections.Hashtable m_usagePagesList = new System.Collections.Hashtable();
    public class DeviceNameInfo
    {
        public string deviceName;
        public string deviceType;
        public System.IntPtr deviceHandle;
        public string Name;
        public string source;
        public ushort key;
        public string vKey;
    }


    private string ReadReg(string item, ref bool isKeyboard)
    {
        // Example Device Identification string @"\??\ACPI#PNP0303#3&13c0b0c5&0#{884b96c3-56ef-11d1-bc8c-00a0c91405dd}";
        item = item.Substring(4);
        // remove the \??\
        string[] split = item.Split('#');
        string id_01 = split[0];
        // ACPI (Class code)
        string id_02 = split[1];
        // PNP0303 (SubClass code)
        string id_03 = split[2];
        // 3&13c0b0c5&0 (Protocol code)
        Microsoft.Win32.RegistryKey OurKey = Microsoft.Win32.Registry.LocalMachine;
        //Open the appropriate key as read-only so no permissions are needed.
        string findme = string.Format("System\\CurrentControlSet\\Enum\\{0}\\{1}\\{2}", id_01, id_02, id_03);
        OurKey = OurKey.OpenSubKey(findme, false);
        //Retrieve the desired information and set isKeyboard
        string deviceDesc = (string)OurKey.GetValue("DeviceDesc");
        string deviceClass = (string)OurKey.GetValue("Class");
        if (deviceClass.ToUpper().Equals("KEYBOARD"))
        {
            isKeyboard = true;
        }
        else
        {
            isKeyboard = false;
        }
        return deviceDesc;
    }

    private string GetDeviceType(int device)
    {
        string deviceType = null;
        switch (device)
        {
            case RIM_TYPEMOUSE:
                deviceType = "MOUSE";
                break; // TODO: might not be correct. Was : Exit Select
            case RIM_TYPEKEYBOARD:
                deviceType = "KEYBOARD";
                break; // TODO: might not be correct. Was : Exit Select
            case RIM_TYPEHID:
                deviceType = "HID";
                break; // TODO: might not be correct. Was : Exit Select
            default:
                deviceType = "UNKNOWN";
                break; // TODO: might not be correct. Was : Exit Select
        }
        return deviceType;
    }

    public int EnumerateDevices()
    {
        int result = 0;
        int deviceCount = 0;
        int dwSize = (System.Runtime.InteropServices.Marshal.SizeOf(typeof(RAWINPUTDEVICELIST)));
        if (GetRawInputDeviceList(System.IntPtr.Zero, ref deviceCount, dwSize) == 0)
        {
            System.IntPtr pRawInputDeviceList = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Convert.ToInt32(dwSize * deviceCount));
            GetRawInputDeviceList(pRawInputDeviceList, ref deviceCount, System.Convert.ToInt32(dwSize));
            for (long i = 0; i <= deviceCount - 1; i++)
            {
                DeviceNameInfo dName = default(DeviceNameInfo);
                string deviceName = null;
                int pcbSizeA = 0;
                int pcbSizeB = 0;
                RAWINPUTDEVICELIST rid = (RAWINPUTDEVICELIST)System.Runtime.InteropServices.Marshal.PtrToStructure(new System.IntPtr((pRawInputDeviceList.ToInt32() + (dwSize * i))), typeof(RAWINPUTDEVICELIST));
                GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICENAME, System.IntPtr.Zero, ref pcbSizeA);
                if (pcbSizeA > 0)
                {
                    System.IntPtr pDataA = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Convert.ToInt32(pcbSizeA));
                    GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICENAME, pDataA, ref pcbSizeA);
                    deviceName = (string)System.Runtime.InteropServices.Marshal.PtrToStringAnsi(pDataA);
                    // Drop the "root" keyboard and mouse devices used for Terminal Services and the Remote Desktop
                    if (!deviceName.ToUpper().Contains("ROOT"))
                    {
                        dName = new DeviceNameInfo();
                        dName.deviceName = (string)System.Runtime.InteropServices.Marshal.PtrToStringAnsi(pDataA);
                        dName.deviceHandle = rid.hDevice;
                        dName.deviceType = GetDeviceType(rid.dwType);
                        GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICEINFO, System.IntPtr.Zero, ref pcbSizeB);
                        if (pcbSizeB > 0)
                        {
                            System.IntPtr pDataB = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Convert.ToInt32(pcbSizeB));
                            System.Runtime.InteropServices.Marshal.Copy(new int[] { pcbSizeB }, 0, pDataB, 1);
                            GetRawInputDeviceInfo(rid.hDevice, RIDI_DEVICEINFO, pDataB, ref pcbSizeB);
                            byte[] deviceInfoBuffer = new byte[pcbSizeB];
                            System.Runtime.InteropServices.Marshal.Copy(pDataB, deviceInfoBuffer, 0, pcbSizeB);
                            System.Runtime.InteropServices.Marshal.FreeHGlobal(pDataB);
                            DeviceInfo dInfo = new DeviceInfo();
                            dInfo.Size = System.BitConverter.ToInt32(deviceInfoBuffer, 0);
                            dInfo.Type = System.BitConverter.ToInt32(deviceInfoBuffer, 4);
                            int pcbSizeC = pcbSizeB - 8;
                            if (((dInfo.Type == RIM_TYPEKEYBOARD) && (pcbSizeC >= System.Runtime.InteropServices.Marshal.SizeOf(typeof(DeviceInfoKeyboard)))))
                            {
                                dInfo.KeyboardInfo.Type = System.BitConverter.ToUInt32(deviceInfoBuffer, 8);
                                dInfo.KeyboardInfo.SubType = System.BitConverter.ToUInt32(deviceInfoBuffer, 12);
                                dInfo.KeyboardInfo.KeyboardMode = System.BitConverter.ToUInt32(deviceInfoBuffer, 16);
                                dInfo.KeyboardInfo.NumberOfFunctionKeys = System.BitConverter.ToUInt32(deviceInfoBuffer, 20);
                                dInfo.KeyboardInfo.NumberOfIndicators = System.BitConverter.ToUInt32(deviceInfoBuffer, 24);
                                dInfo.KeyboardInfo.NumberOfKeysTotal = System.BitConverter.ToUInt32(deviceInfoBuffer, 28);
                            }
                            else if (((dInfo.Type == RIM_TYPEHID) && (pcbSizeC >= System.Runtime.InteropServices.Marshal.SizeOf(typeof(DeviceInfoHID)))))
                            {
                                dInfo.HIDInfo.VendorID = System.BitConverter.ToUInt32(deviceInfoBuffer, 8);
                                dInfo.HIDInfo.ProductID = System.BitConverter.ToUInt32(deviceInfoBuffer, 12);
                                dInfo.HIDInfo.VersionNumber = System.BitConverter.ToUInt32(deviceInfoBuffer, 16);
                                dInfo.HIDInfo.UsagePage = System.BitConverter.ToUInt16(deviceInfoBuffer, 20);
                                dInfo.HIDInfo.Usage = System.BitConverter.ToUInt16(deviceInfoBuffer, 22);
                                if (!m_usagePagesList.ContainsKey(dInfo.HIDInfo.UsagePage))
                                {
                                    m_usagePagesList.Add(dInfo.HIDInfo.UsagePage, dInfo.HIDInfo.UsagePage);
                                }
                            }
                            else if (((dInfo.Type == RIM_TYPEMOUSE) && (pcbSizeC >= System.Runtime.InteropServices.Marshal.SizeOf(typeof(DeviceInfoMouse)))))
                            {
                                dInfo.MouseInfo.ID = System.BitConverter.ToUInt32(deviceInfoBuffer, 8);
                                dInfo.MouseInfo.NumberOfButtons = System.BitConverter.ToUInt32(deviceInfoBuffer, 12);
                                dInfo.MouseInfo.SampleRate = System.BitConverter.ToUInt32(deviceInfoBuffer, 16);
                            }
                            result += 1;
                            m_deviceInfoList.Add(rid.hDevice, dInfo);
                            m_deviceNameList.Add(rid.hDevice, dName);
                        }
                    }
                    System.Runtime.InteropServices.Marshal.FreeHGlobal(pDataA);
                }
            }
            System.Runtime.InteropServices.Marshal.FreeHGlobal(pRawInputDeviceList);
        }
        else
        {
            m_errorMessage = "An error occurred while retrieving the list of raw input devices.";
            result = 0;
        }
        return result;
    }

    public RawInputDevices()
    {
        EnumerateDevices();
    }


    public ushort[] UniqueUsagePages
    {
        get
        {
            ushort[] result = new ushort[0];
            if (m_usagePagesList.Count > 0)
            {
                try
                {
                    m_usagePagesList.Keys.CopyTo(result, 0);
                }
                catch (System.Exception ex)
                {
                    result = new ushort[0];
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
            }
            return result;
        }
    }

}
