namespace ReadQRcode
{
    partial class Main_System
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
            this.VideoViewer = new AForge.Controls.VideoSourcePlayer();
            this.CameraComboBox = new System.Windows.Forms.ComboBox();
            this.TimerThread = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.帳號管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Cam_Page = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.Scan_result_richTextBox = new System.Windows.Forms.RichTextBox();
            this.管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帳號管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.Cam_Page.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // VideoViewer
            // 
            this.VideoViewer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.VideoViewer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.VideoViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.VideoViewer.Location = new System.Drawing.Point(3, 35);
            this.VideoViewer.Name = "VideoViewer";
            this.VideoViewer.Size = new System.Drawing.Size(554, 457);
            this.VideoViewer.TabIndex = 10;
            this.VideoViewer.Text = "VideoViewer";
            this.VideoViewer.VideoSource = null;
            // 
            // CameraComboBox
            // 
            this.CameraComboBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CameraComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.CameraComboBox.FormattingEnabled = true;
            this.CameraComboBox.Location = new System.Drawing.Point(3, 3);
            this.CameraComboBox.Name = "CameraComboBox";
            this.CameraComboBox.Size = new System.Drawing.Size(554, 26);
            this.CameraComboBox.TabIndex = 6;
            // 
            // TimerThread
            // 
            this.TimerThread.Enabled = true;
            this.TimerThread.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.管理ToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(568, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 管理ToolStripMenuItem1
            // 
            this.管理ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帳號管理ToolStripMenuItem1});
            this.管理ToolStripMenuItem1.Name = "管理ToolStripMenuItem1";
            this.管理ToolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.管理ToolStripMenuItem1.Text = "管理";
            // 
            // 帳號管理ToolStripMenuItem1
            // 
            this.帳號管理ToolStripMenuItem1.Name = "帳號管理ToolStripMenuItem1";
            this.帳號管理ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.帳號管理ToolStripMenuItem1.Text = "帳號管理";
            this.帳號管理ToolStripMenuItem1.Click += new System.EventHandler(this.帳號管理ToolStripMenuItem1_Click);
            // 
            // Cam_Page
            // 
            this.Cam_Page.Controls.Add(this.tabPage1);
            this.Cam_Page.Controls.Add(this.tabPage2);
            this.Cam_Page.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Cam_Page.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Cam_Page.Location = new System.Drawing.Point(0, 24);
            this.Cam_Page.Name = "Cam_Page";
            this.Cam_Page.SelectedIndex = 0;
            this.Cam_Page.Size = new System.Drawing.Size(568, 524);
            this.Cam_Page.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.CameraComboBox);
            this.tabPage1.Controls.Add(this.VideoViewer);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 495);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "QR Code 掃描";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Scan_result_richTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 495);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "動作紀錄(Log)";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // Scan_result_richTextBox
            // 
            this.Scan_result_richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Scan_result_richTextBox.Location = new System.Drawing.Point(3, 3);
            this.Scan_result_richTextBox.Name = "Scan_result_richTextBox";
            this.Scan_result_richTextBox.ReadOnly = true;
            this.Scan_result_richTextBox.Size = new System.Drawing.Size(554, 489);
            this.Scan_result_richTextBox.TabIndex = 15;
            this.Scan_result_richTextBox.Text = "";
            // 
            // 管理ToolStripMenuItem
            // 
            this.管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帳號管理ToolStripMenuItem});
            this.管理ToolStripMenuItem.Name = "管理ToolStripMenuItem";
            this.管理ToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            this.管理ToolStripMenuItem.Text = "管理";
            // 
            // 帳號管理ToolStripMenuItem
            // 
            this.帳號管理ToolStripMenuItem.Name = "帳號管理ToolStripMenuItem";
            this.帳號管理ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.帳號管理ToolStripMenuItem.Text = "帳號管理";
            // 
            // Main_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 548);
            this.Controls.Add(this.Cam_Page);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main_System";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "岡山榮民之家-警衛室出入條碼掃描系統";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_System_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.Cam_Page.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AForge.Controls.VideoSourcePlayer VideoViewer;
        private System.Windows.Forms.ComboBox CameraComboBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.Timer TimerThread;
        private System.Windows.Forms.TabControl Cam_Page;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem 管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 帳號管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帳號管理ToolStripMenuItem;
        public System.Windows.Forms.RichTextBox Scan_result_richTextBox;
    }
}

