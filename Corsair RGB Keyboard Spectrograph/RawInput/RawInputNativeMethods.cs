
public abstract class RawInputNativeMethods
{
    static internal int x = 0;
    static internal int m_lastWin32Error = 0;
    static internal string m_errorMessage = "";
    static internal System.ComponentModel.BackgroundWorker mybase_BackgroundWorker = null;
    private class UnSafeNativeMethods
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetRawInputDeviceList(System.IntPtr pRawInputDeviceList, ref int uiNumDevices, int cbSize);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetRawInputDeviceInfo(System.IntPtr hDevice, int uiCommand, System.IntPtr pData, ref int pcbSize);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto, EntryPoint = "RegisterRawInputDevices")]
        public static extern bool RegisterRawInputDevices([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPArray, SizeParamIndex = 0)]RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int GetRawInputData(System.IntPtr hRawInput, RawInputCommand uiCommand, System.IntPtr pData, ref int pcbSize, int cbSizeHeader);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern System.IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, System.IntPtr hWndParent, System.IntPtr hMenu, System.IntPtr hInst, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.AsAny)]object pvParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern short RegisterClass(WNDCLASS wc);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern bool TranslateMessage([System.Runtime.InteropServices.In(), System.Runtime.InteropServices.Out()]ref MSG msg);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int DispatchMessage([System.Runtime.InteropServices.In()]ref MSG msg);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern System.IntPtr DefWindowProc(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto, ExactSpelling = true)]
        public static extern void PostQuitMessage(int nExitCode);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern int GetMessage([System.Runtime.InteropServices.In(), System.Runtime.InteropServices.Out()]ref MSG msg, System.IntPtr hWnd, int uMsgFilterMin, int uMsgFilterMax);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern bool PostMessage(System.IntPtr hWnd, uint Msg, int wParam, long lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        public static extern System.IntPtr GetForegroundWindow();
    }
    static internal void OnWin32Error(System.Exception ex)
    {
        System.Diagnostics.Debug.WriteLine(ex.ToString());
        m_errorMessage = ex.ToString();
        m_lastWin32Error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
        if ((((mybase_BackgroundWorker != null)) && (!mybase_BackgroundWorker.CancellationPending)))
        {
            mybase_BackgroundWorker.CancelAsync();
        }
    }
    static internal System.IntPtr CreateWindowEx(int dwExStyle, string lpszClassName, string lpszWindowName, int style, int x, int y, int width, int height, System.IntPtr hWndParent, System.IntPtr hMenu, System.IntPtr hInst, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.AsAny)]object pvParam)
    {
        System.IntPtr result = System.IntPtr.Zero;
        try
        {
            result = UnSafeNativeMethods.CreateWindowEx(dwExStyle, lpszClassName, lpszWindowName, style, x, y, width, height, hWndParent, hMenu, hInst, pvParam);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = System.IntPtr.Zero;
        }
        return result;
    }
    static internal short RegisterClass(WNDCLASS wc)
    {
        short result = -1;
        try
        {
            result = UnSafeNativeMethods.RegisterClass(wc);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = -1;
        }
        return result;
    }
    static internal bool TranslateMessage([System.Runtime.InteropServices.In(), System.Runtime.InteropServices.Out()]
ref MSG msg)
    {
        bool result = false;
        try
        {
            result = UnSafeNativeMethods.TranslateMessage(ref msg);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = false;
        }
        return result;
    }
    static internal int DispatchMessage([System.Runtime.InteropServices.In()]
ref MSG msg)
    {
        int result = -1;
        try
        {
            result = UnSafeNativeMethods.DispatchMessage(ref msg);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = -1;
        }
        return result;
    }
    static internal System.IntPtr DefWindowProc(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam)
    {
        System.IntPtr result = System.IntPtr.Zero;
        try
        {
            result = UnSafeNativeMethods.DefWindowProc(hWnd, msg, wParam, lParam);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = System.IntPtr.Zero;
        }
        return result;
    }
    static internal void PostQuitMessage(int nExitCode)
    {
        try
        {
            UnSafeNativeMethods.PostQuitMessage(nExitCode);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
        }
    }
    static internal int GetMessage([System.Runtime.InteropServices.In(), System.Runtime.InteropServices.Out()]
ref MSG msg, System.IntPtr hWnd, int uMsgFilterMin, int uMsgFilterMax)
    {
        int result = -1;
        try
        {
            result = UnSafeNativeMethods.GetMessage(ref msg, hWnd, uMsgFilterMin, uMsgFilterMax);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = -1;
        }
        return result;
    }
    static internal bool RegisterRawInputDevices([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPArray, SizeParamIndex = 0)]
RAWINPUTDEVICE[] pRawInputDevices, int uiNumDevices, int cbSize)
    {
        bool result = false;
        try
        {
            result = UnSafeNativeMethods.RegisterRawInputDevices(pRawInputDevices, uiNumDevices, cbSize);
            if (!result)
            {
                OnWin32Error(new System.Exception("Native Method RegisterRawInputDevices returned False"));
            }
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = false;
        }
        return result;
    }
    static internal int GetRawInputData(System.IntPtr hRawInput, RawInputCommand uiCommand, System.IntPtr pData, ref int pcbSize, int cbSizeHeader)
    {
        int result = -1;
        try
        {
            result = UnSafeNativeMethods.GetRawInputData(hRawInput, uiCommand, pData, ref pcbSize, cbSizeHeader);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = -1;
        }
        return result;
    }
    static internal int GetRawInputDeviceList(System.IntPtr pRawInputDeviceList, ref int uiNumDevices, int cbSize)
    {
        int result = -1;
        try
        {
            result = UnSafeNativeMethods.GetRawInputDeviceList(pRawInputDeviceList, ref uiNumDevices, cbSize);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = -1;
        }
        return result;
    }
    static internal int GetRawInputDeviceInfo(System.IntPtr hDevice, int uiCommand, [System.Runtime.InteropServices.In()]
	[System.Runtime.InteropServices.Out()]
	[System.Runtime.InteropServices.Optional()]System.IntPtr pData, [System.Runtime.InteropServices.In()]
	[System.Runtime.InteropServices.Out()]
ref int pcbSize)
    {
        int result = -1;
        try
        {
            result = UnSafeNativeMethods.GetRawInputDeviceInfo(hDevice, uiCommand, pData, ref pcbSize);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = -1;
        }
        return result;
    }
    static internal bool PostMessage(System.IntPtr hWnd, int Msg, int wParam, long lParam)
    {
        System.Diagnostics.Debug.WriteLine(hWnd.ToString("X16") + " : " + Msg.ToString("X16") + " : " + wParam.ToString("X16") + " : " + lParam.ToString("X16"));
        x = x + 1;
        if (x == 30)
        {
            System.Diagnostics.Debug.WriteLine("---------");
        }
        bool result = false;
        try
        {
            result = UnSafeNativeMethods.PostMessage(hWnd, (uint)Msg, wParam, lParam);
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = false;
        }
        return result;
    }
    static internal System.IntPtr GetForegroundWindow()
    {
        System.IntPtr result = System.IntPtr.Zero;
        try
        {
            result = UnSafeNativeMethods.GetForegroundWindow();
        }
        catch (System.Exception ex)
        {
            OnWin32Error(ex);
            result = System.IntPtr.Zero;
        }
        return result;
    }
}




public delegate System.IntPtr WndProc(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam);


[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct MSG
{
    public System.IntPtr hwnd;
    public int message;
    public System.IntPtr wParam;
    public System.IntPtr lParam;
    public int time;
    public int pt_x;
    public int pt_y;
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
public class WNDCLASS
{
    public int style = 0;
    public WndProc lpfnWndProc = null;
    public int cbClsExtra = 0;
    public int cbWndExtra = 0;
    public System.IntPtr hInstance = System.IntPtr.Zero;
    public System.IntPtr hIcon = System.IntPtr.Zero;
    public System.IntPtr hCursor = System.IntPtr.Zero;
    public System.IntPtr hbrBackground = System.IntPtr.Zero;
    public string lpszMenuName = "";
    public string lpszClassName = "";
}

/// <summary>HID usage page flags.</summary>
public enum HIDUsagePage : ushort
{
    /// <summary>Unknown usage page.</summary>
    Undefined = 0x0,
    /// <summary>Generic desktop controls.</summary>
    Generic = 0x1,
    /// <summary>Simulation controls.</summary>
    Simulation = 0x2,
    /// <summary>Virtual reality controls.</summary>
    VR = 0x3,
    /// <summary>Sports controls.</summary>
    Sport = 0x4,
    /// <summary>Games controls.</summary>
    Game = 0x5,
    /// <summary>Keyboard controls.</summary>
    Keyboard = 0x7,
    /// <summary>LED controls.</summary>
    LED = 0x8,
    /// <summary>Button.</summary>
    Button = 0x9,
    /// <summary>Ordinal.</summary>
    Ordinal = 0xa,
    /// <summary>Telephony.</summary>
    Telephony = 0xb,
    /// <summary>Consumer.</summary>
    Consumer = 0xc,
    /// <summary>Digitizer.</summary>
    Digitizer = 0xd,
    /// <summary>Physical interface device.</summary>
    PID = 0xf,
    /// <summary>Unicode.</summary>
    Unicode = 0x10,
    /// <summary>Alphanumeric display.</summary>
    AlphaNumeric = 0x14,
    /// <summary>Medical instruments.</summary>
    Medical = 0x40,
    /// <summary>Monitor page 0.</summary>
    MonitorPage0 = 0x80,
    /// <summary>Monitor page 1.</summary>
    MonitorPage1 = 0x81,
    /// <summary>Monitor page 2.</summary>
    MonitorPage2 = 0x82,
    /// <summary>Monitor page 3.</summary>
    MonitorPage3 = 0x83,
    /// <summary>Power page 0.</summary>
    PowerPage0 = 0x84,
    /// <summary>Power page 1.</summary>
    PowerPage1 = 0x85,
    /// <summary>Power page 2.</summary>
    PowerPage2 = 0x86,
    /// <summary>Power page 3.</summary>
    PowerPage3 = 0x87,
    /// <summary>Bar code scanner.</summary>
    BarCode = 0x8c,
    /// <summary>Scale page.</summary>
    Scale = 0x8d,
    /// <summary>Magnetic strip reading devices.</summary>
    MSR = 0x8e
}

/// <summary>Enumeration containing the HID usage values.</summary>
public enum HIDUsage : ushort
{
    /// <summary></summary>
    Pointer = 0x1,
    /// <summary></summary>
    Mouse = 0x2,
    /// <summary></summary>
    Joystick = 0x4,
    /// <summary></summary>
    Gamepad = 0x5,
    /// <summary></summary>
    Keyboard = 0x6,
    /// <summary></summary>
    Keypad = 0x7,
    /// <summary></summary>
    SystemControl = 0x80,
    /// <summary></summary>
    X = 0x30,
    /// <summary></summary>
    Y = 0x31,
    /// <summary></summary>
    Z = 0x32,
    /// <summary></summary>
    RelativeX = 0x33,
    /// <summary></summary>    
    RelativeY = 0x34,
    /// <summary></summary>
    RelativeZ = 0x35,
    /// <summary></summary>
    Slider = 0x36,
    /// <summary></summary>
    Dial = 0x37,
    /// <summary></summary>
    Wheel = 0x38,
    /// <summary></summary>
    HatSwitch = 0x39,
    /// <summary></summary>
    CountedBuffer = 0x3a,
    /// <summary></summary>
    ByteCount = 0x3b,
    /// <summary></summary>
    MotionWakeup = 0x3c,
    /// <summary></summary>
    VX = 0x40,
    /// <summary></summary>
    VY = 0x41,
    /// <summary></summary>
    VZ = 0x42,
    /// <summary></summary>
    VBRX = 0x43,
    /// <summary></summary>
    VBRY = 0x44,
    /// <summary></summary>
    VBRZ = 0x45,
    /// <summary></summary>
    VNO = 0x46,
    /// <summary></summary>
    SystemControlPower = 0x81,
    /// <summary></summary>
    SystemControlSleep = 0x82,
    /// <summary></summary>
    SystemControlWake = 0x83,
    /// <summary></summary>
    SystemControlContextMenu = 0x84,
    /// <summary></summary>
    SystemControlMainMenu = 0x85,
    /// <summary></summary>
    SystemControlApplicationMenu = 0x86,
    /// <summary></summary>
    SystemControlHelpMenu = 0x87,
    /// <summary></summary>
    SystemControlMenuExit = 0x88,
    /// <summary></summary>
    SystemControlMenuSelect = 0x89,
    /// <summary></summary>
    SystemControlMenuRight = 0x8a,
    /// <summary></summary>
    SystemControlMenuLeft = 0x8b,
    /// <summary></summary>
    SystemControlMenuUp = 0x8c,
    /// <summary></summary>
    SystemControlMenuDown = 0x8d,
    /// <summary></summary>
    KeyboardNoEvent = 0x0,
    /// <summary></summary>
    KeyboardRollover = 0x1,
    /// <summary></summary>
    KeyboardPostFail = 0x2,
    /// <summary></summary>
    KeyboardUndefined = 0x3,
    /// <summary></summary>
    KeyboardaA = 0x4,
    /// <summary></summary>
    KeyboardzZ = 0x1d,
    /// <summary></summary>
    Keyboard1 = 0x1e,
    /// <summary></summary>
    Keyboard0 = 0x27,
    /// <summary></summary>
    KeyboardLeftControl = 0xe0,
    /// <summary></summary>
    KeyboardLeftShift = 0xe1,
    /// <summary></summary>
    KeyboardLeftALT = 0xe2,
    /// <summary></summary>
    KeyboardLeftGUI = 0xe3,
    /// <summary></summary>
    KeyboardRightControl = 0xe4,
    /// <summary></summary>
    KeyboardRightShift = 0xe5,
    /// <summary></summary>
    KeyboardRightALT = 0xe6,
    /// <summary></summary>
    KeyboardRightGUI = 0xe7,
    /// <summary></summary>
    KeyboardScrollLock = 0x47,
    /// <summary></summary>
    KeyboardNumLock = 0x53,
    /// <summary></summary>
    KeyboardCapsLock = 0x39,
    /// <summary></summary>
    KeyboardF1 = 0x3a,
    /// <summary></summary>
    KeyboardF12 = 0x45,
    /// <summary></summary>
    KeyboardReturn = 0x28,
    /// <summary></summary>
    KeyboardEscape = 0x29,
    /// <summary></summary>
    KeyboardDelete = 0x2a,
    /// <summary></summary>
    KeyboardPrintScreen = 0x46,
    /// <summary></summary>
    LEDNumLock = 0x1,
    /// <summary></summary>
    LEDCapsLock = 0x2,
    /// <summary></summary>
    LEDScrollLock = 0x3,
    /// <summary></summary>
    LEDCompose = 0x4,
    /// <summary></summary>
    LEDKana = 0x5,
    /// <summary></summary>
    LEDPower = 0x6,
    /// <summary></summary>
    LEDShift = 0x7,
    /// <summary></summary>
    LEDDoNotDisturb = 0x8,
    /// <summary></summary>
    LEDMute = 0x9,
    /// <summary></summary>
    LEDToneEnable = 0xa,
    /// <summary></summary>
    LEDHighCutFilter = 0xb,
    /// <summary></summary>
    LEDLowCutFilter = 0xc,
    /// <summary></summary>
    LEDEqualizerEnable = 0xd,
    /// <summary></summary>
    LEDSoundFieldOn = 0xe,
    /// <summary></summary>
    LEDSurroundFieldOn = 0xf,
    /// <summary></summary>
    LEDRepeat = 0x10,
    /// <summary></summary>
    LEDStereo = 0x11,
    /// <summary></summary>
    LEDSamplingRateDirect = 0x12,
    /// <summary></summary>
    LEDSpinning = 0x13,
    /// <summary></summary>
    LEDCAV = 0x14,
    /// <summary></summary>
    LEDCLV = 0x15,
    /// <summary></summary>
    LEDRecordingFormatDet = 0x16,
    /// <summary></summary>
    LEDOffHook = 0x17,
    /// <summary></summary>
    LEDRing = 0x18,
    /// <summary></summary>
    LEDMessageWaiting = 0x19,
    /// <summary></summary>
    LEDDataMode = 0x1a,
    /// <summary></summary>
    LEDBatteryOperation = 0x1b,
    /// <summary></summary>
    LEDBatteryOK = 0x1c,
    /// <summary></summary>
    LEDBatteryLow = 0x1d,
    /// <summary></summary>
    LEDSpeaker = 0x1e,
    /// <summary></summary>
    LEDHeadset = 0x1f,
    /// <summary></summary>
    LEDHold = 0x20,
    /// <summary></summary>
    LEDMicrophone = 0x21,
    /// <summary></summary>
    LEDCoverage = 0x22,
    /// <summary></summary>
    LEDNightMode = 0x23,
    /// <summary></summary>
    LEDSendCalls = 0x24,
    /// <summary></summary>
    LEDCallPickup = 0x25,
    /// <summary></summary>
    LEDConference = 0x26,
    /// <summary></summary>
    LEDStandBy = 0x27,
    /// <summary></summary>
    LEDCameraOn = 0x28,
    /// <summary></summary>
    LEDCameraOff = 0x29,
    /// <summary></summary>    
    LEDOnLine = 0x2a,
    /// <summary></summary>
    LEDOffLine = 0x2b,
    /// <summary></summary>
    LEDBusy = 0x2c,
    /// <summary></summary>
    LEDReady = 0x2d,
    /// <summary></summary>
    LEDPaperOut = 0x2e,
    /// <summary></summary>
    LEDPaperJam = 0x2f,
    /// <summary></summary>
    LEDRemote = 0x30,
    /// <summary></summary>
    LEDForward = 0x31,
    /// <summary></summary>
    LEDReverse = 0x32,
    /// <summary></summary>
    LEDStop = 0x33,
    /// <summary></summary>
    LEDRewind = 0x34,
    /// <summary></summary>
    LEDFastForward = 0x35,
    /// <summary></summary>
    LEDPlay = 0x36,
    /// <summary></summary>
    LEDPause = 0x37,
    /// <summary></summary>
    LEDRecord = 0x38,
    /// <summary></summary>
    LEDError = 0x39,
    /// <summary></summary>
    LEDSelectedIndicator = 0x3a,
    /// <summary></summary>
    LEDInUseIndicator = 0x3b,
    /// <summary></summary>
    LEDMultiModeIndicator = 0x3c,
    /// <summary></summary>
    LEDIndicatorOn = 0x3d,
    /// <summary></summary>
    LEDIndicatorFlash = 0x3e,
    /// <summary></summary>
    LEDIndicatorSlowBlink = 0x3f,
    /// <summary></summary>
    LEDIndicatorFastBlink = 0x40,
    /// <summary></summary>
    LEDIndicatorOff = 0x41,
    /// <summary></summary>
    LEDFlashOnTime = 0x42,
    /// <summary></summary>
    LEDSlowBlinkOnTime = 0x43,
    /// <summary></summary>
    LEDSlowBlinkOffTime = 0x44,
    /// <summary></summary>
    LEDFastBlinkOnTime = 0x45,
    /// <summary></summary>
    LEDFastBlinkOffTime = 0x46,
    /// <summary></summary>
    LEDIndicatorColor = 0x47,
    /// <summary></summary>
    LEDRed = 0x48,
    /// <summary></summary>
    LEDGreen = 0x49,
    /// <summary></summary>
    LEDAmber = 0x4a,
    /// <summary></summary>
    LEDGenericIndicator = 0x3b,
    /// <summary></summary>
    TelephonyPhone = 0x1,
    /// <summary></summary>
    TelephonyAnsweringMachine = 0x2,
    /// <summary></summary>
    TelephonyMessageControls = 0x3,
    /// <summary></summary>
    TelephonyHandset = 0x4,
    /// <summary></summary>
    TelephonyHeadset = 0x5,
    /// <summary></summary>
    TelephonyKeypad = 0x6,
    /// <summary></summary>
    TelephonyProgrammableButton = 0x7,
    /// <summary></summary>
    SimulationRudder = 0xba,
    /// <summary></summary>
    SimulationThrottle = 0xbb
}

/// <summary>RawInput device flags.</summary>
[System.Flags()]
public enum RawInputDeviceFlags : int
{
    /// <summary>No flags.</summary>
    None = 0,
    /// <summary>If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from a device which matches the top level collection.</summary>
    Remove = 0x1,
    /// <summary>If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC whose usage page is already specified with PageOnly.</summary>
    Exclude = 0x10,
    /// <summary>If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that Usage must be zero. To exclude a particular top level collection, use Exclude.</summary>
    PageOnly = 0x20,
    /// <summary>If set, this prevents any devices specified by UsagePage or Usage from generating legacy messages. This is only for the mouse and keyboard.</summary>
    NoLegacy = 0x30,
    /// <summary>If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that WindowHandle must be specified.</summary>
    InputSink = 0x100,
    /// <summary>If set, the mouse button click does not activate the other window.</summary>
    CaptureMouse = 0x200,
    /// <summary>If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. NoHotKeys can be specified even if NoLegacy is not specified and WindowHandle is NULL.</summary>
    NoHotKeys = 0x200,
    /// <summary>If set, application keys are handled.  NoLegacy must be specified.  Keyboard only.</summary>
    AppKeys = 0x400
}

/// <summary> Enumeration containing the type device the raw input is coming from. </summary>
public enum RawInputType : int
{
    /// <summary> Mouse input. </summary>
    RIM_TYPEMOUSE = 0,
    /// <summary> Keyboard input. </summary>
    RIM_TYPEKEYBOARD = 1,
    /// <summary> Another device that is not the keyboard or the mouse. </summary>
    RIM_TYPEHID = 2
}

/// <summary> Enumeration contanining the command types to issue. </summary>
public enum RawInputCommand : int
{
    /// <summary> Get input data. </summary>
    Input = 0x10000003,
    /// <summary> Get header data. </summary>
    Header = 0x10000005
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct RAWINPUTDEVICELIST
{
    public System.IntPtr hDevice;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public int dwType;
}

//<System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)> _
//Public Structure RAWINPUT
//    <System.Runtime.InteropServices.FieldOffset(0)> _
//    Public header As RAWINPUTHEADER
//    <System.Runtime.InteropServices.FieldOffset(16)> _
//    Public mouse As RAWMOUSE
//    <System.Runtime.InteropServices.FieldOffset(16)> _
//    Public keyboard As RAWKEYBOARD
//    <System.Runtime.InteropServices.FieldOffset(16)> _
//    Public hid As RAWHID
//End Structure

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct RawInput
{
    public RAWINPUTHEADER Header;
    public Union Data;
    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct Union
    {
        [System.Runtime.InteropServices.FieldOffset(0)]
        public RAWMOUSE Mouse;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public RAWKEYBOARD Keyboard;
        [System.Runtime.InteropServices.FieldOffset(0)]
        public RAWHID HID;
    }
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct RAWINPUTHEADER
{
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public int dwType;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public int dwSize;
    public System.IntPtr hDevice;
    public System.IntPtr wParam;
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct RAWHID
{
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public int dwSizeHID;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public int dwCount;
    public System.IntPtr pData;
    public int Length
    {
        get { return dwSizeHID; }
    }
    public byte[] data(int index)
    {
        byte[] result = new byte[1];
        if (((dwCount > 0) && (index < dwSizeHID)))
        {
            result = new byte[dwCount];
            System.Runtime.InteropServices.Marshal.Copy(pData, result, System.Convert.ToInt32(index * dwCount), dwCount);
        }
        return result;
    }
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct BUTTONSSTR
{
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort usButtonFlags;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort usButtonData;
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Explicit)]
public struct RAWMOUSE
{
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    [System.Runtime.InteropServices.FieldOffset(0)]
    public ushort usFlags;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    [System.Runtime.InteropServices.FieldOffset(4)]
    public uint ulButtons;
    [System.Runtime.InteropServices.FieldOffset(4)]
    public BUTTONSSTR buttonsStr;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    [System.Runtime.InteropServices.FieldOffset(8)]
    public uint ulRawButtons;
    [System.Runtime.InteropServices.FieldOffset(12)]
    public int lLastX;
    [System.Runtime.InteropServices.FieldOffset(16)]
    public int lLastY;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    [System.Runtime.InteropServices.FieldOffset(20)]
    public uint ulExtraInformation;
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct RAWKEYBOARD
{
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort MakeCode;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort Flags;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort Reserved;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort VKey;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public uint Message;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public uint ExtraInformation;
}

[System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
public struct RAWINPUTDEVICE
{
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort usUsagePage;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U2)]
    public ushort usUsage;
    [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.U4)]
    public int dwFlags;
    public System.IntPtr hwndTarget;
}













public struct DeviceInfo
{
    public int Size;
    public int Type;
    public DeviceInfoMouse MouseInfo;
    public DeviceInfoKeyboard KeyboardInfo;
    public DeviceInfoHID HIDInfo;
}

public struct DeviceInfoMouse
{
    public uint ID;
    public uint NumberOfButtons;
    public uint SampleRate;
}

public struct DeviceInfoKeyboard
{
    public uint Type;
    public uint SubType;
    public uint KeyboardMode;
    public uint NumberOfFunctionKeys;
    public uint NumberOfIndicators;
    public uint NumberOfKeysTotal;
}

public struct DeviceInfoHID
{
    public uint VendorID;
    public uint ProductID;
    public uint VersionNumber;
    public ushort UsagePage;
    public ushort Usage;
}