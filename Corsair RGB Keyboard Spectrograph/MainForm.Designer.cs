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
        /* Copy these into InitializeComponent every time the designer nukes it
        UpdateStatusMessage.NewMsg += UpdateStatusMessage_NewMsg;
        UpdateWorkerThread.NewAct += UpdateWorker_NewAct;
        UpdateGraphicOutput.NewOut += UpdateGraphicOutput_NewOut;
        */
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UpdateStatusMessage.NewMsg += UpdateStatusMessage_NewMsg;
            UpdateWorkerThread.NewAct += UpdateWorker_NewAct;
            UpdateGraphicOutput.NewOut += UpdateGraphicOutput_NewOut;
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
            this.tsmStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
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
            this.SettingsUSB3ModeCheck = new System.Windows.Forms.CheckBox();
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSpectro = new System.Windows.Forms.TabPage();
            this.tabEffects = new System.Windows.Forms.TabPage();
            this.EffectRandomRadio = new System.Windows.Forms.RadioButton();
            this.tabStatic = new System.Windows.Forms.TabPage();
            this.NewProfileButton = new System.Windows.Forms.Button();
            this.UpdateKeyboardButton = new System.Windows.Forms.Button();
            this.DeleteKeysButton = new System.Windows.Forms.Button();
            this.SaveProfileButton = new System.Windows.Forms.Button();
            this.LoadProfileButton = new System.Windows.Forms.Button();
            this.KeyboardImageBox = new System.Windows.Forms.PictureBox();
            this.StaticGetKeyboardImage = new System.Windows.Forms.Button();
            this.tabSettings = new System.Windows.Forms.TabPage();
            this.SettingsStaticOnStartCheck = new System.Windows.Forms.CheckBox();
            this.SettingsSpectroOnStartCheck = new System.Windows.Forms.CheckBox();
            this.SettingsBrowseCuePathButton = new System.Windows.Forms.Button();
            this.SettingsCuePathTextBox = new System.Windows.Forms.TextBox();
            this.SettingsCuePathLabel = new System.Windows.Forms.Label();
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
            this.tabControl1.SuspendLayout();
            this.tabSpectro.SuspendLayout();
            this.tabEffects.SuspendLayout();
            this.tabStatic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardImageBox)).BeginInit();
            this.tabSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartSpectrographButton
            // 
            this.StartSpectrographButton.Location = new System.Drawing.Point(15, 275);
            this.StartSpectrographButton.Name = "StartSpectrographButton";
            this.StartSpectrographButton.Size = new System.Drawing.Size(87, 23);
            this.StartSpectrographButton.TabIndex = 0;
            this.StartSpectrographButton.Text = "Start";
            this.StartSpectrographButton.UseVisualStyleBackColor = true;
            this.StartSpectrographButton.Click += new System.EventHandler(this.StartSpectrograph_Click);
            // 
            // StopSpectrographButton
            // 
            this.StopSpectrographButton.Location = new System.Drawing.Point(191, 275);
            this.StopSpectrographButton.Name = "StopSpectrographButton";
            this.StopSpectrographButton.Size = new System.Drawing.Size(87, 23);
            this.StopSpectrographButton.TabIndex = 1;
            this.StopSpectrographButton.Text = "Stop";
            this.StopSpectrographButton.UseVisualStyleBackColor = true;
            this.StopSpectrographButton.Click += new System.EventHandler(this.StopSpectrograph_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLight,
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 387);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(728, 22);
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
            this.SpectroAmplitudeUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.DebugTestModeButton.Location = new System.Drawing.Point(424, 309);
            this.DebugTestModeButton.Name = "DebugTestModeButton";
            this.DebugTestModeButton.Size = new System.Drawing.Size(87, 23);
            this.DebugTestModeButton.TabIndex = 20;
            this.DebugTestModeButton.Text = "Test Mode";
            this.DebugTestModeButton.UseVisualStyleBackColor = true;
            this.DebugTestModeButton.Click += new System.EventHandler(this.DebugTestModeButton_Click);
            // 
            // DebugTesterUD
            // 
            this.DebugTesterUD.Location = new System.Drawing.Point(517, 312);
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
            this.DebugStatusLog.Size = new System.Drawing.Size(278, 259);
            this.DebugStatusLog.TabIndex = 22;
            this.DebugStatusLog.Text = "";
            // 
            // DebugLogLevelUD
            // 
            this.DebugLogLevelUD.Location = new System.Drawing.Point(655, 312);
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
            this.DebugLogLevelLabel.Location = new System.Drawing.Point(592, 314);
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
            this.tsmStart,
            this.tsmStop,
            this.toolStripSeparator2,
            this.tsmQuit});
            this.RightClickMenu.Name = "contextMenuStrip1";
            this.RightClickMenu.ShowCheckMargin = true;
            this.RightClickMenu.ShowImageMargin = false;
            this.RightClickMenu.Size = new System.Drawing.Size(171, 104);
            // 
            // tsmAbout
            // 
            this.tsmAbout.Enabled = false;
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(170, 22);
            this.tsmAbout.Text = "RGB Spectrograph";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmStart
            // 
            this.tsmStart.Name = "tsmStart";
            this.tsmStart.Size = new System.Drawing.Size(170, 22);
            this.tsmStart.Text = "Start";
            this.tsmStart.Click += new System.EventHandler(this.StartSpectrograph_Click);
            // 
            // tsmStop
            // 
            this.tsmStop.Name = "tsmStop";
            this.tsmStop.Size = new System.Drawing.Size(170, 22);
            this.tsmStop.Text = "Stop";
            this.tsmStop.Click += new System.EventHandler(this.StopSpectrograph_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // tsmQuit
            // 
            this.tsmQuit.Name = "tsmQuit";
            this.tsmQuit.Size = new System.Drawing.Size(170, 22);
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
            this.SpectroColorBars.Click += new System.EventHandler(this.SpectroColorBars_Click);
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
            this.SpectroColorBg.Click += new System.EventHandler(this.SpectroColorBackground_Click);
            // 
            // GraphicsPictureBox
            // 
            this.GraphicsPictureBox.Location = new System.Drawing.Point(15, 81);
            this.GraphicsPictureBox.Name = "GraphicsPictureBox";
            this.GraphicsPictureBox.Size = new System.Drawing.Size(165, 68);
            this.GraphicsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GraphicsPictureBox.TabIndex = 32;
            this.GraphicsPictureBox.TabStop = false;
            // 
            // SettingsUSB3ModeCheck
            // 
            this.SettingsUSB3ModeCheck.AutoSize = true;
            this.SettingsUSB3ModeCheck.Location = new System.Drawing.Point(13, 214);
            this.SettingsUSB3ModeCheck.Name = "SettingsUSB3ModeCheck";
            this.SettingsUSB3ModeCheck.Size = new System.Drawing.Size(66, 17);
            this.SettingsUSB3ModeCheck.TabIndex = 33;
            this.SettingsUSB3ModeCheck.Text = "USB 3.0";
            this.SettingsUSB3ModeCheck.UseVisualStyleBackColor = true;
            this.SettingsUSB3ModeCheck.CheckedChanged += new System.EventHandler(this.SettingsUSB3Mode_CheckedChanged);
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
            15,
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
            this.SettingsGetUpdateButton.Location = new System.Drawing.Point(13, 248);
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
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSpectro);
            this.tabControl1.Controls.Add(this.tabEffects);
            this.tabControl1.Controls.Add(this.tabStatic);
            this.tabControl1.Controls.Add(this.tabSettings);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 365);
            this.tabControl1.TabIndex = 53;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
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
            this.tabSpectro.Size = new System.Drawing.Size(696, 339);
            this.tabSpectro.TabIndex = 0;
            this.tabSpectro.Text = "Spectro";
            this.tabSpectro.UseVisualStyleBackColor = true;
            // 
            // tabEffects
            // 
            this.tabEffects.Controls.Add(this.EffectRandomRadio);
            this.tabEffects.Location = new System.Drawing.Point(4, 22);
            this.tabEffects.Name = "tabEffects";
            this.tabEffects.Size = new System.Drawing.Size(696, 339);
            this.tabEffects.TabIndex = 3;
            this.tabEffects.Text = "Effects";
            this.tabEffects.UseVisualStyleBackColor = true;
            // 
            // EffectRandomRadio
            // 
            this.EffectRandomRadio.AutoSize = true;
            this.EffectRandomRadio.Checked = true;
            this.EffectRandomRadio.Location = new System.Drawing.Point(12, 15);
            this.EffectRandomRadio.Name = "EffectRandomRadio";
            this.EffectRandomRadio.Size = new System.Drawing.Size(126, 17);
            this.EffectRandomRadio.TabIndex = 0;
            this.EffectRandomRadio.TabStop = true;
            this.EffectRandomRadio.Text = "Light up random keys";
            this.EffectRandomRadio.UseVisualStyleBackColor = true;
            // 
            // tabStatic
            // 
            this.tabStatic.Controls.Add(this.NewProfileButton);
            this.tabStatic.Controls.Add(this.UpdateKeyboardButton);
            this.tabStatic.Controls.Add(this.DeleteKeysButton);
            this.tabStatic.Controls.Add(this.SaveProfileButton);
            this.tabStatic.Controls.Add(this.LoadProfileButton);
            this.tabStatic.Controls.Add(this.KeyboardImageBox);
            this.tabStatic.Controls.Add(this.StaticGetKeyboardImage);
            this.tabStatic.Location = new System.Drawing.Point(4, 22);
            this.tabStatic.Name = "tabStatic";
            this.tabStatic.Size = new System.Drawing.Size(696, 339);
            this.tabStatic.TabIndex = 4;
            this.tabStatic.Text = "Static Keys";
            this.tabStatic.UseVisualStyleBackColor = true;
            // 
            // NewProfileButton
            // 
            this.NewProfileButton.Location = new System.Drawing.Point(15, 241);
            this.NewProfileButton.Name = "NewProfileButton";
            this.NewProfileButton.Size = new System.Drawing.Size(75, 23);
            this.NewProfileButton.TabIndex = 7;
            this.NewProfileButton.Text = "New Profile";
            this.NewProfileButton.UseVisualStyleBackColor = true;
            this.NewProfileButton.Click += new System.EventHandler(this.NewProfileButton_Click);
            // 
            // UpdateKeyboardButton
            // 
            this.UpdateKeyboardButton.Location = new System.Drawing.Point(177, 270);
            this.UpdateKeyboardButton.Name = "UpdateKeyboardButton";
            this.UpdateKeyboardButton.Size = new System.Drawing.Size(75, 23);
            this.UpdateKeyboardButton.TabIndex = 6;
            this.UpdateKeyboardButton.Text = "Update Out";
            this.UpdateKeyboardButton.UseVisualStyleBackColor = true;
            this.UpdateKeyboardButton.Click += new System.EventHandler(this.UpdateKeyboardButton_Click);
            // 
            // DeleteKeysButton
            // 
            this.DeleteKeysButton.Location = new System.Drawing.Point(96, 270);
            this.DeleteKeysButton.Name = "DeleteKeysButton";
            this.DeleteKeysButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteKeysButton.TabIndex = 5;
            this.DeleteKeysButton.Text = "Delete Keys";
            this.DeleteKeysButton.UseVisualStyleBackColor = true;
            this.DeleteKeysButton.Visible = false;
            this.DeleteKeysButton.Click += new System.EventHandler(this.DeleteKeys_Click);
            // 
            // SaveProfileButton
            // 
            this.SaveProfileButton.Location = new System.Drawing.Point(177, 241);
            this.SaveProfileButton.Name = "SaveProfileButton";
            this.SaveProfileButton.Size = new System.Drawing.Size(75, 23);
            this.SaveProfileButton.TabIndex = 4;
            this.SaveProfileButton.Text = "Save Profile";
            this.SaveProfileButton.UseVisualStyleBackColor = true;
            this.SaveProfileButton.Click += new System.EventHandler(this.SaveProfileButton_Click);
            // 
            // LoadProfileButton
            // 
            this.LoadProfileButton.Location = new System.Drawing.Point(96, 241);
            this.LoadProfileButton.Name = "LoadProfileButton";
            this.LoadProfileButton.Size = new System.Drawing.Size(75, 23);
            this.LoadProfileButton.TabIndex = 3;
            this.LoadProfileButton.Text = "Load Profile";
            this.LoadProfileButton.UseVisualStyleBackColor = true;
            this.LoadProfileButton.Click += new System.EventHandler(this.LoadProfileButton_Click);
            // 
            // KeyboardImageBox
            // 
            this.KeyboardImageBox.Location = new System.Drawing.Point(15, 13);
            this.KeyboardImageBox.Name = "KeyboardImageBox";
            this.KeyboardImageBox.Size = new System.Drawing.Size(660, 222);
            this.KeyboardImageBox.TabIndex = 2;
            this.KeyboardImageBox.TabStop = false;
            // 
            // StaticGetKeyboardImage
            // 
            this.StaticGetKeyboardImage.Location = new System.Drawing.Point(15, 270);
            this.StaticGetKeyboardImage.Name = "StaticGetKeyboardImage";
            this.StaticGetKeyboardImage.Size = new System.Drawing.Size(75, 23);
            this.StaticGetKeyboardImage.TabIndex = 1;
            this.StaticGetKeyboardImage.Text = "Get Image";
            this.StaticGetKeyboardImage.UseVisualStyleBackColor = true;
            this.StaticGetKeyboardImage.Visible = false;
            this.StaticGetKeyboardImage.Click += new System.EventHandler(this.StaticGetKeyboardImage_Click);
            // 
            // tabSettings
            // 
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
            this.tabSettings.Controls.Add(this.SettingsUSB3ModeCheck);
            this.tabSettings.Controls.Add(this.SettingsStartMinimizedCheck);
            this.tabSettings.Controls.Add(this.SettingsEffectsOnStartCheck);
            this.tabSettings.Location = new System.Drawing.Point(4, 22);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.Size = new System.Drawing.Size(696, 339);
            this.tabSettings.TabIndex = 2;
            this.tabSettings.Text = "Settings";
            this.tabSettings.UseVisualStyleBackColor = true;
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
            this.SettingsBrowseCuePathButton.Location = new System.Drawing.Point(13, 305);
            this.SettingsBrowseCuePathButton.Name = "SettingsBrowseCuePathButton";
            this.SettingsBrowseCuePathButton.Size = new System.Drawing.Size(87, 23);
            this.SettingsBrowseCuePathButton.TabIndex = 55;
            this.SettingsBrowseCuePathButton.Text = "Browse";
            this.SettingsBrowseCuePathButton.UseVisualStyleBackColor = true;
            this.SettingsBrowseCuePathButton.Click += new System.EventHandler(this.SettingsBrowseCuePathButton_Click);
            // 
            // SettingsCuePathTextBox
            // 
            this.SettingsCuePathTextBox.Location = new System.Drawing.Point(106, 307);
            this.SettingsCuePathTextBox.Name = "SettingsCuePathTextBox";
            this.SettingsCuePathTextBox.Size = new System.Drawing.Size(580, 20);
            this.SettingsCuePathTextBox.TabIndex = 54;
            this.SettingsCuePathTextBox.TextChanged += new System.EventHandler(this.SettingsCuePathTextBox_TextChanged);
            // 
            // SettingsCuePathLabel
            // 
            this.SettingsCuePathLabel.AutoSize = true;
            this.SettingsCuePathLabel.Location = new System.Drawing.Point(103, 291);
            this.SettingsCuePathLabel.Name = "SettingsCuePathLabel";
            this.SettingsCuePathLabel.Size = new System.Drawing.Size(128, 13);
            this.SettingsCuePathLabel.TabIndex = 53;
            this.SettingsCuePathLabel.Text = "Corsair Utility Engine Path";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(728, 409);
            this.Controls.Add(this.DebugTestModeButton);
            this.Controls.Add(this.DebugTesterUD);
            this.Controls.Add(this.DebugStatusLog);
            this.Controls.Add(this.DebugLogLevelUD);
            this.Controls.Add(this.DebugLogLevelLabel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RGB Keyboard Spectrograph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
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
            this.tabControl1.ResumeLayout(false);
            this.tabSpectro.ResumeLayout(false);
            this.tabSpectro.PerformLayout();
            this.tabEffects.ResumeLayout(false);
            this.tabEffects.PerformLayout();
            this.tabStatic.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.KeyboardImageBox)).EndInit();
            this.tabSettings.ResumeLayout(false);
            this.tabSettings.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem tsmStart;
        private System.Windows.Forms.ToolStripMenuItem tsmStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmQuit;
        private System.Windows.Forms.CheckBox SettingsLaunchCueCheck;
        private System.Windows.Forms.Button SpectroColorBars;
        private System.Windows.Forms.ComboBox SpectroBgEffectCB;
        private System.Windows.Forms.Button SpectroColorBg;
        private System.Windows.Forms.PictureBox GraphicsPictureBox;
        private System.Windows.Forms.CheckBox SettingsUSB3ModeCheck;
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabSpectro;
        private System.Windows.Forms.TabPage tabEffects;
        private System.Windows.Forms.TabPage tabStatic;
        private System.Windows.Forms.TabPage tabSettings;
        private System.Windows.Forms.Label SettingsCuePathLabel;
        private System.Windows.Forms.Button SettingsBrowseCuePathButton;
        private System.Windows.Forms.TextBox SettingsCuePathTextBox;
        private System.Windows.Forms.RadioButton EffectRandomRadio;
        private System.Windows.Forms.Button StaticGetKeyboardImage;
        private System.Windows.Forms.PictureBox KeyboardImageBox;
        private System.Windows.Forms.Button LoadProfileButton;
        private System.Windows.Forms.Button SaveProfileButton;
        private System.Windows.Forms.Button DeleteKeysButton;
        private System.Windows.Forms.Button UpdateKeyboardButton;
        private System.Windows.Forms.Button NewProfileButton;
        private System.Windows.Forms.CheckBox SettingsStaticOnStartCheck;
        private System.Windows.Forms.CheckBox SettingsSpectroOnStartCheck;

    }
}

