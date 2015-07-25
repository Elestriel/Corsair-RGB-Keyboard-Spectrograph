
public class RawInputHook : RawInputNativeMethods
{
    private SimpleMessageOnlyWindow m_SimpleMessageWindow = new SimpleMessageOnlyWindow();
    public event OnRawInputFromMouseEventHandler OnRawInputFromMouse;
    public delegate void OnRawInputFromMouseEventHandler(RAWINPUTHEADER riHeader, RAWMOUSE riMouse);
    public event OnRawInputFromKeyboardEventHandler OnRawInputFromKeyboard;
    public delegate void OnRawInputFromKeyboardEventHandler(RAWINPUTHEADER riHeader, RAWKEYBOARD riKeyboard);
    public event OnRawInputFromHIDEventHandler OnRawInputFromHID;
    public delegate void OnRawInputFromHIDEventHandler(RAWINPUTHEADER riHeader, RAWHID riHID);
    public event OnRawInputFromUnknownEventHandler OnRawInputFromUnknown;
    public delegate void OnRawInputFromUnknownEventHandler(RawInput riUnknownType);

    public RawInputHook()
    {
        m_SimpleMessageWindow.OnWindowsMessageCreate += new SimpleMessageOnlyWindow.OnWindowsMessageCreateEventHandler(SimpleMessageWindowCreate);
        m_SimpleMessageWindow.OnWindowsMessageInput += new SimpleMessageOnlyWindow.OnWindowsMessageInputEventHandler(SimpleMessageWindowInput);
        //
    }

    public void SimpleMessageWindowCreate(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam)
    {
        RAWINPUTDEVICE[] rid = { new RAWINPUTDEVICE() };
        rid[0].dwFlags = (int)RawInputDeviceFlags.InputSink | (int)RawInputDeviceFlags.NoHotKeys;
        rid[0].usUsagePage = (ushort)HIDUsagePage.Generic;
        rid[0].usUsage = (ushort)HIDUsage.Keyboard;
        rid[0].hwndTarget = hWnd;
        RegisterRawInputDevices(rid, rid.Length, System.Runtime.InteropServices.Marshal.SizeOf(rid[0]));
    }

    public void SimpleMessageWindowInput(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam)
    {
        RawInput ri = new RawInput();
        int blen = 0;
        int hlen = System.Runtime.InteropServices.Marshal.SizeOf(typeof(RAWINPUTHEADER));
        int bytesRead = -1;

        bytesRead = GetRawInputData(lParam, RawInputCommand.Input, System.IntPtr.Zero, ref blen, hlen);
        if (((bytesRead == -1) || (blen < 1)))
        {
            System.Diagnostics.Debug.WriteLine("GetRawInputData Error Retreiving Buffer size.");
        }
        else
        {
            System.IntPtr riBuffer = System.Runtime.InteropServices.Marshal.AllocHGlobal(blen);
            bytesRead = GetRawInputData(lParam, RawInputCommand.Input, riBuffer, ref blen, hlen);
            if (bytesRead != blen)
            {
                System.Diagnostics.Debug.WriteLine("GetRawInputData Error Retreiving Buffer data.");
            }
            else
            {
                byte[] bb = new byte[bytesRead];
                try
                {
                    ri = (RawInput)System.Runtime.InteropServices.Marshal.PtrToStructure(riBuffer, typeof(RawInput));
                    System.Runtime.InteropServices.Marshal.Copy(riBuffer, bb, 0, bb.Length);
                }
                catch (System.Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());
                }
                if (ri.Equals(null))
                {
                    System.Diagnostics.Debug.WriteLine("Error Casting Marshalled Buffer into RawInput structure.");
                }
                else
                {
                    //string deviceType = null;
                    switch (ri.Header.dwType)
                    {
                        case 0:
                            //deviceType = "MOUSE";
                            if ((((OnRawInputFromMouse != null)) && (OnRawInputFromMouse.GetInvocationList().Length > 0)))
                            {
                                RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnRawInputFromMouse, new object[] {
				ri.Header,
				ri.Data.Mouse
			});
                            }
                            break;
                        case 1:
                            //deviceType = "KEYBOARD";
                            if ((((OnRawInputFromKeyboard != null)) && (OnRawInputFromKeyboard.GetInvocationList().Length > 0)))
                            {
                                RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnRawInputFromKeyboard, new object[] {
				ri.Header,
				ri.Data.Keyboard
			});
                            }
                            break;
                        case 2:
                            //deviceType = "HID";
                            if ((((OnRawInputFromHID != null)) && (OnRawInputFromHID.GetInvocationList().Length > 0)))
                            {
                                RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnRawInputFromHID, new object[] {
				ri.Header,
				ri.Data.HID
			});
                            }
                            break;
                        default:
                            //deviceType = "UNKNOWN";
                            if ((((OnRawInputFromUnknown != null)) && (OnRawInputFromUnknown.GetInvocationList().Length > 0)))
                            {
                                RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnRawInputFromUnknown, new object[] { ri });
                            }
                            break;
                    }
                }
            }
            try
            {
                System.Runtime.InteropServices.Marshal.FreeHGlobal(riBuffer);
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error Freeing Marshalled Buffer for RawInput data.");
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
    }
    public int lastWin32Error
    {
        get { return m_lastWin32Error; }
    }
    public string errorMessage
    {
        get { return m_errorMessage; }
    }
}


//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik, @toddanglin
//Facebook: facebook.com/telerik
//=======================================================
