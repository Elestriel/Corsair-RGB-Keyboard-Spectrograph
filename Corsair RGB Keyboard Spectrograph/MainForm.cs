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

using CSCore;
using CSCore.CoreAudioAPI;

namespace RGBKeyboardSpectrograph
{
    public partial class MainForm : Form
    {
        string[] keyboardIDs;
        string[] keyboardNames;
        string[] keyboardPositionMaps;
        string[] keyboardSizeMaps;
        Image keyboardImage;
   
        Thread workerThread = Program.newWorker;

        public MainForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region Form Stuff
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateStatusMessage.ShowStatusMessage(1, "Shutting Down...");
            Application.DoEvents();

            if (Program.RunKeyboardThread != 0) { 
                StopSpectrograph();
            };

            Thread.Sleep(500);

            if (Program.RunKeyboardThread != 3) { 
                while (workerThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(1000);
                    UpdateStatusMessage.ShowStatusMessage(2, "Waiting for thread to quit...");
                } 
            }

            if (Program.SettingsRestoreOnExit == true)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Restoring Keyboard Lighting");
                KeyboardWriter restoreLightingWriter = new KeyboardWriter(true);
                Thread.Sleep(500);
            }

            if (Program.SettingLaunchCueOnExit == true)
            {
                try
                {
                    UpdateStatusMessage.ShowStatusMessage(1, "Launching CUE");
                    Process.Start(SettingsCuePathTextBox.Text);
                }
                catch { }
            }

            // Save application settings
            // Listboxes
            Properties.Settings.Default.userKeyboardModel = SettingsKeyboardModelCB.Text;
            Properties.Settings.Default.userKeyboardLayout = SettingsKeyboardLayoutCB.Text;
            Properties.Settings.Default.userColorBackgroundType = SpectroBgEffectCB.Text;
            Properties.Settings.Default.userColorBarsType = SpectroBarEffectCB.Text;

            // UpDowns
            Properties.Settings.Default.userAmplitude = (int)SpectroAmplitudeUD.Value;
            Properties.Settings.Default.userBackgroundBrightness = (int)SpectroBgBrightnessUD.Value;
            Properties.Settings.Default.userBarBrightness = (int)SpectroBarBrightnessUD.Value;
            Properties.Settings.Default.userLogLevel = (int)DebugLogLevelUD.Value;
            Properties.Settings.Default.userRefreshDelay = (int)SpectroRefreshDelayUD.Value;
            Properties.Settings.Default.userBackgroundEffectWidth = (float)SpectroBgWidth.Value;
            Properties.Settings.Default.userBackgroundEffectSpeed = (float)SpectroBgSpeed.Value;
            Properties.Settings.Default.userBarEffectWidth = (float)SpectroBarWidth.Value;
            Properties.Settings.Default.userBarEffectSpeed = (float)SpectroBarSpeed.Value;

            // CheckBoxes
            Properties.Settings.Default.userMinimizeToTray = SettingsMinimizeToTrayCheck.Checked;
            Properties.Settings.Default.userUsb3Mode = SettingsUSB3ModeCheck.Checked;
            Properties.Settings.Default.userShowGraphics = SpectroShowGraphicsCheck.Checked;
            Properties.Settings.Default.userStartMinimized = SettingsStartMinimizedCheck.Checked;
            Properties.Settings.Default.userEffectsOnStart = SettingsEffectsOnStartCheck.Checked;
            Properties.Settings.Default.userRestoreLighting = SettingsRestoreLightingCheck.Checked;
            Properties.Settings.Default.userLaunchCueOnExit = SettingsLaunchCueCheck.Checked;

            // TextBoxes
            Properties.Settings.Default.userCueLocation = SettingsCuePathTextBox.Text;

            // Colours
            Properties.Settings.Default.userColorBars = SpectroColorBars.BackColor;
            Properties.Settings.Default.userColorBackground = SpectroColorBg.BackColor;
            
            // Capture Settings
            Properties.Settings.Default.userCaptureMode = Program.CSCore_DeviceType;
            Properties.Settings.Default.userCaptureDevice = SpectroWasapiDevicesCB.Text;

            // Save Settings
            Properties.Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized && SettingsMinimizeToTrayCheck.Checked == true)
            {
                notifyIcon.Visible = true;
                notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateStatusMessage.ShowStatusMessage(0, "Version " + Program.VersionNumber);

            // Check for updates
            if (CheckForUpdates() == true)
            {
                if (Program.VersionCheckData[0] != Program.VersionNumber)
                {
                    UpdateStatusMessage.ShowStatusMessage(0, "Latest Version: " + Program.VersionCheckData[0]);
                    SettingsGetUpdateButton.Visible = true;
                }
            }

            // Start manipulating controls and loading saved values
            UpdateStatusMessage.ShowStatusMessage(1, "Populating Controls");
            notifyIcon.Visible = false;
            
            // Populate Combo Boxes
            SettingsKeyboardModelCB.Items.Add("K65-RGB");
            SettingsKeyboardModelCB.Items.Add("K70-RGB");
            SettingsKeyboardModelCB.Items.Add("K95-RGB");

            SpectroBgEffectCB.Items.Add("Solid Colour");
            SpectroBgEffectCB.Items.Add("Rainbow Right");
            SpectroBgEffectCB.Items.Add("Rainbow Left");
            SpectroBgEffectCB.Items.Add("Rainbow Pulse");
            SpectroBgEffectCB.Items.Add("Rainbow Swipes");

            SpectroBarEffectCB.Items.Add("Solid Colour");
            SpectroBarEffectCB.Items.Add("Rainbow Right");
            SpectroBarEffectCB.Items.Add("Rainbow Left");
            SpectroBarEffectCB.Items.Add("Rainbow Pulse");
            SpectroBarEffectCB.Items.Add("Static Rainbow");
            SpectroBarEffectCB.Items.Add("Classic Bars");

            // Get Input Device list
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active).ToList();
            SpectroWasapiDevicesCB.DataSource = devices;
            SpectroWasapiDevicesCB.DisplayMember = "FriendlyName";
            
            // Load all settings. Those that require manipulation or verification
            // are first loaded to variables to help manipulate them.
            UpdateStatusMessage.ShowStatusMessage(1, "Loading Settings");

            // ListBoxes
            string settingKeyboardModel = Properties.Settings.Default.userKeyboardModel;
            if (SettingsKeyboardModelCB.FindStringExact(settingKeyboardModel) > -1) { SettingsKeyboardModelCB.SelectedIndex = SettingsKeyboardModelCB.FindStringExact(settingKeyboardModel); };

            string settingKeyboardLayout = Properties.Settings.Default.userKeyboardLayout;
            if (SettingsKeyboardLayoutCB.FindStringExact(settingKeyboardLayout) > -1) { SettingsKeyboardLayoutCB.SelectedIndex = SettingsKeyboardLayoutCB.FindStringExact(settingKeyboardLayout); };

            string settingBackgroundColorType = Properties.Settings.Default.userColorBackgroundType;
            if (SpectroBgEffectCB.FindStringExact(settingBackgroundColorType) > -1) { SpectroBgEffectCB.SelectedIndex = SpectroBgEffectCB.FindStringExact(settingBackgroundColorType); }
            else {SpectroBgEffectCB.SelectedIndex = 1; };

            string settingBarColorType = Properties.Settings.Default.userColorBarsType;
            if (SpectroBarEffectCB.FindStringExact(settingBarColorType) > -1) { SpectroBarEffectCB.SelectedIndex = SpectroBarEffectCB.FindStringExact(settingBarColorType); }
            else { SpectroBarEffectCB.SelectedIndex = 1; };

            string settingCaptureDeviceName = Properties.Settings.Default.userCaptureDevice;
            if (SpectroWasapiDevicesCB.FindStringExact(settingCaptureDeviceName) > -1) { SpectroWasapiDevicesCB.SelectedIndex = SpectroWasapiDevicesCB.FindStringExact(settingCaptureDeviceName); };

            // UpDowns
            int settingAmplitude = Properties.Settings.Default.userAmplitude;
            if (settingAmplitude < 1 || settingAmplitude > 100) { settingAmplitude = 10; };
            SpectroAmplitudeUD.Value = settingAmplitude;

            int settingBackgroundBrightness = Properties.Settings.Default.userBackgroundBrightness;
            if (settingBackgroundBrightness < 0 || settingBackgroundBrightness > 70) { settingBackgroundBrightness = 15; };
            SpectroBgBrightnessUD.Value = settingBackgroundBrightness;

            int settingBarBrightness = Properties.Settings.Default.userBarBrightness;
            if (settingBarBrightness < 0 || settingBarBrightness > 70) { settingBarBrightness = 15; };
            SpectroBarBrightnessUD.Value = settingBarBrightness;

            int settingLogLevel = Properties.Settings.Default.userLogLevel;
            if (settingLogLevel < 3) { settingLogLevel = 3; };
            DebugLogLevelUD.Value = settingLogLevel;
            Program.LogLevel = settingLogLevel;

            int settingRefreshDelay = Properties.Settings.Default.userRefreshDelay;
            if (settingRefreshDelay < 0 || settingRefreshDelay > 1000) { settingRefreshDelay = 20; };
            SpectroRefreshDelayUD.Value = settingRefreshDelay;

            float settingEffectWidth = Properties.Settings.Default.userBackgroundEffectWidth;
            if (settingEffectWidth < 1 || settingEffectWidth > 1000) { settingEffectWidth = 104; };
            SpectroBgWidth.Value = (decimal)settingEffectWidth;

            float settingEffectSpeed = Properties.Settings.Default.userBackgroundEffectSpeed;
            if (settingEffectSpeed < 0.1 || settingEffectSpeed > 10) { settingEffectSpeed = 1; };
            SpectroBgSpeed.Value = (decimal)settingEffectSpeed;

            float settingBarWidth = Properties.Settings.Default.userBarEffectWidth;
            if (settingBarWidth < 1 || settingBarWidth > 1000) { settingBarWidth = 104; };
            SpectroBarWidth.Value = (decimal)settingBarWidth;

            float settingBarSpeed = Properties.Settings.Default.userBarEffectSpeed;
            if (settingBarSpeed < 1 || settingBarSpeed > 10) { settingBarSpeed = 1; };
            SpectroBarSpeed.Value = (decimal)settingBarSpeed;

            // CheckBoxes
            SettingsMinimizeToTrayCheck.Checked = Properties.Settings.Default.userMinimizeToTray;
            SettingsUSB3ModeCheck.Checked = Properties.Settings.Default.userUsb3Mode;
            SpectroShowGraphicsCheck.Checked = Properties.Settings.Default.userShowGraphics;
            SpectroShowGraphicsCheck_CheckedChanged(null, null); // Update the Program variable and the picturebox's visibility
            SettingsStartMinimizedCheck.Checked = Properties.Settings.Default.userStartMinimized;
            SettingsEffectsOnStartCheck.Checked = Properties.Settings.Default.userEffectsOnStart;
            SettingsRestoreLightingCheck.Checked = Properties.Settings.Default.userRestoreLighting;
            SettingsLaunchCueCheck.Checked = Properties.Settings.Default.userLaunchCueOnExit;

            // RadioButtons
            switch (Properties.Settings.Default.userCaptureMode)
            {
                case 0:
                    SpectroWasapiLoopbackRadio.Checked = true;
                    break;
                case 1:
                    SpectroWasapiRadio.Checked = true;
                    break;
                default:
                    SpectroWasapiLoopbackRadio.Checked = true;
                    break;
            }
            SpectroWasapiLoopbackRadio_CheckedChanged(null, null);

            // TextBoxes
            SettingsCuePathTextBox.Text = Properties.Settings.Default.userCueLocation;

            // Colours
            Color settingBarColor = Properties.Settings.Default.userColorBars;
            SpectroColorBars.BackColor = settingBarColor; 
            SpectroColorBars.ForeColor = ContrastColor(SpectroColorBars.BackColor);
            Program.SpectroBars.Color.Set(SpectroColorBars.BackColor);

            Color settingBackgroundColor = Properties.Settings.Default.userColorBackground;
            SpectroColorBg.BackColor = settingBackgroundColor;
            SpectroColorBg.ForeColor = ContrastColor(SpectroColorBg.BackColor);
            Program.SpectroBg.Color.Set(SpectroColorBg.BackColor);
            
            // Automatically minimize
            if (Properties.Settings.Default.userStartMinimized == true) { this.WindowState = FormWindowState.Minimized; };

            // Automatically start effects
            if (Properties.Settings.Default.userEffectsOnStart == true) { StartSpectrograph_Click(null, null); };

            // Done!
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

                if (Program.DevMode == true)
                {
                    Program.SettingsKeyboardID = 0x1B11;
                }
                else
                {
                    switch (SettingsKeyboardModelCB.Text)
                    {
                        case "K65-RGB":
                            Program.SettingsKeyboardID = 0x1B17;
                            break;
                        case "K70-RGB":
                            Program.SettingsKeyboardID = 0x1B13;
                            break;
                        case "K95-RGB":
                            Program.SettingsKeyboardID = 0x1B11;
                            break;
                    }
                }

                UpdateStatusMessage.ShowStatusMessage(4, "Hardware ID: " + Program.SettingsKeyboardID.ToString("X"));
                SettingsKeyboardLayoutCB.Items.Clear();

                for (int i = 0; i < keyboardNames.Length; i++)
                {
                    SettingsKeyboardLayoutCB.Items.Add(keyboardNames[i]);
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

        private bool CheckForUpdates()
        {
            String URLString = "http://elestriel.cf/pages/keyboardspectro/version.xml";
            try
            {
                XmlTextReader reader = new XmlTextReader(URLString);
                int i = 0;

                while (reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Text: //Display the text in each element.
                            Program.VersionCheckData[i] = reader.Value;
                            i++;
                            break;
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion Form Stuff

        #region Thread Start/Stop
        private bool StartSpectrograph(int RunType)
        {
            // Check if CUE is still running
            Process[] pname = Process.GetProcessesByName("CorsairHID");
            if (pname.Length != 0) UpdateStatusMessage.ShowStatusMessage(3, "Corsair Utility Engine is still running!");

            // Set Program variables
            Program.SpectroAmplitude = (float)SpectroAmplitudeUD.Value;
            Program.SpectroBg.Color.SetD(SpectroColorBg.BackColor);
            Program.SpectroBg.Set(SpectroBgEffectCB.Text,
                                  (float)SpectroBgWidth.Value,
                                  (float)SpectroBgSpeed.Value,
                                  0f,
                                  (float)SpectroBgBrightnessUD.Value);
            Program.SpectroBars.Color.SetD(SpectroColorBars.BackColor);
            Program.SpectroBars.Set(SpectroBarEffectCB.Text,
                                    (float)SpectroBarWidth.Value,
                                    (float)SpectroBarSpeed.Value,
                                    0f,
                                    (float)SpectroBarBrightnessUD.Value);
            Program.SettingsRestoreOnExit = SettingsRestoreLightingCheck.Checked;

            // Get audio device info
            if (SpectroWasapiLoopbackRadio.Checked == true) { Program.CSCore_DeviceType = 0; };
            if (SpectroWasapiRadio.Checked == true) { Program.CSCore_DeviceType = 1; };

            // Break if there's no keyboard layout selected
            if (SettingsKeyboardLayoutCB.SelectedIndex < 0) {
                MessageBox.Show("There is no layout selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusMessage.ShowStatusMessage(3, "No layout selected.");
                return false;
            };

            // Load position and size maps
            string positionMaps = keyboardPositionMaps[SettingsKeyboardLayoutCB.SelectedIndex];
            string sizeMaps = keyboardSizeMaps[SettingsKeyboardLayoutCB.SelectedIndex];

            // Replace the '.' decimals by whatever the system decimal separator may be, if it's not a period
            char DecimalSep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (DecimalSep != '.') {
                positionMaps = positionMaps.Replace('.', DecimalSep);
                sizeMaps = sizeMaps.Replace('.', DecimalSep);
            }

            // Verify the loaded maps
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
                        "Selected index: " + SettingsKeyboardLayoutCB.SelectedIndex + 
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
                        "Selected index: " + SettingsKeyboardLayoutCB.SelectedIndex +
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

            int captureType;
            MMDevice captureDevice;

            if (RunType == 4) // Test Mode
            {
                captureType = 0;
                captureDevice = null;
            }
            else
            {
                // Set capture type (input/output) and device, if output is selected
                if (SpectroWasapiLoopbackRadio.Checked)
                {
                    captureType = 0;
                    captureDevice = null;
                }
                else if (SpectroWasapiRadio.Checked)
                {
                    captureType = 1;
                    captureDevice = (MMDevice)SpectroWasapiDevicesCB.SelectedItem;
                }
                else
                {
                    captureType = 0;
                    captureDevice = null;
                }
            }

            // Launch worker thread, passing it the type and device to use
            workerThread = new Thread(() => SpectroControl.KeyboardControl(captureType, captureDevice));
            workerThread.Start();

            // Set Program-wide current keyboard name
            Program.SettingsKeyboardName = SettingsKeyboardModelCB.Text;
            Program.RunKeyboardThread = RunType;
            return true;
        }

        private void StopSpectrograph()
        {
            // Don't run the Stop procedure if the thread was never started in the first place
            if (Program.RunKeyboardThread == 3) { return; };

            UpdateStatusMessage.ShowStatusMessage(2, "Stopping Capture");
            Program.RunKeyboardThread = 0;
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
                this.Invoke((MethodInvoker)(() => DebugStatusLog.AppendText(messagePrefix + messageText + Environment.NewLine, logColour)));
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
            this.Invoke((MethodInvoker)(() => GraphicsPictureBox.Image = Program.SpectroGraphicRender));
        }
        #endregion

        #region Controls

        #region Tab: Spectro

        #region Buttons
        private void StartSpectrograph_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 1) { StopSpectrograph(); };
            if (Program.RunKeyboardThread == 2) { return; };
            if (StartSpectrograph(2) == true)
            {
                switch (SettingsKeyboardModelCB.Text)
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
                Program.SpectroGraphicRender = new Bitmap(Program.MyCanvasWidth, 7);
                tabEffects.Enabled = false;
                StatusTimer.Start();
                DebugTestModeButton.Enabled = false;
            }
        }
        private void StopSpectrograph_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 1 || Program.RunKeyboardThread == 2 || Program.RunKeyboardThread == 4)
            {
                StopSpectrograph();
                StartSpectrographButton.Enabled = true;
                DebugTestModeButton.Enabled = true;
                tabEffects.Enabled = true;
            }
        }

        #endregion Buttons

        #region ListBoxes
        private void SpectroBackgroundEffectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SpectroBg.Mode = SpectroBgEffectCB.Text;
            if (SpectroBgEffectCB.Text == "Solid Colour")
            {
                SpectroBgBrightnessUD.Enabled = false;
                SpectroColorBg.Enabled = true;
                SpectroColorBg.Visible = true;
                SpectroBgWidth.Enabled = false;
                SpectroBgSpeed.Enabled = false;
                SpectroBgWidth.Maximum = 1000;
            }
            else if (SpectroBgEffectCB.Text == "Rainbow Right")
            {
                SpectroBgBrightnessUD.Enabled = true;
                SpectroColorBg.Enabled = false;
                SpectroColorBg.Visible = false;
                SpectroBgWidth.Enabled = true;
                SpectroBgSpeed.Enabled = true;
                SpectroBgWidth.Maximum = 104;
                SpectroBgWidth.Value = 104;
            }
            else if (SpectroBgEffectCB.Text == "Rainbow Left")
            {
                SpectroBgBrightnessUD.Enabled = true;
                SpectroColorBg.Enabled = false;
                SpectroColorBg.Visible = false;
                SpectroBgWidth.Enabled = true;
                SpectroBgSpeed.Enabled = true;
                SpectroBgWidth.Maximum = 104;
                SpectroBgWidth.Value = 104;
            }
            else if (SpectroBgEffectCB.Text == "Rainbow Pulse")
            {
                SpectroBgBrightnessUD.Enabled = true;
                SpectroColorBg.Enabled = false;
                SpectroColorBg.Visible = false;
                SpectroBgWidth.Enabled = false;
                SpectroBgSpeed.Enabled = true;
                SpectroBgWidth.Maximum = 1000;
            }
            else if (SpectroBgEffectCB.Text == "Rainbow Swipes")
            {
                SpectroBgBrightnessUD.Enabled = true;
                SpectroColorBg.Enabled = false;
                SpectroColorBg.Visible = false;
                SpectroBgWidth.Enabled = true;
                SpectroBgSpeed.Enabled = true;
                SpectroBgWidth.Maximum = 1000;
            }
            else if (SpectroBgEffectCB.Text == "Colour Waves")
            {
                SpectroBgBrightnessUD.Enabled = true;
                SpectroColorBg.Enabled = false;
                SpectroColorBg.Visible = false;
                SpectroBgWidth.Enabled = true;
                SpectroBgSpeed.Enabled = true;
                SpectroBgWidth.Maximum = 1000;
            }
            else
            {
                UpdateStatusMessage.ShowStatusMessage(3, "You've selected an invalid effect.");
            }
        }

        private void SpectroBarEffectCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.SpectroBars.Mode = SpectroBarEffectCB.Text;
            if (SpectroBarEffectCB.Text == "Solid Colour")
            {
                SpectroBarBrightnessUD.Enabled = false;
                SpectroColorBars.Enabled = true;
                SpectroColorBars.Visible = true;
                SpectroBarWidth.Enabled = false;
                SpectroBarSpeed.Enabled = false;
                SpectroBarWidth.Maximum = 104;
            }
            else if (SpectroBarEffectCB.Text == "Rainbow Right")
            {
                SpectroBarBrightnessUD.Enabled = true;
                SpectroColorBars.Enabled = false;
                SpectroColorBars.Visible = false;
                SpectroBarWidth.Enabled = true;
                SpectroBarSpeed.Enabled = true;
                SpectroBarWidth.Maximum = 104;
                SpectroBarWidth.Value = 104;
            }
            else if (SpectroBarEffectCB.Text == "Rainbow Left")
            {
                SpectroBarBrightnessUD.Enabled = true;
                SpectroColorBars.Enabled = false;
                SpectroColorBars.Visible = false;
                SpectroBarWidth.Enabled = true;
                SpectroBarSpeed.Enabled = true;
                SpectroBarWidth.Maximum = 104;
                SpectroBarWidth.Value = 104;
            }
            else if (SpectroBarEffectCB.Text == "Rainbow Pulse")
            {
                SpectroBarBrightnessUD.Enabled = true;
                SpectroColorBars.Enabled = false;
                SpectroColorBars.Visible = false;
                SpectroBarWidth.Enabled = true;
                SpectroBarSpeed.Enabled = true;
                SpectroBarWidth.Maximum = 104;
            }
            else if (SpectroBarEffectCB.Text == "Static Rainbow")
            {
                SpectroBarBrightnessUD.Enabled = true;
                SpectroColorBars.Enabled = false;
                SpectroColorBars.Visible = false;
                SpectroBarWidth.Enabled = true;
                SpectroBarSpeed.Enabled = true;
                SpectroBarWidth.Maximum = 104;
            }
            else if (SpectroBarEffectCB.Text == "Classic Bars")
            {
                SpectroBarBrightnessUD.Enabled = true;
                SpectroColorBars.Enabled = true;
                SpectroColorBars.Visible = true;
                SpectroBarWidth.Enabled = false;
                SpectroBarSpeed.Enabled = false;
                SpectroBarWidth.Maximum = 104;
            }

        }

        #endregion ListBoxes

        #region UpDowns
        private void SpectroBackgroundBrightnessUD_ValueChanged(object sender, EventArgs e)
        {
            if (SpectroBgBrightnessUD.Value < 10 && SpectroBgBrightnessUD.Value > 5)
            {
                SpectroBgBrightnessUD.Value = 0;
            }
            else if (SpectroBgBrightnessUD.Value <= 5 && SpectroBgBrightnessUD.Value > 0)
            {
                SpectroBgBrightnessUD.Value = 10;
            }
            Program.SpectroBg.Brightness = (int)SpectroBgBrightnessUD.Value;
        }

        private void SpectroBarBrightnessUD_ValueChanged(object sender, EventArgs e)
        {
            if (SpectroBarBrightnessUD.Value < 10 && SpectroBarBrightnessUD.Value > 5)
            {
                SpectroBarBrightnessUD.Value = 0;
            }
            else if (SpectroBarBrightnessUD.Value <= 5 && SpectroBarBrightnessUD.Value > 0)
            {
                SpectroBarBrightnessUD.Value = 10;
            }
            Program.SpectroBars.Brightness = (int)SpectroBarBrightnessUD.Value;
        }

        private void SpectroAmplitudeUD_ValueChanged(object sender, EventArgs e)
        {
            Program.SpectroAmplitude = (int)SpectroAmplitudeUD.Value;
        }

        private void SpectroRefreshDelayUD_ValueChanged(object sender, EventArgs e)
        {
            Program.RefreshDelay = (int)SpectroRefreshDelayUD.Value;
        }

        private void SpectroEffectWidth_ValueChanged(object sender, EventArgs e)
        {
            // Apply maximum to width if Rainbow is selected
            if (Program.MyCanvasWidth > 0 && (SpectroBgEffectCB.Text == "Rainbow Right" ||
                                              SpectroBgEffectCB.Text == "Rainbow Left"))
            {
                if (SpectroBgWidth.Value > Program.MyCanvasWidth) { SpectroBgWidth.Value = Program.MyCanvasWidth; };
                SpectroBgWidth.Maximum = Program.MyCanvasWidth;
            };

            Program.SpectroBg.Width = (float)SpectroBgWidth.Value;
        }

        private void SpectroEffectSpeed_ValueChanged(object sender, EventArgs e)
        {
            Program.SpectroBg.Speed = (float)SpectroBgSpeed.Value;
        }

        private void SpectroBarWidth_ValueChanged(object sender, EventArgs e)
        {
            // Apply maximum to width if Rainbow is selected
            if (Program.MyCanvasWidth > 0 && (SpectroBarEffectCB.Text == "Rainbow Right" ||
                                              SpectroBarEffectCB.Text == "Rainbow Left"))
            {
                if (SpectroBarWidth.Value > Program.MyCanvasWidth) { SpectroBarWidth.Value = Program.MyCanvasWidth; };
                SpectroBarWidth.Maximum = Program.MyCanvasWidth;
            };

            Program.SpectroBars.Width = (float)SpectroBarWidth.Value;
        }

        private void SpectroBarSpeed_ValueChanged(object sender, EventArgs e)
        {
            Program.SpectroBars.Speed = (float)SpectroBarSpeed.Value;
        }

        #endregion UpDowns

        #region CheckBoxes
        private void SpectroShowGraphicsCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.SpectroShowGraphics = SpectroShowGraphicsCheck.Checked;

            if (SpectroShowGraphicsCheck.Checked == true)
                GraphicsPictureBox.Visible = true;
            else
                GraphicsPictureBox.Visible = false;
        }

        #endregion CheckBoxes

        #region Colours
        private void SpectroColorBars_Click(object sender, EventArgs e)
        {
            ColorDialog ColorPicker = new ColorDialog();
            ColorPicker.AllowFullOpen = true;
            ColorPicker.ShowHelp = true;
            ColorPicker.Color = SpectroColorBars.BackColor;

            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                SpectroColorBars.BackColor = ColorPicker.Color;
                SpectroColorBars.ForeColor = ContrastColor(ColorPicker.Color);
                Program.SpectroBars.Color.SetD(SpectroColorBars.BackColor);
            }
        }

        private void SpectroColorBackground_Click(object sender, EventArgs e)
        {
            ColorDialog ColorPicker = new ColorDialog();
            ColorPicker.AllowFullOpen = true;
            ColorPicker.ShowHelp = true;
            ColorPicker.Color = SpectroColorBg.BackColor;

            if (ColorPicker.ShowDialog() == DialogResult.OK)
            {
                SpectroColorBg.BackColor = ColorPicker.Color;
                SpectroColorBg.ForeColor = ContrastColor(ColorPicker.Color);
                Program.SpectroBg.Color.SetD(SpectroColorBg.BackColor);
            }
        }

        #endregion Colours

        #region CSCore
        private void SpectroWasapiLoopbackRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.CSCore_NewDevice == false)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to change devices.");
                Program.CSCore_NewDevice = true;
            }
            if (SpectroWasapiLoopbackRadio.Checked == true)
            {
                Program.CSCore_DeviceType = 0;
                SpectroWasapiDevicesCB.Enabled = false;
            };
        }

        private void SpectroWasapiRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (Program.CSCore_NewDevice == false)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to change devices.");
                Program.CSCore_NewDevice = true;
            }
            if (SpectroWasapiRadio.Checked == true)
            {
                Program.CSCore_DeviceType = 1;
                SpectroWasapiDevicesCB.Enabled = true;
            };
        }

        private void SpectroWasapiDevicesCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.CSCore_NewDevice == false)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to change devices.");
                Program.CSCore_NewDevice = true;
            }
        }

        #endregion CSCore

        #endregion Tab: Spectro

        #region Tab: Effects

        #endregion Tab: Effects

        #region Tab: Static Keys

        #region Buttons
        private void StaticGetKeyboardImage_Click(object sender, EventArgs e)
        {
            string keyboardDirectoryName = "";

            switch (SettingsKeyboardModelCB.Text)
            {
                case "K65-RGB":
                    keyboardDirectoryName = "cgk65rgb";
                    break;
                case "K70-RGB":
                    keyboardDirectoryName = "k70rgb";
                    break;
                case "K95-RGB":
                    keyboardDirectoryName = "k95rgb";
                    break;
            }
            string imagePath = Directory.GetCurrentDirectory() + "\\corsair_devices\\" +
                                      keyboardDirectoryName + "\\image\\" + keyboardIDs[SettingsKeyboardLayoutCB.SelectedIndex] +
                                      ".jpg";

            keyboardImage = Image.FromFile(imagePath);
            keyboardImage = ScaleImage(keyboardImage, 660, 222);
            KeyboardImageBox.Image = keyboardImage;
            
            XmlToKeyMap xmlToKeyMap = new XmlToKeyMap();
            KeyData[] keyData = xmlToKeyMap.LoadKeyLocations();
            DrawKeysOnImage(keyData);
        }

        public void DrawKeysOnImage(KeyData[] keyData)
        {
            double ImageScale = 0.6;
            int offsetX = 0;
            int offsetY = 1;

            Button[] keyboardButtons = new Button[keyData.Length];

            for (int i = 0; i < keyData.Length ; i++)
            {

                keyboardButtons[i] = new Button();
                keyboardButtons[i].Location = new Point((int)(keyData[i].Coords[0].X * ImageScale + offsetX), 
                                                        (int)(keyData[i].Coords[0].Y * ImageScale + offsetY));
                keyboardButtons[i].Size = new Size((int)(keyData[i].Coords[1].X * ImageScale) - (int)(keyData[i].Coords[0].X * ImageScale),
                                                    (int)(keyData[i].Coords[2].Y * ImageScale) - (int)(keyData[i].Coords[0].Y * ImageScale));
                keyboardButtons[i].Text = ""; // keyData[i].Name;
                keyboardButtons[i].FlatStyle = FlatStyle.Flat;
                keyboardButtons[i].FlatAppearance.BorderColor = Color.White;
                keyboardButtons[i].FlatAppearance.BorderSize = 0;
                keyboardButtons[i].Parent = KeyboardImageBox;
                keyboardButtons[i].BackColor = Color.Transparent;
                keyboardButtons[i].Tag = keyData[i].KeyID;
                KeyboardImageBox.Controls.Add(keyboardButtons[i]);
                keyboardButtons[i].Click += KeyboardButton_Click;
            }

            KeyboardImageBox.SendToBack();
        }

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public void KeyboardButton_Click(object sender, EventArgs e)
        {
            int buttonID = (int)((Button)sender).Tag;
            Console.WriteLine("Button Pressed: " + buttonID);
        }

        #endregion Buttons

        private void KeyboardImageBox_Click(object sender, EventArgs e)
        {
            /*
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            Console.WriteLine("X: " + me.Location.X + "   Y: " + me.Location.Y);
             * */
        }
        #endregion Tab: Static Keys

        #region Tab: Settings

        #region Buttons
        private void SettingsGetUpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("There is a new version of Keyboard Spectro available.\nWould you like to get it now?",
                           "New Version Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://elestriel.cf/?page=keyboardspectro");
            }

        }

        #endregion Buttons

        #region ListBoxes
        private void SettingsKeyboardModelCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PreviousLayout = SettingsKeyboardLayoutCB.Text;

            LoadFromConfig(SettingsKeyboardModelCB.Text);

            if (SettingsKeyboardLayoutCB.Items.Contains(PreviousLayout))
            {
                SettingsKeyboardLayoutCB.Text = PreviousLayout;
            }
            switch (SettingsKeyboardModelCB.Text)
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
            SpectroEffectWidth_ValueChanged(null, null);
            SpectroBarWidth_ValueChanged(null, null);
        }

        private void SettingsKeyboardLayoutCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 2)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to apply new layout.");
            }
        }

        #endregion ListBoxes

        #region Buttons
        private void SettingsBrowseCuePathButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = "CUE (CorsairHID.exe)|CorsairHID.exe|Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SettingsCuePathTextBox.Text = openFileDialog.FileName;
            }
        }

        #endregion Buttons

        #region CheckBoxes
        private void SettingsUSB3Mode_CheckedChanged(object sender, EventArgs e)
        {
            Program.SettingsUsb3Mode = SettingsUSB3ModeCheck.Checked;
        }

        private void SettingsRestoreLightingCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.SettingsRestoreOnExit = SettingsRestoreLightingCheck.Checked;
        }

        private void SettingsLaunchCueCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.SettingLaunchCueOnExit = SettingsLaunchCueCheck.Checked;
        }

        #endregion CheckBoxes

        #region TextBoxes
        private void SettingsCuePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SettingsCuePathTextBox.Text != "" && SettingsLaunchCueCheck.Checked == true) { Program.SettingLaunchCueOnExit = true; }
            else { Program.SettingLaunchCueOnExit = false; };
        }

        #endregion

        #endregion Tab: Settings

        #region Program: Debug

        #region Buttons
        private void DebugTestModeButton_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 3 || Program.RunKeyboardThread == 0)
            {
                UpdateStatusMessage.ShowStatusMessage(4, "Starting Test Mode");
                if (StartSpectrograph(4) == true) { StartSpectrographButton.Enabled = false; }
            }
        }

        #endregion Buttons

        #region UpDowns
        private void DebugTesterUD_ValueChanged(object sender, EventArgs e)
        {
            Program.TestLed = (int)DebugTesterUD.Value;
        }

        private void DebugVerbosityUD_ValueChanged(object sender, EventArgs e)
        {
            Program.LogLevel = (int)DebugLogLevelUD.Value;
        }

        #endregion UpDowns

        #endregion Tab: Debug

        #region Program
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool ShowDebugControls = true;
            if (tabControl1.SelectedIndex == 2) { ShowDebugControls = false; };

            DebugStatusLog.Visible = ShowDebugControls;
            DebugTestModeButton.Visible = ShowDebugControls;
            DebugTesterUD.Visible = ShowDebugControls;
            DebugLogLevelLabel.Visible = ShowDebugControls;
            DebugLogLevelUD.Visible = ShowDebugControls;
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
            notifyIcon.Visible = false;
        }
        
        private void StatusTimer_Tick(object sender, EventArgs e)
        {
            Application.DoEvents();
                    if (Program.ThreadStatus == 1)
                    {
                        Program.ThreadStatus = 0;
                        StatusLight.BackColor = Color.Green;
                    }
                    else
                    {
                        StatusLight.BackColor = Color.Orange;
                    }
        }

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Program


        #endregion Controls

    } //MainForm

    #region Helper Classes

#region Thread Delegates
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

#endregion Thread Delegates

#region Custom Controls

#endregion Custom Controls

#endregion Helper Classes
}