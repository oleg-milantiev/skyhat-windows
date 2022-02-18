namespace SkyHat
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label12 = new System.Windows.Forms.Label();
            this.velocity = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.maxSpeed = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.threshold = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.timeout = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.firstRight = new System.Windows.Forms.RadioButton();
            this.firstLeft = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.moveBoth = new System.Windows.Forms.RadioButton();
            this.moveLeft = new System.Windows.Forms.RadioButton();
            this.moveRight = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.brightness = new System.Windows.Forms.TrackBar();
            this.label14 = new System.Windows.Forms.Label();
            this.settingsSave = new System.Windows.Forms.Button();
            this.comPort = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lightOff = new System.Windows.Forms.Button();
            this.lightOn = new System.Windows.Forms.Button();
            this.light = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.moveAbort = new System.Windows.Forms.Button();
            this.moveClose = new System.Windows.Forms.Button();
            this.moveOpen = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLight = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusHatLeft = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusHatRight = new System.Windows.Forms.ToolStripStatusLabel();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.velocity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(238, 138);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 23;
            this.label12.Text = "0..254 PWM";
            // 
            // velocity
            // 
            this.velocity.Enabled = false;
            this.velocity.Location = new System.Drawing.Point(140, 136);
            this.velocity.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.velocity.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.velocity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.velocity.Name = "velocity";
            this.velocity.Size = new System.Drawing.Size(91, 20);
            this.velocity.TabIndex = 22;
            this.velocity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.velocity.ValueChanged += new System.EventHandler(this.velocity_ValueChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(5, 138);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 21;
            this.label13.Text = "Motor velocity";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(238, 115);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "0..254 PWM";
            // 
            // maxSpeed
            // 
            this.maxSpeed.Enabled = false;
            this.maxSpeed.Location = new System.Drawing.Point(140, 114);
            this.maxSpeed.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.maxSpeed.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.maxSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxSpeed.Name = "maxSpeed";
            this.maxSpeed.Size = new System.Drawing.Size(91, 20);
            this.maxSpeed.TabIndex = 19;
            this.maxSpeed.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.maxSpeed.ValueChanged += new System.EventHandler(this.maxSpeed_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(112, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Motor maximum speed";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(238, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(30, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "ADU";
            // 
            // threshold
            // 
            this.threshold.Enabled = false;
            this.threshold.Location = new System.Drawing.Point(140, 91);
            this.threshold.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.threshold.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.threshold.Name = "threshold";
            this.threshold.Size = new System.Drawing.Size(91, 20);
            this.threshold.TabIndex = 16;
            this.threshold.ValueChanged += new System.EventHandler(this.threshold_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 93);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Current sensor threshold";
            // 
            // timeout
            // 
            this.timeout.Enabled = false;
            this.timeout.Location = new System.Drawing.Point(140, 68);
            this.timeout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.timeout.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
            this.timeout.Name = "timeout";
            this.timeout.Size = new System.Drawing.Size(91, 20);
            this.timeout.TabIndex = 13;
            this.timeout.ValueChanged += new System.EventHandler(this.timeout_ValueChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(197, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "v.1.8.1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(238, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "seconds";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Move timeout:";
            // 
            // firstRight
            // 
            this.firstRight.AutoSize = true;
            this.firstRight.Enabled = false;
            this.firstRight.Location = new System.Drawing.Point(70, 4);
            this.firstRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.firstRight.Name = "firstRight";
            this.firstRight.Size = new System.Drawing.Size(50, 17);
            this.firstRight.TabIndex = 8;
            this.firstRight.TabStop = true;
            this.firstRight.Text = "Right";
            this.firstRight.UseVisualStyleBackColor = true;
            this.firstRight.CheckedChanged += new System.EventHandler(this.firstRight_CheckedChanged);
            // 
            // firstLeft
            // 
            this.firstLeft.AutoSize = true;
            this.firstLeft.Enabled = false;
            this.firstLeft.Location = new System.Drawing.Point(2, 4);
            this.firstLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.firstLeft.Name = "firstLeft";
            this.firstLeft.Size = new System.Drawing.Size(43, 17);
            this.firstLeft.TabIndex = 7;
            this.firstLeft.TabStop = true;
            this.firstLeft.Text = "Left";
            this.firstLeft.UseVisualStyleBackColor = true;
            this.firstLeft.CheckedChanged += new System.EventHandler(this.firstLeft_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(98, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Comm Port";
            // 
            // logo
            // 
            this.logo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.logo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logo.ErrorImage = global::SkyHat.Properties.Resources.logo;
            this.logo.Image = global::SkyHat.Properties.Resources.logo;
            this.logo.Location = new System.Drawing.Point(193, 26);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(158, 68);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.logo.TabIndex = 12;
            this.logo.TabStop = false;
            this.logo.DoubleClick += new System.EventHandler(this.logo_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "First Hat part move:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.brightness);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.velocity);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.maxSpeed);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.settingsSave);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.threshold);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.timeout);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(8, 190);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(343, 223);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.moveBoth);
            this.panel2.Controls.Add(this.moveLeft);
            this.panel2.Controls.Add(this.moveRight);
            this.panel2.Location = new System.Drawing.Point(140, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(198, 25);
            this.panel2.TabIndex = 27;
            // 
            // moveBoth
            // 
            this.moveBoth.AutoSize = true;
            this.moveBoth.Enabled = false;
            this.moveBoth.Location = new System.Drawing.Point(147, 4);
            this.moveBoth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveBoth.Name = "moveBoth";
            this.moveBoth.Size = new System.Drawing.Size(47, 17);
            this.moveBoth.TabIndex = 9;
            this.moveBoth.TabStop = true;
            this.moveBoth.Text = "Both";
            this.moveBoth.UseVisualStyleBackColor = true;
            this.moveBoth.CheckedChanged += new System.EventHandler(this.moveBoth_CheckedChanged);
            // 
            // moveLeft
            // 
            this.moveLeft.AutoSize = true;
            this.moveLeft.Enabled = false;
            this.moveLeft.Location = new System.Drawing.Point(2, 4);
            this.moveLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveLeft.Name = "moveLeft";
            this.moveLeft.Size = new System.Drawing.Size(43, 17);
            this.moveLeft.TabIndex = 7;
            this.moveLeft.TabStop = true;
            this.moveLeft.Text = "Left";
            this.moveLeft.UseVisualStyleBackColor = true;
            this.moveLeft.CheckedChanged += new System.EventHandler(this.moveLeft_CheckedChanged);
            // 
            // moveRight
            // 
            this.moveRight.AutoSize = true;
            this.moveRight.Enabled = false;
            this.moveRight.Location = new System.Drawing.Point(70, 4);
            this.moveRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveRight.Name = "moveRight";
            this.moveRight.Size = new System.Drawing.Size(50, 17);
            this.moveRight.TabIndex = 8;
            this.moveRight.TabStop = true;
            this.moveRight.Text = "Right";
            this.moveRight.UseVisualStyleBackColor = true;
            this.moveRight.CheckedChanged += new System.EventHandler(this.moveRight_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Move part";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.firstLeft);
            this.panel1.Controls.Add(this.firstRight);
            this.panel1.Location = new System.Drawing.Point(140, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(198, 25);
            this.panel1.TabIndex = 26;
            // 
            // brightness
            // 
            this.brightness.Location = new System.Drawing.Point(134, 159);
            this.brightness.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.brightness.Maximum = 255;
            this.brightness.Name = "brightness";
            this.brightness.Size = new System.Drawing.Size(204, 42);
            this.brightness.TabIndex = 25;
            this.brightness.Value = 128;
            this.brightness.Scroll += new System.EventHandler(this.brightness_Scroll);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 160);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 13);
            this.label14.TabIndex = 24;
            this.label14.Text = "EL Panel brightness";
            // 
            // settingsSave
            // 
            this.settingsSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.settingsSave.Enabled = false;
            this.settingsSave.Location = new System.Drawing.Point(8, 188);
            this.settingsSave.Name = "settingsSave";
            this.settingsSave.Size = new System.Drawing.Size(59, 24);
            this.settingsSave.TabIndex = 9;
            this.settingsSave.Text = "Save";
            this.settingsSave.UseVisualStyleBackColor = true;
            this.settingsSave.Click += new System.EventHandler(this.settingsSave_Click);
            // 
            // comPort
            // 
            this.comPort.FormattingEnabled = true;
            this.comPort.Location = new System.Drawing.Point(84, 61);
            this.comPort.Name = "comPort";
            this.comPort.Size = new System.Drawing.Size(87, 21);
            this.comPort.TabIndex = 15;
            this.comPort.SelectedIndexChanged += new System.EventHandler(this.comPort_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lightOff);
            this.groupBox2.Controls.Add(this.lightOn);
            this.groupBox2.Controls.Add(this.light);
            this.groupBox2.Location = new System.Drawing.Point(8, 101);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(175, 84);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Light";
            // 
            // lightOff
            // 
            this.lightOff.Enabled = false;
            this.lightOff.Location = new System.Drawing.Point(8, 49);
            this.lightOff.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lightOff.Name = "lightOff";
            this.lightOff.Size = new System.Drawing.Size(59, 27);
            this.lightOff.TabIndex = 14;
            this.lightOff.Text = "Off";
            this.lightOff.UseVisualStyleBackColor = true;
            this.lightOff.Click += new System.EventHandler(this.lightOff_Click);
            // 
            // lightOn
            // 
            this.lightOn.Enabled = false;
            this.lightOn.Location = new System.Drawing.Point(8, 18);
            this.lightOn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lightOn.Name = "lightOn";
            this.lightOn.Size = new System.Drawing.Size(59, 27);
            this.lightOn.TabIndex = 13;
            this.lightOn.Text = "On";
            this.lightOn.UseVisualStyleBackColor = true;
            this.lightOn.Click += new System.EventHandler(this.lightOn_Click);
            // 
            // light
            // 
            this.light.Location = new System.Drawing.Point(73, 18);
            this.light.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.light.Name = "light";
            this.light.Size = new System.Drawing.Size(98, 58);
            this.light.TabIndex = 12;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.moveAbort);
            this.groupBox3.Controls.Add(this.moveClose);
            this.groupBox3.Controls.Add(this.moveOpen);
            this.groupBox3.Location = new System.Drawing.Point(193, 101);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(158, 84);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movement";
            // 
            // moveAbort
            // 
            this.moveAbort.Enabled = false;
            this.moveAbort.Location = new System.Drawing.Point(70, 17);
            this.moveAbort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveAbort.Name = "moveAbort";
            this.moveAbort.Size = new System.Drawing.Size(80, 58);
            this.moveAbort.TabIndex = 16;
            this.moveAbort.Text = "STOP!";
            this.moveAbort.UseVisualStyleBackColor = true;
            this.moveAbort.Click += new System.EventHandler(this.moveAbort_Click);
            // 
            // moveClose
            // 
            this.moveClose.Enabled = false;
            this.moveClose.Location = new System.Drawing.Point(7, 49);
            this.moveClose.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveClose.Name = "moveClose";
            this.moveClose.Size = new System.Drawing.Size(59, 27);
            this.moveClose.TabIndex = 15;
            this.moveClose.Text = "Close";
            this.moveClose.UseVisualStyleBackColor = true;
            this.moveClose.Click += new System.EventHandler(this.moveClose_Click);
            // 
            // moveOpen
            // 
            this.moveOpen.Enabled = false;
            this.moveOpen.Location = new System.Drawing.Point(7, 17);
            this.moveOpen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.moveOpen.Name = "moveOpen";
            this.moveOpen.Size = new System.Drawing.Size(59, 27);
            this.moveOpen.TabIndex = 14;
            this.moveOpen.Text = "Open";
            this.moveOpen.UseVisualStyleBackColor = true;
            this.moveOpen.Click += new System.EventHandler(this.moveOpen_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.statusLight,
            this.toolStripStatusLabel2,
            this.statusHatLeft,
            this.statusHatRight,
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 410);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip.Size = new System.Drawing.Size(353, 29);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 19;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 24);
            this.toolStripStatusLabel1.Text = "Light: ";
            // 
            // statusLight
            // 
            this.statusLight.AutoSize = false;
            this.statusLight.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusLight.Name = "statusLight";
            this.statusLight.Size = new System.Drawing.Size(74, 24);
            this.statusLight.Text = "Unknown";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(40, 24);
            this.toolStripStatusLabel2.Text = "Hat: ";
            // 
            // statusHatLeft
            // 
            this.statusHatLeft.AutoSize = false;
            this.statusHatLeft.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.statusHatLeft.Name = "statusHatLeft";
            this.statusHatLeft.Size = new System.Drawing.Size(74, 24);
            this.statusHatLeft.Text = "Unknown";
            // 
            // statusHatRight
            // 
            this.statusHatRight.Name = "statusHatRight";
            this.statusHatRight.Size = new System.Drawing.Size(51, 24);
            this.statusHatRight.Text = "Unknown";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 24);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 32);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 65);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(353, 24);
            this.menuStrip1.TabIndex = 21;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // configToolStripMenuItem
            // 
            this.configToolStripMenuItem.Name = "configToolStripMenuItem";
            this.configToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.configToolStripMenuItem.Text = "&Config";
            this.configToolStripMenuItem.Click += new System.EventHandler(this.configToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 439);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.logo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comPort);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SkyHat";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.velocity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brightness)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown velocity;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown maxSpeed;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown threshold;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown timeout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton firstRight;
        private System.Windows.Forms.RadioButton firstLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox logo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comPort;
        private System.Windows.Forms.Button settingsSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button lightOff;
        private System.Windows.Forms.Button lightOn;
        private System.Windows.Forms.Panel light;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button moveAbort;
        private System.Windows.Forms.Button moveClose;
        private System.Windows.Forms.Button moveOpen;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel statusLight;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel statusHatLeft;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton moveBoth;
        private System.Windows.Forms.RadioButton moveLeft;
        private System.Windows.Forms.RadioButton moveRight;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar brightness;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripStatusLabel statusHatRight;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;

    }
}

