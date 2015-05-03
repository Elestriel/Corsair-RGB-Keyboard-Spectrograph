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

            // Save application settings
            // Listboxes
            Properties.Settings.Default.userKeyboardModel = KeyboardModelComboBox.Text;
            Properties.Settings.Default.userKeyboardLayout = KeyboardLayoutComboBox.Text;
            Properties.Settings.Default.userColorBackgroundType = BackgroundEffectComboBox.Text;

            // UpDowns
            Properties.Settings.Default.userAmplitude = (int)AmplitudeUD.Value;
            Properties.Settings.Default.userBackgroundBrightness = (int)BackgroundBrightnessUD.Value;
            Properties.Settings.Default.userLogLevel = (int)LogLevelUD.Value;
            Properties.Settings.Default.userRefreshDelay = (int)RefreshDelayUD.Value;
            Properties.Settings.Default.userEffectWidth = (float)EffectWidth.Value;
            Properties.Settings.Default.userEffectSpeed = (float)EffectSpeed.Value;

            // CheckBoxes
            Properties.Settings.Default.userMinimizeToTray = MinimizeToTrayCheck.Checked;
            Properties.Settings.Default.userUsb3Mode = USB3ModeCheck.Checked;
            Properties.Settings.Default.userShowGraphics = ShowGraphicsCheck.Checked;
            Properties.Settings.Default.userStartMinimized = StartMinimizedCheck.Checked;
            Properties.Settings.Default.userEffectsOnStart = EffectsOnStartCheck.Checked;

            // Colours
            Properties.Settings.Default.userColorBars = colorBars.BackColor;
            Properties.Settings.Default.userColorBackground = colorBackground.BackColor;

            // Views
            Properties.Settings.Default.userViewDebug = Program.MyViewDebug;
            Properties.Settings.Default.userViewSettings = Program.MyViewSettings;

            // Save Settings
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
            notifyIcon.Visible = false;

            // Incomplete controls to hide
            //LaunchCueCheck.Visible = false; 
            //GraphicsPictureBox.Visible = false;
            //BackgroundEffectComboBox.Visible = false;
            //colorBackground.Visible = false;

            KeyboardModelComboBox.Items.Add("K65-RGB");
            KeyboardModelComboBox.Items.Add("K70-RGB");
            KeyboardModelComboBox.Items.Add("K95-RGB");

            BackgroundEffectComboBox.Items.Add("Solid Colour");
            BackgroundEffectComboBox.Items.Add("Rainbow");
            BackgroundEffectComboBox.Items.Add("Rainbow Pulse");
            BackgroundEffectComboBox.Items.Add("Rainbow Swipes");
            BackgroundEffectComboBox.Items.Add("Colour Waves");
            
            // Load all settings. Those that require manipulation or verification
            // are first loaded to variables to help manipulate them.
            UpdateStatusMessage.ShowStatusMessage(1, "Loading Settings");

            // ListBoxes
            string settingKeyboardModel = Properties.Settings.Default.userKeyboardModel;
            if (KeyboardModelComboBox.FindStringExact(settingKeyboardModel) > -1) { KeyboardModelComboBox.SelectedIndex = KeyboardModelComboBox.FindStringExact(settingKeyboardModel); };

            string settingKeyboardLayout = Properties.Settings.Default.userKeyboardLayout;
            if (KeyboardLayoutComboBox.FindStringExact(settingKeyboardLayout) > -1) { KeyboardLayoutComboBox.SelectedIndex = KeyboardLayoutComboBox.FindStringExact(settingKeyboardLayout); };

            string settingBackgroundColorType = Properties.Settings.Default.userColorBackgroundType;
            if (BackgroundEffectComboBox.FindStringExact(settingBackgroundColorType) > -1) { BackgroundEffectComboBox.SelectedIndex = BackgroundEffectComboBox.FindStringExact(settingBackgroundColorType); };

            // UpDowns
            int settingAmplitude = Properties.Settings.Default.userAmplitude;
            if (settingAmplitude < 1 || settingAmplitude > 100) { settingAmplitude = 10; };
            AmplitudeUD.Value = settingAmplitude;

            int settingBackgroundBrightness = Properties.Settings.Default.userBackgroundBrightness;
            if (settingBackgroundBrightness < 0 || settingBackgroundBrightness > 70) { settingBackgroundBrightness = 15; };
            BackgroundBrightnessUD.Value = settingBackgroundBrightness;

            int settingLogLevel = Properties.Settings.Default.userLogLevel;
            if (settingLogLevel < 3) { settingLogLevel = 3; };
            LogLevelUD.Value = settingLogLevel;
            Program.LogLevel = settingLogLevel;

            int settingRefreshDelay = Properties.Settings.Default.userRefreshDelay;
            if (settingRefreshDelay < 5 || settingRefreshDelay > 1000) { settingRefreshDelay = 20; };
            RefreshDelayUD.Value = settingRefreshDelay;

            float settingEffectWidth = Properties.Settings.Default.userEffectWidth;
            if (settingEffectWidth < 1 || settingEffectWidth > 1000) { settingEffectWidth = 100; };
            EffectWidth.Value = (decimal)settingEffectWidth;

            float settingEffectSpeed = Properties.Settings.Default.userEffectSpeed;
            if (settingEffectSpeed < 0.1 || settingEffectSpeed > 10) { settingEffectSpeed = 1; };
            EffectSpeed.Value = (decimal)settingEffectSpeed;

            // CheckBoxes
            MinimizeToTrayCheck.Checked = Properties.Settings.Default.userMinimizeToTray;
            USB3ModeCheck.Checked = Properties.Settings.Default.userUsb3Mode;
            ShowGraphicsCheck.Checked = Properties.Settings.Default.userShowGraphics;
            ShowGraphicsCheck_CheckedChanged(null, null); // Update the Program variable and the picturebox's visibility
            StartMinimizedCheck.Checked = Properties.Settings.Default.userStartMinimized;
            EffectsOnStartCheck.Checked = Properties.Settings.Default.userEffectsOnStart;

            // Colours
            Color settingBarColor = Properties.Settings.Default.userColorBars;
            colorBars.BackColor = settingBarColor; 
            colorBars.ForeColor = ContrastColor(colorBars.BackColor);
            Program.MyBarsRed = (int)(colorBars.BackColor.R);
            Program.MyBarsGreen = (int)(colorBars.BackColor.G);
            Program.MyBarsBlue = (int)(colorBars.BackColor.B);

            Color settingBackgroundColor = Properties.Settings.Default.userColorBackground;
            colorBackground.BackColor = settingBackgroundColor;
            colorBackground.ForeColor = ContrastColor(colorBackground.BackColor);
            Program.MyBgRed = (int)(colorBackground.BackColor.R);
            Program.MyBgGreen = (int)(colorBackground.BackColor.G);
            Program.MyBgBlue = (int)(colorBackground.BackColor.B);

            // Views
            Program.MyViewDebug = Properties.Settings.Default.userViewDebug;
            Program.MyViewSettings = Properties.Settings.Default.userViewSettings;
            SetWindowSize();

            // Automatically minimize
            if (Properties.Settings.Default.userStartMinimized == true) { this.WindowState = FormWindowState.Minimized; };

            // Automatically start effects
            if (Properties.Settings.Default.userEffectsOnStart == true) { StartSpectrograph_Click(null, null); };

            // Done!
            UpdateStatusMessage.ShowStatusMessage(1, "Ready");
        }

        private void SetWindowSize()
        {
            float dpiX, dpiY;
            Graphics graphics = this.CreateGraphics();
            dpiX = graphics.DpiX;
            dpiY = graphics.DpiY;

            int ControlScaling = (int)(dpiX / 96);

            if (Program.MyViewDebug == true) { 
                this.Width = 683 * ControlScaling; 
                this.Text = "RGB Keyboard Spectrograph"; 
            }
            else 
            {
                this.Width = 312 * ControlScaling; 
                this.Text = "RGB Spectro"; 
            };

            if (Program.MyViewSettings == true) {
                this.Height = 469 * ControlScaling; 
            }
            else {
                this.Height = 377 * ControlScaling; 
            };
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

                if (Program.DevMode == true)
                {
                    Program.MyKeyboardID = 0x1B11;
                }
                else
                {
                    switch (KeyboardModelComboBox.Text)
                    {
                        case "K65-RGB":
                            Program.MyKeyboardID = 0x1B17;
                            break;
                        case "K70-RGB":
                            Program.MyKeyboardID = 0x1B13;
                            break;
                        case "K95-RGB":
                            Program.MyKeyboardID = 0x1B11;
                            break;
                    }
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

        Color ContrastColor(Color color)
        {
            int d = 0;

            // Check luminance with green bias
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // Bright colours, dark text
            else
                d = 255; // Dark colours, light text

            return Color.FromArgb(d, d, d);
        }
        #endregion Form Stuff

        #region Thread Start/Stop
        private bool StartSpectrograph(int RunType)
        {
            Process[] pname = Process.GetProcessesByName("CorsairHID");
            if (pname.Length != 0) UpdateStatusMessage.ShowStatusMessage(3, "Corsair Utility Engine is still running!");
            
            
            Program.MyAmplitude = (float)AmplitudeUD.Value;
            Program.MyBarsRed = (int)(colorBars.BackColor.R);
            Program.MyBarsGreen = (int)(colorBars.BackColor.G);
            Program.MyBarsBlue = (int)(colorBars.BackColor.B);
            Program.MyBackgroundBrightness = (float)BackgroundBrightnessUD.Value;
            Program.MyEffectWidth = (float)EffectWidth.Value;
            Program.MyEffectSpeed = (float)EffectSpeed.Value;
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

        public void UpdateGraphicOutput_NewOut(Bitmap render)
        {
            this.Invoke((MethodInvoker)(() => GraphicsPictureBox.Image = Program.MyGraphicRender));
        }
        #endregion

        #region Controls

        #region Buttons

        private void StartSpectrograph_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 0) { Program.RunKeyboardThread = 3; };
            if (Program.RunKeyboardThread == 1) { StopSpectrograph(); };
            if (StartSpectrograph(2) == true)
            {
                switch (KeyboardModelComboBox.Text)
                {
                    case "K65-RGB":
                        Program.MyCanvasWidth = 76;
                        break;
                    case "K70-RGB":
                        Program.MyCanvasWidth = 92;
                        break;
                    case "K95-RGB":
                        Program.MyCanvasWidth = 104;
                        break;
                }
                Program.MyGraphicRender = new Bitmap(Program.MyCanvasWidth, 7);
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

        private void TestModeButton_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 3 || Program.RunKeyboardThread == 0)
            {
                UpdateStatusMessage.ShowStatusMessage(4, "Starting Test Mode");
                if (StartSpectrograph(4) == true) { StartSpectrographButton.Enabled = false; }
            }
        }

        private void ShowDebug_Click(object sender, EventArgs e)
        {
            Program.MyViewDebug = !Program.MyViewDebug;
            SetWindowSize();
        }

        private void ShowSettings_Click(object sender, EventArgs e)
        {
            Program.MyViewSettings = !Program.MyViewSettings;
            SetWindowSize();
        }

        #endregion Buttons

        #region ListBoxes

        private void KeyboardModelComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PreviousLayout = KeyboardLayoutComboBox.Text;

            LoadFromConfig(KeyboardModelComboBox.Text);

            if (KeyboardLayoutComboBox.Items.Contains(PreviousLayout))
            {
                KeyboardLayoutComboBox.Text = PreviousLayout;
            }
        }

        private void KeyboardLayoutComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 2)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to apply new layout.");
            }
        }

        private void BackgroundEffectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.MyBackgroundMode = BackgroundEffectComboBox.Text;
            if (BackgroundEffectComboBox.Text == "Solid Colour")
            {
                BackgroundBrightnessUD.Enabled = false;
                colorBackground.Enabled = true;
                colorBackground.Visible = true;
                EffectWidth.Enabled = false;
                EffectSpeed.Enabled = false;
                EffectWidth.Maximum = 1000;
            }
            else if (BackgroundEffectComboBox.Text == "Rainbow")
            {
                BackgroundBrightnessUD.Enabled = true;
                colorBackground.Enabled = false;
                colorBackground.Visible = false;
                EffectWidth.Enabled = true;
                EffectSpeed.Enabled = true;
                EffectWidth.Maximum = 104;
            }
            else if (BackgroundEffectComboBox.Text == "Rainbow Pulse")
            {
                BackgroundBrightnessUD.Enabled = true;
                colorBackground.Enabled = false;
                colorBackground.Visible = false;
                EffectWidth.Enabled = false;
                EffectSpeed.Enabled = true;
                EffectWidth.Maximum = 1000;
            }
            else if (BackgroundEffectComboBox.Text == "Rainbow Swipes")
            {
                BackgroundBrightnessUD.Enabled = true;
                colorBackground.Enabled = false;
                colorBackground.Visible = false;
                EffectWidth.Enabled = true;
                EffectSpeed.Enabled = true;
                EffectWidth.Maximum = 1000;
            }
            else if (BackgroundEffectComboBox.Text == "Colour Waves")
            {
                BackgroundBrightnessUD.Enabled = true;
                colorBackground.Enabled = false;
                colorBackground.Visible = false;
                EffectWidth.Enabled = true;
                EffectSpeed.Enabled = true;
                EffectWidth.Maximum = 1000;
            }
            else
            {
                UpdateStatusMessage.ShowStatusMessage(3, "You've selected an invalid effect.");
            }
        }

        #endregion ListBoxes

        #region UpDowns

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

        private void RefreshDelayUD_ValueChanged(object sender, EventArgs e)
        {
            Program.RefreshDelay = (int)RefreshDelayUD.Value;
        }
        private void EffectWidth_ValueChanged(object sender, EventArgs e)
        {
            // Apply maximum to width if Rainbow is selected
            if (Program.MyCanvasWidth > 0 && BackgroundEffectComboBox.Text == "Rainbow") { EffectWidth.Maximum = Program.MyCanvasWidth; };

            Program.MyEffectWidth = (float)EffectWidth.Value;
        }

        private void EffectSpeed_ValueChanged(object sender, EventArgs e)
        {
            Program.MyEffectSpeed = (float)EffectSpeed.Value;
        }

        #endregion UpDowns

        #region CheckBoxes

        private void USB3Mode_CheckedChanged(object sender, EventArgs e)
        {
            Program.MyUsb3Mode = USB3ModeCheck.Checked;
        }

        private void ShowGraphicsCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.MyShowGraphics = ShowGraphicsCheck.Checked;

            if (ShowGraphicsCheck.Checked == true)
                GraphicsPictureBox.Visible = true;
            else
                GraphicsPictureBox.Visible = false;
        }

        #endregion CheckBoxes

        #region Colours

        private void colorBars_Click(object sender, EventArgs e)
        {
            ColorDialog ColorPicker = new ColorDialog();
            ColorPicker.AllowFullOpen = true;
            ColorPicker.ShowHelp = true;
            ColorPicker.Color = colorBars.BackColor;

            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                colorBars.BackColor = ColorPicker.Color;
                colorBars.ForeColor = ContrastColor(ColorPicker.Color);
                Program.MyBarsRed = (int)(colorBars.BackColor.R);
                Program.MyBarsGreen = (int)(colorBars.BackColor.G);
                Program.MyBarsBlue = (int)(colorBars.BackColor.B);
            }
        }

        private void colorBackground_Click(object sender, EventArgs e)
        {
            ColorDialog ColorPicker = new ColorDialog();
            ColorPicker.AllowFullOpen = true;
            ColorPicker.ShowHelp = true;
            ColorPicker.Color = colorBackground.BackColor;

            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                colorBackground.BackColor = ColorPicker.Color;
                colorBackground.ForeColor = ContrastColor(ColorPicker.Color);
                Program.MyBgRed = (int)(colorBackground.BackColor.R);
                Program.MyBgGreen = (int)(colorBackground.BackColor.G);
                Program.MyBgBlue = (int)(colorBackground.BackColor.B);
            }
        }

        #endregion Colours

        #region Others

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

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Others

        #endregion Controls

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

    public delegate void GraphicOutputDelegate(Bitmap render);
    public static class UpdateGraphicOutput
    {
        public static Form MainForm;
        public static event GraphicOutputDelegate NewOut;

        public static void GraphicOutput(Bitmap render)
        {
            ThreadSafeGraphicOutput(render);
        }

        private static void ThreadSafeGraphicOutput(Bitmap render)
        {
            if (MainForm != null && MainForm.InvokeRequired)
            {
                MainForm.Invoke(new GraphicOutputDelegate(ThreadSafeGraphicOutput), new object[] { render });
            }
            else
            {
                NewOut(render);
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