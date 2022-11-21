namespace SkyHat
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nameRight = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nameLeft = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Save = new System.Windows.Forms.Button();
            this.Close = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.telegramHash = new System.Windows.Forms.TextBox();
            this.telegramUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.telegramEnabled = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.telegramPool = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telegramPool)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "SkyHat program configuration";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nameRight);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.nameLeft);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 82);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Names";
            // 
            // nameRight
            // 
            this.nameRight.Location = new System.Drawing.Point(122, 51);
            this.nameRight.Name = "nameRight";
            this.nameRight.Size = new System.Drawing.Size(213, 22);
            this.nameRight.TabIndex = 3;
            this.nameRight.TextChanged += new System.EventHandler(this.fields_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Right Hat name:";
            // 
            // nameLeft
            // 
            this.nameLeft.Location = new System.Drawing.Point(122, 19);
            this.nameLeft.Name = "nameLeft";
            this.nameLeft.Size = new System.Drawing.Size(213, 22);
            this.nameLeft.TabIndex = 1;
            this.nameLeft.TextChanged += new System.EventHandler(this.fields_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Left Hat name:";
            // 
            // Save
            // 
            this.Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Save.Enabled = false;
            this.Save.Location = new System.Drawing.Point(12, 311);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 28);
            this.Save.TabIndex = 2;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Location = new System.Drawing.Point(274, 311);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 28);
            this.Close.TabIndex = 3;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            this.Close.Click += new System.EventHandler(this.Close_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.telegramPool);
            this.groupBox2.Controls.Add(this.telegramEnabled);
            this.groupBox2.Controls.Add(this.telegramHash);
            this.groupBox2.Controls.Add(this.telegramUrl);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 124);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(341, 162);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Telegram";
            // 
            // telegramHash
            // 
            this.telegramHash.Enabled = false;
            this.telegramHash.Location = new System.Drawing.Point(122, 87);
            this.telegramHash.Name = "telegramHash";
            this.telegramHash.Size = new System.Drawing.Size(213, 22);
            this.telegramHash.TabIndex = 1;
            this.telegramHash.Click += new System.EventHandler(this.hash_Click);
            this.telegramHash.TextChanged += new System.EventHandler(this.fields_TextChanged);
            // 
            // telegramUrl
            // 
            this.telegramUrl.Enabled = false;
            this.telegramUrl.Location = new System.Drawing.Point(122, 53);
            this.telegramUrl.Name = "telegramUrl";
            this.telegramUrl.Size = new System.Drawing.Size(213, 22);
            this.telegramUrl.TabIndex = 1;
            this.telegramUrl.TextChanged += new System.EventHandler(this.fields_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 17);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hash:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "URL Endpoint:";
            // 
            // telegramEnabled
            // 
            this.telegramEnabled.AutoSize = true;
            this.telegramEnabled.Location = new System.Drawing.Point(122, 21);
            this.telegramEnabled.Name = "telegramEnabled";
            this.telegramEnabled.Size = new System.Drawing.Size(81, 21);
            this.telegramEnabled.TabIndex = 2;
            this.telegramEnabled.Text = "enabled";
            this.telegramEnabled.UseVisualStyleBackColor = true;
            this.telegramEnabled.CheckedChanged += new System.EventHandler(this.telegramEnabled_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "Pool time:";
            // 
            // telegramPool
            // 
            this.telegramPool.Location = new System.Drawing.Point(122, 122);
            this.telegramPool.Name = "telegramPool";
            this.telegramPool.Size = new System.Drawing.Size(120, 22);
            this.telegramPool.TabIndex = 3;
            this.telegramPool.ValueChanged += new System.EventHandler(this.fields_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(265, 124);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "seconds";
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 346);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Config";
            this.Load += new System.EventHandler(this.Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.telegramPool)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox nameLeft;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameRight;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox telegramHash;
        private System.Windows.Forms.TextBox telegramUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox telegramEnabled;
        private System.Windows.Forms.NumericUpDown telegramPool;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}