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
            this.KeyboardModelComboBox = new System.Windows.Forms.ComboBox();
            this.KeyboardLayoutComboBox = new System.Windows.Forms.ComboBox();
            this.AmplitudeUD = new System.Windows.Forms.NumericUpDown();
            this.lblAmplitude = new System.Windows.Forms.Label();
            this.lblRainbowBrightness = new System.Windows.Forms.Label();
            this.BackgroundBrightnessUD = new System.Windows.Forms.NumericUpDown();
            this.TestModeButton = new System.Windows.Forms.Button();
            this.TesterUD = new System.Windows.Forms.NumericUpDown();
            this.StatusLog = new System.Windows.Forms.RichTextBox();
            this.LogLevelUD = new System.Windows.Forms.NumericUpDown();
            this.LogLevelLabel = new System.Windows.Forms.Label();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.RightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmStart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MinimizeToTrayCheck = new System.Windows.Forms.CheckBox();
            this.StatusTimer = new System.Windows.Forms.Timer(this.components);
            this.RefreshDelayLabel = new System.Windows.Forms.Label();
            this.RefreshDelayUD = new System.Windows.Forms.NumericUpDown();
            this.LaunchCueCheck = new System.Windows.Forms.CheckBox();
            this.colorBars = new System.Windows.Forms.Button();
            this.BackgroundEffectComboBox = new System.Windows.Forms.ComboBox();
            this.colorBackground = new System.Windows.Forms.Button();
            this.GraphicsPictureBox = new System.Windows.Forms.PictureBox();
            this.USB3ModeCheck = new System.Windows.Forms.CheckBox();
            this.ShowGraphicsCheck = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EffectWidth = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.EffectSpeed = new System.Windows.Forms.NumericUpDown();
            this.ShowSettings = new System.Windows.Forms.Button();
            this.ShowDebug = new System.Windows.Forms.Button();
            this.StartMinimizedCheck = new System.Windows.Forms.CheckBox();
            this.EffectsOnStartCheck = new System.Windows.Forms.CheckBox();
            this.comboWasapiDevices = new System.Windows.Forms.ComboBox();
            this.radioButtonWasapiLoopback = new System.Windows.Forms.RadioButton();
            this.radioButtonWasapi = new System.Windows.Forms.RadioButton();
            this.BarEffectComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.BarBrightnessUD = new System.Windows.Forms.NumericUpDown();
            this.BarSpeed = new System.Windows.Forms.NumericUpDown();
            this.BarWidth = new System.Windows.Forms.NumericUpDown();
            this.GetUpdateButton = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundBrightnessUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TesterUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogLevelUD)).BeginInit();
            this.RightClickMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RefreshDelayUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffectWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffectSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarBrightnessUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // StartSpectrographButton
            // 
            this.StartSpectrographButton.Location = new System.Drawing.Point(12, 282);
            this.StartSpectrographButton.Name = "StartSpectrographButton";
            this.StartSpectrographButton.Size = new System.Drawing.Size(87, 23);
            this.StartSpectrographButton.TabIndex = 0;
            this.StartSpectrographButton.Text = "Start";
            this.StartSpectrographButton.UseVisualStyleBackColor = true;
            this.StartSpectrographButton.Click += new System.EventHandler(this.StartSpectrograph_Click);
            // 
            // StopSpectrographButton
            // 
            this.StopSpectrographButton.Location = new System.Drawing.Point(198, 282);
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 440);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(663, 22);
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
            // KeyboardModelComboBox
            // 
            this.KeyboardModelComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyboardModelComboBox.FormattingEnabled = true;
            this.KeyboardModelComboBox.Location = new System.Drawing.Point(12, 12);
            this.KeyboardModelComboBox.Name = "KeyboardModelComboBox";
            this.KeyboardModelComboBox.Size = new System.Drawing.Size(130, 21);
            this.KeyboardModelComboBox.TabIndex = 4;
            this.KeyboardModelComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyboardModelComboBox_SelectedIndexChanged);
            // 
            // KeyboardLayoutComboBox
            // 
            this.KeyboardLayoutComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeyboardLayoutComboBox.FormattingEnabled = true;
            this.KeyboardLayoutComboBox.Location = new System.Drawing.Point(155, 12);
            this.KeyboardLayoutComboBox.Name = "KeyboardLayoutComboBox";
            this.KeyboardLayoutComboBox.Size = new System.Drawing.Size(130, 21);
            this.KeyboardLayoutComboBox.TabIndex = 6;
            this.KeyboardLayoutComboBox.SelectedIndexChanged += new System.EventHandler(this.KeyboardLayoutComboBox_SelectedIndexChanged);
            // 
            // AmplitudeUD
            // 
            this.AmplitudeUD.Location = new System.Drawing.Point(238, 57);
            this.AmplitudeUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmplitudeUD.Name = "AmplitudeUD";
            this.AmplitudeUD.Size = new System.Drawing.Size(47, 20);
            this.AmplitudeUD.TabIndex = 8;
            this.AmplitudeUD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AmplitudeUD.ValueChanged += new System.EventHandler(this.AmplitudeUD_ValueChanged);
            // 
            // lblAmplitude
            // 
            this.lblAmplitude.AutoSize = true;
            this.lblAmplitude.Location = new System.Drawing.Point(175, 59);
            this.lblAmplitude.Name = "lblAmplitude";
            this.lblAmplitude.Size = new System.Drawing.Size(57, 13);
            this.lblAmplitude.TabIndex = 9;
            this.lblAmplitude.Text = "Sensitivity:";
            // 
            // lblRainbowBrightness
            // 
            this.lblRainbowBrightness.AutoSize = true;
            this.lblRainbowBrightness.Location = new System.Drawing.Point(12, 85);
            this.lblRainbowBrightness.Name = "lblRainbowBrightness";
            this.lblRainbowBrightness.Size = new System.Drawing.Size(77, 13);
            this.lblRainbowBrightness.TabIndex = 19;
            this.lblRainbowBrightness.Text = "BG Brightness:";
            // 
            // BackgroundBrightnessUD
            // 
            this.BackgroundBrightnessUD.Location = new System.Drawing.Point(95, 83);
            this.BackgroundBrightnessUD.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.BackgroundBrightnessUD.Name = "BackgroundBrightnessUD";
            this.BackgroundBrightnessUD.Size = new System.Drawing.Size(47, 20);
            this.BackgroundBrightnessUD.TabIndex = 18;
            this.BackgroundBrightnessUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.BackgroundBrightnessUD.ValueChanged += new System.EventHandler(this.BackgroundBrightnessUD_ValueChanged);
            // 
            // TestModeButton
            // 
            this.TestModeButton.Location = new System.Drawing.Point(300, 282);
            this.TestModeButton.Name = "TestModeButton";
            this.TestModeButton.Size = new System.Drawing.Size(87, 23);
            this.TestModeButton.TabIndex = 20;
            this.TestModeButton.Text = "Test Mode";
            this.TestModeButton.UseVisualStyleBackColor = true;
            this.TestModeButton.Click += new System.EventHandler(this.TestModeButton_Click);
            // 
            // TesterUD
            // 
            this.TesterUD.Location = new System.Drawing.Point(393, 285);
            this.TesterUD.Maximum = new decimal(new int[] {
            143,
            0,
            0,
            0});
            this.TesterUD.Name = "TesterUD";
            this.TesterUD.Size = new System.Drawing.Size(47, 20);
            this.TesterUD.TabIndex = 21;
            this.TesterUD.ValueChanged += new System.EventHandler(this.TesterUD_ValueChanged);
            // 
            // StatusLog
            // 
            this.StatusLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.StatusLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLog.HideSelection = false;
            this.StatusLog.Location = new System.Drawing.Point(300, 12);
            this.StatusLog.Name = "StatusLog";
            this.StatusLog.Size = new System.Drawing.Size(356, 264);
            this.StatusLog.TabIndex = 22;
            this.StatusLog.Text = "";
            // 
            // LogLevelUD
            // 
            this.LogLevelUD.Location = new System.Drawing.Point(526, 285);
            this.LogLevelUD.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.LogLevelUD.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LogLevelUD.Name = "LogLevelUD";
            this.LogLevelUD.Size = new System.Drawing.Size(47, 20);
            this.LogLevelUD.TabIndex = 23;
            this.LogLevelUD.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.LogLevelUD.ValueChanged += new System.EventHandler(this.VerbosityUD_ValueChanged);
            // 
            // LogLevelLabel
            // 
            this.LogLevelLabel.AutoSize = true;
            this.LogLevelLabel.Location = new System.Drawing.Point(463, 287);
            this.LogLevelLabel.Name = "LogLevelLabel";
            this.LogLevelLabel.Size = new System.Drawing.Size(57, 13);
            this.LogLevelLabel.TabIndex = 24;
            this.LogLevelLabel.Text = "Log Level:";
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
            // MinimizeToTrayCheck
            // 
            this.MinimizeToTrayCheck.AutoSize = true;
            this.MinimizeToTrayCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.MinimizeToTrayCheck.Location = new System.Drawing.Point(146, 338);
            this.MinimizeToTrayCheck.Name = "MinimizeToTrayCheck";
            this.MinimizeToTrayCheck.Size = new System.Drawing.Size(139, 17);
            this.MinimizeToTrayCheck.TabIndex = 25;
            this.MinimizeToTrayCheck.Text = "Minimize to System Tray";
            this.MinimizeToTrayCheck.UseVisualStyleBackColor = true;
            // 
            // StatusTimer
            // 
            this.StatusTimer.Tick += new System.EventHandler(this.StatusTimer_Tick);
            // 
            // RefreshDelayLabel
            // 
            this.RefreshDelayLabel.AutoSize = true;
            this.RefreshDelayLabel.Location = new System.Drawing.Point(12, 59);
            this.RefreshDelayLabel.Name = "RefreshDelayLabel";
            this.RefreshDelayLabel.Size = new System.Drawing.Size(77, 13);
            this.RefreshDelayLabel.TabIndex = 27;
            this.RefreshDelayLabel.Text = "Refresh Delay:";
            // 
            // RefreshDelayUD
            // 
            this.RefreshDelayUD.Location = new System.Drawing.Point(95, 57);
            this.RefreshDelayUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.RefreshDelayUD.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.RefreshDelayUD.Name = "RefreshDelayUD";
            this.RefreshDelayUD.Size = new System.Drawing.Size(47, 20);
            this.RefreshDelayUD.TabIndex = 26;
            this.RefreshDelayUD.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.RefreshDelayUD.ValueChanged += new System.EventHandler(this.RefreshDelayUD_ValueChanged);
            // 
            // LaunchCueCheck
            // 
            this.LaunchCueCheck.AutoSize = true;
            this.LaunchCueCheck.Location = new System.Drawing.Point(12, 338);
            this.LaunchCueCheck.Name = "LaunchCueCheck";
            this.LaunchCueCheck.Size = new System.Drawing.Size(122, 17);
            this.LaunchCueCheck.TabIndex = 28;
            this.LaunchCueCheck.Text = "Launch CUE on Exit";
            this.LaunchCueCheck.UseVisualStyleBackColor = true;
            // 
            // colorBars
            // 
            this.colorBars.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBars.Location = new System.Drawing.Point(130, 155);
            this.colorBars.Name = "colorBars";
            this.colorBars.Size = new System.Drawing.Size(55, 23);
            this.colorBars.TabIndex = 29;
            this.colorBars.Text = "Bars";
            this.colorBars.UseVisualStyleBackColor = true;
            this.colorBars.Click += new System.EventHandler(this.colorBars_Click);
            // 
            // BackgroundEffectComboBox
            // 
            this.BackgroundEffectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BackgroundEffectComboBox.FormattingEnabled = true;
            this.BackgroundEffectComboBox.Location = new System.Drawing.Point(12, 128);
            this.BackgroundEffectComboBox.Name = "BackgroundEffectComboBox";
            this.BackgroundEffectComboBox.Size = new System.Drawing.Size(112, 21);
            this.BackgroundEffectComboBox.TabIndex = 30;
            this.BackgroundEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.BackgroundEffectComboBox_SelectedIndexChanged);
            // 
            // colorBackground
            // 
            this.colorBackground.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.colorBackground.Location = new System.Drawing.Point(130, 126);
            this.colorBackground.Name = "colorBackground";
            this.colorBackground.Size = new System.Drawing.Size(55, 23);
            this.colorBackground.TabIndex = 31;
            this.colorBackground.Text = "BG";
            this.colorBackground.UseVisualStyleBackColor = true;
            this.colorBackground.Click += new System.EventHandler(this.colorBackground_Click);
            // 
            // GraphicsPictureBox
            // 
            this.GraphicsPictureBox.Location = new System.Drawing.Point(12, 184);
            this.GraphicsPictureBox.Name = "GraphicsPictureBox";
            this.GraphicsPictureBox.Size = new System.Drawing.Size(165, 68);
            this.GraphicsPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GraphicsPictureBox.TabIndex = 32;
            this.GraphicsPictureBox.TabStop = false;
            // 
            // USB3ModeCheck
            // 
            this.USB3ModeCheck.AutoSize = true;
            this.USB3ModeCheck.Location = new System.Drawing.Point(12, 361);
            this.USB3ModeCheck.Name = "USB3ModeCheck";
            this.USB3ModeCheck.Size = new System.Drawing.Size(66, 17);
            this.USB3ModeCheck.TabIndex = 33;
            this.USB3ModeCheck.Text = "USB 3.0";
            this.USB3ModeCheck.UseVisualStyleBackColor = true;
            this.USB3ModeCheck.CheckedChanged += new System.EventHandler(this.USB3Mode_CheckedChanged);
            // 
            // ShowGraphicsCheck
            // 
            this.ShowGraphicsCheck.AutoSize = true;
            this.ShowGraphicsCheck.Location = new System.Drawing.Point(12, 259);
            this.ShowGraphicsCheck.Name = "ShowGraphicsCheck";
            this.ShowGraphicsCheck.Size = new System.Drawing.Size(136, 17);
            this.ShowGraphicsCheck.TabIndex = 34;
            this.ShowGraphicsCheck.Text = "Show Graphical Output";
            this.ShowGraphicsCheck.UseVisualStyleBackColor = true;
            this.ShowGraphicsCheck.CheckedChanged += new System.EventHandler(this.ShowGraphicsCheck_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 35;
            this.label1.Text = "Width";
            // 
            // EffectWidth
            // 
            this.EffectWidth.Location = new System.Drawing.Point(191, 129);
            this.EffectWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.EffectWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EffectWidth.Name = "EffectWidth";
            this.EffectWidth.Size = new System.Drawing.Size(47, 20);
            this.EffectWidth.TabIndex = 36;
            this.EffectWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.EffectWidth.ValueChanged += new System.EventHandler(this.EffectWidth_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(247, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 38;
            this.label2.Text = "Speed";
            // 
            // EffectSpeed
            // 
            this.EffectSpeed.DecimalPlaces = 1;
            this.EffectSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.EffectSpeed.Location = new System.Drawing.Point(244, 129);
            this.EffectSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.EffectSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.EffectSpeed.Name = "EffectSpeed";
            this.EffectSpeed.Size = new System.Drawing.Size(41, 20);
            this.EffectSpeed.TabIndex = 37;
            this.EffectSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.EffectSpeed.ValueChanged += new System.EventHandler(this.EffectSpeed_ValueChanged);
            // 
            // ShowSettings
            // 
            this.ShowSettings.Location = new System.Drawing.Point(198, 229);
            this.ShowSettings.Name = "ShowSettings";
            this.ShowSettings.Size = new System.Drawing.Size(87, 23);
            this.ShowSettings.TabIndex = 39;
            this.ShowSettings.Text = "Settings";
            this.ShowSettings.UseVisualStyleBackColor = true;
            this.ShowSettings.Click += new System.EventHandler(this.ShowSettings_Click);
            // 
            // ShowDebug
            // 
            this.ShowDebug.Location = new System.Drawing.Point(198, 200);
            this.ShowDebug.Name = "ShowDebug";
            this.ShowDebug.Size = new System.Drawing.Size(87, 23);
            this.ShowDebug.TabIndex = 40;
            this.ShowDebug.Text = "Debug";
            this.ShowDebug.UseVisualStyleBackColor = true;
            this.ShowDebug.Click += new System.EventHandler(this.ShowDebug_Click);
            // 
            // StartMinimizedCheck
            // 
            this.StartMinimizedCheck.AutoSize = true;
            this.StartMinimizedCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StartMinimizedCheck.Location = new System.Drawing.Point(188, 361);
            this.StartMinimizedCheck.Name = "StartMinimizedCheck";
            this.StartMinimizedCheck.Size = new System.Drawing.Size(97, 17);
            this.StartMinimizedCheck.TabIndex = 41;
            this.StartMinimizedCheck.Text = "Start Minimized";
            this.StartMinimizedCheck.UseVisualStyleBackColor = true;
            // 
            // EffectsOnStartCheck
            // 
            this.EffectsOnStartCheck.AutoSize = true;
            this.EffectsOnStartCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.EffectsOnStartCheck.Location = new System.Drawing.Point(186, 384);
            this.EffectsOnStartCheck.Name = "EffectsOnStartCheck";
            this.EffectsOnStartCheck.Size = new System.Drawing.Size(99, 17);
            this.EffectsOnStartCheck.TabIndex = 42;
            this.EffectsOnStartCheck.Text = "Effects on Start";
            this.EffectsOnStartCheck.UseVisualStyleBackColor = true;
            // 
            // comboWasapiDevices
            // 
            this.comboWasapiDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboWasapiDevices.FormattingEnabled = true;
            this.comboWasapiDevices.Location = new System.Drawing.Point(130, 407);
            this.comboWasapiDevices.Name = "comboWasapiDevices";
            this.comboWasapiDevices.Size = new System.Drawing.Size(155, 21);
            this.comboWasapiDevices.TabIndex = 45;
            this.comboWasapiDevices.SelectedIndexChanged += new System.EventHandler(this.comboWasapiDevices_SelectedIndexChanged);
            // 
            // radioButtonWasapiLoopback
            // 
            this.radioButtonWasapiLoopback.AutoSize = true;
            this.radioButtonWasapiLoopback.Checked = true;
            this.radioButtonWasapiLoopback.Location = new System.Drawing.Point(12, 408);
            this.radioButtonWasapiLoopback.Name = "radioButtonWasapiLoopback";
            this.radioButtonWasapiLoopback.Size = new System.Drawing.Size(57, 17);
            this.radioButtonWasapiLoopback.TabIndex = 43;
            this.radioButtonWasapiLoopback.TabStop = true;
            this.radioButtonWasapiLoopback.Text = "Output";
            this.radioButtonWasapiLoopback.UseVisualStyleBackColor = true;
            this.radioButtonWasapiLoopback.CheckedChanged += new System.EventHandler(this.radioButtonWasapiLoopback_CheckedChanged);
            // 
            // radioButtonWasapi
            // 
            this.radioButtonWasapi.AutoSize = true;
            this.radioButtonWasapi.Location = new System.Drawing.Point(75, 408);
            this.radioButtonWasapi.Name = "radioButtonWasapi";
            this.radioButtonWasapi.Size = new System.Drawing.Size(49, 17);
            this.radioButtonWasapi.TabIndex = 44;
            this.radioButtonWasapi.Text = "Input";
            this.radioButtonWasapi.UseVisualStyleBackColor = true;
            this.radioButtonWasapi.CheckedChanged += new System.EventHandler(this.radioButtonWasapi_CheckedChanged);
            // 
            // BarEffectComboBox
            // 
            this.BarEffectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BarEffectComboBox.FormattingEnabled = true;
            this.BarEffectComboBox.Location = new System.Drawing.Point(12, 157);
            this.BarEffectComboBox.Name = "BarEffectComboBox";
            this.BarEffectComboBox.Size = new System.Drawing.Size(112, 21);
            this.BarEffectComboBox.TabIndex = 46;
            this.BarEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.BarEffectComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(154, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Bar Brightness:";
            // 
            // BarBrightnessUD
            // 
            this.BarBrightnessUD.Location = new System.Drawing.Point(238, 83);
            this.BarBrightnessUD.Maximum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.BarBrightnessUD.Name = "BarBrightnessUD";
            this.BarBrightnessUD.Size = new System.Drawing.Size(47, 20);
            this.BarBrightnessUD.TabIndex = 47;
            this.BarBrightnessUD.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.BarBrightnessUD.ValueChanged += new System.EventHandler(this.BarBrightnessUD_ValueChanged);
            // 
            // BarSpeed
            // 
            this.BarSpeed.DecimalPlaces = 1;
            this.BarSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.BarSpeed.Location = new System.Drawing.Point(244, 158);
            this.BarSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.BarSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.BarSpeed.Name = "BarSpeed";
            this.BarSpeed.Size = new System.Drawing.Size(41, 20);
            this.BarSpeed.TabIndex = 50;
            this.BarSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BarSpeed.ValueChanged += new System.EventHandler(this.BarSpeed_ValueChanged);
            // 
            // BarWidth
            // 
            this.BarWidth.Location = new System.Drawing.Point(191, 158);
            this.BarWidth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BarWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.BarWidth.Name = "BarWidth";
            this.BarWidth.Size = new System.Drawing.Size(47, 20);
            this.BarWidth.TabIndex = 49;
            this.BarWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.BarWidth.ValueChanged += new System.EventHandler(this.BarWidth_ValueChanged);
            // 
            // GetUpdateButton
            // 
            this.GetUpdateButton.Location = new System.Drawing.Point(105, 282);
            this.GetUpdateButton.Name = "GetUpdateButton";
            this.GetUpdateButton.Size = new System.Drawing.Size(87, 23);
            this.GetUpdateButton.TabIndex = 51;
            this.GetUpdateButton.Text = "Get Update";
            this.GetUpdateButton.UseVisualStyleBackColor = true;
            this.GetUpdateButton.Visible = false;
            this.GetUpdateButton.Click += new System.EventHandler(this.GetUpdateButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(663, 462);
            this.Controls.Add(this.GetUpdateButton);
            this.Controls.Add(this.BarSpeed);
            this.Controls.Add(this.BarWidth);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BarBrightnessUD);
            this.Controls.Add(this.BarEffectComboBox);
            this.Controls.Add(this.comboWasapiDevices);
            this.Controls.Add(this.radioButtonWasapiLoopback);
            this.Controls.Add(this.radioButtonWasapi);
            this.Controls.Add(this.EffectsOnStartCheck);
            this.Controls.Add(this.StartMinimizedCheck);
            this.Controls.Add(this.ShowDebug);
            this.Controls.Add(this.ShowSettings);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EffectSpeed);
            this.Controls.Add(this.EffectWidth);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowGraphicsCheck);
            this.Controls.Add(this.USB3ModeCheck);
            this.Controls.Add(this.GraphicsPictureBox);
            this.Controls.Add(this.colorBackground);
            this.Controls.Add(this.BackgroundEffectComboBox);
            this.Controls.Add(this.colorBars);
            this.Controls.Add(this.LaunchCueCheck);
            this.Controls.Add(this.RefreshDelayLabel);
            this.Controls.Add(this.RefreshDelayUD);
            this.Controls.Add(this.MinimizeToTrayCheck);
            this.Controls.Add(this.LogLevelLabel);
            this.Controls.Add(this.LogLevelUD);
            this.Controls.Add(this.StatusLog);
            this.Controls.Add(this.TesterUD);
            this.Controls.Add(this.TestModeButton);
            this.Controls.Add(this.lblRainbowBrightness);
            this.Controls.Add(this.BackgroundBrightnessUD);
            this.Controls.Add(this.lblAmplitude);
            this.Controls.Add(this.AmplitudeUD);
            this.Controls.Add(this.KeyboardLayoutComboBox);
            this.Controls.Add(this.KeyboardModelComboBox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StopSpectrographButton);
            this.Controls.Add(this.StartSpectrographButton);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "RGB Keyboard Spectrograph";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmplitudeUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BackgroundBrightnessUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TesterUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogLevelUD)).EndInit();
            this.RightClickMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RefreshDelayUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GraphicsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffectWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EffectSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarBrightnessUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BarWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartSpectrographButton;
        private System.Windows.Forms.Button StopSpectrographButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.ComboBox KeyboardModelComboBox;
        private System.Windows.Forms.ComboBox KeyboardLayoutComboBox;
        private System.Windows.Forms.NumericUpDown AmplitudeUD;
        private System.Windows.Forms.Label lblAmplitude;
        private System.Windows.Forms.Label lblRainbowBrightness;
        private System.Windows.Forms.NumericUpDown BackgroundBrightnessUD;
        private System.Windows.Forms.Button TestModeButton;
        private System.Windows.Forms.NumericUpDown TesterUD;
        private System.Windows.Forms.RichTextBox StatusLog;
        private System.Windows.Forms.NumericUpDown LogLevelUD;
        private System.Windows.Forms.Label LogLevelLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.CheckBox MinimizeToTrayCheck;
        private System.Windows.Forms.ToolStripStatusLabel StatusLight;
        private System.Windows.Forms.Timer StatusTimer;
        private System.Windows.Forms.Label RefreshDelayLabel;
        private System.Windows.Forms.NumericUpDown RefreshDelayUD;
        private System.Windows.Forms.ContextMenuStrip RightClickMenu;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmStart;
        private System.Windows.Forms.ToolStripMenuItem tsmStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsmQuit;
        private System.Windows.Forms.CheckBox LaunchCueCheck;
        private System.Windows.Forms.Button colorBars;
        private System.Windows.Forms.ComboBox BackgroundEffectComboBox;
        private System.Windows.Forms.Button colorBackground;
        private System.Windows.Forms.PictureBox GraphicsPictureBox;
        private System.Windows.Forms.CheckBox USB3ModeCheck;
        private System.Windows.Forms.CheckBox ShowGraphicsCheck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown EffectWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown EffectSpeed;
        private System.Windows.Forms.Button ShowSettings;
        private System.Windows.Forms.Button ShowDebug;
        private System.Windows.Forms.CheckBox StartMinimizedCheck;
        private System.Windows.Forms.CheckBox EffectsOnStartCheck;
        private System.Windows.Forms.ComboBox comboWasapiDevices;
        private System.Windows.Forms.RadioButton radioButtonWasapiLoopback;
        private System.Windows.Forms.RadioButton radioButtonWasapi;
        private System.Windows.Forms.ComboBox BarEffectComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown BarBrightnessUD;
        private System.Windows.Forms.NumericUpDown BarSpeed;
        private System.Windows.Forms.NumericUpDown BarWidth;
        private System.Windows.Forms.Button GetUpdateButton;

    }
}

