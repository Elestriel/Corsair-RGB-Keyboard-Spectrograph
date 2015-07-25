
public class SimpleMessageOnlyWindow : RawInputNativeMethods
{
    private const int WM_CREATE = 1;
    private const int WM_CLOSE = 16;
    private const int WM_INPUT = 255;
    private int m_exitCode = 0;
    private int m_messageCount = 0;
    private System.IntPtr m_handle = System.IntPtr.Zero;
    private System.ComponentModel.BackgroundWorker m_BackgroundWorker = new System.ComponentModel.BackgroundWorker(); //Asynchronous Non-Blocking Background Worker
    public event OnWindowsMessageCreateEventHandler OnWindowsMessageCreate;
    public delegate void OnWindowsMessageCreateEventHandler(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam);
    public event OnWindowsMessageInputEventHandler OnWindowsMessageInput;
    public delegate void OnWindowsMessageInputEventHandler(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam);
    public event OnWindowsMessageCloseEventHandler OnWindowsMessageClose;
    public delegate void OnWindowsMessageCloseEventHandler(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam);
    public event OnNativeGetMessageEventHandler OnNativeGetMessage;
    public delegate void OnNativeGetMessageEventHandler(object Sender, int msgCount, int iRet, MSG msg);
    private struct OnWindowMessageParams
    {
        public System.IntPtr hWnd;
        public int msg;
        public System.IntPtr wParam;
        public System.IntPtr lParam;
    }
    public System.IntPtr WndProcCallback(System.IntPtr hWnd, int msg, System.IntPtr wParam, System.IntPtr lParam)
    {
        OnWindowMessageParams msgParams = new OnWindowMessageParams();
        msgParams.hWnd = hWnd;
        msgParams.msg = msg;
        msgParams.wParam = wParam;
        msgParams.lParam = lParam;
        switch (msg)
        {
            case WM_CREATE:
                m_BackgroundWorker.ReportProgress(31, msgParams);
                break;
            case WM_INPUT:
                m_BackgroundWorker.ReportProgress(32, msgParams);
                break;
            case WM_CLOSE:
                m_BackgroundWorker.ReportProgress(33, msgParams);
                PostQuitMessage(m_exitCode);
                //0)
                if (!m_BackgroundWorker.CancellationPending)
                {
                    m_BackgroundWorker.CancelAsync();
                }
                break;
            default:
                return DefWindowProc(hWnd, msg, wParam, lParam);
        }
        return System.IntPtr.Zero;
    }
    private void m_BackgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
        MSG msg = new MSG();
        WNDCLASS wc = new WNDCLASS();
        System.IntPtr hInstance = new System.IntPtr(System.Runtime.InteropServices.Marshal.GetHINSTANCE(System.Reflection.Assembly.GetExecutingAssembly().GetModules()[0]).ToInt32());
        //System.Runtime.InteropServices.Marshal.GetHINSTANCE(GetType(Module1).Module)
        wc.lpfnWndProc = WndProcCallback;
        wc.hInstance = hInstance;
        wc.lpszClassName = "SimpleMessageWindow";
        RegisterClass(wc);
        m_handle = CreateWindowEx(0, wc.lpszClassName, null, 0, 0, 0, 0, 0, new System.IntPtr(-3), System.IntPtr.Zero, hInstance, 0);
        //(0, wc.lpszClassName, Nothing, 0, 0, 0, 0, 0, -3, 0, hInstance, 0) 'HWND_MESSAGE = -3
        int iRet = 1;
        try
        {
            while (!(((iRet == 0) || (iRet == -1))))
            {
                iRet = GetMessage(ref msg, m_handle, 0, 0);
                //ERROR (GetLastError)
                if (iRet == -1)
                {
                    m_lastWin32Error = System.Runtime.InteropServices.Marshal.GetLastWin32Error();
                    m_exitCode = iRet;
                    //WM_QUIT
                }
                else if (iRet == 0)
                {
                    m_exitCode = msg.wParam.ToInt32();
                }
                else
                {
                    m_BackgroundWorker.ReportProgress(iRet, msg);
                    TranslateMessage(ref msg);
                    DispatchMessage(ref msg);
                }
            }
        }
        catch (System.Exception ex)
        {
            System.Diagnostics.Debug.Write(ex.ToString());
            //should never happen... (all unsafe method calls have handlers)
            iRet = -1;
        }
    }
    private void m_BackgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
    {
        if (((e.UserState != null)))
        {
            int iRet = e.ProgressPercentage;
            if ((object.ReferenceEquals(e.UserState.GetType(), typeof(MSG))))
            {
                m_messageCount += 1;
                MSG msg = (MSG)e.UserState;
                if ((((OnNativeGetMessage != null)) && (OnNativeGetMessage.GetInvocationList().Length > 0)))
                {
                    RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnNativeGetMessage, new object[] {
					this,
					m_messageCount,
					iRet,
					msg
				});
                }
            }
            else if ((object.ReferenceEquals(e.UserState.GetType(), typeof(OnWindowMessageParams))))
            {
                OnWindowMessageParams msgParams = (OnWindowMessageParams)e.UserState;
                if (iRet == 31)
                {
                    if ((((OnWindowsMessageCreate != null)) && (OnWindowsMessageCreate.GetInvocationList().Length > 0)))
                    {
                        RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnWindowsMessageCreate, new object[] {
						msgParams.hWnd,
						msgParams.msg,
						msgParams.wParam,
						msgParams.lParam
					});
                    }
                }
                else if (iRet == 32)
                {
                    if ((((OnWindowsMessageInput != null)) && (OnWindowsMessageInput.GetInvocationList().Length > 0)))
                    {
                        RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnWindowsMessageInput, new object[] {
						msgParams.hWnd,
						msgParams.msg,
						msgParams.wParam,
						msgParams.lParam
					});
                    }
                }
                else if (iRet == 33)
                {
                    if ((((OnWindowsMessageClose != null)) && (OnWindowsMessageClose.GetInvocationList().Length > 0)))
                    {
                        RaiseEventUtility.RaiseEventAndExecuteItInTheTargetThread(OnWindowsMessageClose, new object[] {
						msgParams.hWnd,
						msgParams.msg,
						msgParams.wParam,
						msgParams.lParam
					});
                    }
                }
            }
        }
    }
    public SimpleMessageOnlyWindow()
    {
        m_BackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(m_BackgroundWorker_DoWork);
        m_BackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(m_BackgroundWorker_ProgressChanged);
        m_BackgroundWorker.WorkerReportsProgress = true;
        m_BackgroundWorker.WorkerSupportsCancellation = true;
        mybase_BackgroundWorker = m_BackgroundWorker;
        m_BackgroundWorker.RunWorkerAsync();
    }
    public int lastWin32Error
    {
        get { return m_lastWin32Error; }
    }
    public string errorMessage
    {
        get { return m_errorMessage; }
    }
    public int exitCode
    {
        get { return m_exitCode; }
    }
    public int messageCount
    {
        get { return m_messageCount; }
    }
    public System.IntPtr handle
    {
        get { return m_handle; }
    }
}













