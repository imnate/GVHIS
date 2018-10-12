namespace ReadQRcode
{
    partial class QR
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
            this.QR_CodePic = new System.Windows.Forms.PictureBox();
            this.Save_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.QR_CodePic)).BeginInit();
            this.SuspendLayout();
            // 
            // QR_CodePic
            // 
            this.QR_CodePic.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QR_CodePic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.QR_CodePic.Location = new System.Drawing.Point(0, 0);
            this.QR_CodePic.Name = "QR_CodePic";
            this.QR_CodePic.Size = new System.Drawing.Size(401, 380);
            this.QR_CodePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.QR_CodePic.TabIndex = 0;
            this.QR_CodePic.TabStop = false;
            // 
            // Save_btn
            // 
            this.Save_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Save_btn.Location = new System.Drawing.Point(0, 332);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(401, 48);
            this.Save_btn.TabIndex = 1;
            this.Save_btn.Text = "保存 QR Code";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // QR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 380);
            this.Controls.Add(this.Save_btn);
            this.Controls.Add(this.QR_CodePic);
            this.Name = "QR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QR";
            ((System.ComponentModel.ISupportInitialize)(this.QR_CodePic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox QR_CodePic;
        private System.Windows.Forms.Button Save_btn;
    }
}