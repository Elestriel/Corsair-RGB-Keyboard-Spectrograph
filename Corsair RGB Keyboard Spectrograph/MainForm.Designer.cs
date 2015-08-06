namespace RGBKeyboardSpectrograph
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.StartSpectrographButton = new System.Windows.Forms.Button();
            this.StopSpectrographButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLight = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.SettingsKeyboardModelCB = new System.Windows.Forms.ComboBox();
            this.SettingsKeyboardLayoutCB = new System.Windows.Forms.ComboBox();
            this.SpectroAmplitudeUD = new System.Windows.Forms.NumericUpDown();
            this.SpectroAmplitudeLabel = new System.Windows.Forms.Label();
            this.SpectroBgBrightnessUD = new System.Windows.Forms.NumericUpDown();
            this.DebugTestModeButton = new System.Windows.Forms.Button();
            this.DebugTesterUD = new System.Windows.Forms.NumericUpDown();
            this.DebugStatusLog = new System.Windows.Forms.RichTextBox();
            this.DebugLogLevelUD = new System.Windows.Forms.NumericUpDown();
            this.DebugLogLevelLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmShowStatic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmRefreshStatic = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSwitchStaticProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmStartSpectro = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSpectroAmplitude = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStartEffects = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmReactive = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHeatmap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmResetHeatmap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMinimizeToTrayCheck = new System.Windows.Forms.CheckBox();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.SpectroRefreshDelayLabel = new System.Windows.Forms.Label();
            this.SpectroRefreshDelayUD = new System.Windows.Forms.NumericUpDown();
            this.SettingsLaunchCueCheck = new System.Windows.Forms.CheckBox();
            this.SpectroColorBars = new System.Windows.Forms.Button();
            this.SpectroBgEffectCB = new System.Windows.Forms.ComboBox();
            this.SpectroColorBg = new System.Windows.Forms.Button();
            this.GraphicsPictureBox = new System.Windows.Forms.PictureBox();
            this.SpectroShowGraphicsCheck = new System.Windows.Forms.CheckBox();
            this.SpectroWidthLabel = new System.Windows.Forms.Label();
            this.SpectroBgWidth = new System.Windows.Forms.NumericUpDown();
            this.SpectroSpeedLabel = new System.Windows.Forms.Label();
            this.SpectroBgSpeed = new System.Windows.Forms.NumericUpDown();
            this.SettingsStartMinimizedCheck = new System.Windows.Forms.CheckBox();
            this.SettingsEffectsOnStartCheck = new System.Windows.Forms.CheckBox();
            this.SpectroWasapiDevicesCB = new System.Windows.Forms.ComboBox();
            this.SpectroWasapiLoopbackRadio = new System.Windows.Forms.RadioButton();
            this.SpectroWasapiRadio = new System.Windows.Forms.RadioButton();
            this.SpectroBarEffectCB = new System.Windows.Forms.ComboBox();
            this.SpectroBrightnessLabel = new System.Windows.Forms.Label();
            this.SpectroBarBrightnessUD = new System.Windows.Forms.NumericUpDown();
            this.SpectroBarSpeed = new System.Windows.Forms.NumericUpDown();
            this.SpectroBarWidth = new System.Windows.Forms.NumericUpDown();
            this.SettingsGetUpdateButton = new System.Windows.Forms.Button();
            this.SettingsRestoreLightingCheck = new System.Windows.Forms.CheckBox();
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.tabSpectro = new System.Windows.Forms.TabPage();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.Effect_Float_FrequencyLabel = new System.Windows.Forms.Label();
            this.Effect_Float_DurationLabel = new System.Windows.Forms.Label();
            this.Effect_Float_DurationUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_FrequencyUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_EndGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_End_BlueGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_End_Blue_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_End_Blue_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_End_Blue_HighButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_Blue_LowButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_GreenGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_End_Green_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_End_Green_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_End_Green_HighButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_Green_LowButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_RedGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_End_Red_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_End_Red_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_End_Red_HighButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_Red_LowButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_ColourButton = new System.Windows.Forms.Button();
            this.Effect_Float_End_RadioRandom = new System.Windows.Forms.RadioButton();
            this.Effect_Float_End_RadioDefined = new System.Windows.Forms.RadioButton();
            this.Effect_Float_StartGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_Start_BlueGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_Start_Blue_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_Start_Blue_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_Start_Blue_HighButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_Blue_LowButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_GreenGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_Start_Green_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_Start_Green_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_Start_Green_HighButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_Green_LowButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_RedGB = new System.Windows.Forms.GroupBox();
            this.Effect_Float_Start_Red_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_Start_Red_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Effect_Float_Start_Red_HighButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_Red_LowButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_ColourButton = new System.Windows.Forms.Button();
            this.Effect_Float_Start_RadioRandom = new System.Windows.Forms.RadioButton();
            this.Effect_Float_Start_RadioDefined = new System.Windows.Forms.RadioButton();
            this.EffectsStopButton = new System.Windows.Forms.Button();
            this.EffectsStartButton = new System.Windows.Forms.Button();
            this.EffectTabControl = new System.Windows.Forms.TabControl();
            this.EffectTab_RandomLights = new System.Windows.Forms.TabPage();
            this.EffectTab_Rainfall = new System.Windows.Forms.TabPage();
            this.tabStatic = new System.Windows.Forms.TabPage();
            this.ToggleNumOn = new System.Windows.Forms.Button();
            this.ToggleScrollOn = new System.Windows.Forms.Button();
            this.ToggleCapsOn = new System.Windows.Forms.Button();
            this.ToggleMuteOn = new System.Windows.Forms.Button();
            this.StaticMouseLightsGB = new System.Windows.Forms.GroupBox();
            this.StaticMouseLight4 = new System.Windows.Forms.Button();
            this.StaticMouseLight1 = new System.Windows.Forms.Button();
            this.StaticMouseLight2 = new System.Windows.Forms.Button();
            this.StaticMouseLight3 = new System.Windows.Forms.Button();
            this.StaticProfileListCB = new System.Windows.Forms.ComboBox();
            this.StaticSaveProfileAsButton = new System.Windows.Forms.Button();
            this.StaticClearButton = new System.Windows.Forms.Button();
            this.StaticCopyPasteColor = new System.Windows.Forms.Button();
            this.StaticPasteButton = new System.Windows.Forms.Button();
            this.StaticCopyButton = new System.Windows.Forms.Button();
            this.StaticNewProfileButton = new System.Windows.Forms.Button();
            this.StaticUpdateKeyboardButton = new System.Windows.Forms.Button();
            this.StaticDeleteKeysButton = new System.Windows.Forms.Button();
            this.StaticSaveProfileButton = new System.Windows.Forms.Button();
            this.StaticLoadProfileButton = new System.Windows.Forms.Button();
            this.StaticKeyboardImageBox = new System.Windows.Forms.PictureBox();
            this.StaticGetKeyboardImage = new System.Windows.Forms.Button();
            this.tabReactive = new System.Windows.Forms.TabPage();
            this.ReactiveTabControl = new System.Windows.Forms.TabControl();
            this.ReactiveTab_Reactive = new System.Windows.Forms.TabPage();
            this.Reactive_FrequencyLabel = new System.Windows.Forms.Label();
            this.Reactive_DurationLabel = new System.Windows.Forms.Label();
            this.Reactive_DurationUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_FrequencyUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_StartGB = new System.Windows.Forms.GroupBox();
            this.Reactive_Start_RadioRainbow = new System.Windows.Forms.RadioButton();
            this.Reactive_Start_BlueGB = new System.Windows.Forms.GroupBox();
            this.Reactive_Start_Blue_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_Start_Blue_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_Start_Blue_HighButton = new System.Windows.Forms.Button();
            this.Reactive_Start_Blue_LowButton = new System.Windows.Forms.Button();
            this.Reactive_Start_GreenGB = new System.Windows.Forms.GroupBox();
            this.Reactive_Start_Green_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_Start_Green_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_Start_Green_HighButton = new System.Windows.Forms.Button();
            this.Reactive_Start_Green_LowButton = new System.Windows.Forms.Button();
            this.Reactive_Start_RedGB = new System.Windows.Forms.GroupBox();
            this.Reactive_Start_Red_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_Start_Red_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_Start_Red_HighButton = new System.Windows.Forms.Button();
            this.Reactive_Start_Red_LowButton = new System.Windows.Forms.Button();
            this.Reactive_Start_ColourButton = new System.Windows.Forms.Button();
            this.Reactive_Start_RadioRandom = new System.Windows.Forms.RadioButton();
            this.Reactive_Start_RadioDefined = new System.Windows.Forms.RadioButton();
            this.Reactive_EndGB = new System.Windows.Forms.GroupBox();
            this.Reactive_End_RadioOriginal = new System.Windows.Forms.RadioButton();
            this.Reactive_End_BlueGB = new System.Windows.Forms.GroupBox();
            this.Reactive_End_Blue_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_End_Blue_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_End_Blue_HighButton = new System.Windows.Forms.Button();
            this.Reactive_End_Blue_LowButton = new System.Windows.Forms.Button();
            this.Reactive_End_GreenGB = new System.Windows.Forms.GroupBox();
            this.Reactive_End_Green_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_End_Green_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_End_Green_HighButton = new System.Windows.Forms.Button();
            this.Reactive_End_Green_LowButton = new System.Windows.Forms.Button();
            this.Reactive_End_RedGB = new System.Windows.Forms.GroupBox();
            this.Reactive_End_Red_HighUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_End_Red_LowUD = new System.Windows.Forms.NumericUpDown();
            this.Reactive_End_Red_HighButton = new System.Windows.Forms.Button();
            this.Reactive_End_Red_LowButton = new System.Windows.Forms.Button();
            this.Reactive_End_ColourButton = new System.Windows.Forms.Button();
            this.Reactive_End_RadioRandom = new System.Windows.Forms.RadioButton();
            this.Reactive_End_RadioDefined = new System.Windows.Forms.RadioButton();
            this.ReactiveTab_Heatmap = new System.Windows.Forms.TabPage();
            this.Heatmap_ResetMaxButton = new System.Windows.Forms.Button();
            this.Heatmap_End_ColourLabel = new System.Windows.Forms.Label();
            this.Heatmap_Start_ColourLabel = new System.Windows.Forms.Label();
            this.Heatmap_End_ColourButton = new System.Windows.Forms.Button();
            this.Heatmap_Start_ColourButton = new System.Windows.Forms.Button();
            this.ReactiveStopButton = new System.Windows.Forms.Button();
            this.ReactiveStartButton = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.AnimationsUseStaticLights = new System.Windows.Forms.CheckBox();
            this.SettingsMouseModelCB = new System.Windows.Forms.ComboBox();
            this.SettingsEffectsIncludeMouse = new System.Windows.Forms.CheckBox();
            this.SettingsIdleSwitcher = new System.Windows.Forms.CheckBox();
            this.SettingsIdleLabel3 = new System.Windows.Forms.Label();
            this.SettingsIdleProfileCB = new System.Windows.Forms.ComboBox();
            this.SettingsIdleModeCB = new System.Windows.Forms.ComboBox();
            this.SettingsIdleLabel2 = new System.Windows.Forms.Label();
            this.SettingsIdleTimeUD = new System.Windows.Forms.NumericUpDown();
            this.SettingsIdleLabel1 = new System.Windows.Forms.Label();
            this.SettingsStaticOnStartCheck = new System.Windows.Forms.CheckBox();
            this.SettingsSpectroOnStartCheck = new System.Windows.Forms.CheckBox();
            this.SettingsBrowseCuePathButton = new System.Windows.Forms.Button();
            this.SettingsCuePathTextBox = new System.Windows.Forms.TextBox();
            this.SettingsCuePathLabel = new System.Windows.Forms.Label();
            this.ToggleCheckTimer = new System.Windows.Forms.Timer(this.components);
            this.SettingsSuppressCueWarnings = new System.Windows.Forms.CheckBox();
            this.ToggleCapsLabel = new System.Windows.Forms.Label();
            this.ToggleNumLabel = new System.Windows.Forms.Label();
            this.ToggleNumOff = new System.Windows.Forms.Button();
            this.ToggleCapsOff = new System.Windows.Forms.Button();
            this.ToggleScrollOff = new System.Windows.Forms.Button();
            this.ToggleMuteOff = new System.Windows.Forms.Button();
            this.ToggleMuteLabel = new System.Windows.Forms.Label();
            this.ToggleScrollLabel = new System.Windows.Forms.Label();
            this.UseToggleColoursCheck = new System.Windows.Forms.CheckBox();
            this.tsmSpectroAmplitudeSlider = new RGBKeyboardSpectrograph.ToolStripTrackBar();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroAmplitudeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBgBrightnessUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugTesterUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugLogLevelUD)).BeginInit();
            this.RightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroRefreshDelayUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBgWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBgSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBarBrightnessUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBarWidth)).BeginInit();
            this.MainTabControl.SuspendLayout();
            this.tabSpectro.SuspendLayout();
            this.tabEffects.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_DurationUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_FrequencyUD)).BeginInit();
            this.Effect_Float_EndGB.SuspendLayout();
            this.Effect_Float_End_BlueGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Blue_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Blue_LowUD)).BeginInit();
            this.Effect_Float_End_GreenGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Green_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Green_LowUD)).BeginInit();
            this.Effect_Float_End_RedGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Red_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Red_LowUD)).BeginInit();
            this.Effect_Float_StartGB.SuspendLayout();
            this.Effect_Float_Start_BlueGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Blue_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Blue_LowUD)).BeginInit();
            this.Effect_Float_Start_GreenGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Green_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Green_LowUD)).BeginInit();
            this.Effect_Float_Start_RedGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Red_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Red_LowUD)).BeginInit();
            this.EffectTabControl.SuspendLayout();
            this.tabStatic.SuspendLayout();
            this.StaticMouseLightsGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.StaticKeyboardImageBox)).BeginInit();
            this.tabReactive.SuspendLayout();
            this.ReactiveTabControl.SuspendLayout();
            this.ReactiveTab_Reactive.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_DurationUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_FrequencyUD)).BeginInit();
            this.Reactive_StartGB.SuspendLayout();
            this.Reactive_Start_BlueGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Blue_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Blue_LowUD)).BeginInit();
            this.Reactive_Start_GreenGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Green_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Green_LowUD)).BeginInit();
            this.Reactive_Start_RedGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Red_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Red_LowUD)).BeginInit();
            this.Reactive_EndGB.SuspendLayout();
            this.Reactive_End_BlueGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Blue_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Blue_LowUD)).BeginInit();
            this.Reactive_End_GreenGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Green_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Green_LowUD)).BeginInit();
            this.Reactive_End_RedGB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Red_HighUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Red_LowUD)).BeginInit();
            this.ReactiveTab_Heatmap.SuspendLayout();
            this.tabSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsIdleTimeUD)).BeginInit();
            this.SuspendLayout();
            // 
            // StartSpectrographButton
            // 
            this.StartSpectrographButton.Location = new System.Drawing.Point(7, 330);
            this.StartSpectrographButton.Name = "StartSpectrographButton";
            this.StartSpectrographButton.Size = new System.Drawing.Size(75, 23);
            this.StartSpectrographButton.TabIndex = 0;
            this.StartSpectrographButton.Text = "Start";
            this.StartSpectrographButton.UseVisualStyleBackColor = true;
            this.StartSpectrographButton.Click += new System.EventHandler(this.StartSpectrograph_Click);
            // 
            // StopSpectrographButton
            // 
            this.StopSpectrographButton.Location = new System.Drawing.Point(323, 330);
            this.StopSpectrographButton.Name = "StopSpectrographButton";
            this.StopSpectrographButton.Size = new System.Drawing.Size(75, 23);
            this.StopSpectrographButton.TabIndex = 1;
            this.StopSpectrographButton.Text = "Stop";
            this.StopSpectrographButton.UseVisualStyleBackColor = true;
            this.StopSpectrographButton.Click += new System.EventHandler(this.StopEffects);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLight,
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 405);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(724, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLight
            // 
            this.StatusLight.Name = "StatusLight";
            this.StatusLight.Size = new System.Drawing.Size(16, 17);
            this.StatusLight.Text = "   ";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(67, 17);
            this.StatusLabel.Text = "StatusLabel";
            // 
            // SettingsKeyboardModelCB
            // 
            this.SettingsKeyboardModelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SettingsKeyboardModelCB.FormattingEnabled = true;
            this.SettingsKeyboardModelCB.Location = new System.Drawing.Point(13, 13);
            this.SettingsKeyboardModelCB.Name = "SettingsKeyboardModelCB";
            this.SettingsKeyboardModelCB.Size = new System.Drawing.Size(130, 21);
            this.SettingsKeyboardModelCB.TabIndex = 4;
            this.SettingsKeyboardModelCB.SelectedIndexChanged += new System.EventHandler(this.SettingsKeyboardModelCB_SelectedIndexChanged);
            // 
            // SettingsKeyboardLayoutCB
            // 
            this.SettingsKeyboardLayoutCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SettingsKeyboardLayoutCB.FormattingEnabled = true;
            this.SettingsKeyboardLayoutCB.Location = new System.Drawing.Point(13, 40);
            this.SettingsKeyboardLayoutCB.Name = "SettingsKeyboardLayoutCB";
            this.SettingsKeyboardLayoutCB.Size = new System.Drawing.Size(130, 21);
            this.SettingsKeyboardLayoutCB.TabIndex = 6;
            this.SettingsKeyboardLayoutCB.SelectedIndexChanged += new System.EventHandler(this.SettingsKeyboardLayoutCB_SelectedIndexChanged);
            // 
            // SpectroAmplitudeUD
            // 
            this.SpectroAmplitudeUD.Location = new System.Drawing.Point(231, 249);
            this.SpectroAmplitudeUD.Name = "SpectroAmplitudeUD";
            this.SpectroAmplitudeUD.Size = new System.Drawing.Size(47, 20);
            this.SpectroAmplitudeUD.TabIndex = 8;
            this.SpectroAmplitudeUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpectroAmplitudeUD.ValueChanged += new System.EventHandler(this.SpectroAmplitudeUD_ValueChanged);
            // 
            // SpectroAmplitudeLabel
            // 
            this.SpectroAmplitudeLabel.AutoSize = true;
            this.SpectroAmplitudeLabel.Location = new System.Drawing.Point(168, 251);
            this.SpectroAmplitudeLabel.Name = "SpectroAmplitudeLabel";
            this.SpectroAmplitudeLabel.Size = new System.Drawing.Size(57, 13);
            this.SpectroAmplitudeLabel.TabIndex = 9;
            this.SpectroAmplitudeLabel.Text = "Sensitivity:";
            // 
            // SpectroBgBrightnessUD
            // 
            this.SpectroBgBrightnessUD.Location = new System.Drawing.Point(294, 26);
            this.SpectroBgBrightnessUD.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.SpectroBgBrightnessUD.Name = "SpectroBgBrightnessUD";
            this.SpectroBgBrightnessUD.Size = new System.Drawing.Size(47, 20);
            this.SpectroBgBrightnessUD.TabIndex = 18;
            this.SpectroBgBrightnessUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.SpectroBgBrightnessUD.ValueChanged += new System.EventHandler(this.SpectroBackgroundBrightnessUD_ValueChanged);
            // 
            // DebugTestModeButton
            // 
            this.DebugTestModeButton.Location = new System.Drawing.Point(424, 332);
            this.DebugTestModeButton.Name = "DebugTestModeButton";
            this.DebugTestModeButton.Size = new System.Drawing.Size(87, 23);
            this.DebugTestModeButton.TabIndex = 20;
            this.DebugTestModeButton.Text = "Test Mode";
            this.DebugTestModeButton.UseVisualStyleBackColor = true;
            this.DebugTestModeButton.Click += new System.EventHandler(this.DebugTestModeButton_Click);
            // 
            // DebugTesterUD
            // 
            this.DebugTesterUD.Location = new System.Drawing.Point(517, 334);
            this.DebugTesterUD.Maximum = new decimal(new int[] {
            143,
            0,
            0,
            0});
            this.DebugTesterUD.Name = "DebugTesterUD";
            this.DebugTesterUD.Size = new System.Drawing.Size(47, 20);
            this.DebugTesterUD.TabIndex = 21;
            this.DebugTesterUD.ValueChanged += new System.EventHandler(this.DebugTesterUD_ValueChanged);
            // 
            // DebugStatusLog
            // 
            this.DebugStatusLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DebugStatusLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DebugStatusLog.HideSelection = false;
            this.DebugStatusLog.Location = new System.Drawing.Point(424, 44);
            this.DebugStatusLog.Name = "DebugStatusLog";
            this.DebugStatusLog.Size = new System.Drawing.Size(278, 282);
            this.DebugStatusLog.TabIndex = 22;
            this.DebugStatusLog.Text = "";
            // 
            // DebugLogLevelUD
            // 
            this.DebugLogLevelUD.Location = new System.Drawing.Point(655, 334);
            this.DebugLogLevelUD.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.DebugLogLevelUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.DebugLogLevelUD.Name = "DebugLogLevelUD";
            this.DebugLogLevelUD.Size = new System.Drawing.Size(47, 20);
            this.DebugLogLevelUD.TabIndex = 23;
            this.DebugLogLevelUD.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.DebugLogLevelUD.ValueChanged += new System.EventHandler(this.DebugVerbosityUD_ValueChanged);
            // 
            // DebugLogLevelLabel
            // 
            this.DebugLogLevelLabel.AutoSize = true;
            this.DebugLogLevelLabel.Location = new System.Drawing.Point(592, 336);
            this.DebugLogLevelLabel.Name = "DebugLogLevelLabel";
            this.DebugLogLevelLabel.Size = new System.Drawing.Size(57, 13);
            this.DebugLogLevelLabel.TabIndex = 24;
            this.DebugLogLevelLabel.Text = "Log Level:";
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "Double-click to restore.";
            this.notifyIcon.BalloonTipTitle = "Keyboard Spectrograph";
            this.notifyIcon.ContextMenuStrip = this.RightClickMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Keyboard Spectrograph";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // RightClickMenu
            // 
            this.RightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout,
            this.toolStripSeparator1,
            this.tsmShowStatic,
            this.tsmRefreshStatic,
            this.tsmSwitchStaticProfile,
            this.toolStripSeparator2,
            this.tsmStartSpectro,
            this.tsmStartEffects,
            this.tsmReactive,
            this.tsmHeatmap,
            this.tsmStop,
            this.toolStripSeparator3,
            this.tsmQuit});
            this.RightClickMenu.Name = "contextMenuStrip1";
            this.RightClickMenu.ShowCheckMargin = true;
            this.RightClickMenu.ShowImageMargin = false;
            this.RightClickMenu.Size = new System.Drawing.Size(173, 242);
            this.RightClickMenu.Opening += new System.ComponentModel.CancelEventHandler(this.RightClickMenu_Opening);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Enabled = false;
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(172, 22);
            this.tsmAbout.Text = "RGB Spectrograph";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmShowStatic
            // 
            this.tsmShowStatic.Name = "tsmShowStatic";
            this.tsmShowStatic.Size = new System.Drawing.Size(172, 22);
            this.tsmShowStatic.Text = "Show Static Keys";
            this.tsmShowStatic.Click += new System.EventHandler(this.tsmShowStatic_Click);
            // 
            // tsmRefreshStatic
            // 
            this.tsmRefreshStatic.Name = "tsmRefreshStatic";
            this.tsmRefreshStatic.Size = new System.Drawing.Size(172, 22);
            this.tsmRefreshStatic.Text = "Refresh Static Keys";
            this.tsmRefreshStatic.Click += new System.EventHandler(this.UpdateKeyboardButton_Click);
            // 
            // tsmSwitchStaticProfile
            // 
            this.tsmSwitchStaticProfile.Name = "tsmSwitchStaticProfile";
            this.tsmSwitchStaticProfile.Size = new System.Drawing.Size(172, 22);
            this.tsmSwitchStaticProfile.Text = "Change Profile";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmStartSpectro
            // 
            this.tsmStartSpectro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSpectroAmplitude,
            this.tsmSpectroAmplitudeSlider});
            this.tsmStartSpectro.Name = "tsmStartSpectro";
            this.tsmStartSpectro.Size = new System.Drawing.Size(172, 22);
            this.tsmStartSpectro.Text = "Start Spectro";
            this.tsmStartSpectro.Click += new System.EventHandler(this.StartSpectrograph_Click);
            // 
            // tsmSpectroAmplitude
            // 
            this.tsmSpectroAmplitude.Name = "tsmSpectroAmplitude";
            this.tsmSpectroAmplitude.Size = new System.Drawing.Size(164, 22);
            this.tsmSpectroAmplitude.Text = "Amplitude: x";
            // 
            // tsmStartEffects
            // 
            this.tsmStartEffects.Name = "tsmStartEffects";
            this.tsmStartEffects.Size = new System.Drawing.Size(172, 22);
            this.tsmStartEffects.Text = "Start Effects";
            this.tsmStartEffects.Click += new System.EventHandler(this.EffectsStartButton_Click);
            // 
            // tsmReactive
            // 
            this.tsmReactive.Name = "tsmReactive";
            this.tsmReactive.Size = new System.Drawing.Size(172, 22);
            this.tsmReactive.Text = "Start Reactive";
            this.tsmReactive.Click += new System.EventHandler(this.ReactiveStartButton_LaunchFromRightClickMenu);
            // 
            // tsmHeatmap
            // 
            this.tsmHeatmap.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmResetHeatmap});
            this.tsmHeatmap.Name = "tsmHeatmap";
            this.tsmHeatmap.Size = new System.Drawing.Size(172, 22);
            this.tsmHeatmap.Text = "Start Heatmap";
            this.tsmHeatmap.Click += new System.EventHandler(this.ReactiveStartButton_LaunchFromRightClickMenu);
            // 
            // tsmResetHeatmap
            // 
            this.tsmResetHeatmap.Name = "tsmResetHeatmap";
            this.tsmResetHeatmap.Size = new System.Drawing.Size(102, 22);
            this.tsmResetHeatmap.Text = "Reset";
            this.tsmResetHeatmap.Click += new System.EventHandler(this.Heatmap_ResetMaxButton_Click);
            // 
            // tsmStop
            // 
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.Size = new System.Drawing.Size(172, 22);
            this.tsmStop.Text = "Stop Animation";
            this.tsmStop.Click += new System.EventHandler(this.StopEffects);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(169, 6);
            // 
            // tsmQuit
            // 
            this.tsmQuit.Name = "tsmQuit";
            this.tsmQuit.Size = new System.Drawing.Size(172, 22);
            this.tsmQuit.Text = "Quit";
            this.tsmQuit.Click += new System.EventHandler(this.tsmQuit_Click);
            // 
            // SettingsMinimizeToTrayCheck
            // 
            this.SettingsMinimizeToTrayCheck.AutoSize = true;
            this.SettingsMinimizeToTrayCheck.Location = new System.Drawing.Point(13, 76);
            this.SettingsMinimizeToTrayCheck.Name = "SettingsMinimizeToTrayCheck";
            this.SettingsMinimizeToTrayCheck.Size = new System.Drawing.Size(139, 17);
            this.SettingsMinimizeToTrayCheck.TabIndex = 25;
            this.SettingsMinimizeToTrayCheck.Text = "Minimize to System Tray";
            this.SettingsMinimizeToTrayCheck.UseVisualStyleBackColor = true;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // SpectroRefreshDelayLabel
            // 
            this.SpectroRefreshDelayLabel.AutoSize = true;
            this.SpectroRefreshDelayLabel.Location = new System.Drawing.Point(12, 251);
            this.SpectroRefreshDelayLabel.Name = "SpectroRefreshDelayLabel";
            this.SpectroRefreshDelayLabel.Size = new System.Drawing.Size(77, 13);
            this.SpectroRefreshDelayLabel.TabIndex = 27;
            this.SpectroRefreshDelayLabel.Text = "Refresh Delay:";
            // 
            // SpectroRefreshDelayUD
            // 
            this.SpectroRefreshDelayUD.Location = new System.Drawing.Point(95, 249);
            this.SpectroRefreshDelayUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SpectroRefreshDelayUD.Name = "SpectroRefreshDelayUD";
            this.SpectroRefreshDelayUD.Size = new System.Drawing.Size(47, 20);
            this.SpectroRefreshDelayUD.TabIndex = 26;
            this.SpectroRefreshDelayUD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.SpectroRefreshDelayUD.ValueChanged += new System.EventHandler(this.SpectroRefreshDelayUD_ValueChanged);
            // 
            // SettingsLaunchCueCheck
            // 
            this.SettingsLaunchCueCheck.AutoSize = true;
            this.SettingsLaunchCueCheck.Location = new System.Drawing.Point(13, 145);
            this.SettingsLaunchCueCheck.Name = "SettingsLaunchCueCheck";
            this.SettingsLaunchCueCheck.Size = new System.Drawing.Size(122, 17);
            this.SettingsLaunchCueCheck.TabIndex = 28;
            this.SettingsLaunchCueCheck.Text = "Launch CUE on Exit";
            this.SettingsLaunchCueCheck.UseVisualStyleBackColor = true;
            this.SettingsLaunchCueCheck.CheckedChanged += new System.EventHandler(this.SettingsLaunchCueCheck_CheckedChanged);
            // 
            // SpectroColorBars
            // 
            this.SpectroColorBars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpectroColorBars.Location = new System.Drawing.Point(133, 52);
            this.SpectroColorBars.Name = "SpectroColorBars";
            this.SpectroColorBars.Size = new System.Drawing.Size(55, 23);
            this.SpectroColorBars.TabIndex = 29;
            this.SpectroColorBars.Text = "Bars";
            this.SpectroColorBars.UseVisualStyleBackColor = true;
            this.SpectroColorBars.Click += new System.EventHandler(this.SpectroColourButton_Click);
            // 
            // SpectroBgEffectCB
            // 
            this.SpectroBgEffectCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpectroBgEffectCB.FormattingEnabled = true;
            this.SpectroBgEffectCB.Location = new System.Drawing.Point(15, 25);
            this.SpectroBgEffectCB.Name = "SpectroBgEffectCB";
            this.SpectroBgEffectCB.Size = new System.Drawing.Size(112, 21);
            this.SpectroBgEffectCB.TabIndex = 30;
            this.SpectroBgEffectCB.SelectedIndexChanged += new System.EventHandler(this.SpectroBackgroundEffectCB_SelectedIndexChanged);
            // 
            // SpectroColorBg
            // 
            this.SpectroColorBg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpectroColorBg.Location = new System.Drawing.Point(133, 23);
            this.SpectroColorBg.Name = "SpectroColorBg";
            this.SpectroColorBg.Size = new System.Drawing.Size(55, 23);
            this.SpectroColorBg.TabIndex = 31;
            this.SpectroColorBg.Text = "BG";
            this.SpectroColorBg.UseVisualStyleBackColor = true;
            this.SpectroColorBg.Click += new System.EventHandler(this.SpectroColourButton_Click);
            // 
            // GraphicsPictureBox
            // 
            this.GraphicsPictureBox.Location = new System.Drawing.Point(15, 81);
            this.GraphicsPictureBox.Name = "GraphicsPictureBox";
            this.GraphicsPictureBox.Size = new System.Drawing.Size(165, 68);
            this.GraphicsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GraphicsPictureBox.TabIndex = 32;
            this.GraphicsPictureBox.TabStop = false;
            this.GraphicsPictureBox.Visible = false;
            // 
            // SpectroShowGraphicsCheck
            // 
            this.SpectroShowGraphicsCheck.AutoSize = true;
            this.SpectroShowGraphicsCheck.Location = new System.Drawing.Point(15, 156);
            this.SpectroShowGraphicsCheck.Name = "SpectroShowGraphicsCheck";
            this.SpectroShowGraphicsCheck.Size = new System.Drawing.Size(136, 17);
            this.SpectroShowGraphicsCheck.TabIndex = 34;
            this.SpectroShowGraphicsCheck.Text = "Show Graphical Output";
            this.SpectroShowGraphicsCheck.UseVisualStyleBackColor = true;
            this.SpectroShowGraphicsCheck.Visible = false;
            this.SpectroShowGraphicsCheck.CheckedChanged += new System.EventHandler(this.SpectroShowGraphicsCheck_CheckedChanged);
            // 
            // SpectroWidthLabel
            // 
            this.SpectroWidthLabel.AutoSize = true;
            this.SpectroWidthLabel.Location = new System.Drawing.Point(194, 10);
            this.SpectroWidthLabel.Name = "SpectroWidthLabel";
            this.SpectroWidthLabel.Size = new System.Drawing.Size(35, 13);
            this.SpectroWidthLabel.TabIndex = 35;
            this.SpectroWidthLabel.Text = "Width";
            // 
            // SpectroBgWidth
            // 
            this.SpectroBgWidth.Location = new System.Drawing.Point(194, 26);
            this.SpectroBgWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SpectroBgWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpectroBgWidth.Name = "SpectroBgWidth";
            this.SpectroBgWidth.Size = new System.Drawing.Size(47, 20);
            this.SpectroBgWidth.TabIndex = 36;
            this.SpectroBgWidth.Value = new decimal(new int[] {
            104,
            0,
            0,
            0});
            this.SpectroBgWidth.ValueChanged += new System.EventHandler(this.SpectroEffectWidth_ValueChanged);
            // 
            // SpectroSpeedLabel
            // 
            this.SpectroSpeedLabel.AutoSize = true;
            this.SpectroSpeedLabel.Location = new System.Drawing.Point(244, 10);
            this.SpectroSpeedLabel.Name = "SpectroSpeedLabel";
            this.SpectroSpeedLabel.Size = new System.Drawing.Size(38, 13);
            this.SpectroSpeedLabel.TabIndex = 38;
            this.SpectroSpeedLabel.Text = "Speed";
            // 
            // SpectroBgSpeed
            // 
            this.SpectroBgSpeed.DecimalPlaces = 1;
            this.SpectroBgSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SpectroBgSpeed.Location = new System.Drawing.Point(247, 26);
            this.SpectroBgSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpectroBgSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SpectroBgSpeed.Name = "SpectroBgSpeed";
            this.SpectroBgSpeed.Size = new System.Drawing.Size(41, 20);
            this.SpectroBgSpeed.TabIndex = 37;
            this.SpectroBgSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpectroBgSpeed.ValueChanged += new System.EventHandler(this.SpectroEffectSpeed_ValueChanged);
            // 
            // SettingsStartMinimizedCheck
            // 
            this.SettingsStartMinimizedCheck.AutoSize = true;
            this.SettingsStartMinimizedCheck.Location = new System.Drawing.Point(13, 99);
            this.SettingsStartMinimizedCheck.Name = "SettingsStartMinimizedCheck";
            this.SettingsStartMinimizedCheck.Size = new System.Drawing.Size(97, 17);
            this.SettingsStartMinimizedCheck.TabIndex = 41;
            this.SettingsStartMinimizedCheck.Text = "Start Minimized";
            this.SettingsStartMinimizedCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsEffectsOnStartCheck
            // 
            this.SettingsEffectsOnStartCheck.AutoSize = true;
            this.SettingsEffectsOnStartCheck.Location = new System.Drawing.Point(188, 99);
            this.SettingsEffectsOnStartCheck.Name = "SettingsEffectsOnStartCheck";
            this.SettingsEffectsOnStartCheck.Size = new System.Drawing.Size(99, 17);
            this.SettingsEffectsOnStartCheck.TabIndex = 42;
            this.SettingsEffectsOnStartCheck.Text = "Effects on Start";
            this.SettingsEffectsOnStartCheck.UseVisualStyleBackColor = true;
            this.SettingsEffectsOnStartCheck.CheckedChanged += new System.EventHandler(this.SettingsEffectsOnStartCheck_CheckedChanged);
            // 
            // SpectroWasapiDevicesCB
            // 
            this.SpectroWasapiDevicesCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpectroWasapiDevicesCB.FormattingEnabled = true;
            this.SpectroWasapiDevicesCB.Location = new System.Drawing.Point(70, 212);
            this.SpectroWasapiDevicesCB.Name = "SpectroWasapiDevicesCB";
            this.SpectroWasapiDevicesCB.Size = new System.Drawing.Size(208, 21);
            this.SpectroWasapiDevicesCB.TabIndex = 45;
            this.SpectroWasapiDevicesCB.SelectedIndexChanged += new System.EventHandler(this.SpectroWasapiDevicesCB_SelectedIndexChanged);
            // 
            // SpectroWasapiLoopbackRadio
            // 
            this.SpectroWasapiLoopbackRadio.AutoSize = true;
            this.SpectroWasapiLoopbackRadio.Checked = true;
            this.SpectroWasapiLoopbackRadio.Location = new System.Drawing.Point(15, 190);
            this.SpectroWasapiLoopbackRadio.Name = "SpectroWasapiLoopbackRadio";
            this.SpectroWasapiLoopbackRadio.Size = new System.Drawing.Size(57, 17);
            this.SpectroWasapiLoopbackRadio.TabIndex = 43;
            this.SpectroWasapiLoopbackRadio.TabStop = true;
            this.SpectroWasapiLoopbackRadio.Text = "Output";
            this.SpectroWasapiLoopbackRadio.UseVisualStyleBackColor = true;
            this.SpectroWasapiLoopbackRadio.CheckedChanged += new System.EventHandler(this.SpectroWasapiLoopbackRadio_CheckedChanged);
            // 
            // SpectroWasapiRadio
            // 
            this.SpectroWasapiRadio.AutoSize = true;
            this.SpectroWasapiRadio.Location = new System.Drawing.Point(15, 213);
            this.SpectroWasapiRadio.Name = "SpectroWasapiRadio";
            this.SpectroWasapiRadio.Size = new System.Drawing.Size(49, 17);
            this.SpectroWasapiRadio.TabIndex = 44;
            this.SpectroWasapiRadio.Text = "Input";
            this.SpectroWasapiRadio.UseVisualStyleBackColor = true;
            this.SpectroWasapiRadio.CheckedChanged += new System.EventHandler(this.SpectroWasapiRadio_CheckedChanged);
            // 
            // SpectroBarEffectCB
            // 
            this.SpectroBarEffectCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SpectroBarEffectCB.FormattingEnabled = true;
            this.SpectroBarEffectCB.Location = new System.Drawing.Point(15, 54);
            this.SpectroBarEffectCB.Name = "SpectroBarEffectCB";
            this.SpectroBarEffectCB.Size = new System.Drawing.Size(112, 21);
            this.SpectroBarEffectCB.TabIndex = 46;
            this.SpectroBarEffectCB.SelectedIndexChanged += new System.EventHandler(this.SpectroBarEffectCB_SelectedIndexChanged);
            // 
            // SpectroBrightnessLabel
            // 
            this.SpectroBrightnessLabel.AutoSize = true;
            this.SpectroBrightnessLabel.Location = new System.Drawing.Point(293, 10);
            this.SpectroBrightnessLabel.Name = "SpectroBrightnessLabel";
            this.SpectroBrightnessLabel.Size = new System.Drawing.Size(56, 13);
            this.SpectroBrightnessLabel.TabIndex = 48;
            this.SpectroBrightnessLabel.Text = "Brightness";
            // 
            // SpectroBarBrightnessUD
            // 
            this.SpectroBarBrightnessUD.Location = new System.Drawing.Point(294, 55);
            this.SpectroBarBrightnessUD.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.SpectroBarBrightnessUD.Name = "SpectroBarBrightnessUD";
            this.SpectroBarBrightnessUD.Size = new System.Drawing.Size(47, 20);
            this.SpectroBarBrightnessUD.TabIndex = 47;
            this.SpectroBarBrightnessUD.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.SpectroBarBrightnessUD.ValueChanged += new System.EventHandler(this.SpectroBarBrightnessUD_ValueChanged);
            // 
            // SpectroBarSpeed
            // 
            this.SpectroBarSpeed.DecimalPlaces = 1;
            this.SpectroBarSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SpectroBarSpeed.Location = new System.Drawing.Point(247, 55);
            this.SpectroBarSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.SpectroBarSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.SpectroBarSpeed.Name = "SpectroBarSpeed";
            this.SpectroBarSpeed.Size = new System.Drawing.Size(41, 20);
            this.SpectroBarSpeed.TabIndex = 50;
            this.SpectroBarSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpectroBarSpeed.ValueChanged += new System.EventHandler(this.SpectroBarSpeed_ValueChanged);
            // 
            // SpectroBarWidth
            // 
            this.SpectroBarWidth.Location = new System.Drawing.Point(194, 55);
            this.SpectroBarWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.SpectroBarWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SpectroBarWidth.Name = "SpectroBarWidth";
            this.SpectroBarWidth.Size = new System.Drawing.Size(47, 20);
            this.SpectroBarWidth.TabIndex = 49;
            this.SpectroBarWidth.Value = new decimal(new int[] {
            104,
            0,
            0,
            0});
            this.SpectroBarWidth.ValueChanged += new System.EventHandler(this.SpectroBarWidth_ValueChanged);
            // 
            // SettingsGetUpdateButton
            // 
            this.SettingsGetUpdateButton.Location = new System.Drawing.Point(315, 24);
            this.SettingsGetUpdateButton.Name = "SettingsGetUpdateButton";
            this.SettingsGetUpdateButton.Size = new System.Drawing.Size(87, 23);
            this.SettingsGetUpdateButton.TabIndex = 51;
            this.SettingsGetUpdateButton.Text = "Get Update";
            this.SettingsGetUpdateButton.UseVisualStyleBackColor = true;
            this.SettingsGetUpdateButton.Visible = false;
            this.SettingsGetUpdateButton.Click += new System.EventHandler(this.SettingsGetUpdateButton_Click);
            // 
            // SettingsRestoreLightingCheck
            // 
            this.SettingsRestoreLightingCheck.AutoSize = true;
            this.SettingsRestoreLightingCheck.Location = new System.Drawing.Point(13, 168);
            this.SettingsRestoreLightingCheck.Name = "SettingsRestoreLightingCheck";
            this.SettingsRestoreLightingCheck.Size = new System.Drawing.Size(138, 17);
            this.SettingsRestoreLightingCheck.TabIndex = 52;
            this.SettingsRestoreLightingCheck.Text = "Restore Lighting on Exit";
            this.SettingsRestoreLightingCheck.UseVisualStyleBackColor = true;
            this.SettingsRestoreLightingCheck.CheckedChanged += new System.EventHandler(this.SettingsRestoreLightingCheck_CheckedChanged);
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.tabSpectro);
            this.MainTabControl.Controls.Add(this.tabEffects);
            this.MainTabControl.Controls.Add(this.tabStatic);
            this.MainTabControl.Controls.Add(this.tabReactive);
            this.MainTabControl.Controls.Add(this.tabSettings);
            this.MainTabControl.Location = new System.Drawing.Point(12, 12);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(704, 386);
            this.MainTabControl.TabIndex = 53;
            this.MainTabControl.SelectedIndexChanged += new System.EventHandler(this.MainTabControl_SelectedIndexChanged);
            // 
            // tabSpectro
            // 
            this.tabSpectro.Controls.Add(this.SpectroWasapiDevicesCB);
            this.tabSpectro.Controls.Add(this.StartSpectrographButton);
            this.tabSpectro.Controls.Add(this.StopSpectrographButton);
            this.tabSpectro.Controls.Add(this.SpectroAmplitudeUD);
            this.tabSpectro.Controls.Add(this.SpectroWasapiLoopbackRadio);
            this.tabSpectro.Controls.Add(this.SpectroWasapiRadio);
            this.tabSpectro.Controls.Add(this.SpectroAmplitudeLabel);
            this.tabSpectro.Controls.Add(this.SpectroBarSpeed);
            this.tabSpectro.Controls.Add(this.SpectroBgBrightnessUD);
            this.tabSpectro.Controls.Add(this.SpectroBarWidth);
            this.tabSpectro.Controls.Add(this.SpectroBrightnessLabel);
            this.tabSpectro.Controls.Add(this.SpectroRefreshDelayUD);
            this.tabSpectro.Controls.Add(this.SpectroBarBrightnessUD);
            this.tabSpectro.Controls.Add(this.SpectroRefreshDelayLabel);
            this.tabSpectro.Controls.Add(this.SpectroBarEffectCB);
            this.tabSpectro.Controls.Add(this.SpectroColorBars);
            this.tabSpectro.Controls.Add(this.SpectroBgEffectCB);
            this.tabSpectro.Controls.Add(this.SpectroColorBg);
            this.tabSpectro.Controls.Add(this.GraphicsPictureBox);
            this.tabSpectro.Controls.Add(this.SpectroShowGraphicsCheck);
            this.tabSpectro.Controls.Add(this.SpectroWidthLabel);
            this.tabSpectro.Controls.Add(this.SpectroBgWidth);
            this.tabSpectro.Controls.Add(this.SpectroBgSpeed);
            this.tabSpectro.Controls.Add(this.SpectroSpeedLabel);
            this.tabSpectro.Location = new System.Drawing.Point(4, 22);
            this.tabSpectro.Name = "tabSpectro";
            this.tabSpectro.Padding = new System.Windows.Forms.Padding(3);
            this.tabSpectro.Size = new System.Drawing.Size(696, 360);
            this.tabSpectro.TabIndex = 0;
            this.tabSpectro.Text = "Spectro";
            this.tabSpectro.UseVisualStyleBackColor = true;
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.Effect_Float_FrequencyLabel);
            this.tabEffects.Controls.Add(this.Effect_Float_DurationLabel);
            this.tabEffects.Controls.Add(this.Effect_Float_DurationUD);
            this.tabEffects.Controls.Add(this.Effect_Float_FrequencyUD);
            this.tabEffects.Controls.Add(this.Effect_Float_EndGB);
            this.tabEffects.Controls.Add(this.Effect_Float_StartGB);
            this.tabEffects.Controls.Add(this.EffectsStopButton);
            this.tabEffects.Controls.Add(this.EffectsStartButton);
            this.tabEffects.Controls.Add(this.EffectTabControl);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Size = new System.Drawing.Size(696, 360);
            this.tabEffects.TabIndex = 3;
            this.tabEffects.Text = "Effects";
            this.tabEffects.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_FrequencyLabel
            // 
            this.Effect_Float_FrequencyLabel.AutoSize = true;
            this.Effect_Float_FrequencyLabel.Location = new System.Drawing.Point(176, 295);
            this.Effect_Float_FrequencyLabel.Name = "Effect_Float_FrequencyLabel";
            this.Effect_Float_FrequencyLabel.Size = new System.Drawing.Size(72, 13);
            this.Effect_Float_FrequencyLabel.TabIndex = 5;
            this.Effect_Float_FrequencyLabel.Text = "Update Delay";
            // 
            // Effect_Float_DurationLabel
            // 
            this.Effect_Float_DurationLabel.AutoSize = true;
            this.Effect_Float_DurationLabel.Location = new System.Drawing.Point(68, 295);
            this.Effect_Float_DurationLabel.Name = "Effect_Float_DurationLabel";
            this.Effect_Float_DurationLabel.Size = new System.Drawing.Size(47, 13);
            this.Effect_Float_DurationLabel.TabIndex = 4;
            this.Effect_Float_DurationLabel.Text = "Duration";
            // 
            // Effect_Float_DurationUD
            // 
            this.Effect_Float_DurationUD.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Effect_Float_DurationUD.Location = new System.Drawing.Point(13, 293);
            this.Effect_Float_DurationUD.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.Effect_Float_DurationUD.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.Effect_Float_DurationUD.Name = "Effect_Float_DurationUD";
            this.Effect_Float_DurationUD.Size = new System.Drawing.Size(49, 20);
            this.Effect_Float_DurationUD.TabIndex = 1;
            this.Effect_Float_DurationUD.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.Effect_Float_DurationUD.ValueChanged += new System.EventHandler(this.Effects_RandomLights_DurationUD_ValueChanged);
            // 
            // Effect_Float_FrequencyUD
            // 
            this.Effect_Float_FrequencyUD.Location = new System.Drawing.Point(121, 293);
            this.Effect_Float_FrequencyUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Effect_Float_FrequencyUD.Name = "Effect_Float_FrequencyUD";
            this.Effect_Float_FrequencyUD.Size = new System.Drawing.Size(49, 20);
            this.Effect_Float_FrequencyUD.TabIndex = 2;
            this.Effect_Float_FrequencyUD.ValueChanged += new System.EventHandler(this.Effects_RandomLights_FrequencyUD_ValueChanged);
            // 
            // Effect_Float_EndGB
            // 
            this.Effect_Float_EndGB.Controls.Add(this.Effect_Float_End_BlueGB);
            this.Effect_Float_EndGB.Controls.Add(this.Effect_Float_End_GreenGB);
            this.Effect_Float_EndGB.Controls.Add(this.Effect_Float_End_RedGB);
            this.Effect_Float_EndGB.Controls.Add(this.Effect_Float_End_ColourButton);
            this.Effect_Float_EndGB.Controls.Add(this.Effect_Float_End_RadioRandom);
            this.Effect_Float_EndGB.Controls.Add(this.Effect_Float_End_RadioDefined);
            this.Effect_Float_EndGB.Location = new System.Drawing.Point(210, 39);
            this.Effect_Float_EndGB.Name = "Effect_Float_EndGB";
            this.Effect_Float_EndGB.Size = new System.Drawing.Size(176, 248);
            this.Effect_Float_EndGB.TabIndex = 16;
            this.Effect_Float_EndGB.TabStop = false;
            this.Effect_Float_EndGB.Text = "End Colour";
            // 
            // Effect_Float_End_BlueGB
            // 
            this.Effect_Float_End_BlueGB.Controls.Add(this.Effect_Float_End_Blue_HighUD);
            this.Effect_Float_End_BlueGB.Controls.Add(this.Effect_Float_End_Blue_LowUD);
            this.Effect_Float_End_BlueGB.Controls.Add(this.Effect_Float_End_Blue_HighButton);
            this.Effect_Float_End_BlueGB.Controls.Add(this.Effect_Float_End_Blue_LowButton);
            this.Effect_Float_End_BlueGB.Location = new System.Drawing.Point(12, 192);
            this.Effect_Float_End_BlueGB.Name = "Effect_Float_End_BlueGB";
            this.Effect_Float_End_BlueGB.Size = new System.Drawing.Size(152, 48);
            this.Effect_Float_End_BlueGB.TabIndex = 15;
            this.Effect_Float_End_BlueGB.TabStop = false;
            this.Effect_Float_End_BlueGB.Text = "Range of Blue";
            // 
            // Effect_Float_End_Blue_HighUD
            // 
            this.Effect_Float_End_Blue_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Effect_Float_End_Blue_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Blue_HighUD.Name = "Effect_Float_End_Blue_HighUD";
            this.Effect_Float_End_Blue_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_End_Blue_HighUD.TabIndex = 14;
            this.Effect_Float_End_Blue_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Blue_HighUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_End_UpdateColorBoxes);
            // 
            // Effect_Float_End_Blue_LowUD
            // 
            this.Effect_Float_End_Blue_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Effect_Float_End_Blue_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Blue_LowUD.Name = "Effect_Float_End_Blue_LowUD";
            this.Effect_Float_End_Blue_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_End_Blue_LowUD.TabIndex = 8;
            this.Effect_Float_End_Blue_LowUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_End_UpdateColorBoxes);
            // 
            // Effect_Float_End_Blue_HighButton
            // 
            this.Effect_Float_End_Blue_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_Blue_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Effect_Float_End_Blue_HighButton.Name = "Effect_Float_End_Blue_HighButton";
            this.Effect_Float_End_Blue_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_End_Blue_HighButton.TabIndex = 13;
            this.Effect_Float_End_Blue_HighButton.Tag = "";
            this.Effect_Float_End_Blue_HighButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_End_Blue_LowButton
            // 
            this.Effect_Float_End_Blue_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_Blue_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Effect_Float_End_Blue_LowButton.Name = "Effect_Float_End_Blue_LowButton";
            this.Effect_Float_End_Blue_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_End_Blue_LowButton.TabIndex = 12;
            this.Effect_Float_End_Blue_LowButton.Tag = "";
            this.Effect_Float_End_Blue_LowButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_End_GreenGB
            // 
            this.Effect_Float_End_GreenGB.Controls.Add(this.Effect_Float_End_Green_HighUD);
            this.Effect_Float_End_GreenGB.Controls.Add(this.Effect_Float_End_Green_LowUD);
            this.Effect_Float_End_GreenGB.Controls.Add(this.Effect_Float_End_Green_HighButton);
            this.Effect_Float_End_GreenGB.Controls.Add(this.Effect_Float_End_Green_LowButton);
            this.Effect_Float_End_GreenGB.Location = new System.Drawing.Point(12, 140);
            this.Effect_Float_End_GreenGB.Name = "Effect_Float_End_GreenGB";
            this.Effect_Float_End_GreenGB.Size = new System.Drawing.Size(152, 48);
            this.Effect_Float_End_GreenGB.TabIndex = 15;
            this.Effect_Float_End_GreenGB.TabStop = false;
            this.Effect_Float_End_GreenGB.Text = "Range of Green";
            // 
            // Effect_Float_End_Green_HighUD
            // 
            this.Effect_Float_End_Green_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Effect_Float_End_Green_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Green_HighUD.Name = "Effect_Float_End_Green_HighUD";
            this.Effect_Float_End_Green_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_End_Green_HighUD.TabIndex = 14;
            this.Effect_Float_End_Green_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Green_HighUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_End_UpdateColorBoxes);
            // 
            // Effect_Float_End_Green_LowUD
            // 
            this.Effect_Float_End_Green_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Effect_Float_End_Green_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Green_LowUD.Name = "Effect_Float_End_Green_LowUD";
            this.Effect_Float_End_Green_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_End_Green_LowUD.TabIndex = 8;
            this.Effect_Float_End_Green_LowUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_End_UpdateColorBoxes);
            // 
            // Effect_Float_End_Green_HighButton
            // 
            this.Effect_Float_End_Green_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_Green_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Effect_Float_End_Green_HighButton.Name = "Effect_Float_End_Green_HighButton";
            this.Effect_Float_End_Green_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_End_Green_HighButton.TabIndex = 13;
            this.Effect_Float_End_Green_HighButton.Tag = "";
            this.Effect_Float_End_Green_HighButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_End_Green_LowButton
            // 
            this.Effect_Float_End_Green_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_Green_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Effect_Float_End_Green_LowButton.Name = "Effect_Float_End_Green_LowButton";
            this.Effect_Float_End_Green_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_End_Green_LowButton.TabIndex = 12;
            this.Effect_Float_End_Green_LowButton.Tag = "";
            this.Effect_Float_End_Green_LowButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_End_RedGB
            // 
            this.Effect_Float_End_RedGB.Controls.Add(this.Effect_Float_End_Red_HighUD);
            this.Effect_Float_End_RedGB.Controls.Add(this.Effect_Float_End_Red_LowUD);
            this.Effect_Float_End_RedGB.Controls.Add(this.Effect_Float_End_Red_HighButton);
            this.Effect_Float_End_RedGB.Controls.Add(this.Effect_Float_End_Red_LowButton);
            this.Effect_Float_End_RedGB.Location = new System.Drawing.Point(12, 88);
            this.Effect_Float_End_RedGB.Name = "Effect_Float_End_RedGB";
            this.Effect_Float_End_RedGB.Size = new System.Drawing.Size(152, 48);
            this.Effect_Float_End_RedGB.TabIndex = 12;
            this.Effect_Float_End_RedGB.TabStop = false;
            this.Effect_Float_End_RedGB.Text = "Range of Red";
            // 
            // Effect_Float_End_Red_HighUD
            // 
            this.Effect_Float_End_Red_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Effect_Float_End_Red_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Red_HighUD.Name = "Effect_Float_End_Red_HighUD";
            this.Effect_Float_End_Red_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_End_Red_HighUD.TabIndex = 14;
            this.Effect_Float_End_Red_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Red_HighUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_End_UpdateColorBoxes);
            // 
            // Effect_Float_End_Red_LowUD
            // 
            this.Effect_Float_End_Red_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Effect_Float_End_Red_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_End_Red_LowUD.Name = "Effect_Float_End_Red_LowUD";
            this.Effect_Float_End_Red_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_End_Red_LowUD.TabIndex = 8;
            this.Effect_Float_End_Red_LowUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_End_UpdateColorBoxes);
            // 
            // Effect_Float_End_Red_HighButton
            // 
            this.Effect_Float_End_Red_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_Red_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Effect_Float_End_Red_HighButton.Name = "Effect_Float_End_Red_HighButton";
            this.Effect_Float_End_Red_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_End_Red_HighButton.TabIndex = 13;
            this.Effect_Float_End_Red_HighButton.Tag = "";
            this.Effect_Float_End_Red_HighButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_End_Red_LowButton
            // 
            this.Effect_Float_End_Red_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_Red_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Effect_Float_End_Red_LowButton.Name = "Effect_Float_End_Red_LowButton";
            this.Effect_Float_End_Red_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_End_Red_LowButton.TabIndex = 12;
            this.Effect_Float_End_Red_LowButton.Tag = "";
            this.Effect_Float_End_Red_LowButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_End_ColourButton
            // 
            this.Effect_Float_End_ColourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_End_ColourButton.Location = new System.Drawing.Point(118, 19);
            this.Effect_Float_End_ColourButton.Name = "Effect_Float_End_ColourButton";
            this.Effect_Float_End_ColourButton.Size = new System.Drawing.Size(46, 17);
            this.Effect_Float_End_ColourButton.TabIndex = 11;
            this.Effect_Float_End_ColourButton.Tag = "";
            this.Effect_Float_End_ColourButton.UseVisualStyleBackColor = true;
            this.Effect_Float_End_ColourButton.Click += new System.EventHandler(this.Effects_RandomLights_ColourButton_Click);
            // 
            // Effect_Float_End_RadioRandom
            // 
            this.Effect_Float_End_RadioRandom.AutoSize = true;
            this.Effect_Float_End_RadioRandom.Location = new System.Drawing.Point(12, 42);
            this.Effect_Float_End_RadioRandom.Name = "Effect_Float_End_RadioRandom";
            this.Effect_Float_End_RadioRandom.Size = new System.Drawing.Size(98, 17);
            this.Effect_Float_End_RadioRandom.TabIndex = 1;
            this.Effect_Float_End_RadioRandom.Text = "Random Colour";
            this.Effect_Float_End_RadioRandom.UseVisualStyleBackColor = true;
            this.Effect_Float_End_RadioRandom.CheckedChanged += new System.EventHandler(this.Effects_RandomLights_End_RadioCheckedChanged);
            // 
            // Effect_Float_End_RadioDefined
            // 
            this.Effect_Float_End_RadioDefined.AutoSize = true;
            this.Effect_Float_End_RadioDefined.Checked = true;
            this.Effect_Float_End_RadioDefined.Location = new System.Drawing.Point(12, 19);
            this.Effect_Float_End_RadioDefined.Name = "Effect_Float_End_RadioDefined";
            this.Effect_Float_End_RadioDefined.Size = new System.Drawing.Size(95, 17);
            this.Effect_Float_End_RadioDefined.TabIndex = 0;
            this.Effect_Float_End_RadioDefined.TabStop = true;
            this.Effect_Float_End_RadioDefined.Text = "Defined Colour";
            this.Effect_Float_End_RadioDefined.UseVisualStyleBackColor = true;
            this.Effect_Float_End_RadioDefined.CheckedChanged += new System.EventHandler(this.Effects_RandomLights_End_RadioCheckedChanged);
            // 
            // Effect_Float_StartGB
            // 
            this.Effect_Float_StartGB.Controls.Add(this.Effect_Float_Start_BlueGB);
            this.Effect_Float_StartGB.Controls.Add(this.Effect_Float_Start_GreenGB);
            this.Effect_Float_StartGB.Controls.Add(this.Effect_Float_Start_RedGB);
            this.Effect_Float_StartGB.Controls.Add(this.Effect_Float_Start_ColourButton);
            this.Effect_Float_StartGB.Controls.Add(this.Effect_Float_Start_RadioRandom);
            this.Effect_Float_StartGB.Controls.Add(this.Effect_Float_Start_RadioDefined);
            this.Effect_Float_StartGB.Location = new System.Drawing.Point(20, 39);
            this.Effect_Float_StartGB.Name = "Effect_Float_StartGB";
            this.Effect_Float_StartGB.Size = new System.Drawing.Size(176, 248);
            this.Effect_Float_StartGB.TabIndex = 7;
            this.Effect_Float_StartGB.TabStop = false;
            this.Effect_Float_StartGB.Text = "Start Colour";
            // 
            // Effect_Float_Start_BlueGB
            // 
            this.Effect_Float_Start_BlueGB.Controls.Add(this.Effect_Float_Start_Blue_HighUD);
            this.Effect_Float_Start_BlueGB.Controls.Add(this.Effect_Float_Start_Blue_LowUD);
            this.Effect_Float_Start_BlueGB.Controls.Add(this.Effect_Float_Start_Blue_HighButton);
            this.Effect_Float_Start_BlueGB.Controls.Add(this.Effect_Float_Start_Blue_LowButton);
            this.Effect_Float_Start_BlueGB.Location = new System.Drawing.Point(12, 192);
            this.Effect_Float_Start_BlueGB.Name = "Effect_Float_Start_BlueGB";
            this.Effect_Float_Start_BlueGB.Size = new System.Drawing.Size(152, 48);
            this.Effect_Float_Start_BlueGB.TabIndex = 15;
            this.Effect_Float_Start_BlueGB.TabStop = false;
            this.Effect_Float_Start_BlueGB.Text = "Range of Blue";
            // 
            // Effect_Float_Start_Blue_HighUD
            // 
            this.Effect_Float_Start_Blue_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Effect_Float_Start_Blue_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Blue_HighUD.Name = "Effect_Float_Start_Blue_HighUD";
            this.Effect_Float_Start_Blue_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_Start_Blue_HighUD.TabIndex = 14;
            this.Effect_Float_Start_Blue_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Blue_HighUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_Start_UpdateColorBoxes);
            // 
            // Effect_Float_Start_Blue_LowUD
            // 
            this.Effect_Float_Start_Blue_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Effect_Float_Start_Blue_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Blue_LowUD.Name = "Effect_Float_Start_Blue_LowUD";
            this.Effect_Float_Start_Blue_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_Start_Blue_LowUD.TabIndex = 8;
            this.Effect_Float_Start_Blue_LowUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_Start_UpdateColorBoxes);
            // 
            // Effect_Float_Start_Blue_HighButton
            // 
            this.Effect_Float_Start_Blue_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_Blue_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Effect_Float_Start_Blue_HighButton.Name = "Effect_Float_Start_Blue_HighButton";
            this.Effect_Float_Start_Blue_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_Start_Blue_HighButton.TabIndex = 13;
            this.Effect_Float_Start_Blue_HighButton.Tag = "";
            this.Effect_Float_Start_Blue_HighButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_Start_Blue_LowButton
            // 
            this.Effect_Float_Start_Blue_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_Blue_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Effect_Float_Start_Blue_LowButton.Name = "Effect_Float_Start_Blue_LowButton";
            this.Effect_Float_Start_Blue_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_Start_Blue_LowButton.TabIndex = 12;
            this.Effect_Float_Start_Blue_LowButton.Tag = "";
            this.Effect_Float_Start_Blue_LowButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_Start_GreenGB
            // 
            this.Effect_Float_Start_GreenGB.Controls.Add(this.Effect_Float_Start_Green_HighUD);
            this.Effect_Float_Start_GreenGB.Controls.Add(this.Effect_Float_Start_Green_LowUD);
            this.Effect_Float_Start_GreenGB.Controls.Add(this.Effect_Float_Start_Green_HighButton);
            this.Effect_Float_Start_GreenGB.Controls.Add(this.Effect_Float_Start_Green_LowButton);
            this.Effect_Float_Start_GreenGB.Location = new System.Drawing.Point(12, 140);
            this.Effect_Float_Start_GreenGB.Name = "Effect_Float_Start_GreenGB";
            this.Effect_Float_Start_GreenGB.Size = new System.Drawing.Size(152, 48);
            this.Effect_Float_Start_GreenGB.TabIndex = 15;
            this.Effect_Float_Start_GreenGB.TabStop = false;
            this.Effect_Float_Start_GreenGB.Text = "Range of Green";
            // 
            // Effect_Float_Start_Green_HighUD
            // 
            this.Effect_Float_Start_Green_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Effect_Float_Start_Green_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Green_HighUD.Name = "Effect_Float_Start_Green_HighUD";
            this.Effect_Float_Start_Green_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_Start_Green_HighUD.TabIndex = 14;
            this.Effect_Float_Start_Green_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Green_HighUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_Start_UpdateColorBoxes);
            // 
            // Effect_Float_Start_Green_LowUD
            // 
            this.Effect_Float_Start_Green_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Effect_Float_Start_Green_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Green_LowUD.Name = "Effect_Float_Start_Green_LowUD";
            this.Effect_Float_Start_Green_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_Start_Green_LowUD.TabIndex = 8;
            this.Effect_Float_Start_Green_LowUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_Start_UpdateColorBoxes);
            // 
            // Effect_Float_Start_Green_HighButton
            // 
            this.Effect_Float_Start_Green_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_Green_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Effect_Float_Start_Green_HighButton.Name = "Effect_Float_Start_Green_HighButton";
            this.Effect_Float_Start_Green_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_Start_Green_HighButton.TabIndex = 13;
            this.Effect_Float_Start_Green_HighButton.Tag = "";
            this.Effect_Float_Start_Green_HighButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_Start_Green_LowButton
            // 
            this.Effect_Float_Start_Green_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_Green_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Effect_Float_Start_Green_LowButton.Name = "Effect_Float_Start_Green_LowButton";
            this.Effect_Float_Start_Green_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_Start_Green_LowButton.TabIndex = 12;
            this.Effect_Float_Start_Green_LowButton.Tag = "";
            this.Effect_Float_Start_Green_LowButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_Start_RedGB
            // 
            this.Effect_Float_Start_RedGB.Controls.Add(this.Effect_Float_Start_Red_HighUD);
            this.Effect_Float_Start_RedGB.Controls.Add(this.Effect_Float_Start_Red_LowUD);
            this.Effect_Float_Start_RedGB.Controls.Add(this.Effect_Float_Start_Red_HighButton);
            this.Effect_Float_Start_RedGB.Controls.Add(this.Effect_Float_Start_Red_LowButton);
            this.Effect_Float_Start_RedGB.Location = new System.Drawing.Point(12, 88);
            this.Effect_Float_Start_RedGB.Name = "Effect_Float_Start_RedGB";
            this.Effect_Float_Start_RedGB.Size = new System.Drawing.Size(152, 48);
            this.Effect_Float_Start_RedGB.TabIndex = 12;
            this.Effect_Float_Start_RedGB.TabStop = false;
            this.Effect_Float_Start_RedGB.Text = "Range of Red";
            // 
            // Effect_Float_Start_Red_HighUD
            // 
            this.Effect_Float_Start_Red_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Effect_Float_Start_Red_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Red_HighUD.Name = "Effect_Float_Start_Red_HighUD";
            this.Effect_Float_Start_Red_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_Start_Red_HighUD.TabIndex = 14;
            this.Effect_Float_Start_Red_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Red_HighUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_Start_UpdateColorBoxes);
            // 
            // Effect_Float_Start_Red_LowUD
            // 
            this.Effect_Float_Start_Red_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Effect_Float_Start_Red_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Effect_Float_Start_Red_LowUD.Name = "Effect_Float_Start_Red_LowUD";
            this.Effect_Float_Start_Red_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Effect_Float_Start_Red_LowUD.TabIndex = 8;
            this.Effect_Float_Start_Red_LowUD.ValueChanged += new System.EventHandler(this.Effect_RandomLights_Start_UpdateColorBoxes);
            // 
            // Effect_Float_Start_Red_HighButton
            // 
            this.Effect_Float_Start_Red_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_Red_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Effect_Float_Start_Red_HighButton.Name = "Effect_Float_Start_Red_HighButton";
            this.Effect_Float_Start_Red_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_Start_Red_HighButton.TabIndex = 13;
            this.Effect_Float_Start_Red_HighButton.Tag = "";
            this.Effect_Float_Start_Red_HighButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_Start_Red_LowButton
            // 
            this.Effect_Float_Start_Red_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_Red_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Effect_Float_Start_Red_LowButton.Name = "Effect_Float_Start_Red_LowButton";
            this.Effect_Float_Start_Red_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Effect_Float_Start_Red_LowButton.TabIndex = 12;
            this.Effect_Float_Start_Red_LowButton.Tag = "";
            this.Effect_Float_Start_Red_LowButton.UseVisualStyleBackColor = true;
            // 
            // Effect_Float_Start_ColourButton
            // 
            this.Effect_Float_Start_ColourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Effect_Float_Start_ColourButton.Location = new System.Drawing.Point(118, 19);
            this.Effect_Float_Start_ColourButton.Name = "Effect_Float_Start_ColourButton";
            this.Effect_Float_Start_ColourButton.Size = new System.Drawing.Size(46, 17);
            this.Effect_Float_Start_ColourButton.TabIndex = 11;
            this.Effect_Float_Start_ColourButton.Tag = "";
            this.Effect_Float_Start_ColourButton.UseVisualStyleBackColor = true;
            this.Effect_Float_Start_ColourButton.Click += new System.EventHandler(this.Effects_RandomLights_ColourButton_Click);
            // 
            // Effect_Float_Start_RadioRandom
            // 
            this.Effect_Float_Start_RadioRandom.AutoSize = true;
            this.Effect_Float_Start_RadioRandom.Location = new System.Drawing.Point(12, 42);
            this.Effect_Float_Start_RadioRandom.Name = "Effect_Float_Start_RadioRandom";
            this.Effect_Float_Start_RadioRandom.Size = new System.Drawing.Size(98, 17);
            this.Effect_Float_Start_RadioRandom.TabIndex = 1;
            this.Effect_Float_Start_RadioRandom.Text = "Random Colour";
            this.Effect_Float_Start_RadioRandom.UseVisualStyleBackColor = true;
            this.Effect_Float_Start_RadioRandom.CheckedChanged += new System.EventHandler(this.Effects_RandomLights_Start_RadioCheckedChanged);
            // 
            // Effect_Float_Start_RadioDefined
            // 
            this.Effect_Float_Start_RadioDefined.AutoSize = true;
            this.Effect_Float_Start_RadioDefined.Checked = true;
            this.Effect_Float_Start_RadioDefined.Location = new System.Drawing.Point(12, 19);
            this.Effect_Float_Start_RadioDefined.Name = "Effect_Float_Start_RadioDefined";
            this.Effect_Float_Start_RadioDefined.Size = new System.Drawing.Size(95, 17);
            this.Effect_Float_Start_RadioDefined.TabIndex = 0;
            this.Effect_Float_Start_RadioDefined.TabStop = true;
            this.Effect_Float_Start_RadioDefined.Text = "Defined Colour";
            this.Effect_Float_Start_RadioDefined.UseVisualStyleBackColor = true;
            this.Effect_Float_Start_RadioDefined.CheckedChanged += new System.EventHandler(this.Effects_RandomLights_Start_RadioCheckedChanged);
            // 
            // EffectsStopButton
            // 
            this.EffectsStopButton.Location = new System.Drawing.Point(323, 330);
            this.EffectsStopButton.Name = "EffectsStopButton";
            this.EffectsStopButton.Size = new System.Drawing.Size(75, 23);
            this.EffectsStopButton.TabIndex = 2;
            this.EffectsStopButton.Text = "Stop";
            this.EffectsStopButton.UseVisualStyleBackColor = true;
            this.EffectsStopButton.Click += new System.EventHandler(this.StopEffects);
            // 
            // EffectsStartButton
            // 
            this.EffectsStartButton.Location = new System.Drawing.Point(7, 330);
            this.EffectsStartButton.Name = "EffectsStartButton";
            this.EffectsStartButton.Size = new System.Drawing.Size(75, 23);
            this.EffectsStartButton.TabIndex = 0;
            this.EffectsStartButton.Text = "Start";
            this.EffectsStartButton.UseVisualStyleBackColor = true;
            this.EffectsStartButton.Click += new System.EventHandler(this.EffectsStartButton_Click);
            // 
            // EffectTabControl
            // 
            this.EffectTabControl.Controls.Add(this.EffectTab_RandomLights);
            this.EffectTabControl.Controls.Add(this.EffectTab_Rainfall);
            this.EffectTabControl.Location = new System.Drawing.Point(3, 10);
            this.EffectTabControl.Name = "EffectTabControl";
            this.EffectTabControl.SelectedIndex = 0;
            this.EffectTabControl.Size = new System.Drawing.Size(399, 314);
            this.EffectTabControl.TabIndex = 1;
            this.EffectTabControl.SelectedIndexChanged += new System.EventHandler(this.EffectTabControl_SelectedIndexChanged);
            // 
            // EffectTab_RandomLights
            // 
            this.EffectTab_RandomLights.Location = new System.Drawing.Point(4, 22);
            this.EffectTab_RandomLights.Name = "EffectTab_RandomLights";
            this.EffectTab_RandomLights.Padding = new System.Windows.Forms.Padding(3);
            this.EffectTab_RandomLights.Size = new System.Drawing.Size(391, 288);
            this.EffectTab_RandomLights.TabIndex = 0;
            this.EffectTab_RandomLights.Text = "Random Lights";
            this.EffectTab_RandomLights.UseVisualStyleBackColor = true;
            // 
            // EffectTab_Rainfall
            // 
            this.EffectTab_Rainfall.Location = new System.Drawing.Point(4, 22);
            this.EffectTab_Rainfall.Name = "EffectTab_Rainfall";
            this.EffectTab_Rainfall.Size = new System.Drawing.Size(391, 288);
            this.EffectTab_Rainfall.TabIndex = 1;
            this.EffectTab_Rainfall.Text = "Rainfall";
            this.EffectTab_Rainfall.UseVisualStyleBackColor = true;
            // 
            // tabStatic
            // 
            this.tabStatic.Controls.Add(this.UseToggleColoursCheck);
            this.tabStatic.Controls.Add(this.ToggleMuteLabel);
            this.tabStatic.Controls.Add(this.ToggleScrollLabel);
            this.tabStatic.Controls.Add(this.ToggleScrollOff);
            this.tabStatic.Controls.Add(this.ToggleMuteOff);
            this.tabStatic.Controls.Add(this.ToggleNumOff);
            this.tabStatic.Controls.Add(this.ToggleCapsOff);
            this.tabStatic.Controls.Add(this.ToggleNumLabel);
            this.tabStatic.Controls.Add(this.ToggleCapsLabel);
            this.tabStatic.Controls.Add(this.ToggleNumOn);
            this.tabStatic.Controls.Add(this.ToggleScrollOn);
            this.tabStatic.Controls.Add(this.ToggleCapsOn);
            this.tabStatic.Controls.Add(this.ToggleMuteOn);
            this.tabStatic.Controls.Add(this.StaticMouseLightsGB);
            this.tabStatic.Controls.Add(this.StaticProfileListCB);
            this.tabStatic.Controls.Add(this.StaticSaveProfileAsButton);
            this.tabStatic.Controls.Add(this.StaticClearButton);
            this.tabStatic.Controls.Add(this.StaticCopyPasteColor);
            this.tabStatic.Controls.Add(this.StaticPasteButton);
            this.tabStatic.Controls.Add(this.StaticCopyButton);
            this.tabStatic.Controls.Add(this.StaticNewProfileButton);
            this.tabStatic.Controls.Add(this.StaticUpdateKeyboardButton);
            this.tabStatic.Controls.Add(this.StaticDeleteKeysButton);
            this.tabStatic.Controls.Add(this.StaticSaveProfileButton);
            this.tabStatic.Controls.Add(this.StaticLoadProfileButton);
            this.tabStatic.Controls.Add(this.StaticKeyboardImageBox);
            this.tabStatic.Controls.Add(this.StaticGetKeyboardImage);
            this.tabStatic.Location = new System.Drawing.Point(4, 22);
            this.tabStatic.Name = "tabStatic";
            this.tabStatic.Size = new System.Drawing.Size(696, 360);
            this.tabStatic.TabIndex = 4;
            this.tabStatic.Text = "Static Keys";
            this.tabStatic.UseVisualStyleBackColor = true;
            // 
            // ToggleNumOn
            // 
            this.ToggleNumOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleNumOn.Location = new System.Drawing.Point(322, 330);
            this.ToggleNumOn.Name = "ToggleNumOn";
            this.ToggleNumOn.Size = new System.Drawing.Size(36, 23);
            this.ToggleNumOn.TabIndex = 71;
            this.ToggleNumOn.Tag = "251";
            this.ToggleNumOn.Text = "On";
            this.ToggleNumOn.UseVisualStyleBackColor = true;
            this.ToggleNumOn.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleScrollOn
            // 
            this.ToggleScrollOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleScrollOn.Location = new System.Drawing.Point(178, 329);
            this.ToggleScrollOn.Name = "ToggleScrollOn";
            this.ToggleScrollOn.Size = new System.Drawing.Size(36, 23);
            this.ToggleScrollOn.TabIndex = 70;
            this.ToggleScrollOn.Tag = "253";
            this.ToggleScrollOn.Text = "On";
            this.ToggleScrollOn.UseVisualStyleBackColor = true;
            this.ToggleScrollOn.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleCapsOn
            // 
            this.ToggleCapsOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleCapsOn.Location = new System.Drawing.Point(49, 329);
            this.ToggleCapsOn.Name = "ToggleCapsOn";
            this.ToggleCapsOn.Size = new System.Drawing.Size(36, 23);
            this.ToggleCapsOn.TabIndex = 69;
            this.ToggleCapsOn.Tag = "255";
            this.ToggleCapsOn.Text = "On";
            this.ToggleCapsOn.UseVisualStyleBackColor = true;
            this.ToggleCapsOn.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleMuteOn
            // 
            this.ToggleMuteOn.Enabled = false;
            this.ToggleMuteOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleMuteOn.Location = new System.Drawing.Point(451, 330);
            this.ToggleMuteOn.Name = "ToggleMuteOn";
            this.ToggleMuteOn.Size = new System.Drawing.Size(36, 23);
            this.ToggleMuteOn.TabIndex = 68;
            this.ToggleMuteOn.Tag = "249";
            this.ToggleMuteOn.Text = "On";
            this.ToggleMuteOn.UseVisualStyleBackColor = true;
            this.ToggleMuteOn.Visible = false;
            this.ToggleMuteOn.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // StaticMouseLightsGB
            // 
            this.StaticMouseLightsGB.Controls.Add(this.StaticMouseLight4);
            this.StaticMouseLightsGB.Controls.Add(this.StaticMouseLight1);
            this.StaticMouseLightsGB.Controls.Add(this.StaticMouseLight2);
            this.StaticMouseLightsGB.Controls.Add(this.StaticMouseLight3);
            this.StaticMouseLightsGB.Location = new System.Drawing.Point(365, 243);
            this.StaticMouseLightsGB.Name = "StaticMouseLightsGB";
            this.StaticMouseLightsGB.Size = new System.Drawing.Size(183, 79);
            this.StaticMouseLightsGB.TabIndex = 64;
            this.StaticMouseLightsGB.TabStop = false;
            this.StaticMouseLightsGB.Text = "Mouse Lights";
            // 
            // StaticMouseLight4
            // 
            this.StaticMouseLight4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticMouseLight4.Location = new System.Drawing.Point(94, 48);
            this.StaticMouseLight4.Name = "StaticMouseLight4";
            this.StaticMouseLight4.Size = new System.Drawing.Size(82, 23);
            this.StaticMouseLight4.TabIndex = 67;
            this.StaticMouseLight4.Tag = "3";
            this.StaticMouseLight4.UseVisualStyleBackColor = true;
            this.StaticMouseLight4.Click += new System.EventHandler(this.StaticMouseColor_Click);
            // 
            // StaticMouseLight1
            // 
            this.StaticMouseLight1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticMouseLight1.Location = new System.Drawing.Point(6, 19);
            this.StaticMouseLight1.Name = "StaticMouseLight1";
            this.StaticMouseLight1.Size = new System.Drawing.Size(82, 23);
            this.StaticMouseLight1.TabIndex = 64;
            this.StaticMouseLight1.Tag = "0";
            this.StaticMouseLight1.UseVisualStyleBackColor = true;
            this.StaticMouseLight1.Click += new System.EventHandler(this.StaticMouseColor_Click);
            // 
            // StaticMouseLight2
            // 
            this.StaticMouseLight2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticMouseLight2.Location = new System.Drawing.Point(6, 48);
            this.StaticMouseLight2.Name = "StaticMouseLight2";
            this.StaticMouseLight2.Size = new System.Drawing.Size(82, 23);
            this.StaticMouseLight2.TabIndex = 66;
            this.StaticMouseLight2.Tag = "1";
            this.StaticMouseLight2.UseVisualStyleBackColor = true;
            this.StaticMouseLight2.Click += new System.EventHandler(this.StaticMouseColor_Click);
            // 
            // StaticMouseLight3
            // 
            this.StaticMouseLight3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticMouseLight3.Location = new System.Drawing.Point(94, 19);
            this.StaticMouseLight3.Name = "StaticMouseLight3";
            this.StaticMouseLight3.Size = new System.Drawing.Size(82, 23);
            this.StaticMouseLight3.TabIndex = 65;
            this.StaticMouseLight3.Tag = "2";
            this.StaticMouseLight3.UseVisualStyleBackColor = true;
            this.StaticMouseLight3.Click += new System.EventHandler(this.StaticMouseColor_Click);
            // 
            // StaticProfileListCB
            // 
            this.StaticProfileListCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StaticProfileListCB.FormattingEnabled = true;
            this.StaticProfileListCB.Location = new System.Drawing.Point(15, 270);
            this.StaticProfileListCB.Name = "StaticProfileListCB";
            this.StaticProfileListCB.Size = new System.Drawing.Size(156, 21);
            this.StaticProfileListCB.TabIndex = 63;
            // 
            // StaticSaveProfileAsButton
            // 
            this.StaticSaveProfileAsButton.Location = new System.Drawing.Point(177, 270);
            this.StaticSaveProfileAsButton.Name = "StaticSaveProfileAsButton";
            this.StaticSaveProfileAsButton.Size = new System.Drawing.Size(75, 23);
            this.StaticSaveProfileAsButton.TabIndex = 60;
            this.StaticSaveProfileAsButton.Text = "Save As...";
            this.StaticSaveProfileAsButton.UseVisualStyleBackColor = true;
            this.StaticSaveProfileAsButton.Click += new System.EventHandler(this.StaticSaveProfileAsButton_Click);
            // 
            // StaticClearButton
            // 
            this.StaticClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticClearButton.Location = new System.Drawing.Point(258, 299);
            this.StaticClearButton.Name = "StaticClearButton";
            this.StaticClearButton.Size = new System.Drawing.Size(82, 23);
            this.StaticClearButton.TabIndex = 11;
            this.StaticClearButton.Text = "Clear";
            this.StaticClearButton.UseVisualStyleBackColor = true;
            this.StaticClearButton.Click += new System.EventHandler(this.StaticClearButton_Click);
            // 
            // StaticCopyPasteColor
            // 
            this.StaticCopyPasteColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticCopyPasteColor.Location = new System.Drawing.Point(288, 241);
            this.StaticCopyPasteColor.Name = "StaticCopyPasteColor";
            this.StaticCopyPasteColor.Size = new System.Drawing.Size(52, 52);
            this.StaticCopyPasteColor.TabIndex = 10;
            this.StaticCopyPasteColor.Tag = "";
            this.StaticCopyPasteColor.UseVisualStyleBackColor = true;
            this.StaticCopyPasteColor.Click += new System.EventHandler(this.OpenColorPicker);
            // 
            // StaticPasteButton
            // 
            this.StaticPasteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticPasteButton.Image = global::RGBKeyboardSpectrograph.Properties.Resources.paintbucket;
            this.StaticPasteButton.Location = new System.Drawing.Point(258, 270);
            this.StaticPasteButton.Name = "StaticPasteButton";
            this.StaticPasteButton.Size = new System.Drawing.Size(24, 23);
            this.StaticPasteButton.TabIndex = 9;
            this.StaticPasteButton.UseVisualStyleBackColor = true;
            this.StaticPasteButton.Click += new System.EventHandler(this.StaticPasteButton_Click);
            // 
            // StaticCopyButton
            // 
            this.StaticCopyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StaticCopyButton.Image = global::RGBKeyboardSpectrograph.Properties.Resources.eyedropper;
            this.StaticCopyButton.Location = new System.Drawing.Point(258, 241);
            this.StaticCopyButton.Name = "StaticCopyButton";
            this.StaticCopyButton.Size = new System.Drawing.Size(24, 23);
            this.StaticCopyButton.TabIndex = 8;
            this.StaticCopyButton.UseVisualStyleBackColor = true;
            this.StaticCopyButton.Click += new System.EventHandler(this.StaticCopyButton_Click);
            // 
            // StaticNewProfileButton
            // 
            this.StaticNewProfileButton.Location = new System.Drawing.Point(15, 241);
            this.StaticNewProfileButton.Name = "StaticNewProfileButton";
            this.StaticNewProfileButton.Size = new System.Drawing.Size(75, 23);
            this.StaticNewProfileButton.TabIndex = 7;
            this.StaticNewProfileButton.Text = "Clear Profile";
            this.StaticNewProfileButton.UseVisualStyleBackColor = true;
            this.StaticNewProfileButton.Click += new System.EventHandler(this.NewProfileButton_Click);
            // 
            // StaticUpdateKeyboardButton
            // 
            this.StaticUpdateKeyboardButton.Location = new System.Drawing.Point(610, 305);
            this.StaticUpdateKeyboardButton.Name = "StaticUpdateKeyboardButton";
            this.StaticUpdateKeyboardButton.Size = new System.Drawing.Size(75, 23);
            this.StaticUpdateKeyboardButton.TabIndex = 6;
            this.StaticUpdateKeyboardButton.Text = "Update Out";
            this.StaticUpdateKeyboardButton.UseVisualStyleBackColor = true;
            this.StaticUpdateKeyboardButton.Visible = false;
            this.StaticUpdateKeyboardButton.Click += new System.EventHandler(this.UpdateKeyboardButton_Click);
            // 
            // StaticDeleteKeysButton
            // 
            this.StaticDeleteKeysButton.Location = new System.Drawing.Point(610, 280);
            this.StaticDeleteKeysButton.Name = "StaticDeleteKeysButton";
            this.StaticDeleteKeysButton.Size = new System.Drawing.Size(75, 23);
            this.StaticDeleteKeysButton.TabIndex = 5;
            this.StaticDeleteKeysButton.Text = "Delete Keys";
            this.StaticDeleteKeysButton.UseVisualStyleBackColor = true;
            this.StaticDeleteKeysButton.Visible = false;
            this.StaticDeleteKeysButton.Click += new System.EventHandler(this.DeleteKeys_Click);
            // 
            // StaticSaveProfileButton
            // 
            this.StaticSaveProfileButton.Location = new System.Drawing.Point(177, 241);
            this.StaticSaveProfileButton.Name = "StaticSaveProfileButton";
            this.StaticSaveProfileButton.Size = new System.Drawing.Size(75, 23);
            this.StaticSaveProfileButton.TabIndex = 4;
            this.StaticSaveProfileButton.Text = "Save Profile";
            this.StaticSaveProfileButton.UseVisualStyleBackColor = true;
            this.StaticSaveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);
            // 
            // StaticLoadProfileButton
            // 
            this.StaticLoadProfileButton.Location = new System.Drawing.Point(96, 241);
            this.StaticLoadProfileButton.Name = "StaticLoadProfileButton";
            this.StaticLoadProfileButton.Size = new System.Drawing.Size(75, 23);
            this.StaticLoadProfileButton.TabIndex = 3;
            this.StaticLoadProfileButton.Text = "Load Profile";
            this.StaticLoadProfileButton.UseVisualStyleBackColor = true;
            this.StaticLoadProfileButton.Click += new System.EventHandler(this.LoadProfileButton_Click);
            // 
            // StaticKeyboardImageBox
            // 
            this.StaticKeyboardImageBox.Location = new System.Drawing.Point(15, 13);
            this.StaticKeyboardImageBox.Name = "StaticKeyboardImageBox";
            this.StaticKeyboardImageBox.Size = new System.Drawing.Size(660, 222);
            this.StaticKeyboardImageBox.TabIndex = 2;
            this.StaticKeyboardImageBox.TabStop = false;
            // 
            // StaticGetKeyboardImage
            // 
            this.StaticGetKeyboardImage.Location = new System.Drawing.Point(610, 254);
            this.StaticGetKeyboardImage.Name = "StaticGetKeyboardImage";
            this.StaticGetKeyboardImage.Size = new System.Drawing.Size(75, 23);
            this.StaticGetKeyboardImage.TabIndex = 1;
            this.StaticGetKeyboardImage.Text = "Get Image";
            this.StaticGetKeyboardImage.UseVisualStyleBackColor = true;
            this.StaticGetKeyboardImage.Visible = false;
            this.StaticGetKeyboardImage.Click += new System.EventHandler(this.StaticGetKeyboardImage_Click);
            // 
            // tabReactive
            // 
            this.tabReactive.Controls.Add(this.ReactiveTabControl);
            this.tabReactive.Controls.Add(this.ReactiveStopButton);
            this.tabReactive.Controls.Add(this.ReactiveStartButton);
            this.tabReactive.Location = new System.Drawing.Point(4, 22);
            this.tabReactive.Name = "tabReactive";
            this.tabReactive.Size = new System.Drawing.Size(696, 360);
            this.tabReactive.TabIndex = 5;
            this.tabReactive.Text = "Reactive";
            this.tabReactive.UseVisualStyleBackColor = true;
            // 
            // ReactiveTabControl
            // 
            this.ReactiveTabControl.Controls.Add(this.ReactiveTab_Reactive);
            this.ReactiveTabControl.Controls.Add(this.ReactiveTab_Heatmap);
            this.ReactiveTabControl.Location = new System.Drawing.Point(3, 10);
            this.ReactiveTabControl.Name = "ReactiveTabControl";
            this.ReactiveTabControl.SelectedIndex = 0;
            this.ReactiveTabControl.Size = new System.Drawing.Size(399, 314);
            this.ReactiveTabControl.TabIndex = 13;
            // 
            // ReactiveTab_Reactive
            // 
            this.ReactiveTab_Reactive.Controls.Add(this.Reactive_FrequencyLabel);
            this.ReactiveTab_Reactive.Controls.Add(this.Reactive_DurationLabel);
            this.ReactiveTab_Reactive.Controls.Add(this.Reactive_DurationUD);
            this.ReactiveTab_Reactive.Controls.Add(this.Reactive_FrequencyUD);
            this.ReactiveTab_Reactive.Controls.Add(this.Reactive_StartGB);
            this.ReactiveTab_Reactive.Controls.Add(this.Reactive_EndGB);
            this.ReactiveTab_Reactive.Location = new System.Drawing.Point(4, 22);
            this.ReactiveTab_Reactive.Name = "ReactiveTab_Reactive";
            this.ReactiveTab_Reactive.Padding = new System.Windows.Forms.Padding(3);
            this.ReactiveTab_Reactive.Size = new System.Drawing.Size(391, 288);
            this.ReactiveTab_Reactive.TabIndex = 0;
            this.ReactiveTab_Reactive.Text = "Reactive";
            this.ReactiveTab_Reactive.UseVisualStyleBackColor = true;
            // 
            // Reactive_FrequencyLabel
            // 
            this.Reactive_FrequencyLabel.AutoSize = true;
            this.Reactive_FrequencyLabel.Location = new System.Drawing.Point(169, 263);
            this.Reactive_FrequencyLabel.Name = "Reactive_FrequencyLabel";
            this.Reactive_FrequencyLabel.Size = new System.Drawing.Size(72, 13);
            this.Reactive_FrequencyLabel.TabIndex = 22;
            this.Reactive_FrequencyLabel.Text = "Update Delay";
            // 
            // Reactive_DurationLabel
            // 
            this.Reactive_DurationLabel.AutoSize = true;
            this.Reactive_DurationLabel.Location = new System.Drawing.Point(61, 263);
            this.Reactive_DurationLabel.Name = "Reactive_DurationLabel";
            this.Reactive_DurationLabel.Size = new System.Drawing.Size(47, 13);
            this.Reactive_DurationLabel.TabIndex = 21;
            this.Reactive_DurationLabel.Text = "Duration";
            // 
            // Reactive_DurationUD
            // 
            this.Reactive_DurationUD.Increment = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.Reactive_DurationUD.Location = new System.Drawing.Point(6, 261);
            this.Reactive_DurationUD.Maximum = new decimal(new int[] {
            800,
            0,
            0,
            0});
            this.Reactive_DurationUD.Minimum = new decimal(new int[] {
            40,
            0,
            0,
            0});
            this.Reactive_DurationUD.Name = "Reactive_DurationUD";
            this.Reactive_DurationUD.Size = new System.Drawing.Size(49, 20);
            this.Reactive_DurationUD.TabIndex = 19;
            this.Reactive_DurationUD.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.Reactive_DurationUD.ValueChanged += new System.EventHandler(this.Reactive_DurationUD_ValueChanged);
            // 
            // Reactive_FrequencyUD
            // 
            this.Reactive_FrequencyUD.Location = new System.Drawing.Point(114, 261);
            this.Reactive_FrequencyUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Reactive_FrequencyUD.Name = "Reactive_FrequencyUD";
            this.Reactive_FrequencyUD.Size = new System.Drawing.Size(49, 20);
            this.Reactive_FrequencyUD.TabIndex = 20;
            this.Reactive_FrequencyUD.ValueChanged += new System.EventHandler(this.Reactive_FrequencyUD_ValueChanged);
            // 
            // Reactive_StartGB
            // 
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_RadioRainbow);
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_BlueGB);
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_GreenGB);
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_RedGB);
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_ColourButton);
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_RadioRandom);
            this.Reactive_StartGB.Controls.Add(this.Reactive_Start_RadioDefined);
            this.Reactive_StartGB.Location = new System.Drawing.Point(13, 7);
            this.Reactive_StartGB.Name = "Reactive_StartGB";
            this.Reactive_StartGB.Size = new System.Drawing.Size(176, 248);
            this.Reactive_StartGB.TabIndex = 17;
            this.Reactive_StartGB.TabStop = false;
            this.Reactive_StartGB.Text = "Start Colour";
            // 
            // Reactive_Start_RadioRainbow
            // 
            this.Reactive_Start_RadioRainbow.AutoSize = true;
            this.Reactive_Start_RadioRainbow.Enabled = false;
            this.Reactive_Start_RadioRainbow.Location = new System.Drawing.Point(12, 42);
            this.Reactive_Start_RadioRainbow.Name = "Reactive_Start_RadioRainbow";
            this.Reactive_Start_RadioRainbow.Size = new System.Drawing.Size(67, 17);
            this.Reactive_Start_RadioRainbow.TabIndex = 16;
            this.Reactive_Start_RadioRainbow.Text = "Rainbow";
            this.Reactive_Start_RadioRainbow.UseVisualStyleBackColor = true;
            this.Reactive_Start_RadioRainbow.CheckedChanged += new System.EventHandler(this.Reactive_Start_RadioCheckedChanged);
            // 
            // Reactive_Start_BlueGB
            // 
            this.Reactive_Start_BlueGB.Controls.Add(this.Reactive_Start_Blue_HighUD);
            this.Reactive_Start_BlueGB.Controls.Add(this.Reactive_Start_Blue_LowUD);
            this.Reactive_Start_BlueGB.Controls.Add(this.Reactive_Start_Blue_HighButton);
            this.Reactive_Start_BlueGB.Controls.Add(this.Reactive_Start_Blue_LowButton);
            this.Reactive_Start_BlueGB.Location = new System.Drawing.Point(12, 192);
            this.Reactive_Start_BlueGB.Name = "Reactive_Start_BlueGB";
            this.Reactive_Start_BlueGB.Size = new System.Drawing.Size(152, 48);
            this.Reactive_Start_BlueGB.TabIndex = 15;
            this.Reactive_Start_BlueGB.TabStop = false;
            this.Reactive_Start_BlueGB.Text = "Range of Blue";
            // 
            // Reactive_Start_Blue_HighUD
            // 
            this.Reactive_Start_Blue_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Reactive_Start_Blue_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Blue_HighUD.Name = "Reactive_Start_Blue_HighUD";
            this.Reactive_Start_Blue_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_Start_Blue_HighUD.TabIndex = 14;
            this.Reactive_Start_Blue_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Blue_HighUD.ValueChanged += new System.EventHandler(this.Reactive_Start_UpdateColorBoxes);
            // 
            // Reactive_Start_Blue_LowUD
            // 
            this.Reactive_Start_Blue_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Reactive_Start_Blue_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Blue_LowUD.Name = "Reactive_Start_Blue_LowUD";
            this.Reactive_Start_Blue_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_Start_Blue_LowUD.TabIndex = 8;
            this.Reactive_Start_Blue_LowUD.ValueChanged += new System.EventHandler(this.Reactive_Start_UpdateColorBoxes);
            // 
            // Reactive_Start_Blue_HighButton
            // 
            this.Reactive_Start_Blue_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_Blue_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Reactive_Start_Blue_HighButton.Name = "Reactive_Start_Blue_HighButton";
            this.Reactive_Start_Blue_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_Start_Blue_HighButton.TabIndex = 13;
            this.Reactive_Start_Blue_HighButton.Tag = "";
            this.Reactive_Start_Blue_HighButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_Start_Blue_LowButton
            // 
            this.Reactive_Start_Blue_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_Blue_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Reactive_Start_Blue_LowButton.Name = "Reactive_Start_Blue_LowButton";
            this.Reactive_Start_Blue_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_Start_Blue_LowButton.TabIndex = 12;
            this.Reactive_Start_Blue_LowButton.Tag = "";
            this.Reactive_Start_Blue_LowButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_Start_GreenGB
            // 
            this.Reactive_Start_GreenGB.Controls.Add(this.Reactive_Start_Green_HighUD);
            this.Reactive_Start_GreenGB.Controls.Add(this.Reactive_Start_Green_LowUD);
            this.Reactive_Start_GreenGB.Controls.Add(this.Reactive_Start_Green_HighButton);
            this.Reactive_Start_GreenGB.Controls.Add(this.Reactive_Start_Green_LowButton);
            this.Reactive_Start_GreenGB.Location = new System.Drawing.Point(12, 140);
            this.Reactive_Start_GreenGB.Name = "Reactive_Start_GreenGB";
            this.Reactive_Start_GreenGB.Size = new System.Drawing.Size(152, 48);
            this.Reactive_Start_GreenGB.TabIndex = 15;
            this.Reactive_Start_GreenGB.TabStop = false;
            this.Reactive_Start_GreenGB.Text = "Range of Green";
            // 
            // Reactive_Start_Green_HighUD
            // 
            this.Reactive_Start_Green_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Reactive_Start_Green_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Green_HighUD.Name = "Reactive_Start_Green_HighUD";
            this.Reactive_Start_Green_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_Start_Green_HighUD.TabIndex = 14;
            this.Reactive_Start_Green_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Green_HighUD.ValueChanged += new System.EventHandler(this.Reactive_Start_UpdateColorBoxes);
            // 
            // Reactive_Start_Green_LowUD
            // 
            this.Reactive_Start_Green_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Reactive_Start_Green_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Green_LowUD.Name = "Reactive_Start_Green_LowUD";
            this.Reactive_Start_Green_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_Start_Green_LowUD.TabIndex = 8;
            this.Reactive_Start_Green_LowUD.ValueChanged += new System.EventHandler(this.Reactive_Start_UpdateColorBoxes);
            // 
            // Reactive_Start_Green_HighButton
            // 
            this.Reactive_Start_Green_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_Green_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Reactive_Start_Green_HighButton.Name = "Reactive_Start_Green_HighButton";
            this.Reactive_Start_Green_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_Start_Green_HighButton.TabIndex = 13;
            this.Reactive_Start_Green_HighButton.Tag = "";
            this.Reactive_Start_Green_HighButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_Start_Green_LowButton
            // 
            this.Reactive_Start_Green_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_Green_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Reactive_Start_Green_LowButton.Name = "Reactive_Start_Green_LowButton";
            this.Reactive_Start_Green_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_Start_Green_LowButton.TabIndex = 12;
            this.Reactive_Start_Green_LowButton.Tag = "";
            this.Reactive_Start_Green_LowButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_Start_RedGB
            // 
            this.Reactive_Start_RedGB.Controls.Add(this.Reactive_Start_Red_HighUD);
            this.Reactive_Start_RedGB.Controls.Add(this.Reactive_Start_Red_LowUD);
            this.Reactive_Start_RedGB.Controls.Add(this.Reactive_Start_Red_HighButton);
            this.Reactive_Start_RedGB.Controls.Add(this.Reactive_Start_Red_LowButton);
            this.Reactive_Start_RedGB.Location = new System.Drawing.Point(12, 88);
            this.Reactive_Start_RedGB.Name = "Reactive_Start_RedGB";
            this.Reactive_Start_RedGB.Size = new System.Drawing.Size(152, 48);
            this.Reactive_Start_RedGB.TabIndex = 12;
            this.Reactive_Start_RedGB.TabStop = false;
            this.Reactive_Start_RedGB.Text = "Range of Red";
            // 
            // Reactive_Start_Red_HighUD
            // 
            this.Reactive_Start_Red_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Reactive_Start_Red_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Red_HighUD.Name = "Reactive_Start_Red_HighUD";
            this.Reactive_Start_Red_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_Start_Red_HighUD.TabIndex = 14;
            this.Reactive_Start_Red_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Red_HighUD.ValueChanged += new System.EventHandler(this.Reactive_Start_UpdateColorBoxes);
            // 
            // Reactive_Start_Red_LowUD
            // 
            this.Reactive_Start_Red_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Reactive_Start_Red_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_Start_Red_LowUD.Name = "Reactive_Start_Red_LowUD";
            this.Reactive_Start_Red_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_Start_Red_LowUD.TabIndex = 8;
            this.Reactive_Start_Red_LowUD.ValueChanged += new System.EventHandler(this.Reactive_Start_UpdateColorBoxes);
            // 
            // Reactive_Start_Red_HighButton
            // 
            this.Reactive_Start_Red_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_Red_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Reactive_Start_Red_HighButton.Name = "Reactive_Start_Red_HighButton";
            this.Reactive_Start_Red_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_Start_Red_HighButton.TabIndex = 13;
            this.Reactive_Start_Red_HighButton.Tag = "";
            this.Reactive_Start_Red_HighButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_Start_Red_LowButton
            // 
            this.Reactive_Start_Red_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_Red_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Reactive_Start_Red_LowButton.Name = "Reactive_Start_Red_LowButton";
            this.Reactive_Start_Red_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_Start_Red_LowButton.TabIndex = 12;
            this.Reactive_Start_Red_LowButton.Tag = "";
            this.Reactive_Start_Red_LowButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_Start_ColourButton
            // 
            this.Reactive_Start_ColourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_Start_ColourButton.Location = new System.Drawing.Point(118, 19);
            this.Reactive_Start_ColourButton.Name = "Reactive_Start_ColourButton";
            this.Reactive_Start_ColourButton.Size = new System.Drawing.Size(46, 17);
            this.Reactive_Start_ColourButton.TabIndex = 11;
            this.Reactive_Start_ColourButton.Tag = "";
            this.Reactive_Start_ColourButton.UseVisualStyleBackColor = true;
            this.Reactive_Start_ColourButton.Click += new System.EventHandler(this.Reactive_ColourButton_ColourChange);
            // 
            // Reactive_Start_RadioRandom
            // 
            this.Reactive_Start_RadioRandom.AutoSize = true;
            this.Reactive_Start_RadioRandom.Location = new System.Drawing.Point(12, 65);
            this.Reactive_Start_RadioRandom.Name = "Reactive_Start_RadioRandom";
            this.Reactive_Start_RadioRandom.Size = new System.Drawing.Size(98, 17);
            this.Reactive_Start_RadioRandom.TabIndex = 1;
            this.Reactive_Start_RadioRandom.Text = "Random Colour";
            this.Reactive_Start_RadioRandom.UseVisualStyleBackColor = true;
            this.Reactive_Start_RadioRandom.CheckedChanged += new System.EventHandler(this.Reactive_Start_RadioCheckedChanged);
            // 
            // Reactive_Start_RadioDefined
            // 
            this.Reactive_Start_RadioDefined.AutoSize = true;
            this.Reactive_Start_RadioDefined.Checked = true;
            this.Reactive_Start_RadioDefined.Location = new System.Drawing.Point(12, 19);
            this.Reactive_Start_RadioDefined.Name = "Reactive_Start_RadioDefined";
            this.Reactive_Start_RadioDefined.Size = new System.Drawing.Size(95, 17);
            this.Reactive_Start_RadioDefined.TabIndex = 0;
            this.Reactive_Start_RadioDefined.TabStop = true;
            this.Reactive_Start_RadioDefined.Text = "Defined Colour";
            this.Reactive_Start_RadioDefined.UseVisualStyleBackColor = true;
            this.Reactive_Start_RadioDefined.CheckedChanged += new System.EventHandler(this.Reactive_Start_RadioCheckedChanged);
            // 
            // Reactive_EndGB
            // 
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_RadioOriginal);
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_BlueGB);
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_GreenGB);
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_RedGB);
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_ColourButton);
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_RadioRandom);
            this.Reactive_EndGB.Controls.Add(this.Reactive_End_RadioDefined);
            this.Reactive_EndGB.Location = new System.Drawing.Point(203, 7);
            this.Reactive_EndGB.Name = "Reactive_EndGB";
            this.Reactive_EndGB.Size = new System.Drawing.Size(176, 248);
            this.Reactive_EndGB.TabIndex = 18;
            this.Reactive_EndGB.TabStop = false;
            this.Reactive_EndGB.Text = "End Colour";
            // 
            // Reactive_End_RadioOriginal
            // 
            this.Reactive_End_RadioOriginal.AutoSize = true;
            this.Reactive_End_RadioOriginal.Checked = true;
            this.Reactive_End_RadioOriginal.Location = new System.Drawing.Point(12, 42);
            this.Reactive_End_RadioOriginal.Name = "Reactive_End_RadioOriginal";
            this.Reactive_End_RadioOriginal.Size = new System.Drawing.Size(93, 17);
            this.Reactive_End_RadioOriginal.TabIndex = 16;
            this.Reactive_End_RadioOriginal.TabStop = true;
            this.Reactive_End_RadioOriginal.Text = "Original Colour";
            this.Reactive_End_RadioOriginal.UseVisualStyleBackColor = true;
            this.Reactive_End_RadioOriginal.CheckedChanged += new System.EventHandler(this.Reactive_End_RadioCheckedChanged);
            // 
            // Reactive_End_BlueGB
            // 
            this.Reactive_End_BlueGB.Controls.Add(this.Reactive_End_Blue_HighUD);
            this.Reactive_End_BlueGB.Controls.Add(this.Reactive_End_Blue_LowUD);
            this.Reactive_End_BlueGB.Controls.Add(this.Reactive_End_Blue_HighButton);
            this.Reactive_End_BlueGB.Controls.Add(this.Reactive_End_Blue_LowButton);
            this.Reactive_End_BlueGB.Location = new System.Drawing.Point(12, 192);
            this.Reactive_End_BlueGB.Name = "Reactive_End_BlueGB";
            this.Reactive_End_BlueGB.Size = new System.Drawing.Size(152, 48);
            this.Reactive_End_BlueGB.TabIndex = 15;
            this.Reactive_End_BlueGB.TabStop = false;
            this.Reactive_End_BlueGB.Text = "Range of Blue";
            // 
            // Reactive_End_Blue_HighUD
            // 
            this.Reactive_End_Blue_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Reactive_End_Blue_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Blue_HighUD.Name = "Reactive_End_Blue_HighUD";
            this.Reactive_End_Blue_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_End_Blue_HighUD.TabIndex = 14;
            this.Reactive_End_Blue_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Blue_HighUD.ValueChanged += new System.EventHandler(this.Reactive_End_UpdateColorBoxes);
            // 
            // Reactive_End_Blue_LowUD
            // 
            this.Reactive_End_Blue_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Reactive_End_Blue_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Blue_LowUD.Name = "Reactive_End_Blue_LowUD";
            this.Reactive_End_Blue_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_End_Blue_LowUD.TabIndex = 8;
            this.Reactive_End_Blue_LowUD.ValueChanged += new System.EventHandler(this.Reactive_End_UpdateColorBoxes);
            // 
            // Reactive_End_Blue_HighButton
            // 
            this.Reactive_End_Blue_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_Blue_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Reactive_End_Blue_HighButton.Name = "Reactive_End_Blue_HighButton";
            this.Reactive_End_Blue_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_End_Blue_HighButton.TabIndex = 13;
            this.Reactive_End_Blue_HighButton.Tag = "";
            this.Reactive_End_Blue_HighButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_End_Blue_LowButton
            // 
            this.Reactive_End_Blue_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_Blue_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Reactive_End_Blue_LowButton.Name = "Reactive_End_Blue_LowButton";
            this.Reactive_End_Blue_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_End_Blue_LowButton.TabIndex = 12;
            this.Reactive_End_Blue_LowButton.Tag = "";
            this.Reactive_End_Blue_LowButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_End_GreenGB
            // 
            this.Reactive_End_GreenGB.Controls.Add(this.Reactive_End_Green_HighUD);
            this.Reactive_End_GreenGB.Controls.Add(this.Reactive_End_Green_LowUD);
            this.Reactive_End_GreenGB.Controls.Add(this.Reactive_End_Green_HighButton);
            this.Reactive_End_GreenGB.Controls.Add(this.Reactive_End_Green_LowButton);
            this.Reactive_End_GreenGB.Location = new System.Drawing.Point(12, 140);
            this.Reactive_End_GreenGB.Name = "Reactive_End_GreenGB";
            this.Reactive_End_GreenGB.Size = new System.Drawing.Size(152, 48);
            this.Reactive_End_GreenGB.TabIndex = 15;
            this.Reactive_End_GreenGB.TabStop = false;
            this.Reactive_End_GreenGB.Text = "Range of Green";
            // 
            // Reactive_End_Green_HighUD
            // 
            this.Reactive_End_Green_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Reactive_End_Green_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Green_HighUD.Name = "Reactive_End_Green_HighUD";
            this.Reactive_End_Green_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_End_Green_HighUD.TabIndex = 14;
            this.Reactive_End_Green_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Green_HighUD.ValueChanged += new System.EventHandler(this.Reactive_End_UpdateColorBoxes);
            // 
            // Reactive_End_Green_LowUD
            // 
            this.Reactive_End_Green_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Reactive_End_Green_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Green_LowUD.Name = "Reactive_End_Green_LowUD";
            this.Reactive_End_Green_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_End_Green_LowUD.TabIndex = 8;
            this.Reactive_End_Green_LowUD.ValueChanged += new System.EventHandler(this.Reactive_End_UpdateColorBoxes);
            // 
            // Reactive_End_Green_HighButton
            // 
            this.Reactive_End_Green_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_Green_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Reactive_End_Green_HighButton.Name = "Reactive_End_Green_HighButton";
            this.Reactive_End_Green_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_End_Green_HighButton.TabIndex = 13;
            this.Reactive_End_Green_HighButton.Tag = "";
            this.Reactive_End_Green_HighButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_End_Green_LowButton
            // 
            this.Reactive_End_Green_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_Green_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Reactive_End_Green_LowButton.Name = "Reactive_End_Green_LowButton";
            this.Reactive_End_Green_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_End_Green_LowButton.TabIndex = 12;
            this.Reactive_End_Green_LowButton.Tag = "";
            this.Reactive_End_Green_LowButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_End_RedGB
            // 
            this.Reactive_End_RedGB.Controls.Add(this.Reactive_End_Red_HighUD);
            this.Reactive_End_RedGB.Controls.Add(this.Reactive_End_Red_LowUD);
            this.Reactive_End_RedGB.Controls.Add(this.Reactive_End_Red_HighButton);
            this.Reactive_End_RedGB.Controls.Add(this.Reactive_End_Red_LowButton);
            this.Reactive_End_RedGB.Location = new System.Drawing.Point(12, 88);
            this.Reactive_End_RedGB.Name = "Reactive_End_RedGB";
            this.Reactive_End_RedGB.Size = new System.Drawing.Size(152, 48);
            this.Reactive_End_RedGB.TabIndex = 12;
            this.Reactive_End_RedGB.TabStop = false;
            this.Reactive_End_RedGB.Text = "Range of Red";
            // 
            // Reactive_End_Red_HighUD
            // 
            this.Reactive_End_Red_HighUD.Location = new System.Drawing.Point(107, 19);
            this.Reactive_End_Red_HighUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Red_HighUD.Name = "Reactive_End_Red_HighUD";
            this.Reactive_End_Red_HighUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_End_Red_HighUD.TabIndex = 14;
            this.Reactive_End_Red_HighUD.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Red_HighUD.ValueChanged += new System.EventHandler(this.Reactive_End_UpdateColorBoxes);
            // 
            // Reactive_End_Red_LowUD
            // 
            this.Reactive_End_Red_LowUD.Location = new System.Drawing.Point(6, 19);
            this.Reactive_End_Red_LowUD.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.Reactive_End_Red_LowUD.Name = "Reactive_End_Red_LowUD";
            this.Reactive_End_Red_LowUD.Size = new System.Drawing.Size(39, 20);
            this.Reactive_End_Red_LowUD.TabIndex = 8;
            this.Reactive_End_Red_LowUD.ValueChanged += new System.EventHandler(this.Reactive_End_UpdateColorBoxes);
            // 
            // Reactive_End_Red_HighButton
            // 
            this.Reactive_End_Red_HighButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_Red_HighButton.Location = new System.Drawing.Point(79, 19);
            this.Reactive_End_Red_HighButton.Name = "Reactive_End_Red_HighButton";
            this.Reactive_End_Red_HighButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_End_Red_HighButton.TabIndex = 13;
            this.Reactive_End_Red_HighButton.Tag = "";
            this.Reactive_End_Red_HighButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_End_Red_LowButton
            // 
            this.Reactive_End_Red_LowButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_Red_LowButton.Location = new System.Drawing.Point(51, 19);
            this.Reactive_End_Red_LowButton.Name = "Reactive_End_Red_LowButton";
            this.Reactive_End_Red_LowButton.Size = new System.Drawing.Size(22, 20);
            this.Reactive_End_Red_LowButton.TabIndex = 12;
            this.Reactive_End_Red_LowButton.Tag = "";
            this.Reactive_End_Red_LowButton.UseVisualStyleBackColor = true;
            // 
            // Reactive_End_ColourButton
            // 
            this.Reactive_End_ColourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Reactive_End_ColourButton.Location = new System.Drawing.Point(118, 19);
            this.Reactive_End_ColourButton.Name = "Reactive_End_ColourButton";
            this.Reactive_End_ColourButton.Size = new System.Drawing.Size(46, 17);
            this.Reactive_End_ColourButton.TabIndex = 11;
            this.Reactive_End_ColourButton.Tag = "";
            this.Reactive_End_ColourButton.UseVisualStyleBackColor = true;
            this.Reactive_End_ColourButton.Click += new System.EventHandler(this.Reactive_ColourButton_ColourChange);
            // 
            // Reactive_End_RadioRandom
            // 
            this.Reactive_End_RadioRandom.AutoSize = true;
            this.Reactive_End_RadioRandom.Location = new System.Drawing.Point(12, 65);
            this.Reactive_End_RadioRandom.Name = "Reactive_End_RadioRandom";
            this.Reactive_End_RadioRandom.Size = new System.Drawing.Size(98, 17);
            this.Reactive_End_RadioRandom.TabIndex = 1;
            this.Reactive_End_RadioRandom.Text = "Random Colour";
            this.Reactive_End_RadioRandom.UseVisualStyleBackColor = true;
            this.Reactive_End_RadioRandom.CheckedChanged += new System.EventHandler(this.Reactive_End_RadioCheckedChanged);
            // 
            // Reactive_End_RadioDefined
            // 
            this.Reactive_End_RadioDefined.AutoSize = true;
            this.Reactive_End_RadioDefined.Location = new System.Drawing.Point(12, 19);
            this.Reactive_End_RadioDefined.Name = "Reactive_End_RadioDefined";
            this.Reactive_End_RadioDefined.Size = new System.Drawing.Size(95, 17);
            this.Reactive_End_RadioDefined.TabIndex = 0;
            this.Reactive_End_RadioDefined.Text = "Defined Colour";
            this.Reactive_End_RadioDefined.UseVisualStyleBackColor = true;
            this.Reactive_End_RadioDefined.CheckedChanged += new System.EventHandler(this.Reactive_End_RadioCheckedChanged);
            // 
            // ReactiveTab_Heatmap
            // 
            this.ReactiveTab_Heatmap.Controls.Add(this.Heatmap_ResetMaxButton);
            this.ReactiveTab_Heatmap.Controls.Add(this.Heatmap_End_ColourLabel);
            this.ReactiveTab_Heatmap.Controls.Add(this.Heatmap_Start_ColourLabel);
            this.ReactiveTab_Heatmap.Controls.Add(this.Heatmap_End_ColourButton);
            this.ReactiveTab_Heatmap.Controls.Add(this.Heatmap_Start_ColourButton);
            this.ReactiveTab_Heatmap.Location = new System.Drawing.Point(4, 22);
            this.ReactiveTab_Heatmap.Name = "ReactiveTab_Heatmap";
            this.ReactiveTab_Heatmap.Size = new System.Drawing.Size(391, 288);
            this.ReactiveTab_Heatmap.TabIndex = 1;
            this.ReactiveTab_Heatmap.Text = "Heatmap";
            this.ReactiveTab_Heatmap.UseVisualStyleBackColor = true;
            // 
            // Heatmap_ResetMaxButton
            // 
            this.Heatmap_ResetMaxButton.Location = new System.Drawing.Point(11, 249);
            this.Heatmap_ResetMaxButton.Name = "Heatmap_ResetMaxButton";
            this.Heatmap_ResetMaxButton.Size = new System.Drawing.Size(75, 23);
            this.Heatmap_ResetMaxButton.TabIndex = 14;
            this.Heatmap_ResetMaxButton.Text = "Reset";
            this.Heatmap_ResetMaxButton.UseVisualStyleBackColor = true;
            this.Heatmap_ResetMaxButton.Click += new System.EventHandler(this.Heatmap_ResetMaxButton_Click);
            // 
            // Heatmap_End_ColourLabel
            // 
            this.Heatmap_End_ColourLabel.AutoSize = true;
            this.Heatmap_End_ColourLabel.Location = new System.Drawing.Point(24, 39);
            this.Heatmap_End_ColourLabel.Name = "Heatmap_End_ColourLabel";
            this.Heatmap_End_ColourLabel.Size = new System.Drawing.Size(49, 13);
            this.Heatmap_End_ColourLabel.TabIndex = 15;
            this.Heatmap_End_ColourLabel.Text = "Most Hit:";
            this.Heatmap_End_ColourLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Heatmap_Start_ColourLabel
            // 
            this.Heatmap_Start_ColourLabel.AutoSize = true;
            this.Heatmap_Start_ColourLabel.Location = new System.Drawing.Point(21, 16);
            this.Heatmap_Start_ColourLabel.Name = "Heatmap_Start_ColourLabel";
            this.Heatmap_Start_ColourLabel.Size = new System.Drawing.Size(52, 13);
            this.Heatmap_Start_ColourLabel.TabIndex = 14;
            this.Heatmap_Start_ColourLabel.Text = "Least Hit:";
            this.Heatmap_Start_ColourLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Heatmap_End_ColourButton
            // 
            this.Heatmap_End_ColourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Heatmap_End_ColourButton.Location = new System.Drawing.Point(79, 37);
            this.Heatmap_End_ColourButton.Name = "Heatmap_End_ColourButton";
            this.Heatmap_End_ColourButton.Size = new System.Drawing.Size(46, 17);
            this.Heatmap_End_ColourButton.TabIndex = 13;
            this.Heatmap_End_ColourButton.Tag = "";
            this.Heatmap_End_ColourButton.UseVisualStyleBackColor = true;
            this.Heatmap_End_ColourButton.Click += new System.EventHandler(this.Heatmap_ColourButton_ColourChange);
            // 
            // Heatmap_Start_ColourButton
            // 
            this.Heatmap_Start_ColourButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Heatmap_Start_ColourButton.Location = new System.Drawing.Point(79, 14);
            this.Heatmap_Start_ColourButton.Name = "Heatmap_Start_ColourButton";
            this.Heatmap_Start_ColourButton.Size = new System.Drawing.Size(46, 17);
            this.Heatmap_Start_ColourButton.TabIndex = 12;
            this.Heatmap_Start_ColourButton.Tag = "";
            this.Heatmap_Start_ColourButton.UseVisualStyleBackColor = true;
            this.Heatmap_Start_ColourButton.Click += new System.EventHandler(this.Heatmap_ColourButton_ColourChange);
            // 
            // ReactiveStopButton
            // 
            this.ReactiveStopButton.Location = new System.Drawing.Point(323, 330);
            this.ReactiveStopButton.Name = "ReactiveStopButton";
            this.ReactiveStopButton.Size = new System.Drawing.Size(75, 23);
            this.ReactiveStopButton.TabIndex = 4;
            this.ReactiveStopButton.Text = "Stop";
            this.ReactiveStopButton.UseVisualStyleBackColor = true;
            this.ReactiveStopButton.Click += new System.EventHandler(this.StopEffects);
            // 
            // ReactiveStartButton
            // 
            this.ReactiveStartButton.Location = new System.Drawing.Point(7, 330);
            this.ReactiveStartButton.Name = "ReactiveStartButton";
            this.ReactiveStartButton.Size = new System.Drawing.Size(75, 23);
            this.ReactiveStartButton.TabIndex = 3;
            this.ReactiveStartButton.Text = "Start";
            this.ReactiveStartButton.UseVisualStyleBackColor = true;
            this.ReactiveStartButton.Click += new System.EventHandler(this.ReactiveStartButton_Click);
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.SettingsSuppressCueWarnings);
            this.tabSettings.Controls.Add(this.AnimationsUseStaticLights);
            this.tabSettings.Controls.Add(this.SettingsMouseModelCB);
            this.tabSettings.Controls.Add(this.SettingsEffectsIncludeMouse);
            this.tabSettings.Controls.Add(this.SettingsIdleSwitcher);
            this.tabSettings.Controls.Add(this.SettingsIdleLabel3);
            this.tabSettings.Controls.Add(this.SettingsIdleProfileCB);
            this.tabSettings.Controls.Add(this.SettingsIdleModeCB);
            this.tabSettings.Controls.Add(this.SettingsIdleLabel2);
            this.tabSettings.Controls.Add(this.SettingsIdleTimeUD);
            this.tabSettings.Controls.Add(this.SettingsIdleLabel1);
            this.tabSettings.Controls.Add(this.SettingsStaticOnStartCheck);
            this.tabSettings.Controls.Add(this.SettingsSpectroOnStartCheck);
            this.tabSettings.Controls.Add(this.SettingsBrowseCuePathButton);
            this.tabSettings.Controls.Add(this.SettingsCuePathTextBox);
            this.tabSettings.Controls.Add(this.SettingsCuePathLabel);
            this.tabSettings.Controls.Add(this.SettingsMinimizeToTrayCheck);
            this.tabSettings.Controls.Add(this.SettingsKeyboardLayoutCB);
            this.tabSettings.Controls.Add(this.SettingsGetUpdateButton);
            this.tabSettings.Controls.Add(this.SettingsRestoreLightingCheck);
            this.tabSettings.Controls.Add(this.SettingsKeyboardModelCB);
            this.tabSettings.Controls.Add(this.SettingsLaunchCueCheck);
            this.tabSettings.Controls.Add(this.SettingsStartMinimizedCheck);
            this.tabSettings.Controls.Add(this.SettingsEffectsOnStartCheck);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(696, 360);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
            // 
            // AnimationsUseStaticLights
            // 
            this.AnimationsUseStaticLights.AutoSize = true;
            this.AnimationsUseStaticLights.Location = new System.Drawing.Point(188, 168);
            this.AnimationsUseStaticLights.Name = "AnimationsUseStaticLights";
            this.AnimationsUseStaticLights.Size = new System.Drawing.Size(174, 17);
            this.AnimationsUseStaticLights.TabIndex = 67;
            this.AnimationsUseStaticLights.Text = "Show Static Keys in Animations";
            this.AnimationsUseStaticLights.UseVisualStyleBackColor = true;
            this.AnimationsUseStaticLights.CheckedChanged += new System.EventHandler(this.AnimationsUseStaticLights_CheckedChanged);
            // 
            // SettingsMouseModelCB
            // 
            this.SettingsMouseModelCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SettingsMouseModelCB.FormattingEnabled = true;
            this.SettingsMouseModelCB.Location = new System.Drawing.Point(161, 13);
            this.SettingsMouseModelCB.Name = "SettingsMouseModelCB";
            this.SettingsMouseModelCB.Size = new System.Drawing.Size(130, 21);
            this.SettingsMouseModelCB.TabIndex = 66;
            this.SettingsMouseModelCB.SelectedIndexChanged += new System.EventHandler(this.SettingsMouseModelCB_SelectedIndexChanged);
            // 
            // SettingsEffectsIncludeMouse
            // 
            this.SettingsEffectsIncludeMouse.AutoSize = true;
            this.SettingsEffectsIncludeMouse.Location = new System.Drawing.Point(161, 42);
            this.SettingsEffectsIncludeMouse.Name = "SettingsEffectsIncludeMouse";
            this.SettingsEffectsIncludeMouse.Size = new System.Drawing.Size(135, 17);
            this.SettingsEffectsIncludeMouse.TabIndex = 65;
            this.SettingsEffectsIncludeMouse.Text = "Apply Effects to Mouse";
            this.SettingsEffectsIncludeMouse.UseVisualStyleBackColor = true;
            this.SettingsEffectsIncludeMouse.CheckedChanged += new System.EventHandler(this.SettingsUseMosue_CheckedChanged);
            // 
            // SettingsIdleSwitcher
            // 
            this.SettingsIdleSwitcher.AutoSize = true;
            this.SettingsIdleSwitcher.Location = new System.Drawing.Point(13, 214);
            this.SettingsIdleSwitcher.Name = "SettingsIdleSwitcher";
            this.SettingsIdleSwitcher.Size = new System.Drawing.Size(153, 17);
            this.SettingsIdleSwitcher.TabIndex = 64;
            this.SettingsIdleSwitcher.Text = "Change Settings when Idle";
            this.SettingsIdleSwitcher.UseVisualStyleBackColor = true;
            this.SettingsIdleSwitcher.CheckedChanged += new System.EventHandler(this.SettingsIdleSwitcher_CheckedChanged);
            // 
            // SettingsIdleLabel3
            // 
            this.SettingsIdleLabel3.AutoSize = true;
            this.SettingsIdleLabel3.Location = new System.Drawing.Point(209, 261);
            this.SettingsIdleLabel3.Name = "SettingsIdleLabel3";
            this.SettingsIdleLabel3.Size = new System.Drawing.Size(39, 13);
            this.SettingsIdleLabel3.TabIndex = 63;
            this.SettingsIdleLabel3.Text = "Profile:";
            this.SettingsIdleLabel3.Visible = false;
            // 
            // SettingsIdleProfileCB
            // 
            this.SettingsIdleProfileCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SettingsIdleProfileCB.FormattingEnabled = true;
            this.SettingsIdleProfileCB.Location = new System.Drawing.Point(254, 258);
            this.SettingsIdleProfileCB.Name = "SettingsIdleProfileCB";
            this.SettingsIdleProfileCB.Size = new System.Drawing.Size(148, 21);
            this.SettingsIdleProfileCB.TabIndex = 62;
            this.SettingsIdleProfileCB.Visible = false;
            // 
            // SettingsIdleModeCB
            // 
            this.SettingsIdleModeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SettingsIdleModeCB.FormattingEnabled = true;
            this.SettingsIdleModeCB.Location = new System.Drawing.Point(254, 231);
            this.SettingsIdleModeCB.Name = "SettingsIdleModeCB";
            this.SettingsIdleModeCB.Size = new System.Drawing.Size(148, 21);
            this.SettingsIdleModeCB.TabIndex = 61;
            this.SettingsIdleModeCB.Visible = false;
            this.SettingsIdleModeCB.SelectedIndexChanged += new System.EventHandler(this.SettingsIdleModeCB_SelectedIndexChanged);
            // 
            // SettingsIdleLabel2
            // 
            this.SettingsIdleLabel2.AutoSize = true;
            this.SettingsIdleLabel2.Location = new System.Drawing.Point(157, 234);
            this.SettingsIdleLabel2.Name = "SettingsIdleLabel2";
            this.SettingsIdleLabel2.Size = new System.Drawing.Size(91, 13);
            this.SettingsIdleLabel2.TabIndex = 60;
            this.SettingsIdleLabel2.Text = "minutes, switch to";
            this.SettingsIdleLabel2.Visible = false;
            // 
            // SettingsIdleTimeUD
            // 
            this.SettingsIdleTimeUD.Location = new System.Drawing.Point(106, 232);
            this.SettingsIdleTimeUD.Name = "SettingsIdleTimeUD";
            this.SettingsIdleTimeUD.Size = new System.Drawing.Size(45, 20);
            this.SettingsIdleTimeUD.TabIndex = 59;
            this.SettingsIdleTimeUD.Visible = false;
            this.SettingsIdleTimeUD.ValueChanged += new System.EventHandler(this.SettingsIdleTimeUD_ValueChanged);
            // 
            // SettingsIdleLabel1
            // 
            this.SettingsIdleLabel1.AutoSize = true;
            this.SettingsIdleLabel1.Location = new System.Drawing.Point(10, 234);
            this.SettingsIdleLabel1.Name = "SettingsIdleLabel1";
            this.SettingsIdleLabel1.Size = new System.Drawing.Size(92, 13);
            this.SettingsIdleLabel1.TabIndex = 58;
            this.SettingsIdleLabel1.Text = "After being idle for";
            this.SettingsIdleLabel1.Visible = false;
            // 
            // SettingsStaticOnStartCheck
            // 
            this.SettingsStaticOnStartCheck.AutoSize = true;
            this.SettingsStaticOnStartCheck.Location = new System.Drawing.Point(188, 122);
            this.SettingsStaticOnStartCheck.Name = "SettingsStaticOnStartCheck";
            this.SettingsStaticOnStartCheck.Size = new System.Drawing.Size(119, 17);
            this.SettingsStaticOnStartCheck.TabIndex = 57;
            this.SettingsStaticOnStartCheck.Text = "Static Keys on Start";
            this.SettingsStaticOnStartCheck.UseVisualStyleBackColor = true;
            // 
            // SettingsSpectroOnStartCheck
            // 
            this.SettingsSpectroOnStartCheck.AutoSize = true;
            this.SettingsSpectroOnStartCheck.Location = new System.Drawing.Point(188, 76);
            this.SettingsSpectroOnStartCheck.Name = "SettingsSpectroOnStartCheck";
            this.SettingsSpectroOnStartCheck.Size = new System.Drawing.Size(103, 17);
            this.SettingsSpectroOnStartCheck.TabIndex = 56;
            this.SettingsSpectroOnStartCheck.Text = "Spectro on Start";
            this.SettingsSpectroOnStartCheck.UseVisualStyleBackColor = true;
            this.SettingsSpectroOnStartCheck.CheckedChanged += new System.EventHandler(this.SettingsSpectroOnStartCheck_CheckedChanged);
            // 
            // SettingsBrowseCuePathButton
            // 
            this.SettingsBrowseCuePathButton.Location = new System.Drawing.Point(13, 334);
            this.SettingsBrowseCuePathButton.Name = "SettingsBrowseCuePathButton";
            this.SettingsBrowseCuePathButton.Size = new System.Drawing.Size(87, 23);
            this.SettingsBrowseCuePathButton.TabIndex = 55;
            this.SettingsBrowseCuePathButton.Text = "Browse";
            this.SettingsBrowseCuePathButton.UseVisualStyleBackColor = true;
            this.SettingsBrowseCuePathButton.Click += new System.EventHandler(this.SettingsBrowseCuePathButton_Click);
            // 
            // SettingsCuePathTextBox
            // 
            this.SettingsCuePathTextBox.Location = new System.Drawing.Point(106, 336);
            this.SettingsCuePathTextBox.Name = "SettingsCuePathTextBox";
            this.SettingsCuePathTextBox.Size = new System.Drawing.Size(580, 20);
            this.SettingsCuePathTextBox.TabIndex = 54;
            this.SettingsCuePathTextBox.TextChanged += new System.EventHandler(this.SettingsCuePathTextBox_TextChanged);
            // 
            // SettingsCuePathLabel
            // 
            this.SettingsCuePathLabel.AutoSize = true;
            this.SettingsCuePathLabel.Location = new System.Drawing.Point(103, 320);
            this.SettingsCuePathLabel.Name = "SettingsCuePathLabel";
            this.SettingsCuePathLabel.Size = new System.Drawing.Size(128, 13);
            this.SettingsCuePathLabel.TabIndex = 53;
            this.SettingsCuePathLabel.Text = "Corsair Utility Engine Path";
            // 
            // ToggleCheckTimer
            // 
            this.ToggleCheckTimer.Tick += new System.EventHandler(this.ToggleCheckTimer_Tick);
            // 
            // SettingsSuppressCueWarnings
            // 
            this.SettingsSuppressCueWarnings.AutoSize = true;
            this.SettingsSuppressCueWarnings.Location = new System.Drawing.Point(188, 191);
            this.SettingsSuppressCueWarnings.Name = "SettingsSuppressCueWarnings";
            this.SettingsSuppressCueWarnings.Size = new System.Drawing.Size(143, 17);
            this.SettingsSuppressCueWarnings.TabIndex = 68;
            this.SettingsSuppressCueWarnings.Text = "Suppress CUE Warnings";
            this.SettingsSuppressCueWarnings.UseVisualStyleBackColor = true;
            this.SettingsSuppressCueWarnings.CheckedChanged += new System.EventHandler(this.SettingsSuppressCueWarnings_CheckedChanged);
            // 
            // ToggleCapsLabel
            // 
            this.ToggleCapsLabel.AutoSize = true;
            this.ToggleCapsLabel.Location = new System.Drawing.Point(12, 335);
            this.ToggleCapsLabel.Name = "ToggleCapsLabel";
            this.ToggleCapsLabel.Size = new System.Drawing.Size(31, 13);
            this.ToggleCapsLabel.TabIndex = 72;
            this.ToggleCapsLabel.Text = "Caps";
            // 
            // ToggleNumLabel
            // 
            this.ToggleNumLabel.AutoSize = true;
            this.ToggleNumLabel.Location = new System.Drawing.Point(285, 335);
            this.ToggleNumLabel.Name = "ToggleNumLabel";
            this.ToggleNumLabel.Size = new System.Drawing.Size(29, 13);
            this.ToggleNumLabel.TabIndex = 73;
            this.ToggleNumLabel.Text = "Num";
            // 
            // ToggleNumOff
            // 
            this.ToggleNumOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleNumOff.Location = new System.Drawing.Point(360, 330);
            this.ToggleNumOff.Name = "ToggleNumOff";
            this.ToggleNumOff.Size = new System.Drawing.Size(36, 23);
            this.ToggleNumOff.TabIndex = 75;
            this.ToggleNumOff.Tag = "250";
            this.ToggleNumOff.Text = "Off";
            this.ToggleNumOff.UseVisualStyleBackColor = true;
            this.ToggleNumOff.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleCapsOff
            // 
            this.ToggleCapsOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleCapsOff.Location = new System.Drawing.Point(87, 329);
            this.ToggleCapsOff.Name = "ToggleCapsOff";
            this.ToggleCapsOff.Size = new System.Drawing.Size(36, 23);
            this.ToggleCapsOff.TabIndex = 74;
            this.ToggleCapsOff.Tag = "254";
            this.ToggleCapsOff.Text = "Off";
            this.ToggleCapsOff.UseVisualStyleBackColor = true;
            this.ToggleCapsOff.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleScrollOff
            // 
            this.ToggleScrollOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleScrollOff.Location = new System.Drawing.Point(216, 329);
            this.ToggleScrollOff.Name = "ToggleScrollOff";
            this.ToggleScrollOff.Size = new System.Drawing.Size(36, 23);
            this.ToggleScrollOff.TabIndex = 77;
            this.ToggleScrollOff.Tag = "252";
            this.ToggleScrollOff.Text = "Off";
            this.ToggleScrollOff.UseVisualStyleBackColor = true;
            this.ToggleScrollOff.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleMuteOff
            // 
            this.ToggleMuteOff.Enabled = false;
            this.ToggleMuteOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ToggleMuteOff.Location = new System.Drawing.Point(489, 330);
            this.ToggleMuteOff.Name = "ToggleMuteOff";
            this.ToggleMuteOff.Size = new System.Drawing.Size(36, 23);
            this.ToggleMuteOff.TabIndex = 76;
            this.ToggleMuteOff.Tag = "248";
            this.ToggleMuteOff.Text = "Off";
            this.ToggleMuteOff.UseVisualStyleBackColor = true;
            this.ToggleMuteOff.Visible = false;
            this.ToggleMuteOff.Click += new System.EventHandler(this.ToggleColours_Click);
            // 
            // ToggleMuteLabel
            // 
            this.ToggleMuteLabel.AutoSize = true;
            this.ToggleMuteLabel.Location = new System.Drawing.Point(414, 335);
            this.ToggleMuteLabel.Name = "ToggleMuteLabel";
            this.ToggleMuteLabel.Size = new System.Drawing.Size(31, 13);
            this.ToggleMuteLabel.TabIndex = 79;
            this.ToggleMuteLabel.Text = "Mute";
            this.ToggleMuteLabel.Visible = false;
            // 
            // ToggleScrollLabel
            // 
            this.ToggleScrollLabel.AutoSize = true;
            this.ToggleScrollLabel.Location = new System.Drawing.Point(139, 335);
            this.ToggleScrollLabel.Name = "ToggleScrollLabel";
            this.ToggleScrollLabel.Size = new System.Drawing.Size(33, 13);
            this.ToggleScrollLabel.TabIndex = 78;
            this.ToggleScrollLabel.Text = "Scroll";
            // 
            // UseToggleColoursCheck
            // 
            this.UseToggleColoursCheck.AutoSize = true;
            this.UseToggleColoursCheck.Location = new System.Drawing.Point(15, 303);
            this.UseToggleColoursCheck.Name = "UseToggleColoursCheck";
            this.UseToggleColoursCheck.Size = new System.Drawing.Size(125, 17);
            this.UseToggleColoursCheck.TabIndex = 80;
            this.UseToggleColoursCheck.Text = "Use toggle indicators";
            this.UseToggleColoursCheck.UseVisualStyleBackColor = true;
            this.UseToggleColoursCheck.CheckedChanged += new System.EventHandler(this.UseToggleColoursCheck_CheckedChanged);
            // 
            // tsmSpectroAmplitudeSlider
            // 
            this.tsmSpectroAmplitudeSlider.Maximum = 10;
            this.tsmSpectroAmplitudeSlider.Minimum = 0;
            this.tsmSpectroAmplitudeSlider.Name = "tsmSpectroAmplitudeSlider";
            this.tsmSpectroAmplitudeSlider.Size = new System.Drawing.Size(104, 45);
            this.tsmSpectroAmplitudeSlider.Text = "toolStripTrackBar1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 427);
            this.Controls.Add(this.DebugTestModeButton);
            this.Controls.Add(this.DebugTesterUD);
            this.Controls.Add(this.DebugStatusLog);
            this.Controls.Add(this.DebugLogLevelUD);
            this.Controls.Add(this.DebugLogLevelLabel);
            this.Controls.Add(this.MainTabControl);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RGB Keyboard Spectrograph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroAmplitudeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBgBrightnessUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugTesterUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DebugLogLevelUD)).EndInit();
            this.RightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SpectroRefreshDelayUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBgWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBgSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBarBrightnessUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpectroBarWidth)).EndInit();
            this.MainTabControl.ResumeLayout(false);
            this.tabSpectro.ResumeLayout(false);
            this.tabSpectro.PerformLayout();
            this.tabEffects.ResumeLayout(false);
            this.tabEffects.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_DurationUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_FrequencyUD)).EndInit();
            this.Effect_Float_EndGB.ResumeLayout(false);
            this.Effect_Float_EndGB.PerformLayout();
            this.Effect_Float_End_BlueGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Blue_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Blue_LowUD)).EndInit();
            this.Effect_Float_End_GreenGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Green_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Green_LowUD)).EndInit();
            this.Effect_Float_End_RedGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Red_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_End_Red_LowUD)).EndInit();
            this.Effect_Float_StartGB.ResumeLayout(false);
            this.Effect_Float_StartGB.PerformLayout();
            this.Effect_Float_Start_BlueGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Blue_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Blue_LowUD)).EndInit();
            this.Effect_Float_Start_GreenGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Green_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Green_LowUD)).EndInit();
            this.Effect_Float_Start_RedGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Red_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Effect_Float_Start_Red_LowUD)).EndInit();
            this.EffectTabControl.ResumeLayout(false);
            this.tabStatic.ResumeLayout(false);
            this.tabStatic.PerformLayout();
            this.StaticMouseLightsGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.StaticKeyboardImageBox)).EndInit();
            this.tabReactive.ResumeLayout(false);
            this.ReactiveTabControl.ResumeLayout(false);
            this.ReactiveTab_Reactive.ResumeLayout(false);
            this.ReactiveTab_Reactive.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_DurationUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_FrequencyUD)).EndInit();
            this.Reactive_StartGB.ResumeLayout(false);
            this.Reactive_StartGB.PerformLayout();
            this.Reactive_Start_BlueGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Blue_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Blue_LowUD)).EndInit();
            this.Reactive_Start_GreenGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Green_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Green_LowUD)).EndInit();
            this.Reactive_Start_RedGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Red_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_Start_Red_LowUD)).EndInit();
            this.Reactive_EndGB.ResumeLayout(false);
            this.Reactive_EndGB.PerformLayout();
            this.Reactive_End_BlueGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Blue_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Blue_LowUD)).EndInit();
            this.Reactive_End_GreenGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Green_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Green_LowUD)).EndInit();
            this.Reactive_End_RedGB.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Red_HighUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Reactive_End_Red_LowUD)).EndInit();
            this.ReactiveTab_Heatmap.ResumeLayout(false);
            this.ReactiveTab_Heatmap.PerformLayout();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsIdleTimeUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSpectrographButton;
        private System.Windows.Forms.Button StopSpectrographButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ComboBox SettingsKeyboardModelCB;
        private System.Windows.Forms.ComboBox SettingsKeyboardLayoutCB;
        private System.Windows.Forms.NumericUpDown SpectroAmplitudeUD;
        private System.Windows.Forms.Label SpectroAmplitudeLabel;
        private System.Windows.Forms.NumericUpDown SpectroBgBrightnessUD;
        private System.Windows.Forms.Button DebugTestModeButton;
        private System.Windows.Forms.NumericUpDown DebugTesterUD;
        private System.Windows.Forms.RichTextBox DebugStatusLog;
        private System.Windows.Forms.NumericUpDown DebugLogLevelUD;
        private System.Windows.Forms.Label DebugLogLevelLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox SettingsMinimizeToTrayCheck;
        private System.Windows.Forms.ToolStripStatusLabel StatusLight;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Label SpectroRefreshDelayLabel;
        private System.Windows.Forms.NumericUpDown SpectroRefreshDelayUD;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmStartSpectro;
        private System.Windows.Forms.ToolStripMenuItem tsmStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmQuit;
        private System.Windows.Forms.CheckBox SettingsLaunchCueCheck;
        private System.Windows.Forms.Button SpectroColorBars;
        private System.Windows.Forms.ComboBox SpectroBgEffectCB;
        private System.Windows.Forms.Button SpectroColorBg;
        private System.Windows.Forms.PictureBox GraphicsPictureBox;
        private System.Windows.Forms.CheckBox SpectroShowGraphicsCheck;
        private System.Windows.Forms.Label SpectroWidthLabel;
        private System.Windows.Forms.NumericUpDown SpectroBgWidth;
        private System.Windows.Forms.Label SpectroSpeedLabel;
        private System.Windows.Forms.NumericUpDown SpectroBgSpeed;
        private System.Windows.Forms.CheckBox SettingsStartMinimizedCheck;
        private System.Windows.Forms.CheckBox SettingsEffectsOnStartCheck;
        private System.Windows.Forms.ComboBox SpectroWasapiDevicesCB;
        private System.Windows.Forms.RadioButton SpectroWasapiLoopbackRadio;
        private System.Windows.Forms.RadioButton SpectroWasapiRadio;
        private System.Windows.Forms.ComboBox SpectroBarEffectCB;
        private System.Windows.Forms.Label SpectroBrightnessLabel;
        private System.Windows.Forms.NumericUpDown SpectroBarBrightnessUD;
        private System.Windows.Forms.NumericUpDown SpectroBarSpeed;
        private System.Windows.Forms.NumericUpDown SpectroBarWidth;
        private System.Windows.Forms.Button SettingsGetUpdateButton;
        private System.Windows.Forms.CheckBox SettingsRestoreLightingCheck;
        private System.Windows.Forms.TabControl MainTabControl;
        private System.Windows.Forms.TabPage tabSpectro;
        private System.Windows.Forms.TabPage tabEffects;
        private System.Windows.Forms.TabPage tabStatic;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label SettingsCuePathLabel;
        private System.Windows.Forms.Button SettingsBrowseCuePathButton;
        private System.Windows.Forms.TextBox SettingsCuePathTextBox;
        private System.Windows.Forms.Button StaticGetKeyboardImage;
        private System.Windows.Forms.PictureBox StaticKeyboardImageBox;
        private System.Windows.Forms.Button StaticLoadProfileButton;
        private System.Windows.Forms.Button StaticSaveProfileButton;
        private System.Windows.Forms.Button StaticDeleteKeysButton;
        private System.Windows.Forms.Button StaticUpdateKeyboardButton;
        private System.Windows.Forms.Button StaticNewProfileButton;
        private System.Windows.Forms.CheckBox SettingsStaticOnStartCheck;
        private System.Windows.Forms.CheckBox SettingsSpectroOnStartCheck;
        private System.Windows.Forms.Button StaticPasteButton;
        private System.Windows.Forms.Button StaticCopyButton;
        private System.Windows.Forms.Button StaticCopyPasteColor;
        private System.Windows.Forms.Button StaticClearButton;
        private System.Windows.Forms.Button EffectsStartButton;
        private System.Windows.Forms.Label Effect_Float_FrequencyLabel;
        private System.Windows.Forms.Label Effect_Float_DurationLabel;
        private System.Windows.Forms.NumericUpDown Effect_Float_FrequencyUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_DurationUD;
        private System.Windows.Forms.GroupBox Effect_Float_StartGB;
        private System.Windows.Forms.GroupBox Effect_Float_Start_BlueGB;
        private System.Windows.Forms.NumericUpDown Effect_Float_Start_Blue_HighUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_Start_Blue_LowUD;
        private System.Windows.Forms.Button Effect_Float_Start_Blue_HighButton;
        private System.Windows.Forms.Button Effect_Float_Start_Blue_LowButton;
        private System.Windows.Forms.GroupBox Effect_Float_Start_GreenGB;
        private System.Windows.Forms.NumericUpDown Effect_Float_Start_Green_HighUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_Start_Green_LowUD;
        private System.Windows.Forms.Button Effect_Float_Start_Green_HighButton;
        private System.Windows.Forms.Button Effect_Float_Start_Green_LowButton;
        private System.Windows.Forms.GroupBox Effect_Float_Start_RedGB;
        private System.Windows.Forms.NumericUpDown Effect_Float_Start_Red_HighUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_Start_Red_LowUD;
        private System.Windows.Forms.Button Effect_Float_Start_Red_HighButton;
        private System.Windows.Forms.Button Effect_Float_Start_Red_LowButton;
        private System.Windows.Forms.Button Effect_Float_Start_ColourButton;
        private System.Windows.Forms.RadioButton Effect_Float_Start_RadioRandom;
        private System.Windows.Forms.RadioButton Effect_Float_Start_RadioDefined;
        private System.Windows.Forms.GroupBox Effect_Float_EndGB;
        private System.Windows.Forms.GroupBox Effect_Float_End_BlueGB;
        private System.Windows.Forms.NumericUpDown Effect_Float_End_Blue_HighUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_End_Blue_LowUD;
        private System.Windows.Forms.Button Effect_Float_End_Blue_HighButton;
        private System.Windows.Forms.Button Effect_Float_End_Blue_LowButton;
        private System.Windows.Forms.GroupBox Effect_Float_End_GreenGB;
        private System.Windows.Forms.NumericUpDown Effect_Float_End_Green_HighUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_End_Green_LowUD;
        private System.Windows.Forms.Button Effect_Float_End_Green_HighButton;
        private System.Windows.Forms.Button Effect_Float_End_Green_LowButton;
        private System.Windows.Forms.GroupBox Effect_Float_End_RedGB;
        private System.Windows.Forms.NumericUpDown Effect_Float_End_Red_HighUD;
        private System.Windows.Forms.NumericUpDown Effect_Float_End_Red_LowUD;
        private System.Windows.Forms.Button Effect_Float_End_Red_HighButton;
        private System.Windows.Forms.Button Effect_Float_End_Red_LowButton;
        private System.Windows.Forms.Button Effect_Float_End_ColourButton;
        private System.Windows.Forms.RadioButton Effect_Float_End_RadioRandom;
        private System.Windows.Forms.RadioButton Effect_Float_End_RadioDefined;
        private System.Windows.Forms.Button EffectsStopButton;
        private System.Windows.Forms.ToolStripMenuItem tsmShowStatic;
        private System.Windows.Forms.ToolStripMenuItem tsmStartEffects;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsmRefreshStatic;
        private System.Windows.Forms.Label SettingsIdleLabel3;
        private System.Windows.Forms.ComboBox SettingsIdleProfileCB;
        private System.Windows.Forms.ComboBox SettingsIdleModeCB;
        private System.Windows.Forms.Label SettingsIdleLabel2;
        private System.Windows.Forms.NumericUpDown SettingsIdleTimeUD;
        private System.Windows.Forms.Label SettingsIdleLabel1;
        private System.Windows.Forms.CheckBox SettingsIdleSwitcher;
        private System.Windows.Forms.ComboBox StaticProfileListCB;
        private System.Windows.Forms.Button StaticSaveProfileAsButton;
        private System.Windows.Forms.ToolStripMenuItem tsmSwitchStaticProfile;
        private System.Windows.Forms.ToolStripMenuItem tsmSpectroAmplitude;
        private ToolStripTrackBar tsmSpectroAmplitudeSlider;
        private System.Windows.Forms.CheckBox SettingsEffectsIncludeMouse;
        private System.Windows.Forms.ComboBox SettingsMouseModelCB;
        private System.Windows.Forms.GroupBox StaticMouseLightsGB;
        private System.Windows.Forms.Button StaticMouseLight4;
        private System.Windows.Forms.Button StaticMouseLight1;
        private System.Windows.Forms.Button StaticMouseLight2;
        private System.Windows.Forms.Button StaticMouseLight3;
        private System.Windows.Forms.TabControl EffectTabControl;
        private System.Windows.Forms.TabPage EffectTab_RandomLights;
        private System.Windows.Forms.TabPage EffectTab_Rainfall;
        private System.Windows.Forms.Button ReactiveStopButton;
        private System.Windows.Forms.Button ReactiveStartButton;
        private System.Windows.Forms.TabPage tabReactive;
        private System.Windows.Forms.CheckBox AnimationsUseStaticLights;
        private System.Windows.Forms.Button ToggleMuteOn;
        private System.Windows.Forms.Timer ToggleCheckTimer;
        private System.Windows.Forms.TabControl ReactiveTabControl;
        private System.Windows.Forms.TabPage ReactiveTab_Reactive;
        private System.Windows.Forms.GroupBox Reactive_StartGB;
        private System.Windows.Forms.RadioButton Reactive_Start_RadioRainbow;
        private System.Windows.Forms.GroupBox Reactive_Start_BlueGB;
        private System.Windows.Forms.NumericUpDown Reactive_Start_Blue_HighUD;
        private System.Windows.Forms.NumericUpDown Reactive_Start_Blue_LowUD;
        private System.Windows.Forms.Button Reactive_Start_Blue_HighButton;
        private System.Windows.Forms.Button Reactive_Start_Blue_LowButton;
        private System.Windows.Forms.GroupBox Reactive_Start_GreenGB;
        private System.Windows.Forms.NumericUpDown Reactive_Start_Green_HighUD;
        private System.Windows.Forms.NumericUpDown Reactive_Start_Green_LowUD;
        private System.Windows.Forms.Button Reactive_Start_Green_HighButton;
        private System.Windows.Forms.Button Reactive_Start_Green_LowButton;
        private System.Windows.Forms.GroupBox Reactive_Start_RedGB;
        private System.Windows.Forms.NumericUpDown Reactive_Start_Red_HighUD;
        private System.Windows.Forms.NumericUpDown Reactive_Start_Red_LowUD;
        private System.Windows.Forms.Button Reactive_Start_Red_HighButton;
        private System.Windows.Forms.Button Reactive_Start_Red_LowButton;
        private System.Windows.Forms.Button Reactive_Start_ColourButton;
        private System.Windows.Forms.RadioButton Reactive_Start_RadioRandom;
        private System.Windows.Forms.RadioButton Reactive_Start_RadioDefined;
        private System.Windows.Forms.GroupBox Reactive_EndGB;
        private System.Windows.Forms.GroupBox Reactive_End_BlueGB;
        private System.Windows.Forms.NumericUpDown Reactive_End_Blue_HighUD;
        private System.Windows.Forms.NumericUpDown Reactive_End_Blue_LowUD;
        private System.Windows.Forms.Button Reactive_End_Blue_HighButton;
        private System.Windows.Forms.Button Reactive_End_Blue_LowButton;
        private System.Windows.Forms.GroupBox Reactive_End_GreenGB;
        private System.Windows.Forms.NumericUpDown Reactive_End_Green_HighUD;
        private System.Windows.Forms.NumericUpDown Reactive_End_Green_LowUD;
        private System.Windows.Forms.Button Reactive_End_Green_HighButton;
        private System.Windows.Forms.Button Reactive_End_Green_LowButton;
        private System.Windows.Forms.GroupBox Reactive_End_RedGB;
        private System.Windows.Forms.NumericUpDown Reactive_End_Red_HighUD;
        private System.Windows.Forms.NumericUpDown Reactive_End_Red_LowUD;
        private System.Windows.Forms.Button Reactive_End_Red_HighButton;
        private System.Windows.Forms.Button Reactive_End_Red_LowButton;
        private System.Windows.Forms.Button Reactive_End_ColourButton;
        private System.Windows.Forms.RadioButton Reactive_End_RadioRandom;
        private System.Windows.Forms.RadioButton Reactive_End_RadioDefined;
        private System.Windows.Forms.TabPage ReactiveTab_Heatmap;
        private System.Windows.Forms.RadioButton Reactive_End_RadioOriginal;
        private System.Windows.Forms.Button ToggleNumOn;
        private System.Windows.Forms.Button ToggleScrollOn;
        private System.Windows.Forms.Button ToggleCapsOn;
        private System.Windows.Forms.Label Reactive_FrequencyLabel;
        private System.Windows.Forms.Label Reactive_DurationLabel;
        private System.Windows.Forms.NumericUpDown Reactive_DurationUD;
        private System.Windows.Forms.NumericUpDown Reactive_FrequencyUD;
        private System.Windows.Forms.Label Heatmap_End_ColourLabel;
        private System.Windows.Forms.Label Heatmap_Start_ColourLabel;
        private System.Windows.Forms.Button Heatmap_End_ColourButton;
        private System.Windows.Forms.Button Heatmap_Start_ColourButton;
        private System.Windows.Forms.Button Heatmap_ResetMaxButton;
        private System.Windows.Forms.ToolStripMenuItem tsmReactive;
        private System.Windows.Forms.ToolStripMenuItem tsmHeatmap;
        private System.Windows.Forms.ToolStripMenuItem tsmResetHeatmap;
        private System.Windows.Forms.CheckBox SettingsSuppressCueWarnings;
        private System.Windows.Forms.Label ToggleNumLabel;
        private System.Windows.Forms.Label ToggleCapsLabel;
        private System.Windows.Forms.Label ToggleMuteLabel;
        private System.Windows.Forms.Label ToggleScrollLabel;
        private System.Windows.Forms.Button ToggleScrollOff;
        private System.Windows.Forms.Button ToggleMuteOff;
        private System.Windows.Forms.Button ToggleNumOff;
        private System.Windows.Forms.Button ToggleCapsOff;
        private System.Windows.Forms.CheckBox UseToggleColoursCheck;

    }
}

