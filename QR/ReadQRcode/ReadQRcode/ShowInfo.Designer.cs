namespace ReadQRcode
{
    partial class ShowInfo
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
            this.ID_text = new System.Windows.Forms.TextBox();
            this.Name_text = new System.Windows.Forms.TextBox();
            this.Sex_text = new System.Windows.Forms.TextBox();
            this.CarNum_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Enter_button = new System.Windows.Forms.Button();
            this.Leave_button = new System.Windows.Forms.Button();
            this.Photo = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Job_text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_text
            // 
            this.ID_text.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ID_text.Location = new System.Drawing.Point(106, 18);
            this.ID_text.Name = "ID_text";
            this.ID_text.ReadOnly = true;
            this.ID_text.Size = new System.Drawing.Size(216, 36);
            this.ID_text.TabIndex = 0;
            // 
            // Name_text
            // 
            this.Name_text.Enabled = false;
            this.Name_text.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name_text.Location = new System.Drawing.Point(106, 64);
            this.Name_text.Name = "Name_text";
            this.Name_text.Size = new System.Drawing.Size(142, 36);
            this.Name_text.TabIndex = 1;
            // 
            // Sex_text
            // 
            this.Sex_text.Enabled = false;
            this.Sex_text.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Sex_text.Location = new System.Drawing.Point(106, 113);
            this.Sex_text.Name = "Sex_text";
            this.Sex_text.Size = new System.Drawing.Size(142, 36);
            this.Sex_text.TabIndex = 2;
            // 
            // CarNum_text
            // 
            this.CarNum_text.Enabled = false;
            this.CarNum_text.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.CarNum_text.Location = new System.Drawing.Point(106, 213);
            this.CarNum_text.Name = "CarNum_text";
            this.CarNum_text.Size = new System.Drawing.Size(142, 36);
            this.CarNum_text.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(60, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(36, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "姓名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(36, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "車牌:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(36, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "性別:";
            // 
            // Enter_button
            // 
            this.Enter_button.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Enter_button.Location = new System.Drawing.Point(191, 269);
            this.Enter_button.Name = "Enter_button";
            this.Enter_button.Size = new System.Drawing.Size(97, 32);
            this.Enter_button.TabIndex = 8;
            this.Enter_button.Text = "進入榮家";
            this.Enter_button.UseVisualStyleBackColor = true;
            this.Enter_button.Click += new System.EventHandler(this.Enter_button_Click);
            // 
            // Leave_button
            // 
            this.Leave_button.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Leave_button.Location = new System.Drawing.Point(332, 269);
            this.Leave_button.Name = "Leave_button";
            this.Leave_button.Size = new System.Drawing.Size(97, 32);
            this.Leave_button.TabIndex = 9;
            this.Leave_button.Text = "離開榮家";
            this.Leave_button.UseVisualStyleBackColor = true;
            this.Leave_button.Click += new System.EventHandler(this.Leave_button_Click);
            // 
            // Photo
            // 
            this.Photo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Photo.Location = new System.Drawing.Point(366, 15);
            this.Photo.Name = "Photo";
            this.Photo.Size = new System.Drawing.Size(201, 239);
            this.Photo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Photo.TabIndex = 10;
            this.Photo.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(36, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 24);
            this.label5.TabIndex = 12;
            this.label5.Text = "職稱:";
            // 
            // Job_text
            // 
            this.Job_text.Enabled = false;
            this.Job_text.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Job_text.Location = new System.Drawing.Point(106, 164);
            this.Job_text.Name = "Job_text";
            this.Job_text.Size = new System.Drawing.Size(142, 36);
            this.Job_text.TabIndex = 11;
            // 
            // ShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 313);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Job_text);
            this.Controls.Add(this.Photo);
            this.Controls.Add(this.Leave_button);
            this.Controls.Add(this.Enter_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CarNum_text);
            this.Controls.Add(this.Sex_text);
            this.Controls.Add(this.Name_text);
            this.Controls.Add(this.ID_text);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ShowInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "員工資料";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowInfo_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.Photo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID_text;
        private System.Windows.Forms.TextBox Name_text;
        private System.Windows.Forms.TextBox Sex_text;
        private System.Windows.Forms.TextBox CarNum_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Enter_button;
        private System.Windows.Forms.Button Leave_button;
        private System.Windows.Forms.PictureBox Photo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Job_text;
    }
}