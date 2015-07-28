using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using CSCore;
using CSCore.CoreAudioAPI;

using ColorPickerControls;
using ColorPickerControls.Dialogs;
using System.Xaml;

namespace RGBKeyboardSpectrograph
{
    public partial class MainForm : Form
    {
        string[] keyboardIDs;
        string[] keyboardNames;
        string[] keyboardPositionMaps;
        string[] keyboardSizeMaps;
        Image keyboardImage;
        double keyboardImageScale = 0.6;
        int StaticCopyPasteMode = 0;
        bool StaticUnsavedChanges = false;

        Thread workerThread = Program.newWorker;
        Thread idleWatcherThread = Program.idleThread;

        public Reactive_SingleLight ReactiveThread;
        public Reactive_Heatmap HeatmapThread;
                
        public MainForm()
        {
            InitializeComponent();
            // Allow transparent Button BackColors
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        #region Form Stuff
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateStatusMessage.ShowStatusMessage(1, "Shutting Down...");
            Application.DoEvents();

            // Close background threads
            UpdateStatusMessage.ShowStatusMessage(2, "Closing threads...");
          
            if (workerThread != null) {
                // Ask the thread to destroy itself
                Program.RunKeyboardThread = 0;

                // If the thread is busy, wait for it to end
                while (workerThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            };
            if (idleWatcherThread != null)
            {
                // Ask the thread to destroy itself
                Program.WatchForInactivity = false;

                // If the thread is busy, wait for it to end
                while (idleWatcherThread.IsAlive)
                {
                    Application.DoEvents();
                    Thread.Sleep(100);
                }
            };

            // Restore keyboard's on-board lighting effects
            if (Program.SettingsRestoreLightingOnExit == true)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Restoring Keyboard Lighting");
                KeyboardWriter restoreLightingWriter = new KeyboardWriter(true);
                Thread.Sleep(500);
            }

            // Launch CUE
            if (Program.SettingLaunchCueOnExit == true)
            {
                try
                {
                    UpdateStatusMessage.ShowStatusMessage(1, "Launching CUE");
                    Process.Start(SettingsCuePathTextBox.Text);
                }
                catch { }
            }

            Application.DoEvents();

            // Destroy thread-safe handles
            UpdateStatusMessage.NewMsg -= UpdateStatusMessage_NewMsg;
            UpdateGraphicOutput.NewOut -= UpdateGraphicOutput_NewOut;
            InactivityStatusChanged.DoAction -= InactivityStatusChanged_Action;

            // Save application settings
            // Spectro
            Properties.Settings.Default.spectroColorBackgroundType = SpectroBgEffectCB.Text;
            Properties.Settings.Default.spectroColorBarsType = SpectroBarEffectCB.Text;

            Properties.Settings.Default.spectroAmplitude = (int)SpectroAmplitudeUD.Value;
            Properties.Settings.Default.spectroBackgroundBrightness = (int)SpectroBgBrightnessUD.Value;
            Properties.Settings.Default.spectroBarBrightness = (int)SpectroBarBrightnessUD.Value;
            Properties.Settings.Default.spectroRefreshDelay = (int)SpectroRefreshDelayUD.Value;
            Properties.Settings.Default.spectroBackgroundEffectWidth = (float)SpectroBgWidth.Value;
            Properties.Settings.Default.spectroBackgroundEffectSpeed = (float)SpectroBgSpeed.Value;
            Properties.Settings.Default.spectroBarEffectWidth = (float)SpectroBarWidth.Value;
            Properties.Settings.Default.spectroBarEffectSpeed = (float)SpectroBarSpeed.Value;

            Properties.Settings.Default.settingShowGraphics = SpectroShowGraphicsCheck.Checked;

            Properties.Settings.Default.spectroColorBars = SpectroColorBars.BackColor;
            Properties.Settings.Default.spectroColorBackground = SpectroColorBg.BackColor;

            Properties.Settings.Default.spectroCaptureMode = Program.CSCore_DeviceType;
            Properties.Settings.Default.spectroCaptureDevice = SpectroWasapiDevicesCB.Text;

            // Effects
            if (Effect_Float_Start_RadioDefined.Checked == true) { Properties.Settings.Default.Effect_RandomLights_Start_Mode = 1; }
            else { Properties.Settings.Default.Effect_RandomLights_Start_Mode = 2; }
            Properties.Settings.Default.Effect_RandomLights_Start_DefinedColor = Effect_Float_Start_ColourButton.BackColor;
            Properties.Settings.Default.Effect_RandomLights_Start_CLow_Red = Program.EfColors.SRandRLow;
            Properties.Settings.Default.Effect_RandomLights_Start_CLow_Green = Program.EfColors.SRandGLow;
            Properties.Settings.Default.Effect_RandomLights_Start_CLow_Blue = Program.EfColors.SRandBLow;
            Properties.Settings.Default.Effect_RandomLights_Start_CHigh_Red = Program.EfColors.SRandRHigh;
            Properties.Settings.Default.Effect_RandomLights_Start_CHigh_Green = Program.EfColors.SRandGHigh;
            Properties.Settings.Default.Effect_RandomLights_Start_CHigh_Blue = Program.EfColors.SRandBHigh;

            if (Effect_Float_End_RadioDefined.Checked == true) { Properties.Settings.Default.Effect_RandomLights_End_Mode = 1; }
            else { Properties.Settings.Default.Effect_RandomLights_End_Mode = 2; }
            Properties.Settings.Default.Effect_RandomLights_End_DefinedColor = Effect_Float_End_ColourButton.BackColor;
            Properties.Settings.Default.Effect_RandomLights_End_CLow_Red = Program.EfColors.ERandRLow;
            Properties.Settings.Default.Effect_RandomLights_End_CLow_Green = Program.EfColors.ERandGLow;
            Properties.Settings.Default.Effect_RandomLights_End_CLow_Blue = Program.EfColors.ERandBLow;
            Properties.Settings.Default.Effect_RandomLights_End_CHigh_Red = Program.EfColors.ERandRHigh;
            Properties.Settings.Default.Effect_RandomLights_End_CHigh_Green = Program.EfColors.ERandGHigh;
            Properties.Settings.Default.Effect_RandomLights_End_CHigh_Blue = Program.EfColors.ERandBHigh;

            Properties.Settings.Default.Effect_RandomLights_Duration = (int)Effect_Float_DurationUD.Value;
            Properties.Settings.Default.Effect_RandomLights_Delay = (int)Effect_Float_FrequencyUD.Value;

            Properties.Settings.Default.EffectUseStaticKeys = Program.AnimationsUseStaticKeys;

            // Static
            Properties.Settings.Default.appLastUsedProfile = Program.SettingsLastUsedProfile;

            // Reactive 
            if (Reactive_Start_RadioDefined.Checked == true) { Properties.Settings.Default.Reactive_Start_Mode = 0; }
            else if (Reactive_Start_RadioRainbow.Checked == true) {Properties.Settings.Default.Reactive_Start_Mode = 1; }
            else { Properties.Settings.Default.Reactive_Start_Mode = 2; }
            Properties.Settings.Default.Reactive_Start_DefinedColor = Reactive_Start_ColourButton.BackColor;
            Properties.Settings.Default.Reactive_Start_CLow_Red = Program.ReactColors.SRandRLow;
            Properties.Settings.Default.Reactive_Start_CLow_Green = Program.ReactColors.SRandGLow;
            Properties.Settings.Default.Reactive_Start_CLow_Blue = Program.ReactColors.SRandBLow;
            Properties.Settings.Default.Reactive_Start_CHigh_Red = Program.ReactColors.SRandRHigh;
            Properties.Settings.Default.Reactive_Start_CHigh_Green = Program.ReactColors.SRandGHigh;
            Properties.Settings.Default.Reactive_Start_CHigh_Blue = Program.ReactColors.SRandBHigh;

            if (Reactive_End_RadioDefined.Checked == true) { Properties.Settings.Default.Reactive_End_Mode = 0; }
            else if (Reactive_End_RadioOriginal.Checked == true) { Properties.Settings.Default.Reactive_End_Mode = 1; }
            else { Properties.Settings.Default.Reactive_End_Mode = 2; }
            Properties.Settings.Default.Reactive_End_DefinedColor = Reactive_End_ColourButton.BackColor;
            Properties.Settings.Default.Reactive_End_CLow_Red = Program.ReactColors.ERandRLow;
            Properties.Settings.Default.Reactive_End_CLow_Green = Program.ReactColors.ERandGLow;
            Properties.Settings.Default.Reactive_End_CLow_Blue = Program.ReactColors.ERandBLow;
            Properties.Settings.Default.Reactive_End_CHigh_Red = Program.ReactColors.ERandRHigh;
            Properties.Settings.Default.Reactive_End_CHigh_Green = Program.ReactColors.ERandGHigh;
            Properties.Settings.Default.Reactive_End_CHigh_Blue = Program.ReactColors.ERandBHigh;

            Properties.Settings.Default.Reactive_Duration = (int)Reactive_DurationUD.Value;
            Properties.Settings.Default.Reactive_Delay = (int)Reactive_FrequencyUD.Value;

            Properties.Settings.Default.Heatmap_StartColour = Heatmap_Start_ColourButton.BackColor;
            Properties.Settings.Default.Heatmap_EndColour = Heatmap_End_ColourButton.BackColor;

            // Settings
            Properties.Settings.Default.settingKeyboardModel = SettingsKeyboardModelCB.Text;
            Properties.Settings.Default.settingKeyboardLayout = SettingsKeyboardLayoutCB.Text;
            Properties.Settings.Default.settingMouseModel = SettingsMouseModelCB.Text;

            Properties.Settings.Default.debugLogLevel = (int)DebugLogLevelUD.Value;

            Properties.Settings.Default.settingMinimizeToTray = SettingsMinimizeToTrayCheck.Checked;
            Properties.Settings.Default.settingStartMinimized = SettingsStartMinimizedCheck.Checked;
            Properties.Settings.Default.settingSpectroOnStart = SettingsSpectroOnStartCheck.Checked;
            Properties.Settings.Default.settingEffectsOnStart = SettingsEffectsOnStartCheck.Checked;
            Properties.Settings.Default.settingStaticOnStart = SettingsStaticOnStartCheck.Checked;
            Properties.Settings.Default.settingRestoreLighting = SettingsRestoreLightingCheck.Checked;
            Properties.Settings.Default.settingLaunchCueOnExit = SettingsLaunchCueCheck.Checked;
            Properties.Settings.Default.EffectsIncludeMouse = SettingsEffectsIncludeMouse.Checked;

            Properties.Settings.Default.settingCueLocation = SettingsCuePathTextBox.Text;

            Properties.Settings.Default.idleMode = SettingsIdleModeCB.Text;
            Properties.Settings.Default.idleProfile = SettingsIdleProfileCB.Text;
            Properties.Settings.Default.idleTriggerTime = (int)SettingsIdleTimeUD.Value;
            Properties.Settings.Default.idleUseIdleWatcher = SettingsIdleSwitcher.Checked;

            // Save Settings
            Properties.Settings.Default.Save();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // Minimize to tray
            if (this.WindowState == FormWindowState.Minimized && SettingsMinimizeToTrayCheck.Checked == true)
            {
                notifyIcon.Visible = true;
                //notifyIcon.ShowBalloonTip(3000);
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Thread-safe handles
            UpdateStatusMessage.NewMsg += UpdateStatusMessage_NewMsg;
            UpdateGraphicOutput.NewOut += UpdateGraphicOutput_NewOut;
            InactivityStatusChanged.DoAction += InactivityStatusChanged_Action; 

            UpdateStatusMessage.ShowStatusMessage(0, "Version " + Program.VersionNumber);

            // Check for updates
            Thread UpdateChecker = new Thread(this.CheckForUpdates);
            UpdateChecker.Start();

            // Start manipulating controls and loading saved values
            UpdateStatusMessage.ShowStatusMessage(1, "Populating Controls");
            if (!Program.DevMode) { notifyIcon.Visible = false; };

            #region Populate Combo Boxes

            SettingsKeyboardModelCB.Items.Add("K65-RGB");
            SettingsKeyboardModelCB.Items.Add("K70-RGB");
            SettingsKeyboardModelCB.Items.Add("K95-RGB");

            SettingsMouseModelCB.Items.Add("None");
            SettingsMouseModelCB.Items.Add("M65 RGB");
            SettingsMouseModelCB.Items.Add("Sabre 1");
            SettingsMouseModelCB.Items.Add("Sabre 2");

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

            SettingsIdleModeCB.Items.Add("Spectrograph");
            SettingsIdleModeCB.Items.Add("Random Lights");
            SettingsIdleModeCB.Items.Add("Static Profile");

            #endregion Pupulate Combo Boxes

            // Get audio input device list
            var deviceEnum = new MMDeviceEnumerator();
            var devices = deviceEnum.EnumAudioEndpoints(DataFlow.Capture, DeviceState.Active).ToList();
            SpectroWasapiDevicesCB.DataSource = devices;
            SpectroWasapiDevicesCB.DisplayMember = "FriendlyName";
            
            // Load all settings. Those that require manipulation or verification
            // are first loaded to variables to help manipulate them.
            UpdateStatusMessage.ShowStatusMessage(1, "Loading Settings");

            #region Settings: Spectro

            string settingBackgroundColorType = Properties.Settings.Default.spectroColorBackgroundType;
            if (SpectroBgEffectCB.FindStringExact(settingBackgroundColorType) > -1) { SpectroBgEffectCB.SelectedIndex = SpectroBgEffectCB.FindStringExact(settingBackgroundColorType); }
            else { SpectroBgEffectCB.SelectedIndex = 1; };

            string settingBarColorType = Properties.Settings.Default.spectroColorBarsType;
            if (SpectroBarEffectCB.FindStringExact(settingBarColorType) > -1) { SpectroBarEffectCB.SelectedIndex = SpectroBarEffectCB.FindStringExact(settingBarColorType); }
            else { SpectroBarEffectCB.SelectedIndex = 1; };

            string settingCaptureDeviceName = Properties.Settings.Default.spectroCaptureDevice;
            if (SpectroWasapiDevicesCB.FindStringExact(settingCaptureDeviceName) > -1) { SpectroWasapiDevicesCB.SelectedIndex = SpectroWasapiDevicesCB.FindStringExact(settingCaptureDeviceName); };


            int settingAmplitude = Properties.Settings.Default.spectroAmplitude;
            if (settingAmplitude < 0 || settingAmplitude > 100) { settingAmplitude = 10; };
            SpectroAmplitudeUD.Value = settingAmplitude;

            int settingBackgroundBrightness = Properties.Settings.Default.spectroBackgroundBrightness;
            if (settingBackgroundBrightness < 0 || settingBackgroundBrightness > 70) { settingBackgroundBrightness = 15; };
            SpectroBgBrightnessUD.Value = settingBackgroundBrightness;

            int settingBarBrightness = Properties.Settings.Default.spectroBarBrightness;
            if (settingBarBrightness < 0 || settingBarBrightness > 70) { settingBarBrightness = 15; };
            SpectroBarBrightnessUD.Value = settingBarBrightness;

            int settingRefreshDelay = Properties.Settings.Default.spectroRefreshDelay;
            if (settingRefreshDelay < 0 || settingRefreshDelay > 1000) { settingRefreshDelay = 20; };
            SpectroRefreshDelayUD.Value = settingRefreshDelay;

            float settingEffectWidth = Properties.Settings.Default.spectroBackgroundEffectWidth;
            if (settingEffectWidth < 1 || settingEffectWidth > 1000) { settingEffectWidth = 104; };
            SpectroBgWidth.Value = (decimal)settingEffectWidth;

            float settingEffectSpeed = Properties.Settings.Default.spectroBackgroundEffectSpeed;
            if (settingEffectSpeed < 0.1 || settingEffectSpeed > 10) { settingEffectSpeed = 1; };
            SpectroBgSpeed.Value = (decimal)settingEffectSpeed;

            float settingBarWidth = Properties.Settings.Default.spectroBarEffectWidth;
            if (settingBarWidth < 1 || settingBarWidth > 1000) { settingBarWidth = 104; };
            SpectroBarWidth.Value = (decimal)settingBarWidth;

            float settingBarSpeed = Properties.Settings.Default.spectroBarEffectSpeed;
            if (settingBarSpeed < 1 || settingBarSpeed > 10) { settingBarSpeed = 1; };
            SpectroBarSpeed.Value = (decimal)settingBarSpeed;


            switch (Properties.Settings.Default.spectroCaptureMode)
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


            Color settingBarColor = Properties.Settings.Default.spectroColorBars;
            SpectroColorBars.BackColor = settingBarColor;
            SpectroColorBars.ForeColor = ContrastColor(SpectroColorBars.BackColor);
            Program.SpectroBars.Color.Set(SpectroColorBars.BackColor);

            Color settingBackgroundColor = Properties.Settings.Default.spectroColorBackground;
            SpectroColorBg.BackColor = settingBackgroundColor;
            SpectroColorBg.ForeColor = ContrastColor(SpectroColorBg.BackColor);
            Program.SpectroBg.Color.Set(SpectroColorBg.BackColor);

            tsmSpectroAmplitudeSlider.Minimum = 0;
            tsmSpectroAmplitudeSlider.Maximum = 100;
            tsmSpectroAmplitudeSlider.Value = settingAmplitude;
            tsmSpectroAmplitudeSlider.ValueChanged += new System.EventHandler(tsmSpectroAmplitudeSlider_ValueChanged);
            tsmSpectroAmplitude.Text = "Amplitude: " + tsmSpectroAmplitudeSlider.Value;

            tsmStartSpectro.DropDownItems.Add(tsmSpectroAmplitude);

            #endregion Settings: Spectro

            #region Settings: Effects

            #region Effects - Random Lights - Start
            int setting_Effect_RandomLights_S_Mode = Properties.Settings.Default.Effect_RandomLights_Start_Mode;
            if (setting_Effect_RandomLights_S_Mode == 1) { Effect_Float_Start_RadioDefined.Checked = true; }
            else {Effect_Float_Start_RadioRandom.Checked = true; }

            Effect_Float_Start_ColourButton.BackColor = Properties.Settings.Default.Effect_RandomLights_Start_DefinedColor;

            int setting_Effect_RandomLights_S_CLow_Red = Properties.Settings.Default.Effect_RandomLights_Start_CLow_Red;
            if (setting_Effect_RandomLights_S_CLow_Red < 0 || setting_Effect_RandomLights_S_CLow_Red > 255) { setting_Effect_RandomLights_S_CLow_Red = 0; };
            Effect_Float_Start_Red_LowUD.Value = setting_Effect_RandomLights_S_CLow_Red;

            int setting_Effect_RandomLights_S_CLow_Green = Properties.Settings.Default.Effect_RandomLights_Start_CLow_Green;
            if (setting_Effect_RandomLights_S_CLow_Green < 0 || setting_Effect_RandomLights_S_CLow_Green > 255) { setting_Effect_RandomLights_S_CLow_Green = 0; };
            Effect_Float_Start_Green_LowUD.Value = setting_Effect_RandomLights_S_CLow_Green;

            int setting_Effect_RandomLights_S_CLow_Blue = Properties.Settings.Default.Effect_RandomLights_Start_CLow_Blue;
            if (setting_Effect_RandomLights_S_CLow_Blue < 0 || setting_Effect_RandomLights_S_CLow_Blue > 255) { setting_Effect_RandomLights_S_CLow_Blue = 0; };
            Effect_Float_Start_Blue_LowUD.Value = setting_Effect_RandomLights_S_CLow_Blue;

            int setting_Effect_RandomLights_S_CHigh_Red = Properties.Settings.Default.Effect_RandomLights_Start_CHigh_Red;
            if (setting_Effect_RandomLights_S_CHigh_Red < 0 || setting_Effect_RandomLights_S_CHigh_Red > 255) { setting_Effect_RandomLights_S_CHigh_Red = 255; };
            Effect_Float_Start_Red_HighUD.Value = setting_Effect_RandomLights_S_CHigh_Red;

            int setting_Effect_RandomLights_S_CHigh_Green = Properties.Settings.Default.Effect_RandomLights_Start_CHigh_Green;
            if (setting_Effect_RandomLights_S_CHigh_Green < 0 || setting_Effect_RandomLights_S_CHigh_Green > 255) { setting_Effect_RandomLights_S_CHigh_Green = 255; };
            Effect_Float_Start_Green_HighUD.Value = setting_Effect_RandomLights_S_CHigh_Green;

            int setting_Effect_RandomLights_S_CHigh_Blue = Properties.Settings.Default.Effect_RandomLights_Start_CHigh_Blue;
            if (setting_Effect_RandomLights_S_CHigh_Blue < 0 || setting_Effect_RandomLights_S_CHigh_Blue > 255) { setting_Effect_RandomLights_S_CHigh_Blue = 255; };
            Effect_Float_Start_Blue_HighUD.Value = setting_Effect_RandomLights_S_CHigh_Blue;

        #endregion Effects - Random Lights - Start

            #region Effects - Random Lights - End
            int setting_Effect_RandomLights_E_Mode = Properties.Settings.Default.Effect_RandomLights_End_Mode;
            if (setting_Effect_RandomLights_E_Mode == 2) { Effect_Float_End_RadioRandom.Checked = true; }
            else { Effect_Float_End_RadioDefined.Checked = true; }

            Effect_Float_End_ColourButton.BackColor = Properties.Settings.Default.Effect_RandomLights_End_DefinedColor;

            int setting_Effect_RandomLights_E_CLow_Red = Properties.Settings.Default.Effect_RandomLights_End_CLow_Red;
            if (setting_Effect_RandomLights_E_CLow_Red < 0 || setting_Effect_RandomLights_E_CLow_Red > 255) { setting_Effect_RandomLights_E_CLow_Red = 0; };
            Effect_Float_End_Red_LowUD.Value = setting_Effect_RandomLights_E_CLow_Red;

            int setting_Effect_RandomLights_E_CLow_Green = Properties.Settings.Default.Effect_RandomLights_End_CLow_Green;
            if (setting_Effect_RandomLights_E_CLow_Green < 0 || setting_Effect_RandomLights_E_CLow_Green > 255) { setting_Effect_RandomLights_E_CLow_Green = 0; };
            Effect_Float_End_Green_LowUD.Value = setting_Effect_RandomLights_E_CLow_Green;

            int setting_Effect_RandomLights_E_CLow_Blue = Properties.Settings.Default.Effect_RandomLights_End_CLow_Blue;
            if (setting_Effect_RandomLights_E_CLow_Blue < 0 || setting_Effect_RandomLights_E_CLow_Blue > 255) { setting_Effect_RandomLights_E_CLow_Blue = 0; };
            Effect_Float_End_Blue_LowUD.Value = setting_Effect_RandomLights_E_CLow_Blue;

            int setting_Effect_RandomLights_E_CHigh_Red = Properties.Settings.Default.Effect_RandomLights_End_CHigh_Red;
            if (setting_Effect_RandomLights_E_CHigh_Red < 0 || setting_Effect_RandomLights_E_CHigh_Red > 255) { setting_Effect_RandomLights_E_CHigh_Red = 255; };
            Effect_Float_End_Red_HighUD.Value = setting_Effect_RandomLights_E_CHigh_Red;

            int setting_Effect_RandomLights_E_CHigh_Green = Properties.Settings.Default.Effect_RandomLights_End_CHigh_Green;
            if (setting_Effect_RandomLights_E_CHigh_Green < 0 || setting_Effect_RandomLights_E_CHigh_Green > 255) { setting_Effect_RandomLights_E_CHigh_Green = 255; };
            Effect_Float_End_Green_HighUD.Value = setting_Effect_RandomLights_E_CHigh_Green;

            int setting_Effect_RandomLights_E_CHigh_Blue = Properties.Settings.Default.Effect_RandomLights_End_CHigh_Blue;
            if (setting_Effect_RandomLights_E_CHigh_Blue < 0 || setting_Effect_RandomLights_E_CHigh_Blue > 255) { setting_Effect_RandomLights_E_CHigh_Blue = 255; };
            Effect_Float_End_Blue_HighUD.Value = setting_Effect_RandomLights_E_CHigh_Blue;

        #endregion Effects - Random Lights - End

            Effect_Float_DurationUD.Value = Properties.Settings.Default.Effect_RandomLights_Duration;
            Effect_Float_FrequencyUD.Value = Properties.Settings.Default.Effect_RandomLights_Delay;

            Effect_RandomLights_Start_UpdateColorBoxes(null, null);
            Effect_RandomLights_End_UpdateColorBoxes(null, null);
            Effects_RandomLights_Start_RadioCheckedChanged(null, null);
            Effects_RandomLights_End_RadioCheckedChanged(null, null);

            AnimationsUseStaticLights.Checked = Properties.Settings.Default.EffectUseStaticKeys;

            #endregion Settings: Effects

            #region Settings: Static

            Program.SettingsLastUsedProfile = Properties.Settings.Default.appLastUsedProfile;
            StaticKeysLoadProfileList();

            #endregion Settings: Static

            #region Settings: Reactive

            #region Reactive - Start
            int setting_Reactive_S_Mode = Properties.Settings.Default.Reactive_Start_Mode;
            if (setting_Reactive_S_Mode == 0) { Reactive_Start_RadioDefined.Checked = true; }
            else if (setting_Reactive_S_Mode == 1) { Reactive_Start_RadioRandom.Checked = true; } //This should be RaidoRainbow, but we don't want users selecting it
            else if (setting_Reactive_S_Mode == 2) { Reactive_Start_RadioRandom.Checked = true; }
            else { Reactive_Start_RadioRandom.Checked = true; }

            Reactive_Start_ColourButton.BackColor = Properties.Settings.Default.Reactive_Start_DefinedColor;

            int setting_Reactive_S_CLow_Red = Properties.Settings.Default.Reactive_Start_CLow_Red;
            if (setting_Reactive_S_CLow_Red < 0 || setting_Reactive_S_CLow_Red > 255) { setting_Reactive_S_CLow_Red = 0; };
            Reactive_Start_Red_LowUD.Value = setting_Reactive_S_CLow_Red;

            int setting_Reactive_S_CLow_Green = Properties.Settings.Default.Reactive_Start_CLow_Green;
            if (setting_Reactive_S_CLow_Green < 0 || setting_Reactive_S_CLow_Green > 255) { setting_Reactive_S_CLow_Green = 0; };
            Reactive_Start_Green_LowUD.Value = setting_Reactive_S_CLow_Green;

            int setting_Reactive_S_CLow_Blue = Properties.Settings.Default.Reactive_Start_CLow_Blue;
            if (setting_Reactive_S_CLow_Blue < 0 || setting_Reactive_S_CLow_Blue > 255) { setting_Reactive_S_CLow_Blue = 0; };
            Reactive_Start_Blue_LowUD.Value = setting_Reactive_S_CLow_Blue;

            int setting_Reactive_S_CHigh_Red = Properties.Settings.Default.Reactive_Start_CHigh_Red;
            if (setting_Reactive_S_CHigh_Red < 0 || setting_Reactive_S_CHigh_Red > 255) { setting_Reactive_S_CHigh_Red = 255; };
            Reactive_Start_Red_HighUD.Value = setting_Reactive_S_CHigh_Red;

            int setting_Reactive_S_CHigh_Green = Properties.Settings.Default.Reactive_Start_CHigh_Green;
            if (setting_Reactive_S_CHigh_Green < 0 || setting_Reactive_S_CHigh_Green > 255) { setting_Reactive_S_CHigh_Green = 255; };
            Reactive_Start_Green_HighUD.Value = setting_Reactive_S_CHigh_Green;

            int setting_Reactive_S_CHigh_Blue = Properties.Settings.Default.Reactive_Start_CHigh_Blue;
            if (setting_Reactive_S_CHigh_Blue < 0 || setting_Reactive_S_CHigh_Blue > 255) { setting_Reactive_S_CHigh_Blue = 255; };
            Reactive_Start_Blue_HighUD.Value = setting_Reactive_S_CHigh_Blue;

            #endregion Reactive - Start

            #region Reactive - End
            int setting_Reactive_E_Mode = Properties.Settings.Default.Reactive_End_Mode;
            if (setting_Reactive_E_Mode == 0) { Reactive_End_RadioDefined.Checked = true; }
            else if (setting_Reactive_E_Mode == 1) { Reactive_End_RadioOriginal.Checked = true; }
            else if (setting_Reactive_E_Mode == 2) { Reactive_End_RadioRandom.Checked = true; }
            else { Reactive_End_RadioRandom.Checked = true; }

            Reactive_End_ColourButton.BackColor = Properties.Settings.Default.Reactive_End_DefinedColor;

            int setting_Reactive_E_CLow_Red = Properties.Settings.Default.Reactive_End_CLow_Red;
            if (setting_Reactive_E_CLow_Red < 0 || setting_Reactive_E_CLow_Red > 255) { setting_Reactive_E_CLow_Red = 0; };
            Reactive_End_Red_LowUD.Value = setting_Reactive_E_CLow_Red;

            int setting_Reactive_E_CLow_Green = Properties.Settings.Default.Reactive_End_CLow_Green;
            if (setting_Reactive_E_CLow_Green < 0 || setting_Reactive_E_CLow_Green > 255) { setting_Reactive_E_CLow_Green = 0; };
            Reactive_End_Green_LowUD.Value = setting_Reactive_E_CLow_Green;

            int setting_Reactive_E_CLow_Blue = Properties.Settings.Default.Reactive_End_CLow_Blue;
            if (setting_Reactive_E_CLow_Blue < 0 || setting_Reactive_E_CLow_Blue > 255) { setting_Reactive_E_CLow_Blue = 0; };
            Reactive_End_Blue_LowUD.Value = setting_Reactive_E_CLow_Blue;

            int setting_Reactive_E_CHigh_Red = Properties.Settings.Default.Reactive_End_CHigh_Red;
            if (setting_Reactive_E_CHigh_Red < 0 || setting_Reactive_E_CHigh_Red > 255) { setting_Reactive_E_CHigh_Red = 255; };
            Reactive_End_Red_HighUD.Value = setting_Reactive_E_CHigh_Red;

            int setting_Reactive_E_CHigh_Green = Properties.Settings.Default.Reactive_End_CHigh_Green;
            if (setting_Reactive_E_CHigh_Green < 0 || setting_Reactive_E_CHigh_Green > 255) { setting_Reactive_E_CHigh_Green = 255; };
            Reactive_End_Green_HighUD.Value = setting_Reactive_E_CHigh_Green;

            int setting_Reactive_E_CHigh_Blue = Properties.Settings.Default.Reactive_End_CHigh_Blue;
            if (setting_Reactive_E_CHigh_Blue < 0 || setting_Reactive_E_CHigh_Blue > 255) { setting_Reactive_E_CHigh_Blue = 255; };
            Reactive_End_Blue_HighUD.Value = setting_Reactive_E_CHigh_Blue;

            #endregion Reactive - End

            Reactive_DurationUD.Value = Properties.Settings.Default.Reactive_Duration;
            Reactive_FrequencyUD.Value = Properties.Settings.Default.Reactive_Delay;

            Reactive_Start_UpdateColorBoxes(null, null);
            Reactive_End_UpdateColorBoxes(null, null);
            Reactive_Start_RadioCheckedChanged(null, null);
            Reactive_End_RadioCheckedChanged(null, null);

            Heatmap_Start_ColourButton.BackColor = Properties.Settings.Default.Heatmap_StartColour;
            Heatmap_End_ColourButton.BackColor = Properties.Settings.Default.Heatmap_EndColour;

            #endregion Settings: Reactive

            #region Settings: Settings

            string settingKeyboardModel = Properties.Settings.Default.settingKeyboardModel;
            if (SettingsKeyboardModelCB.FindStringExact(settingKeyboardModel) > -1) { SettingsKeyboardModelCB.SelectedIndex = SettingsKeyboardModelCB.FindStringExact(settingKeyboardModel); };

            string settingKeyboardLayout = Properties.Settings.Default.settingKeyboardLayout;
            if (SettingsKeyboardLayoutCB.FindStringExact(settingKeyboardLayout) > -1) { SettingsKeyboardLayoutCB.SelectedIndex = SettingsKeyboardLayoutCB.FindStringExact(settingKeyboardLayout); };

            string settingMouseModel = Properties.Settings.Default.settingMouseModel;
            if (SettingsMouseModelCB.FindStringExact(settingMouseModel) > -1) { SettingsMouseModelCB.SelectedIndex = SettingsMouseModelCB.FindStringExact(settingMouseModel); };
            
            
            int settingLogLevel = Properties.Settings.Default.debugLogLevel;
            if (settingLogLevel < 3) { settingLogLevel = 3; };
            DebugLogLevelUD.Value = settingLogLevel;
            Program.LogLevel = settingLogLevel;


            SettingsMinimizeToTrayCheck.Checked = Properties.Settings.Default.settingMinimizeToTray;
            SpectroShowGraphicsCheck.Checked = Properties.Settings.Default.settingShowGraphics;
            SpectroShowGraphicsCheck_CheckedChanged(null, null); // Update the Program variable and the picturebox's visibility
            SettingsStartMinimizedCheck.Checked = Properties.Settings.Default.settingStartMinimized;
            SettingsSpectroOnStartCheck.Checked = Properties.Settings.Default.settingSpectroOnStart;
            SettingsEffectsOnStartCheck.Checked = Properties.Settings.Default.settingEffectsOnStart;
            SettingsStaticOnStartCheck.Checked = Properties.Settings.Default.settingStaticOnStart;
            SettingsRestoreLightingCheck.Checked = Properties.Settings.Default.settingRestoreLighting;
            SettingsLaunchCueCheck.Checked = Properties.Settings.Default.settingLaunchCueOnExit;
            SettingsEffectsIncludeMouse.Checked = Properties.Settings.Default.EffectsIncludeMouse;

            SettingsCuePathTextBox.Text = Properties.Settings.Default.settingCueLocation;

            string settingIdleMode = Properties.Settings.Default.idleMode;
            if (SettingsIdleModeCB.FindStringExact(settingIdleMode) > -1) { SettingsIdleModeCB.SelectedIndex = SettingsIdleModeCB.FindStringExact(settingIdleMode); };

            string settingIdleProfile = Properties.Settings.Default.idleProfile;
            if (SettingsIdleProfileCB.FindStringExact(settingIdleProfile) > -1) { SettingsIdleProfileCB.SelectedIndex = SettingsIdleProfileCB.FindStringExact(settingIdleProfile); };
            
            int settingIdleTime = Properties.Settings.Default.idleTriggerTime;
            if (settingIdleTime < 0 || settingIdleTime > 1440) { settingIdleTime = 5; };
            SettingsIdleTimeUD.Value = settingIdleTime;

            SettingsIdleSwitcher.Checked = Properties.Settings.Default.idleUseIdleWatcher;

            SettingsIdleSwitcher_CheckedChanged(null, null);

            #endregion Settings: Settings

            #region Tooltips
            ToolTip hintsToolTip = new ToolTip();
            hintsToolTip.AutoPopDelay = 3000;
            hintsToolTip.InitialDelay = 1000;
            hintsToolTip.ReshowDelay = 500;
            hintsToolTip.ShowAlways = true;

            // ToolTip Texts
            /* To add:
             * Everything on Reactive page
             */
            hintsToolTip.SetToolTip(this.AnimationsUseStaticLights, "Whether or not to display static lights on top of effects.");
            hintsToolTip.SetToolTip(this.DebugLogLevelLabel, "");
            hintsToolTip.SetToolTip(this.DebugLogLevelUD, "");
            hintsToolTip.SetToolTip(this.DebugStatusLog, "");
            hintsToolTip.SetToolTip(this.DebugTesterUD, "");
            hintsToolTip.SetToolTip(this.DebugTestModeButton, "Enter test mode, illuminating one key at a time.");
            hintsToolTip.SetToolTip(this.Effect_Float_DurationLabel, "Lifespan of a lit-up key.");
            hintsToolTip.SetToolTip(this.Effect_Float_DurationUD, "Lifespan of a lit-up key.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Blue_HighButton, "Displaying the uppermost blue value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Blue_HighUD, "Set the highest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Blue_LowButton, "Displaying the lowermost blue value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Blue_LowUD, "Set the lowest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_ColourButton, "Click to select a colour.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Green_HighButton, "Displaying the uppermost green value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Green_HighUD, "Set the highest value for the green channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Green_LowButton, "Displaying the lowermost green value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Green_LowUD, "Set the lowest value for the green channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_RadioDefined, "Transition to a defined colour.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_RadioRandom, "Transition to a random colour.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Red_HighButton, "Displaying the uppermost red value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Red_HighUD, "Set the highest value for the red channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Red_LowButton, "Displaying the lowermost red value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_End_Red_LowUD, "Set the lowest value for the red channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_FrequencyLabel, "Time between cycles.");
            hintsToolTip.SetToolTip(this.Effect_Float_FrequencyUD, "Time between cycles.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Blue_HighButton, "Displaying the uppermost blue value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Blue_HighUD, "Set the highest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Blue_LowButton, "Displaying the lowermost blue value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Blue_LowUD, "Set the lowest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_ColourButton, "Click to select a colour.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Green_HighButton, "Displaying the uppermost green value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Green_HighUD, "Set the highest value for the green channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Green_LowButton, "Displaying the lowermost green value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Green_LowUD, "Set the lowest value for the green channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_RadioDefined, "Transition to a defined colour.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_RadioRandom, "Transition to a random colour.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Red_HighButton, "Displaying the uppermost red value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Red_HighUD, "Set the highest value for the red channel.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Red_LowButton, "Displaying the lowermost red value selected.");
            hintsToolTip.SetToolTip(this.Effect_Float_Start_Red_LowUD, "Set the lowest value for the red channel.");
            hintsToolTip.SetToolTip(this.EffectsStartButton, "Start effects.");
            hintsToolTip.SetToolTip(this.EffectsStopButton, "Stop all effects.");
            hintsToolTip.SetToolTip(this.EffectTab_Rainfall, "Display a rainfall effect.");
            hintsToolTip.SetToolTip(this.EffectTab_RandomLights, "Light up random keys.");
            hintsToolTip.SetToolTip(this.Heatmap_End_ColourButton, "Click to select a colour.");
            hintsToolTip.SetToolTip(this.Heatmap_End_ColourLabel, "The colour for the least clicked keys.");
            hintsToolTip.SetToolTip(this.Heatmap_ResetMaxButton, "Reset the counters for all keys to zero.");
            hintsToolTip.SetToolTip(this.Heatmap_Start_ColourButton, "Click to select a colour.");
            hintsToolTip.SetToolTip(this.Heatmap_Start_ColourLabel, "The colour for the most clicked keys.");
            hintsToolTip.SetToolTip(this.Reactive_DurationLabel, "Lifespan of a lit-up key.");
            hintsToolTip.SetToolTip(this.Reactive_DurationUD, "Lifespan of a lit-up key.");
            hintsToolTip.SetToolTip(this.Reactive_End_Blue_HighButton, "Displaying the uppermost blue value selected.");
            hintsToolTip.SetToolTip(this.Reactive_End_Blue_HighUD, "Set the highest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Reactive_End_Blue_LowButton, "Displaying the lowermost blue value selected.");
            hintsToolTip.SetToolTip(this.Reactive_End_Blue_LowUD, "Set the lowest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Reactive_End_ColourButton, "Click to select a colour.");
            hintsToolTip.SetToolTip(this.Reactive_End_Green_HighButton, "Displaying the uppermost green value selected.");
            hintsToolTip.SetToolTip(this.Reactive_End_Green_HighUD, "Set the highest value for the green channel.");
            hintsToolTip.SetToolTip(this.Reactive_End_Green_LowButton, "Displaying the lowermost green value selected.");
            hintsToolTip.SetToolTip(this.Reactive_End_Green_LowUD, "Set the lowest value for the green channel.");
            hintsToolTip.SetToolTip(this.Reactive_End_RadioDefined, "Transition to a defined colour.");
            hintsToolTip.SetToolTip(this.Reactive_End_RadioOriginal, "Transition to the original colour of the key.");
            hintsToolTip.SetToolTip(this.Reactive_End_RadioRandom, "Transition to a random colour.");
            hintsToolTip.SetToolTip(this.Reactive_End_Red_HighButton, "Displaying the uppermost red value selected.");
            hintsToolTip.SetToolTip(this.Reactive_End_Red_HighUD, "Set the highest value for the red channel.");
            hintsToolTip.SetToolTip(this.Reactive_End_Red_LowButton, "Displaying the lowermost red value selected.");
            hintsToolTip.SetToolTip(this.Reactive_End_Red_LowUD, "Set the lowest value for the red channel.");
            hintsToolTip.SetToolTip(this.Reactive_FrequencyLabel, "Time between cycles.");
            hintsToolTip.SetToolTip(this.Reactive_FrequencyUD, "Time between cycles.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Blue_HighButton, "Displaying the uppermost blue value selected.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Blue_HighUD, "Set the highest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Blue_LowButton, "Displaying the lowermost blue value selected.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Blue_LowUD, "Set the lowest value for the blue channel.");
            hintsToolTip.SetToolTip(this.Reactive_Start_ColourButton, "Click to select a colour.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Green_HighButton, "Displaying the uppermost green value selected.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Green_HighUD, "Set the highest value for the green channel.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Green_LowButton, "Displaying the lowermost green value selected.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Green_LowUD, "Set the lowest value for the green channel.");
            hintsToolTip.SetToolTip(this.Reactive_Start_RadioDefined, "Transition to a defined colour.");
            hintsToolTip.SetToolTip(this.Reactive_Start_RadioRainbow, "Transition through a spectral cycle. [To be implemented soon]");
            hintsToolTip.SetToolTip(this.Reactive_Start_RadioRandom, "Transition to a random colour.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Red_HighButton, "Displaying the uppermost red value selected.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Red_HighUD, "Set the highest value for the red channel.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Red_LowButton, "Displaying the lowermost red value selected.");
            hintsToolTip.SetToolTip(this.Reactive_Start_Red_LowUD, "Set the lowest value for the red channel.");
            hintsToolTip.SetToolTip(this.SettingsBrowseCuePathButton, "Find your CUE executable for automatic launching upon close. This is not required.");
            hintsToolTip.SetToolTip(this.SettingsCuePathLabel, "Find your CUE executable for automatic launching upon close. This is not required.");
            hintsToolTip.SetToolTip(this.SettingsCuePathTextBox, "Find your CUE executable for automatic launching upon close. This is not required.");
            hintsToolTip.SetToolTip(this.SettingsEffectsIncludeMouse, "Expand effects to the mouse. NOTE: This currently only applies to the Effects tab.");
            hintsToolTip.SetToolTip(this.SettingsEffectsOnStartCheck, "Automatically start effects when the program starts.");
            hintsToolTip.SetToolTip(this.SettingsGetUpdateButton, "Open your web browser to the location of the latest update.");
            hintsToolTip.SetToolTip(this.SettingsIdleSwitcher, "Switch to different effects or a static profile when away from the computer.");
            hintsToolTip.SetToolTip(this.SettingsKeyboardLayoutCB, "Select the layout of your keyboard.");
            hintsToolTip.SetToolTip(this.SettingsKeyboardModelCB, "Select the model of your keyboard.");
            hintsToolTip.SetToolTip(this.SettingsLaunchCueCheck, "Launches CUE upon quitting this application. Requires the path to be entered below.");
            hintsToolTip.SetToolTip(this.SettingsMinimizeToTrayCheck, "Minimize to the System Tray instead of the Task Bar.");
            hintsToolTip.SetToolTip(this.SettingsMouseModelCB, "Select the model of your mouse.");
            hintsToolTip.SetToolTip(this.SettingsRestoreLightingCheck, "Restores the lightig saved on the device upon quitting the program. NOTE: This does not currently affect mice.");
            hintsToolTip.SetToolTip(this.SettingsSpectroOnStartCheck, "Automatically start the spectrograph when the program starts.");
            hintsToolTip.SetToolTip(this.SettingsStartMinimizedCheck, "Automatically minimizes the program when it is started.");
            hintsToolTip.SetToolTip(this.SettingsStaticOnStartCheck, "Display a static keys profile when the program is started.");
            hintsToolTip.SetToolTip(this.SpectroAmplitudeLabel, "Change the sensitivity of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroAmplitudeUD, "Change the sensitivity of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBarBrightnessUD, "Change the brightness of the foreground of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBarEffectCB, "Select the effect for the foreground of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBarSpeed, "Determines the animation speed for the foreground of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBarWidth, "Determines the width of the effect for the foreground of the spectrograph. For rainbow profiles, the maximum represents the entire keyboard's width.");
            hintsToolTip.SetToolTip(this.SpectroBgBrightnessUD, "Change the brightness of background of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBgEffectCB, "Select the effect for the background of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBgSpeed, "Determines the animation speed for the background of the spectrograph.");
            hintsToolTip.SetToolTip(this.SpectroBgWidth, "Determines the width of the effect for the background of the spectrograph. For rainbow profiles, the maximum represents the entire keyboard's width.");
            hintsToolTip.SetToolTip(this.SpectroColorBars, "Select the colour of the foreground of the spectrograph when using Solid Colour.");
            hintsToolTip.SetToolTip(this.SpectroColorBg, "Select the colour of the background of the spectrograph when using Solid Colour.");
            hintsToolTip.SetToolTip(this.SpectroRefreshDelayLabel, "Time between updates.");
            hintsToolTip.SetToolTip(this.SpectroRefreshDelayUD, "Time between updates.");
            hintsToolTip.SetToolTip(this.SpectroShowGraphicsCheck, "What have you done!? You shouldn't be seeing this!");
            hintsToolTip.SetToolTip(this.SpectroWasapiDevicesCB, "Select your desired input device.");
            hintsToolTip.SetToolTip(this.SpectroWasapiLoopbackRadio, "Listen to the audio being output by your computer's default sound device. NOTE: This may not work on AMD HDMI Audio lines.");
            hintsToolTip.SetToolTip(this.SpectroWasapiRadio, "Listen to the audio being input to your computer over devices such as a microphone or line-in.");
            hintsToolTip.SetToolTip(this.StartSpectrographButton, "Starts the Spectrograph.");
            hintsToolTip.SetToolTip(this.StaticCapsColourButton, "Click to select a colour for Caps Lock.");
            hintsToolTip.SetToolTip(this.StaticClearButton, "Clear the copied colour.");
            hintsToolTip.SetToolTip(this.StaticCopyButton, "Copy a key's colour.");
            hintsToolTip.SetToolTip(this.StaticCopyPasteColor, "Click to define the colour that will be pasted.");
            hintsToolTip.SetToolTip(this.StaticDeleteKeysButton, "DEBUG: Delete all keys from the static page.");
            hintsToolTip.SetToolTip(this.StaticGetKeyboardImage, "DEBUG: Load the image of the selected keyboard.");
            hintsToolTip.SetToolTip(this.StaticLoadProfileButton, "Load a saved profile.");
            hintsToolTip.SetToolTip(this.StaticMouseLight1, "Click to define Mouse Light 1.");
            hintsToolTip.SetToolTip(this.StaticMouseLight2, "Click to define Mouse Light 2.");
            hintsToolTip.SetToolTip(this.StaticMouseLight3, "Click to define Mouse Light 3.");
            hintsToolTip.SetToolTip(this.StaticMouseLight4, "Click to define Mouse Light 4. (Saber Only)");
            hintsToolTip.SetToolTip(this.StaticMutedColourButton, "Click to select a colour for the mute button.");
            hintsToolTip.SetToolTip(this.StaticNewProfileButton, "Clear the current profile.");
            hintsToolTip.SetToolTip(this.StaticNumColourButton, "Click to select a colour for Num Lock.");
            hintsToolTip.SetToolTip(this.StaticPasteButton, "Paste the copied colour.");
            hintsToolTip.SetToolTip(this.StaticProfileListCB, "Profiles stored in the Profiles folder.");
            hintsToolTip.SetToolTip(this.StaticSaveProfileAsButton, "Save the current profile as a new profile.");
            hintsToolTip.SetToolTip(this.StaticSaveProfileButton, "Save the current profile over the selected profile.");
            hintsToolTip.SetToolTip(this.StaticScrollColourButton, "Click to select a colour for Scroll Lock.");
            hintsToolTip.SetToolTip(this.StaticUpdateKeyboardButton, "DEBUG: Outputs current display to the keyboard.");
            hintsToolTip.SetToolTip(this.StopSpectrographButton, "Stops all effects.");

            #endregion Tooltips

            #region Post-Load Tasks
            // Automatically minimize
            if (Properties.Settings.Default.settingStartMinimized == true) { this.WindowState = FormWindowState.Minimized; };

            // Load static key map
            for (int i = 0; i < Program.StaticKeyColors.Length; i++)
            { Program.StaticKeyColors[i] = Color.Transparent; };
            for (int i = 0; i < Program.StaticKeyColorsBytes.Length; i++)
            { 
                Program.StaticKeyColorsBytes[i] = new StaticColorCollection();
                Program.StaticKeyColorsBytes[i].Set(Color.Transparent); 
            };

            StaticGetKeyboardImage_Click(null, null);
            Program.StaticKeysNeedRedraw = false;

            // Initialize Mouse key colors
            for (int i = 0; i < 4; i++)
            { Program.MouseColors[i] = new MouseColorCollection(); }

            // Start up automatic tasks if the selected keyboard is valid
            if (SettingsKeyboardLayoutCB.Text != "" && SettingsKeyboardModelCB.Text != "")
            {
                // Automatically start spectro
                if (Properties.Settings.Default.settingSpectroOnStart == true) { StartSpectrograph_Click(null, null); };

                // Automatically start effects
                if (Properties.Settings.Default.settingEffectsOnStart == true) { EffectsStartButton_Click(null, null); };

                // Automatically apply static keys
                if (Properties.Settings.Default.settingStaticOnStart == true && Program.SettingsLastUsedProfile != "")
                {
                    Color[] keyData = new Color[144];
                    KeyColors keyColors = new KeyColors();
                    XmlProfileIO xmlProfileIO = new XmlProfileIO();

                    keyColors = xmlProfileIO.LoadProfile(Program.SettingsLastUsedProfile);
                    if (keyColors.Success == true)
                    {
                        for (int i = 0; i < 144; i++)
                        {
                            Program.StaticKeyColors[i] = keyColors.Colors[i];
                        }
                        for (int i = 144; i < 148; i++)
                        {
                            Program.MouseColors[i].Set(keyColors.Colors[i]);
                        }
                            RefreshKeyColors();
                    }
                };
            }

            // Show hidden developer controls if in dev mode
            if (Program.DevMode == true)
            {
                StaticGetKeyboardImage.Visible = true;
                StaticDeleteKeysButton.Visible = true;
                StaticUpdateKeyboardButton.Visible = true;
                SpectroShowGraphicsCheck.Visible = true;
                GraphicsPictureBox.Visible = true;
            }
            else
            {
                SpectroShowGraphicsCheck.Checked = false;
                Program.SpectroShowGraphics = false;
            }
            
            // Show Settings tab if there's no layout selected
            if (SettingsKeyboardLayoutCB.SelectedIndex < 0)
            {
                MainTabControl.SelectTab(3);
            };

            // Start up mute watching timer
            //MuteCheckTimer.Start();

            #endregion Post Load Tasks

            // Get rid of the Rainfall tab for now
            EffectTabControl.TabPages.Remove(EffectTab_Rainfall);

            // Done!
            UpdateStatusMessage.ShowStatusMessage(1, "Ready");
        }

        /// <summary>
        /// Loads keyboard's configuration from .XML.
        /// </summary>
        /// <param name="KeyboardID">ID of the keyboard to load configs for.</param>
        /// <returns>True for success, false for failure.</returns>
        public bool LoadFromConfig(string KeyboardID)
        {
            // Make sure the config files can be found
            if (File.Exists("corsair_devices\\" + KeyboardID + ".xml") == false)
            {
                UpdateStatusMessage.ShowStatusMessage(3, "Keyboard Layout Not Found");
                return false;
            }
            else
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Loading Keyboard Layouts");

                // Send all elements from the document to four parallel arrays
                var document = XDocument.Load("corsair_devices\\" + KeyboardID + ".xml");
                keyboardIDs = document.Descendants("id").Select(element => element.Value).ToArray();
                keyboardNames = document.Descendants("name").Select(element => element.Value).ToArray();
                keyboardPositionMaps = document.Descendants("positionmap").Select(element => element.Value).ToArray();
                keyboardSizeMaps = document.Descendants("sizemap").Select(element => element.Value).ToArray();

                // If in DevMode, always use the K95 and M65
                if (Program.DevMode == true)
                {
                    Program.SettingsKeyboardID = 0x1B11;
                    Program.SettingsMouseID = 0x1B12;
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

                // Populate the layouts ComboBox
                SettingsKeyboardLayoutCB.Items.Clear();
                for (int i = 0; i < keyboardNames.Length; i++)
                {
                    SettingsKeyboardLayoutCB.Items.Add(keyboardNames[i]);
                }

                return true;
            }
        }

        /// <summary>
        /// Finds all profiles stored in the Profiles folder and stores their paths in an array.
        /// </summary>
        /// <returns>A string[] containing paths to all of the XML files in /Profiles.</returns>
        public string[] LoadStaticProfileList()
        {
            string path = Program.StaticProfilesPath;
            string[] filePaths = Directory.GetFiles(@path, "*.xml");

            string[] files = new string[filePaths.Length];

            for (int i = 0; i < filePaths.Length; i++)
            {
                files[i] = Path.GetFileName(filePaths[i]);
            }
            
            return files;
        }

        /// <summary>
        /// Check colour and determine if overlaying text should be black or white.
        /// </summary>
        /// <param name="colour">Source colour to find a contrast for.</param>
        /// <returns>A Colour suitable as contrast.</returns>
        Color ContrastColor(Color colour)
        {
            int d = 0;

            // Check luminance with green bias
            double a = 1 - (0.299 * colour.R + 0.587 * colour.G + 0.114 * colour.B) / 255;

            if (a < 0.5)
                d = 0; // Bright colours, dark text
            else
                d = 255; // Dark colours, light text

            return Color.FromArgb(d, d, d);
        }

        /// <summary>
        /// Gets the version info XML file from the version server.
        /// </summary>
        private void CheckForUpdates()
        {
            bool updateIsAvailable = false;
            
            String URLString = "http://emily-maxwell.com/pages/keyboardspectro/version.xml";
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
                updateIsAvailable = true;
            }
            catch
            {
                updateIsAvailable = false;
            }

            // If there's a new build available, print a message in the log
            if (updateIsAvailable == true)
            {
                if (Program.VersionCheckData[0] != Program.VersionNumber)
                {
                    UpdateStatusMessage.ShowStatusMessage(9, "Latest Version: " + Program.VersionCheckData[0]);
                }
            }
        }
        
        #endregion Form Stuff

        #region Effects Start/Stop

        /// <summary>
        /// Sets mouse ID to match the selected mouse.
        /// </summary>
        private void SetMouseSettings()
        {
            switch (SettingsMouseModelCB.Text)
            {
                case "M65 RGB":
                    Program.SettingsMouseID = 0x1B12;
                    Program.SettingsMouseModel = "M65 RGB";
                    break;
                case "Sabre 1":
                    Program.SettingsMouseID = 0x1B14;
                    Program.SettingsMouseModel = "Sabre 1";
                    break;
                case "Sabre 2":
                    Program.SettingsMouseID = 0x1B19;
                    Program.SettingsMouseModel = "Sabre 2";
                    break;
                case "None":
                    Program.SettingsMouseID = 0x0;
                    Program.SettingsMouseModel = "None";
                    break;
            }
        }

        /// <summary>
        /// Starts rendering effects.
        /// </summary>
        /// <param name="Effect">Which effects to launch.</param>
        /// <param name="isIdleLaunch">Is the effect being launched by the idle timer?</param>
        /// <returns>True for success, false for failure.</returns>
        private bool StartEffects(string Effect, bool isIdleLaunch = false)
        {
            // If this is an idle launch, remember the ongoing effect so it can be resumed later
            if (!isIdleLaunch) { Program.InactivityResumeAction = Effect; };

            // If the mouse is to be included, set it up
            Program.IncludeMouseInEffects = SettingsEffectsIncludeMouse.Checked;
            SetMouseSettings();

            // Check if CUE is still running
            Process[] pname = Process.GetProcessesByName("CorsairHID");
            if (pname.Length != 0) UpdateStatusMessage.ShowStatusMessage(3, "Corsair Utility Engine is still running!");

            // Launch effects
            switch (Effect)
            {
                case "Spectro":
                    return StartSpectrograph(2);
                case "Effect-RandomLights":
                    if (Program.RunKeyboardThread == 3) { return false; };
                    if (LoadSizePositionMaps() == false) { return false; };

                    Program.EfSettings.Set((int)Effect_Float_DurationUD.Value, (int)Effect_Float_FrequencyUD.Value, 0);
                    Program.AnimationsUseStaticKeys = AnimationsUseStaticLights.Checked;

                    Program.RunKeyboardThread = 3;
                    workerThread = new Thread(() => Effect_RandomLights.KeyboardControl());
                    workerThread.Start();
                    return true;
                case "Reactive-SingleLight":
                    if (Program.RunKeyboardThread == 10) { return false; };
                    if (LoadSizePositionMaps() == false) { return false; };

                    Program.ReactSettings.Set((int)Reactive_DurationUD.Value, (int)Reactive_FrequencyUD.Value, 0);

                    Program.RunKeyboardThread = 10;
                    ReactiveThread = new Reactive_SingleLight();
                    workerThread = new Thread(() => ReactiveThread.KeyboardControl());
                    workerThread.Start();
                    return true;
                case "Reactive-Heatmap":
                    if (Program.RunKeyboardThread == 11) { return false; };
                    if (LoadSizePositionMaps() == false) { return false; };

                    Heatmap_UpdateColorConfig();

                    Program.RunKeyboardThread = 11;
                    HeatmapThread = new Reactive_Heatmap();
                    workerThread = new Thread(() => HeatmapThread.KeyboardControl());
                    workerThread.Start();
                    return true;
                default:
                    // An inexistant effect was requested
                    return false;
            }
        }

        /// <summary>
        /// Sets up and starts the Spectro.
        /// </summary>
        /// <param name="RunType"></param>
        /// <returns>True for success, false for failure.</returns>
        private bool StartSpectrograph(int RunType = 0)
        {
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
            Program.SettingsRestoreLightingOnExit = SettingsRestoreLightingCheck.Checked;

            // Get audio device info
            if (SpectroWasapiLoopbackRadio.Checked == true) { Program.CSCore_DeviceType = 0; };
            if (SpectroWasapiRadio.Checked == true) { Program.CSCore_DeviceType = 1; };

            // Load keyboard size and position maps
            if (LoadSizePositionMaps() == false) { return false; };

            int captureType;
            MMDevice captureDevice;

            if (RunType == 1) // Test Mode
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

            // Set Program-wide current keyboard model and layout
            Program.SettingsKeyboardModel = SettingsKeyboardModelCB.Text;
            Program.SettingsKeyboardLayout = SettingsKeyboardLayoutCB.Text;
            Program.RunKeyboardThread = RunType;
            return true;
        }

        /// <summary>
        /// Stops effects.
        /// </summary>
        private void StopEffects()
        {
            // Set thread state to 0; this should cause any ongoing effect threads to terminate themselves
            Program.RunKeyboardThread = 0;
            DebugTestModeButton.Enabled = true;

            //MuteCheckTimer.Start();
        }

        /// <summary>
        /// Stops effects. This overload is for controls to call.
        /// </summary>
        private void StopEffects(object sender, EventArgs e)
        {
            StopEffects();
        }

        /// <summary>
        /// Loads the size and position maps for the selected keyboard and layout.
        /// </summary>
        /// <returns>True for success, false for failure.</returns>
        private bool LoadSizePositionMaps()
        {
            // Break if there's no keyboard layout selected
            if (SettingsKeyboardLayoutCB.SelectedIndex < 0)
            {
                MessageBox.Show("There is no layout selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatusMessage.ShowStatusMessage(3, "No layout selected.");
                return false;
            };

            // Load position and size maps
            string positionMaps = keyboardPositionMaps[SettingsKeyboardLayoutCB.SelectedIndex];
            string sizeMaps = keyboardSizeMaps[SettingsKeyboardLayoutCB.SelectedIndex];

            // Replace the '.' decimals by whatever the system decimal separator may be, if it's not a period
            char DecimalSep = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (DecimalSep != '.')
            {
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
                        "\nPosition Map:\n[" + positionMaps + "]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            return true;
        }
        
        #endregion

        #region Thread Safe Delegate Functions

        /// <summary>
        /// Posts a status message to the log and to console.
        /// </summary>
        /// <param name="messageType">Message level</param>
        /// <param name="messageText">Message text</param>
        public void UpdateStatusMessage_NewMsg(int messageType, string messageText)
        {
            string messagePrefix;
            System.ConsoleColor messageColour;
            Color logColour;
            
            // Determine the colour and prefix for the supplied messageType
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
                case 9:
                    messagePrefix = "Update: ";
                    messageColour = ConsoleColor.White;
                    logColour = Color.FromArgb(255, 255, 255);
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

            // If the log level is high enough to show the message, show it
            if (messageType <= Program.LogLevel)
            {
                Console.ForegroundColor = messageColour;
                Console.WriteLine(messagePrefix + messageText);
                Console.ResetColor();

                StatusLabel.Text = messageText;
                this.Invoke((MethodInvoker)(() => DebugStatusLog.AppendText(messagePrefix + messageText + Environment.NewLine, logColour)));
            }

            // If the message is concerning an available update, enable the update button
            if (messageType == 9)
            {
                Console.ForegroundColor = messageColour;
                Console.WriteLine(messagePrefix + messageText);
                Console.ResetColor();

                StatusLabel.Text = "An update is available!";
                this.Invoke((MethodInvoker)(() => DebugStatusLog.AppendText(messagePrefix + messageText + Environment.NewLine, logColour)));
                MethodInvoker action = () => SettingsGetUpdateButton.Visible = true; 
                SettingsGetUpdateButton.Invoke(action);
            }
            if (messageType == 10)
            {
                StatusLabel.Text = messageText;
            }
        }

        /// <summary>
        /// Updates the graphical representation of the keyboard's lights. No longer used. Kept here for reference for customized canvas building.
        /// </summary>
        /// <param name="render"></param>
        public void UpdateGraphicOutput_NewOut(Bitmap render)
        {
            this.Invoke((MethodInvoker)(() => GraphicsPictureBox.Image = Program.SpectroGraphicRender));
        }

        /// <summary>
        /// Idle timer's thread-safe reactions.
        /// </summary>
        /// <param name="idleMode">1: Going from active to idle.
        /// 2: Going from idle to active.</param>
        public void InactivityStatusChanged_Action(int idleMode)
        {
            if (SettingsIdleSwitcher.Enabled == false)
            { 
                this.Invoke((MethodInvoker)(() => SettingsIdleSwitcher.Enabled = true)); 
            };

            if (idleMode > 0)
            {
                string modeText = "";
                string profileText = "";
                if (idleMode == 1) 
                { 
                    this.Invoke((MethodInvoker)delegate()
                    { 
                        modeText = SettingsIdleModeCB.Text;
                        profileText = Program.StaticProfilesPath + SettingsIdleProfileCB.Text;
                    }
                    ); 
                }
                else if (idleMode == 2)
                { 
                    modeText = Program.InactivityResumeAction;
                    profileText = Program.SettingsLastUsedProfile;
                }

                if (workerThread != null)
                {
                    Program.RunKeyboardThread = 0;
                    while (workerThread.IsAlive)
                    {
                        Application.DoEvents();
                        Thread.Sleep(100);
                    }
                };

                switch (modeText)
                {
                    case "Spectro":
                        this.Invoke((MethodInvoker)delegate() { StartEffects("Spectro", true); });
                        break;
                    case "Random Lights": case "Effect-RandomLights":
                        this.Invoke((MethodInvoker)delegate() { StartEffects("Effect-RandomLights", true); });
                        break;
                    case "Static Profile":
                        Program.IgnoreUpdateLastProfile = true;

                        XmlProfileIO xmlProfileIO = new XmlProfileIO();
                        KeyColors keyColors = new KeyColors();

                        keyColors = xmlProfileIO.LoadProfile(profileText);
                
                        if (keyColors.Success == true)
                        {
                            for (int i = 0; i < 144; i++)
                            {
                                Program.StaticKeyColors[i] = keyColors.Colors[i];
                            }
                            this.Invoke((MethodInvoker)(() => RefreshKeyColors()));
                            StaticUnsavedChanges = false;
                        }
                        break;
                    case "Reactive-SingleLight":
                        this.Invoke((MethodInvoker)delegate() { StartEffects("Reactive-SingleLight", true); });
                        break;
                    case "Reactive-Heatmap":
                        this.Invoke((MethodInvoker)delegate() { StartEffects("Reactive-Heatmap", true); });
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Sections

        #region Tab: Spectro

        #region [Spectro] Buttons

        /// <summary>
        /// Starts the Spectrograph effect.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>Need to remove graphical output portions.</remarks>
        private void StartSpectrograph_Click(object sender, EventArgs e)
        {
            RightClickMenu.Hide();
            if (Program.RunKeyboardThread == -2) { Program.RunKeyboardThread = 0; };
            if (Program.RunKeyboardThread == 2) { return; };
            if (StartEffects("Spectro") == true)
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
                StatusTimer.Start();
                DebugTestModeButton.Enabled = false;
            }
        }

        #endregion [Spectro] Buttons

        #region [Spectro] ListBoxes
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

        #endregion [Spectro] ListBoxes

        #region [Spectro] UpDowns
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

        #endregion [Spectro] UpDowns

        #region [Spectro] CheckBoxes
        private void SpectroShowGraphicsCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.SpectroShowGraphics = SpectroShowGraphicsCheck.Checked;

            if (SpectroShowGraphicsCheck.Checked == true)
                GraphicsPictureBox.Visible = true;
            else
                GraphicsPictureBox.Visible = false;
        }

        #endregion [Spectro] CheckBoxes
        
        #region [Spectro] CSCore
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

        #endregion [Spectro] CSCore

        #endregion Tab: Spectro

        #region Tab: Effects

        private void EffectsStartButton_Click(object sender, EventArgs e)
        {
            if (EffectTabControl.SelectedTab == EffectTabControl.TabPages["EffectTab_RandomLights"])
            {
                StartEffects("Effect-RandomLights");
            } 
            else if (EffectTabControl.SelectedTab == EffectTabControl.TabPages["EffectTab_Rainfall"])
            {
                StartEffects("Effect-Rainfall");
            }
        }

        private void AnimationsUseStaticLights_CheckedChanged(object sender, EventArgs e)
        {
            Program.AnimationsUseStaticKeys = AnimationsUseStaticLights.Checked;
            tsmShowStatic.Checked = AnimationsUseStaticLights.Checked;
        }
        private void tsmShowStatic_Click(object sender, EventArgs e)
        {
            tsmShowStatic.Checked = !tsmShowStatic.Checked;
            Program.AnimationsUseStaticKeys = tsmShowStatic.Checked;
            AnimationsUseStaticLights.Checked = tsmShowStatic.Checked;
        }

        private void EffectTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EffectTabControl.SelectedIndex == 2)
            {
                Effect_Float_StartGB.Visible = false;
                Effect_Float_EndGB.Visible = false;
            }
            else
            {
                Effect_Float_StartGB.Visible = true;
                Effect_Float_EndGB.Visible = true;
            }
        }

        #region Tab: Effects: Random Lights
        private void Effects_RandomLights_UpdateColorConfig(int mode)
        {
            switch (mode) { 
                case 1:
                    Program.EfColors.SetStart(
                        (byte)Effect_Float_Start_ColourButton.BackColor.R,
                        (byte)Effect_Float_Start_ColourButton.BackColor.G,
                        (byte)Effect_Float_Start_ColourButton.BackColor.B,
                        Effects_RandomLights_End_GetMode());
                    break;
                case 2:
                    Program.EfColors.SetStart(
                        (int)Effect_Float_Start_Red_LowUD.Value,
                        (int)Effect_Float_Start_Red_HighUD.Value,
                        (int)Effect_Float_Start_Green_LowUD.Value,
                        (int)Effect_Float_Start_Green_HighUD.Value,
                        (int)Effect_Float_Start_Blue_LowUD.Value,
                        (int)Effect_Float_Start_Blue_HighUD.Value,
                        Effects_RandomLights_End_GetMode());
                    break;
                case 3:
                    Program.EfColors.SetEnd(
                        (int)Effect_Float_End_Red_LowUD.Value,
                        (int)Effect_Float_End_Red_HighUD.Value,
                        (int)Effect_Float_End_Green_LowUD.Value,
                        (int)Effect_Float_End_Green_HighUD.Value,
                        (int)Effect_Float_End_Blue_LowUD.Value,
                        (int)Effect_Float_End_Blue_HighUD.Value,
                        Effects_RandomLights_End_GetMode());
                    break;
                case 4:
                    Program.EfColors.SetEnd(
                        (byte)Effect_Float_End_ColourButton.BackColor.R,
                        (byte)Effect_Float_End_ColourButton.BackColor.G,
                        (byte)Effect_Float_End_ColourButton.BackColor.B,
                        Effects_RandomLights_End_GetMode());
                    break;
        }
        }

        private void Effect_RandomLights_Start_UpdateColorBoxes(object sender, EventArgs e)
        {
            Effect_Float_Start_Red_LowButton.BackColor = Color.FromArgb(255, (int)Effect_Float_Start_Red_LowUD.Value, 0, 0);
            Effect_Float_Start_Red_HighButton.BackColor = Color.FromArgb(255, (int)Effect_Float_Start_Red_HighUD.Value, 0, 0);

            Effect_Float_Start_Green_LowButton.BackColor = Color.FromArgb(255, 0, (int)Effect_Float_Start_Green_LowUD.Value, 0);
            Effect_Float_Start_Green_HighButton.BackColor = Color.FromArgb(255, 0, (int)Effect_Float_Start_Green_HighUD.Value, 0);

            Effect_Float_Start_Blue_LowButton.BackColor = Color.FromArgb(255, 0, 0, (int)Effect_Float_Start_Blue_LowUD.Value);
            Effect_Float_Start_Blue_HighButton.BackColor = Color.FromArgb(255, 0, 0, (int)Effect_Float_Start_Blue_HighUD.Value);

            Effect_Float_Start_Red_LowUD.Maximum = Effect_Float_Start_Red_HighUD.Value;
            Effect_Float_Start_Green_LowUD.Maximum = Effect_Float_Start_Green_HighUD.Value;
            Effect_Float_Start_Blue_LowUD.Maximum = Effect_Float_Start_Blue_HighUD.Value;

            Effects_RandomLights_UpdateColorConfig(2);
        }

        private void Effect_RandomLights_End_UpdateColorBoxes(object sender, EventArgs e)
        {
            Effect_Float_End_Red_LowButton.BackColor = Color.FromArgb(255, (int)Effect_Float_End_Red_LowUD.Value, 0, 0);
            Effect_Float_End_Red_HighButton.BackColor = Color.FromArgb(255, (int)Effect_Float_End_Red_HighUD.Value, 0, 0);

            Effect_Float_End_Green_LowButton.BackColor = Color.FromArgb(255, 0, (int)Effect_Float_End_Green_LowUD.Value, 0);
            Effect_Float_End_Green_HighButton.BackColor = Color.FromArgb(255, 0, (int)Effect_Float_End_Green_HighUD.Value, 0);

            Effect_Float_End_Blue_LowButton.BackColor = Color.FromArgb(255, 0, 0, (int)Effect_Float_End_Blue_LowUD.Value);
            Effect_Float_End_Blue_HighButton.BackColor = Color.FromArgb(255, 0, 0, (int)Effect_Float_End_Blue_HighUD.Value);

            Effect_Float_End_Red_LowUD.Maximum = Effect_Float_End_Red_HighUD.Value;
            Effect_Float_End_Green_LowUD.Maximum = Effect_Float_End_Green_HighUD.Value;
            Effect_Float_End_Blue_LowUD.Maximum = Effect_Float_Start_Blue_HighUD.Value;

            Effects_RandomLights_UpdateColorConfig(3);
        }

        private int Effects_RandomLights_End_GetMode()
        {
            /* Modes
             * 1: Defined + Defined
             * 2: Random + Defined
             * 3: Defined + Random
             * 4: Random + Random
             */
            int newMode = 0;

            if (Effect_Float_Start_RadioDefined.Checked && Effect_Float_End_RadioDefined.Checked)
            {
                newMode = 1;
            }
            else if (Effect_Float_Start_RadioRandom.Checked && Effect_Float_End_RadioDefined.Checked)
            {
                newMode = 2;
            }
            else if (Effect_Float_Start_RadioDefined.Checked && Effect_Float_End_RadioRandom.Checked)
            {
                newMode = 3;
            }
            else if (Effect_Float_Start_RadioRandom.Checked && Effect_Float_End_RadioRandom.Checked)
            {
                newMode = 4;
            }

            return newMode;
        }

        private void Effects_RandomLights_ColourButton_Click(object sender, EventArgs e)
        {
            OpenColorPicker(sender);

            if (((Button)sender).Name.ToString() == "Effect_Float_Start_ColourButton")
            { Effects_RandomLights_UpdateColorConfig(1); }

            if (((Button)sender).Name.ToString() == "Effect_Float_End_ColourButton")
            { Effects_RandomLights_UpdateColorConfig(4); }
        }

        private void Effects_RandomLights_Start_RadioCheckedChanged(object sender, EventArgs e)
        {
            if (Effect_Float_Start_RadioDefined.Checked == true)
            { Effects_RandomLights_UpdateColorConfig(1); }

            else if (Effect_Float_Start_RadioRandom.Checked == true)
            { Effects_RandomLights_UpdateColorConfig(2); }
        }

        private void Effects_RandomLights_End_RadioCheckedChanged(object sender, EventArgs e)
        {
            if (Effect_Float_End_RadioDefined.Checked == true)
            { Effects_RandomLights_UpdateColorConfig(4); }

            else if (Effect_Float_End_RadioRandom.Checked == true)
            { Effects_RandomLights_UpdateColorConfig(3); }
        }

        private void Effects_RandomLights_DurationUD_ValueChanged(object sender, EventArgs e)
        {
            Program.EfSettings.Duration = (int)Effect_Float_DurationUD.Value;
        }

        private void Effects_RandomLights_FrequencyUD_ValueChanged(object sender, EventArgs e)
        {
            Program.EfSettings.Frequency = (int)Effect_Float_FrequencyUD.Value;
        }

        #endregion Tab: Effects: Random Lights

        #endregion Tab: Effects

        #region Tab: Static Keys

        #region [Static Keys] Functions
        public void DrawKeysOnImage(KeyData[] keyData)
        {
            double ImageScale = keyboardImageScale;
            int offsetX = 1;
            int offsetY = 0;

            Button[] keyboardButtons = new Button[keyData.Length];

            for (int i = 0; i < keyData.Length; i++)
            {
                keyboardButtons[i] = new Button();
                keyboardButtons[i].Location = new Point((int)(keyData[i].Coords[0].X * ImageScale + offsetX),
                                                        (int)(keyData[i].Coords[0].Y * ImageScale + offsetY));
                keyboardButtons[i].Size = new Size((int)(keyData[i].Coords[1].X * ImageScale) - (int)(keyData[i].Coords[0].X * ImageScale),
                                                    (int)(keyData[i].Coords[2].Y * ImageScale) - (int)(keyData[i].Coords[0].Y * ImageScale));
                keyboardButtons[i].Text = "";
                keyboardButtons[i].FlatStyle = FlatStyle.Flat;
                keyboardButtons[i].FlatAppearance.BorderColor = Color.White;
                keyboardButtons[i].FlatAppearance.BorderSize = 0;
                keyboardButtons[i].Parent = StaticKeyboardImageBox;
                keyboardButtons[i].BackColor = Color.Transparent;
                keyboardButtons[i].Tag = keyData[i].KeyID;
                keyboardButtons[i].Name = "keyboardButtons" + i;
                StaticKeyboardImageBox.Controls.Add(keyboardButtons[i]);
                keyboardButtons[i].Click += KeyboardButton_Click;
            }

            StaticKeyboardImageBox.SendToBack();
        }

        public void RemoveKeysFromImage()
        {
            Control[] searchButton;
            for (int i = 0; i < 144; i++)
            {
                searchButton = StaticKeyboardImageBox.Controls.Find("keyboardButtons" + i, true);

                if (searchButton.Count() > 0)
                {
                    if (StaticKeyboardImageBox.Controls.Contains(searchButton[0]))
                    {
                        searchButton[0].Click -= KeyboardButton_Click;
                        StaticKeyboardImageBox.Controls.Remove(searchButton[0]);
                        searchButton[0].Dispose();
                    }
                }
            }
        }

        private void RefreshKeyColors(bool SuppressMessages = false)
        {
            foreach (Control c in StaticKeyboardImageBox.Controls)
            {
                if ((int)c.Tag >= 0) { c.BackColor = Program.StaticKeyColors[(int)c.Tag]; };
            }

            StaticMouseLight1.BackColor = Program.MouseColors[0].KeyColor;
            StaticMouseLight2.BackColor = Program.MouseColors[1].KeyColor;
            StaticMouseLight3.BackColor = Program.MouseColors[2].KeyColor;
            StaticMouseLight4.BackColor = Program.MouseColors[3].KeyColor;

            for (int i = 0; i < 144; i++)
            {
                Program.StaticKeyColorsBytes[i] = new StaticColorCollection();
                Program.StaticKeyColorsBytes[i].SetD(Program.StaticKeyColors[i]);
            }
            SendStaticKeysToKeyboard(false, true);
            SendColorsToMouse();
        }
        
        public void SendStaticKeysToKeyboard(bool UseLastProfile, bool SuppressMessages = false)
        {
            if (LoadSizePositionMaps() == false) { return; };

            // Reactive Keys will handle the refresh if it's running
            if (Program.RunKeyboardThread == 10)
            {
                ReactiveThread.InitiateReactiveBackground();
            }
            else // Otherwise, refresh manually
            {
                KeyboardWriter keyWriter = new KeyboardWriter(SuppressMessages: SuppressMessages);
                try
                {
                    keyWriter.Write(Program.StaticKeyColorsBytes, true);
                }
                catch
                {
                    UpdateStatusMessage.ShowStatusMessage(3, "Send Keys Failed");
                }
            }
        }

        private void SendColorsToMouse()
        {
            MouseWriter mouseWriter = new MouseWriter();
            try
            {
                mouseWriter.Write(Program.MouseColors, true);
            }
            catch
            {
                UpdateStatusMessage.ShowStatusMessage(3, "Send Mouse Colors Failed");
            }
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

        public static Image ScaleImage(Image image, double scaleRatio)
        {
            var newWidth = (int)(image.Width * scaleRatio);
            var newHeight = (int)(image.Height * scaleRatio);

            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }

        public void StaticKeysLoadProfileList()
        {
            string[] fileList = LoadStaticProfileList();
            ToolStripMenuItem[] tsmProfileList = new ToolStripMenuItem[fileList.Length];

            StaticProfileListCB.Items.Clear();
            StaticProfileListCB.Items.Add("From External File...");

            for (int f = 0; f < fileList.Length; f++)
            { 
                StaticProfileListCB.Items.Add(fileList[f]);

                tsmProfileList[f] = new ToolStripMenuItem();
                tsmProfileList[f].Name = "tsmProfile" + f.ToString();
                tsmProfileList[f].Text = fileList[f];
                tsmProfileList[f].Click += new System.EventHandler(tsmProfileList_Click);
            }

            this.tsmSwitchStaticProfile.DropDownItems.Clear();
            this.tsmSwitchStaticProfile.DropDownItems.AddRange(tsmProfileList);
        }

        #endregion [Static Keys] Functions

        #region [Static Keys] Buttons

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
                default:
                    return;
            }
            string imagePath = Directory.GetCurrentDirectory() + "\\corsair_devices\\" +
                                      keyboardDirectoryName + "\\image\\" + keyboardIDs[SettingsKeyboardLayoutCB.SelectedIndex] +
                                      ".jpg";

            keyboardImage = Image.FromFile(imagePath);
            keyboardImage = ScaleImage(keyboardImage, keyboardImageScale);
            StaticKeyboardImageBox.Image = keyboardImage;
            
            XmlToKeyMap xmlToKeyMap = new XmlToKeyMap();
            KeyData[] keyData = xmlToKeyMap.LoadKeyLocations(SettingsKeyboardModelCB.Text, keyboardIDs[SettingsKeyboardLayoutCB.SelectedIndex]);
            RemoveKeysFromImage();
            DrawKeysOnImage(keyData);
        }
        
        public void KeyboardButton_Click(object sender, EventArgs e)
        {
            if (StaticCopyPasteMode == 0) // Open the color picker
            {
                // ColorPicker based on http://www.codeproject.com/Articles/131708/WPF-Color-Picker-Construction-Kit
                int buttonID = (int)((Button)sender).Tag;

                System.Windows.Media.Color selectedMediaColor;
                Color selectedColor = ((Button)sender).BackColor;
                ColorPickerStandardDialog dia = new ColorPickerStandardDialog();
                dia.InitialColor = System.Windows.Media.Color.FromRgb(((Button)sender).BackColor.R, ((Button)sender).BackColor.G, ((Button)sender).BackColor.B);
                if (dia.ShowDialog() == true)
                {
                    selectedMediaColor = dia.SelectedColor; //do something with the selected color
                    selectedColor = Color.FromArgb(127, selectedMediaColor.R, selectedMediaColor.G, selectedMediaColor.B);
                }
                Program.StaticKeyColors[(int)(((Button)sender).Tag)] = selectedColor;
                RefreshKeyColors();
            }
            else if (StaticCopyPasteMode == 1) // Copy color
            {
                StaticCopyPasteColor.BackColor = Color.FromArgb(255, ((Button)sender).BackColor.R, ((Button)sender).BackColor.G, ((Button)sender).BackColor.B);
                StaticCopyPasteMode = 0;
                StaticCopyButton.FlatAppearance.BorderColor = Color.Black;
            }
            else if (StaticCopyPasteMode == 2) // Paste color
            {
                
                Color copiedColor;
                if (StaticCopyPasteColor.BackColor == Color.Transparent)
                {
                    copiedColor = Color.Transparent;
                }
                else
                {
                    copiedColor = Color.FromArgb(127, StaticCopyPasteColor.BackColor.R, StaticCopyPasteColor.BackColor.G, StaticCopyPasteColor.BackColor.B);
                }

                ((Button)sender).BackColor = copiedColor;
                Program.StaticKeyColors[(int)(((Button)sender).Tag)] = copiedColor;
                RefreshKeyColors();
            }
            StaticUnsavedChanges = true;
        }
        
        private void StaticMouseColor_Click(object sender, EventArgs e)
        {
            if (StaticCopyPasteMode == 0) // Open the color picker
            {
                Color selectedColor = OpenColorPicker(sender);
                int buttonID = 1;

                string buttonName = ((Button)sender).Name;
                buttonName = buttonName.Substring(buttonName.Length - 1);

                Int32.TryParse(buttonName, out buttonID);

                Program.MouseColors[buttonID - 1].Set(selectedColor);
                RefreshKeyColors();
            }
            else if (StaticCopyPasteMode == 1) // Copy color
            {
                StaticCopyPasteColor.BackColor = Color.FromArgb(255, ((Button)sender).BackColor.R, ((Button)sender).BackColor.G, ((Button)sender).BackColor.B);
                StaticCopyPasteMode = 0;
                StaticCopyButton.FlatAppearance.BorderColor = Color.Black;
            }
            else if (StaticCopyPasteMode == 2) // Paste color
            {

                Color copiedColor;
                if (StaticCopyPasteColor.BackColor == Color.Transparent)
                {
                    copiedColor = Color.Transparent;
                }
                else
                {
                    copiedColor = Color.FromArgb(255, StaticCopyPasteColor.BackColor.R, StaticCopyPasteColor.BackColor.G, StaticCopyPasteColor.BackColor.B);
                }

                ((Button)sender).BackColor = copiedColor;
                int buttonID = 1;

                string buttonName = ((Button)sender).Name;
                buttonName = buttonName.Substring(buttonName.Length - 1);

                Int32.TryParse(buttonName, out buttonID);

                Program.MouseColors[buttonID - 1].Set(copiedColor);
                RefreshKeyColors();
            }
            StaticUnsavedChanges = true;
        }

        private void LoadProfileButton_Click(object sender, EventArgs e)
        {
            Color[] keyData = new Color[144];
            bool loadFromDialog = false;
            string fileToLoad = "";

            bool DirectLoad = false;
            if (sender is ToolStripMenuItem)
            {
                fileToLoad = Program.StaticProfilesPath + ((ToolStripMenuItem)sender).Text;
                loadFromDialog = true;
                DirectLoad = true;
            }

            if (!DirectLoad)
            {
                if (StaticProfileListCB.Text == "From External File...")
                {
                    OpenFileDialog ofd = new OpenFileDialog();

                    ofd.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                    ofd.FilterIndex = 1;
                    ofd.Multiselect = false;

                    DialogResult ofdResult = ofd.ShowDialog();

                    if (ofdResult == DialogResult.OK)
                    {
                        fileToLoad = ofd.FileName;
                        loadFromDialog = true;
                    };
                }
                else
                {
                    if (StaticUnsavedChanges == true)
                    {
                        if (MessageBox.Show("You have unsaved changes. Are you sure you wish to load a new profile?",
                            "Unsaved Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            fileToLoad = Program.StaticProfilesPath + StaticProfileListCB.Text;
                            if (File.Exists(fileToLoad)) { loadFromDialog = true; };
                        };
                    }
                    else
                    {
                        fileToLoad = Program.StaticProfilesPath + StaticProfileListCB.Text;
                        if (File.Exists(fileToLoad)) { loadFromDialog = true; };
                    }
                }
            }

            if (loadFromDialog)
            {
                XmlProfileIO xmlProfileIO = new XmlProfileIO();
                KeyColors keyColors = new KeyColors();

                keyColors = xmlProfileIO.LoadProfile(fileToLoad);

                Program.SettingsLastUsedProfile = fileToLoad;
                Program.InactivityResumeAction = "Static Profile";

                if (keyColors.Success == true)
                {
                    for (int i = 0; i < 144; i++)
                    {
                        Program.StaticKeyColors[i] = keyColors.Colors[i];
                    }
                    for (int i = 144; i < 148; i++)
                    {
                        Program.MouseColors[i -144].Set(keyColors.Colors[i]);
                    }
                        RefreshKeyColors();
                    StaticUnsavedChanges = false;
                }
            }
        }

        private void SaveProfileButton_Click(object sender, EventArgs e)
        {
            if (StaticProfileListCB.Text == "" || StaticProfileListCB.Text == "From External File...") { return; };
            XmlProfileIO xmlProfileIO = new XmlProfileIO();
            bool doSave = false;

            if (Path.GetFileName(Program.SettingsLastUsedProfile) != StaticProfileListCB.Text)
            {
                if (MessageBox.Show("Would you like to replace the profile " + StaticProfileListCB.Text + "?",
                        "Unsaved Changes", MessageBoxButtons.YesNo) == DialogResult.Yes)
                { doSave = true; }
            }
            else
            { doSave = true; }

            if (doSave)
            {
                xmlProfileIO.SaveProfile(SettingsKeyboardModelCB.Text, Program.StaticKeyColors, Program.MouseColors, Program.StaticProfilesPath + StaticProfileListCB.Text);
                Program.SettingsLastUsedProfile = Program.StaticProfilesPath + StaticProfileListCB.Text;
                StaticUnsavedChanges = false;
                StaticKeysLoadProfileList();
                StaticProfileListCB.Text = Path.GetFileName(Program.SettingsLastUsedProfile);
            }
        }

        private void StaticSaveProfileAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                XmlProfileIO xmlProfileIO = new XmlProfileIO();
                string xmlFile = sfd.FileName;
                xmlProfileIO.SaveProfile(SettingsKeyboardModelCB.Text, Program.StaticKeyColors, Program.MouseColors, xmlFile);
                Program.SettingsLastUsedProfile = sfd.FileName;
                StaticUnsavedChanges = false;
                StaticKeysLoadProfileList();
                StaticProfileListCB.Text = Path.GetFileName(Program.SettingsLastUsedProfile);
            }
        }

        private void NewProfileButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 144; i++)
            {
                Program.StaticKeyColors[i] = Color.Transparent;
            }
            for (int i = 0; i < 4; i++)
            {
                Program.MouseColors[i].Set(Color.Transparent);
            };
                RefreshKeyColors();
        }

        private void DeleteKeys_Click(object sender, EventArgs e)
        {
            RemoveKeysFromImage();
        }

        private void UpdateKeyboardButton_Click(object sender, EventArgs e)
        {
            SendStaticKeysToKeyboard(false);
        }

        private void StaticCopyButton_Click(object sender, EventArgs e)
        {
            if (StaticCopyPasteMode == 0 || StaticCopyPasteMode == 2)
            {
                StaticCopyPasteMode = 1;
                StaticCopyButton.FlatAppearance.BorderColor = Color.Green;
                StaticPasteButton.FlatAppearance.BorderColor = Color.Black;
            }
            else if (StaticCopyPasteMode == 1)
            {
                StaticCopyPasteMode = 0;
                StaticCopyButton.FlatAppearance.BorderColor = Color.Black;
            }
        }

        private void StaticPasteButton_Click(object sender, EventArgs e)
        {
            if (StaticCopyPasteMode == 0 || StaticCopyPasteMode == 1)
            {
                StaticCopyPasteMode = 2;
                StaticPasteButton.FlatAppearance.BorderColor = Color.Green;
                StaticCopyButton.FlatAppearance.BorderColor = Color.Black;
            }
            else if (StaticCopyPasteMode == 2)
            {
                StaticCopyPasteMode = 0;
                StaticPasteButton.FlatAppearance.BorderColor = Color.Black;
            }
        }

        private void StaticClearButton_Click(object sender, EventArgs e)
        {
            StaticCopyPasteMode = 0;
            StaticCopyButton.FlatAppearance.BorderColor = Color.Black;
            StaticPasteButton.FlatAppearance.BorderColor = Color.Black;
            StaticCopyPasteColor.BackColor = Color.Transparent;
        }

        #endregion [Static Keys] Buttons
        
        #endregion Tab: Static Keys

        #region Tab: Reactive

        #region Reactive - Reactive
        private void ReactiveColor_Click(object sender, EventArgs e)
        {
            System.Windows.Media.Color selectedMediaColor;
            Color selectedColor = ((Button)sender).BackColor;
            ColorPickerStandardDialog dia = new ColorPickerStandardDialog();
            dia.InitialColor = System.Windows.Media.Color.FromRgb(((Button)sender).BackColor.R, ((Button)sender).BackColor.G, ((Button)sender).BackColor.B);
            if (dia.ShowDialog() == true)
            {
                selectedMediaColor = dia.SelectedColor; //do something with the selected color
                selectedColor = Color.FromArgb(255, selectedMediaColor.R, selectedMediaColor.G, selectedMediaColor.B);
            }
            ((Button)sender).BackColor = selectedColor;
        }

        private void ReactiveStartButton_Click(object sender, EventArgs e)
        {
            Reactive_Start_RadioCheckedChanged(null, null);
            Reactive_End_RadioCheckedChanged(null, null);

            if (ReactiveTabControl.SelectedTab == ReactiveTabControl.TabPages["ReactiveTab_Reactive"])
            { StartEffects("Reactive-SingleLight"); }
            else if (ReactiveTabControl.SelectedTab == ReactiveTabControl.TabPages["ReactiveTab_Heatmap"])
            { StartEffects("Reactive-Heatmap"); }
        }

        private void ReactiveStartButton_LaunchFromRightClickMenu(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Name == "tsmReactive")
            { StartEffects("Reactive-SingleLight"); };

            if (((ToolStripMenuItem)sender).Name == "tsmHeatmap")
            { StartEffects("Reactive-Heatmap"); };
        }

        private void Reactive_DurationUD_ValueChanged(object sender, EventArgs e)
        {
            Program.ReactSettings.Duration = (int)Reactive_DurationUD.Value;
        }

        private void Reactive_FrequencyUD_ValueChanged(object sender, EventArgs e)
        {
            Program.ReactSettings.Frequency = (int)Reactive_FrequencyUD.Value;
        }

        private void Reactive_Start_RadioCheckedChanged(object sender, EventArgs e)
        {
            if (Reactive_Start_RadioDefined.Checked == true)
            { Program.ReactTypeStart = 0; }

            else if (Reactive_Start_RadioRainbow.Checked == true)
            { Program.ReactTypeStart = 1; }

            else if (Reactive_Start_RadioRandom.Checked == true)
            { Program.ReactTypeStart = 2; }
        }

        private void Reactive_End_RadioCheckedChanged(object sender, EventArgs e)
        {
            if (Reactive_End_RadioDefined.Checked == true)
            { Program.ReactTypeEnd = 0; }

            else if (Reactive_End_RadioOriginal.Checked == true)
            { Program.ReactTypeEnd = 1; }

            else if (Reactive_End_RadioRandom.Checked == true)
            { Program.ReactTypeEnd = 2; }
        }

        private void Reactive_ColourButton_ColourChange(object sender, EventArgs e)
        {
            OpenColorPicker(sender);
            Reactive_UpdateColorConfig();
        }

        private void Reactive_UpdateColorConfig()
        {
            Program.ReactColors.SetStart(
                Reactive_Start_ColourButton.BackColor.R,
                Reactive_Start_ColourButton.BackColor.G,
                Reactive_Start_ColourButton.BackColor.B, 0);

            Program.ReactColors.SRandRLow = (int)Reactive_Start_Red_LowUD.Value;
            Program.ReactColors.SRandRHigh = (int)Reactive_Start_Red_HighUD.Value;
            Program.ReactColors.SRandGLow = (int)Reactive_Start_Green_LowUD.Value;
            Program.ReactColors.SRandGHigh = (int)Reactive_Start_Green_HighUD.Value;
            Program.ReactColors.SRandBLow = (int)Reactive_Start_Blue_LowUD.Value;
            Program.ReactColors.SRandBHigh = (int)Reactive_Start_Blue_HighUD.Value;

            Program.ReactColors.SetEnd(
                Reactive_End_ColourButton.BackColor.R,
                Reactive_End_ColourButton.BackColor.G,
                Reactive_End_ColourButton.BackColor.B, 0);

            Program.ReactColors.ERandRLow = (int)Reactive_End_Red_LowUD.Value;
            Program.ReactColors.ERandRHigh = (int)Reactive_End_Red_HighUD.Value;
            Program.ReactColors.ERandGLow = (int)Reactive_End_Green_LowUD.Value;
            Program.ReactColors.ERandGHigh = (int)Reactive_End_Green_HighUD.Value;
            Program.ReactColors.ERandBLow = (int)Reactive_End_Blue_LowUD.Value;
            Program.ReactColors.ERandBHigh = (int)Reactive_End_Blue_HighUD.Value;
        }

        private void Reactive_Start_UpdateColorBoxes(object sender, EventArgs e)
        {
            Reactive_Start_Red_LowButton.BackColor = Color.FromArgb(255, (int)Reactive_Start_Red_LowUD.Value, 0, 0);
            Reactive_Start_Red_HighButton.BackColor = Color.FromArgb(255, (int)Reactive_Start_Red_HighUD.Value, 0, 0);

            Reactive_Start_Green_LowButton.BackColor = Color.FromArgb(255, 0, (int)Reactive_Start_Green_LowUD.Value, 0);
            Reactive_Start_Green_HighButton.BackColor = Color.FromArgb(255, 0, (int)Reactive_Start_Green_HighUD.Value, 0);

            Reactive_Start_Blue_LowButton.BackColor = Color.FromArgb(255, 0, 0, (int)Reactive_Start_Blue_LowUD.Value);
            Reactive_Start_Blue_HighButton.BackColor = Color.FromArgb(255, 0, 0, (int)Reactive_Start_Blue_HighUD.Value);

            Reactive_Start_Red_LowUD.Maximum = Reactive_Start_Red_HighUD.Value;
            Reactive_Start_Green_LowUD.Maximum = Reactive_Start_Green_HighUD.Value;
            Reactive_Start_Blue_LowUD.Maximum = Reactive_Start_Blue_HighUD.Value;

            Reactive_UpdateColorConfig();
        }

        private void Reactive_End_UpdateColorBoxes(object sender, EventArgs e)
        {
            Reactive_End_Red_LowButton.BackColor = Color.FromArgb(255, (int)Reactive_End_Red_LowUD.Value, 0, 0);
            Reactive_End_Red_HighButton.BackColor = Color.FromArgb(255, (int)Reactive_End_Red_HighUD.Value, 0, 0);

            Reactive_End_Green_LowButton.BackColor = Color.FromArgb(255, 0, (int)Reactive_End_Green_LowUD.Value, 0);
            Reactive_End_Green_HighButton.BackColor = Color.FromArgb(255, 0, (int)Reactive_End_Green_HighUD.Value, 0);

            Reactive_End_Blue_LowButton.BackColor = Color.FromArgb(255, 0, 0, (int)Reactive_End_Blue_LowUD.Value);
            Reactive_End_Blue_HighButton.BackColor = Color.FromArgb(255, 0, 0, (int)Reactive_End_Blue_HighUD.Value);

            Reactive_End_Red_LowUD.Maximum = Reactive_End_Red_HighUD.Value;
            Reactive_End_Green_LowUD.Maximum = Reactive_End_Green_HighUD.Value;
            Reactive_End_Blue_LowUD.Maximum = Reactive_Start_Blue_HighUD.Value;

            Reactive_UpdateColorConfig();
        }

        #endregion Reactive - Reactive

        #region Reactive - Heatmap

        private void Heatmap_ColourButton_ColourChange(object sender, EventArgs e)
        {
            OpenColorPicker(sender);
            Heatmap_UpdateColorConfig();
        }

        private void Heatmap_UpdateColorConfig()
        {
            Program.HeatmapColors.SetStart(
                Heatmap_Start_ColourButton.BackColor.R,
                Heatmap_Start_ColourButton.BackColor.G,
                Heatmap_Start_ColourButton.BackColor.B, 0);

            Program.HeatmapColors.SetEnd(
                Heatmap_End_ColourButton.BackColor.R,
                Heatmap_End_ColourButton.BackColor.G,
                Heatmap_End_ColourButton.BackColor.B, 0);
        }

        private void Heatmap_ResetMaxButton_Click(object sender, EventArgs e)
        {
            Program.HighestStrikeCount = 0;
            if (HeatmapThread != null) { HeatmapThread.ResetKeyStrikeCounts(); };
        }

        #endregion Reactive - Heatmap

        #endregion Tab: Reactive

        #region Tab: Settings

        #region [Settings] Buttons
        private void SettingsGetUpdateButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("There is a new version of Keyboard Spectro available.\nWould you like to get it now?",
                           "New Version Available!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start("http://elestriel.cf/?page=keyboardspectro");
            }

        }

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

        #endregion [Settings] Buttons

        #region [Settings] ListBoxes
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
            if (SettingsKeyboardModelCB.Text != Program.SettingsKeyboardModel)
            {
                Program.SettingsKeyboardModel = SettingsKeyboardModelCB.Text;
                Program.StaticKeysNeedRedraw = true;
            }
        }

        private void SettingsKeyboardLayoutCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == 2)
            {
                UpdateStatusMessage.ShowStatusMessage(1, "Please stop and start anew to apply new layout.");
            }
            if (SettingsKeyboardLayoutCB.Text != Program.SettingsKeyboardLayout)
            {
                Program.SettingsKeyboardLayout = SettingsKeyboardLayoutCB.Text;
                Program.StaticKeysNeedRedraw = true;
            }
        }

        private void SettingsMouseModelCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetMouseSettings();
        }

        #endregion [Settings] ListBoxes
        
        #region [Settings] CheckBoxes

        private void SettingsRestoreLightingCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.SettingsRestoreLightingOnExit = SettingsRestoreLightingCheck.Checked;
        }

        private void SettingsLaunchCueCheck_CheckedChanged(object sender, EventArgs e)
        {
            Program.SettingLaunchCueOnExit = SettingsLaunchCueCheck.Checked;
        }

        private void SettingsSpectroOnStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SettingsSpectroOnStartCheck.Checked == true) { SettingsEffectsOnStartCheck.Checked = false; };
        }

        private void SettingsEffectsOnStartCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (SettingsEffectsOnStartCheck.Checked == true) { SettingsSpectroOnStartCheck.Checked = false; };
        }

        private void SettingsIdleSwitcher_CheckedChanged(object sender, EventArgs e)
        {
            bool showControls = SettingsIdleSwitcher.Checked;

            SettingsIdleModeCB.Visible = showControls;
            //SettingsIdleProfileCB.Visible = showControls;
            SettingsIdleTimeUD.Visible = showControls;
            SettingsIdleLabel1.Visible = showControls;
            SettingsIdleLabel2.Visible = showControls;
            //SettingsIdleLabel3.Visible = showControls;

            Program.WatchForInactivity = showControls;
            Program.InactivityTimeTrigger = (int)SettingsIdleTimeUD.Value;

            if (showControls)
            {
                SettingsIdleSwitcher.Enabled = false;
                idleWatcherThread = new Thread(() => InactivityWatcher.Watch());
                idleWatcherThread.Start();
            }
        }

        private void SettingsUseMosue_CheckedChanged(object sender, EventArgs e)
        {
            Program.IncludeMouseInEffects = SettingsEffectsIncludeMouse.Checked;
        }

        #endregion [Settings] CheckBoxes

        #region [Settings] TextBoxes
        private void SettingsCuePathTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SettingsCuePathTextBox.Text != "" && SettingsLaunchCueCheck.Checked == true) { Program.SettingLaunchCueOnExit = true; }
            else { Program.SettingLaunchCueOnExit = false; };
        }

        #endregion [Settings] TextBoxes

        #region [Settings] Idle Controls

        private void SettingsIdleTimeUD_ValueChanged(object sender, EventArgs e)
        {
            Program.InactivityTimeTrigger = (int)SettingsIdleTimeUD.Value;
        }

        private void SettingsIdleModeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SettingsIdleModeCB.Text == "Static Profile")
            {
                string[] fileList = LoadStaticProfileList();

                SettingsIdleProfileCB.Items.Clear();

                for (int f = 0; f < fileList.Length; f++)
                { SettingsIdleProfileCB.Items.Add(fileList[f]); }

                SettingsIdleProfileCB.Visible = true;
                SettingsIdleLabel3.Visible = true;
            }
            else
            {
                SettingsIdleProfileCB.Visible = false;
                SettingsIdleLabel3.Visible = false;
            }
        }
        
        #endregion [Settings] Idle Controls

        #endregion Tab: Settings

        #region Debug

        #region [Debug] Buttons
        private void DebugTestModeButton_Click(object sender, EventArgs e)
        {
            if (Program.RunKeyboardThread == -1 || Program.RunKeyboardThread == 0)
            {
                UpdateStatusMessage.ShowStatusMessage(4, "Starting Test Mode");
                if (StartSpectrograph(1) == true) { StartSpectrographButton.Enabled = false; }
            }
        }

        #endregion [Debug] Buttons

        #region [Debug] UpDowns
        private void DebugTesterUD_ValueChanged(object sender, EventArgs e)
        {
            Program.TestLed = (int)DebugTesterUD.Value;
        }

        private void DebugVerbosityUD_ValueChanged(object sender, EventArgs e)
        {
            Program.LogLevel = (int)DebugLogLevelUD.Value;
        }

        #endregion [Debug] UpDowns

        #endregion Debug

        #region Program

        private void MainTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show debug info (log, test mode) when Static Keys tab isn't selected.
            bool ShowDebugControls = true;
            if (MainTabControl.SelectedIndex == 2) { ShowDebugControls = false; };

            DebugStatusLog.Visible = ShowDebugControls;
            DebugTestModeButton.Visible = ShowDebugControls;
            DebugTesterUD.Visible = ShowDebugControls;
            DebugLogLevelLabel.Visible = ShowDebugControls;
            DebugLogLevelUD.Visible = ShowDebugControls;

            // See if keyboard image needs to be redrawn
            if (MainTabControl.SelectedIndex == 2 && Program.StaticKeysNeedRedraw == true)
            {
                Program.StaticKeysNeedRedraw = false;
                // Load static key map
                for (int i = 0; i < Program.StaticKeyColors.Length; i++)
                { Program.StaticKeyColors[i] = Color.Transparent; };
                StaticGetKeyboardImage_Click(null, null);
                // Clear profile
                //NewProfileButton_Click(null, null);
            }
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

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            // Handle the escape key
            // Currently this is only used in Static Keys to exit copy/paste mode
            if (e.KeyCode == Keys.Escape)
            {
                // If we're in the Static Keys page
                if (MainTabControl.SelectedIndex == 2)
                {
                    StaticCopyPasteMode = 0;
                    StaticCopyButton.FlatAppearance.BorderColor = Color.Black;
                    StaticPasteButton.FlatAppearance.BorderColor = Color.Black;
                }
            }
        }

        private void MuteCheckTimer_Tick(object sender, EventArgs e)
        {
            // Leave if one of the effects are running, as they will manage mute state
            if (Program.RunKeyboardThread > 1) { return; };
            
        }

        /// <summary>
        /// Sender-sensitive ColorPicker. Non-control-called method returns the selected Color.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private Color OpenColorPicker(object sender)
        {
            System.Windows.Media.Color selectedMediaColor;
            Color selectedColor = ((Button)sender).BackColor;
            ColorPickerStandardDialog dia = new ColorPickerStandardDialog();
            dia.InitialColor = System.Windows.Media.Color.FromRgb(((Button)sender).BackColor.R, ((Button)sender).BackColor.G, ((Button)sender).BackColor.B);
            if (dia.ShowDialog() == true)
            {
                selectedMediaColor = dia.SelectedColor; //do something with the selected color
                selectedColor = Color.FromArgb(255, selectedMediaColor.R, selectedMediaColor.G, selectedMediaColor.B);
            }
            ((Button)sender).BackColor = selectedColor;
            return selectedColor;
        }

        /// <summary>
        /// Sender-sensitive ColorPicker. This is the control-called method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenColorPicker(object sender, EventArgs e)
        {
            OpenColorPicker(sender);
        }
        #endregion Program

        #region ToolStrip

        private void tsmQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsmProfileList_Click(object sender, EventArgs e)
        {
            LoadProfileButton_Click(sender, e);
        }

        private void tsmSpectroAmplitudeSlider_ValueChanged(object sender, EventArgs e)
        {
            tsmSpectroAmplitude.Text = "Amplitude: " + tsmSpectroAmplitudeSlider.Value;
            SpectroAmplitudeUD.Value = ((TrackBar)sender).Value;
        }
        private void RightClickMenu_Opening(object sender, CancelEventArgs e)
        {
            tsmSpectroAmplitudeSlider.Value = (int)Program.SpectroAmplitude;
        }

        #endregion ToolStrip

        #endregion Sections

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

    public delegate void InactivityWatcherDelegate(int isIdle);
    public static class InactivityStatusChanged
    {
        public static Form MainForm;
        public static event InactivityWatcherDelegate DoAction;

        public static void UpdateInactivity(int isIdle)
        {
            ThreadSafeUpdateInactivity(isIdle);
        }

        private static void ThreadSafeUpdateInactivity(int isIdle)
        {
            if (MainForm != null && MainForm.InvokeRequired)
            {
                MainForm.Invoke(new InactivityWatcherDelegate(ThreadSafeUpdateInactivity), new object[] { isIdle });
            }
            else
            {
                DoAction(isIdle);
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