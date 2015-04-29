using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace RGBKeyboardSpectrograph
{
    public partial class MainForm : Form
    {
        string[] keyboardIDs;
        string[] keyboardNames;
        string[] keyboardPositionMaps;
        string[] keyboardSizeMaps;
        Thread workerThread = Program.newWorker;
        public MainForm()
        {
            InitializeComponent();
        }

        #region Form Stuff
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Program.RunKeyboardThread != 0) { StopSpectrograph(); };

            while (workerThread.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(1000);
                UpdateStatusMessage.ShowStatusMessage(2, "Waiting for thread to quit");
            } 

            Properties.Settings.Default.userKeyboardModel = KeyboardModelComboBox.Text;
            Properties.Settings.Default.userKeyboardLayout = KeyboardLayoutComboBox.Text;
            Properties.Settings.Default.userAmplitude = (int)AmplitudeUD.Value;
            Properties.Settings.Default.userBackgroundBrightness = (int)BackgroundBrightnessUD.Value;
            Properties.Settings.Default.userRed = (int)BarRed.Value;
            Properties.Settings.Default.userGreen = (int)BarGreen.Value;
            Properties.Settings.Default.userBlue = (int)BarBlue.Value;
            Properties.Settings.Default.userLogLevel = (int)LogLevelUD.Value;
            Properties.Settings.Default.userMinimizeToTray = MinimizeToTrayCheck.Checked;
            Properties.Settings.Default.userRefreshDelay = (int)RefreshDelayUD.Value;
            Properties.Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && MinimizeToTrayCheck.Checked == true)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatusMessage.ShowStatusMessage(0, "Version " + Program.VersionNumber);
            UpdateStatusMessage.ShowStatusMessage(1, "Populating Controls");
            LaunchCueCheck.Visible = false; //Hide the Launch CUE checkbox for now
            notifyIcon.Visible = false;
            KeyboardModelComboBox.Items.Add("K65-RGB");
            KeyboardModelComboBox.Items.Add("K70-RGB");
            KeyboardModelComboBox.Items.Add("K95-RGB");
            
            UpdateStatusMessage.ShowStatusMessage(1, "Loading Settings");
            string settingKeyboardModel = Properties.Settings.Default.userKeyboardModel;
            string settingKeyboardLayout = Properties.Settings.Default.userKeyboardLayout;
            int settingAmplitude = Properties.Settings.Default.userAmplitude;
            int settingBackgroundBrightness = Properties.Settings.Default.userBackgroundBrightness;
            int settingBarRed = Properties.Settings.Default.userRed;
            int settingBarGreen = Properties.Settings.Default.userGreen;
            int settingBarBlue = Properties.Settings.Default.userBlue;
            int settingLogLevel = Properties.Settings.Default.userLogLevel;
            bool settingMinimizeToTray = Properties.Settings.Default.userMinimizeToTray;
            int settingRefreshDelay = Properties.Settings.Default.userRefreshDelay;

            // Make sure no sneaky incorrect options could be set as the text of the ComboBoxes
            if (KeyboardModelComboBox.FindStringExact(settingKeyboardModel) > -1) { KeyboardModelComboBox.SelectedIndex = KeyboardModelComboBox.FindStringExact(settingKeyboardModel); };
            if (KeyboardLayoutComboBox.FindStringExact(settingKeyboardLayout) > -1) { KeyboardLayoutComboBox.SelectedIndex = KeyboardLayoutComboBox.FindStringExact(settingKeyboardLayout); };

            if (settingAmplitude < 1 || settingAmplitude > 100) { settingAmplitude = 10; };
            if (settingBackgroundBrightness < 0 || settingBackgroundBrightness > 30) { settingBackgroundBrightness = 15; };
            if (settingBarRed < 0 || settingBarRed > 7) { settingBarRed = 7; };
            if (settingBarGreen < 0 || settingBarGreen > 7) { settingBarGreen = 7; };
            if (settingBarBlue < 0 || settingBarBlue > 7) { settingBarBlue = 7; };
            if (settingLogLevel < 3) { settingLogLevel = 3; };
            MinimizeToTrayCheck.Checked = settingMinimizeToTray;
            if (settingRefreshDelay < 5 || settingRefreshDelay > 1000) { settingRefreshDelay = 20; };

            AmplitudeUD.Value = settingAmplitude;
            BackgroundBrightnessUD.Value = settingBackgroundBrightness;
            BarRed.Value = settingBarRed;
            BarGreen.Value = settingBarGreen;
            BarBlue.Value = settingBarBlue;
            LogLevelUD.Value = settingLogLevel;
            Program.LogLevel = settingLogLevel;
            RefreshDelayUD.Value = settingRefreshDelay;

            UpdateStatusMessage.ShowStatusMessage(1, "Ready");
        }

        public bool LoadFromConfig(string KeyboardID)
        {
            if (File.Exists(KeyboardID + ".xml") == false) {
                UpdateStatusMessage.ShowStatusMessage(3, "Keyboard Layout Not Found");
                return false;
            } 
            else
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Loading Keyboard Layouts");

                var document = XDocument.Load(KeyboardID + ".xml");
                keyboardIDs = document.Descendants("id").Select(element => element.Value).ToArray();
                keyboardNames = document.Descendants("name").Select(element => element.Value).ToArray();
                keyboardPositionMaps = document.Descendants("positionmap").Select(element => element.Value).ToArray();
                keyboardSizeMaps = document.Descendants("sizemap").Select(element => element.Value).ToArray();

                switch (KeyboardModelComboBox.Text)
                {
                    case "K65-RGB":
                        //Program.MyKeyboardID = 0x1B17;
                        Program.MyKeyboardID = 0x1B11;
                        Program.MyCanvasWidth = 76;
                        break;
                    case "K70-RGB":
                        //Program.MyKeyboardID = 0x1B13;
                        Program.MyKeyboardID = 0x1B11;
                        Program.MyCanvasWidth = 92;
                        break;
                    case "K95-RGB":
                        Program.MyKeyboardID = 0x1B11;
                        Program.MyCanvasWidth = 104;
                        break;
                }

                UpdateStatusMessage.ShowStatusMessage(4, "Hardware ID: " + Program.MyKeyboardID.ToString("X"));
                KeyboardLayoutComboBox.Items.Clear();

                for (int i = 0; i < keyboardNames.Length; i++)
                {
                    KeyboardLayoutComboBox.Items.Add(keyboardNames[i]);
                }

                return true;
            }
        }
        #endregion

        #region Thread Start/Stop
        private bool StartSpectrograph(int RunType)
        {
            Process[] pname = Process.GetProcessesByName("CorsairHID");
            if (pname.Length != 0) UpdateStatusMessage.ShowStatusMessage(3, "Corsair Utility Engine is still running!");
            
            Program.MyAmplitude = (float)AmplitudeUD.Value;
            Program.MyBarsRed = (int)BarRed.Value;
            Program.MyBarsGreen = (int)BarGreen.Value;
            Program.MyBarsBlue = (int)BarBlue.Value;
            Program.MyBackgroundBrightness = (float)BackgroundBrightnessUD.Value;
            if (KeyboardLayoutComboBox.SelectedIndex < 0) {
                MessageBox.Show("There is no layout selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusMessage.ShowStatusMessage(3, "No layout selected.");
                return false;
            };

            char DecimalSep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            string positionMaps = keyboardPositionMaps[KeyboardLayoutComboBox.SelectedIndex];
            string sizeMaps = keyboardSizeMaps[KeyboardLayoutComboBox.SelectedIndex];

            if (DecimalSep != '.') {
                positionMaps = positionMaps.Replace('.', DecimalSep);
                sizeMaps = sizeMaps.Replace('.', DecimalSep);
            }

            if (positionMaps.Length > 0 && 
                sizeMaps.Length > 0) 
            {
                bool MapFail = false;
                try
                {
                    Program.MyPositionMap = Array.ConvertAll(positionMaps.Split(';'), byte.Parse);
                }
                catch
                {
                    var result = MessageBox.Show("Splitting the position map failed.\n\n" + 
                        "Selected index: " + KeyboardLayoutComboBox.SelectedIndex + 
                        "\nPosition Map:\n[" + positionMaps +"]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatusMessage.ShowStatusMessage(3, "Position Map loading failed.");
                    MapFail = true;
                }

                try
                {
                    Program.MySizeMap = Array.ConvertAll(sizeMaps.Split(';'), float.Parse);
                }
                catch
                {
                    var result = MessageBox.Show("Splitting the size maps failed.\n\n" +
                        "Selected index: " + KeyboardLayoutComboBox.SelectedIndex +
                        "\nSize Map:\n[" + sizeMaps + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    UpdateStatusMessage.ShowStatusMessage(3, "Size Map loading failed.");
                    MapFail = true;
                }
                if (MapFail == true) { return false; };
            }
            else
            {
                UpdateStatusMessage.ShowStatusMessage(3, "The selected layout is empty");
                return false;
            }

            Program.MyKeyboardName = KeyboardModelComboBox.Text;

            if (Program.RunKeyboardThread == 3 || Program.RunKeyboardThread == 0)
            {
                UpdateStatusMessage.ShowStatusMessage(2, "Creating Thread");
                workerThread = new Thread(KBControl.KeyboardControl);

                UpdateStatusMessage.ShowStatusMessage(2, "Starting");
                workerThread.Start();
                UpdateStatusMessage.ShowStatusMessage(2, "Running");
            }
            Program.RunKeyboardThread = RunType;
            return true;
        }

        private void StopSpectrograph()
        {
            UpdateStatusMessage.ShowStatusMessage(2, "Stopping Thread");
            Program.RunKeyboardThread = 0;
            UpdateStatusMessage.ShowStatusMessage(10, "Stopped");
        }
        #endregion

        #region Thread Safe Delegate Functions
        public void UpdateStatusMessage_NewMsg(int messageType, string messageText)
        {
            string messagePrefix;
            System.ConsoleColor messageColour;
            Color logColour;
            
            switch (messageType)
            {
                case 1:
                    messagePrefix = "App   : ";
                    messageColour = ConsoleColor.Green;
                    logColour = Color.FromArgb(0, 255, 0);
                    break;
                case 2:
                    messagePrefix = "Worker: ";
                    messageColour = ConsoleColor.Cyan;
                    logColour = Color.FromArgb(0, 255, 255);
                    break;
                case 3:
                    messagePrefix = "Error : ";
                    messageColour = ConsoleColor.Red;
                    logColour = Color.FromArgb(255, 64, 64);
                    break;
                case 4:
                    messagePrefix = "Debug : ";
                    messageColour = ConsoleColor.Yellow;
                    logColour = Color.FromArgb(255, 255, 0);
                    break;
                case 5:
                    messagePrefix = "Detail: ";
                    messageColour = ConsoleColor.Magenta;
                    logColour = Color.FromArgb(255, 0, 255);
                    break;
                case 6:
                    messagePrefix = "Detail: ";
                    messageColour = ConsoleColor.Magenta;
                    logColour = Color.FromArgb(255, 128, 192);
                    break;
                case 10:
                    messagePrefix = "Hidden: ";
                    messageColour = ConsoleColor.Gray;
                    logColour = Color.FromArgb(128, 128, 128);
                    break;
                default:
                    messagePrefix = "Gen.  : ";
                    messageColour = ConsoleColor.White;
                    logColour = Color.FromArgb(255, 255, 255);
                    break;
            }

            if (messageType <= Program.LogLevel)
            {
                Console.ForegroundColor = messageColour;
                Console.WriteLine(messagePrefix + messageText);
                Console.ResetColor();

                StatusLabel.Text = messageText;
                this.Invoke((MethodInvoker)(() => StatusLog.AppendText(messagePrefix + messageText + Environment.NewLine, logColour)));
            }
            if (messageType == 10)
            {
                StatusLabel.Text = messageText;
            }
        }

        public void UpdateWorker_NewAct(string strAction)
        {
            switch (strAction)
            {
                case "Stop":
                    this.Invoke((MethodInvoker)(() => StopSpectrograph()));
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Controls
        private void StartSpectrograph_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 0) { Program.RunKeyboardThread = 3; };
            if (Program.RunKeyboardThread == 1) { StopSpectrograph(); };
            if (StartSpectrograph(2) == true)
            {
                StatusTimer.Start();
                TestModeButton.Enabled = false;
            }
        }

        private void StopSpectrograph_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 1 || Program.RunKeyboardThread == 2 || Program.RunKeyboardThread == 4)
            {
                StopSpectrograph();
                StartSpectrographButton.Enabled = true;
                TestModeButton.Enabled = true;
            }
        }

        private void KeyboardModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PreviousLayout = KeyboardLayoutComboBox.Text;

            LoadFromConfig(KeyboardModelComboBox.Text);

            if (KeyboardLayoutComboBox.Items.Contains(PreviousLayout))
            {
                KeyboardLayoutComboBox.Text = PreviousLayout;
            }
        }

        private void TestModeButton_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 3 || Program.RunKeyboardThread == 0)
            {
                UpdateStatusMessage.ShowStatusMessage(4, "Starting Test Mode");
                if (StartSpectrograph(4) == true)  { StartSpectrographButton.Enabled = false; }
            }
        }

        private void TesterUD_ValueChanged(object sender, EventArgs e)
        {
            Program.TestLed = (int)TesterUD.Value;
        }

        private void VerbosityUD_ValueChanged(object sender, EventArgs e)
        {
            Program.LogLevel = (int)LogLevelUD.Value;
        }

        private void BackgroundBrightnessUD_ValueChanged(object sender, EventArgs e)
        {
            if (BackgroundBrightnessUD.Value < 10 && BackgroundBrightnessUD.Value > 5)
            {
                BackgroundBrightnessUD.Value = 0;
            }
            else if (BackgroundBrightnessUD.Value <= 5 && BackgroundBrightnessUD.Value > 0)
            {
                BackgroundBrightnessUD.Value = 10;
            }
            Program.MyBackgroundBrightness = (int)BackgroundBrightnessUD.Value;
        }

        private void AmplitudeUD_ValueChanged(object sender, EventArgs e)
        {
            Program.MyAmplitude = (int)AmplitudeUD.Value;
        }

        private void BarRed_ValueChanged(object sender, EventArgs e)
        {
            Program.MyBarsRed = (int)BarRed.Value;
        }

        private void BarGreen_ValueChanged(object sender, EventArgs e)
        {
            Program.MyBarsGreen = (int)BarGreen.Value;
        }

        private void BarBlue_ValueChanged(object sender, EventArgs e)
        {
            Program.MyBarsBlue = (int)BarBlue.Value;
        }

        private void KeyboardLayoutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 2)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to apply new layout.");
            }
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }
        
        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
            switch (workerThread.IsAlive)
            {
                case false:
                    StatusLight.BackColor = Color.Red;
                    break;
                case true:
                    if (Program.ThreadStatus == 1)
                    {
                        Program.ThreadStatus = 0;
                        StatusLight.BackColor = Color.Green;
                    }
                    else
                    {
                        StatusLight.BackColor = Color.Orange;
                    }
                    break;
                default:
                    break;
            }
        }
        private void RefreshDelayUD_ValueChanged(object sender, EventArgs e)
        {
            Program.RefreshDelay = (int)RefreshDelayUD.Value;
        }

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

#endregion

    } //MainForm

    #region Helper Classes
    public delegate void AddStatusMessageDelegate(int messageType, string messageText);
    public static class UpdateStatusMessage
    {
        public static Form MainForm;
        public static event AddStatusMessageDelegate NewMsg;

        public static void ShowStatusMessage(int messageType, string messageText)
        {
            ThreadSafeStatusMessage(messageType, messageText);
        }

        private static void ThreadSafeStatusMessage(int messageType, string messageText)
        {
            if (MainForm != null && MainForm.InvokeRequired)  // we are in a different thread to the main window
            {
                MainForm.Invoke(new AddStatusMessageDelegate(ThreadSafeStatusMessage), new object[] { messageType, messageText });  // call self from main thread
            }
            else
            {
                NewMsg(messageType, messageText);
            }
        }
    }

    public delegate void NewActionDelegate(string strAction);
    public static class UpdateWorkerThread
    {
        public static Form MainForm;
        public static event NewActionDelegate NewAct;

        public static void UpdateAction(string strAction)
        {
            ThreadSafeActionUpdate(strAction);
        }

        private static void ThreadSafeActionUpdate(string strAction)
        {
            if (MainForm != null && MainForm.InvokeRequired)
            {
                MainForm.Invoke(new NewActionDelegate(ThreadSafeActionUpdate), new object[] { strAction });
            }
            else
            {
                NewAct(strAction);
            }
        }
    }

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox StatusLog, string text, Color color)
        {
            StatusLog.SelectionStart = StatusLog.TextLength;
            StatusLog.SelectionLength = 0;

            StatusLog.SelectionColor = color;
            StatusLog.AppendText(text);
            StatusLog.SelectionColor = StatusLog.ForeColor;
        }
    }
#endregion
}