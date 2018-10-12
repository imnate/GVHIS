namespace ReadQRcode
{
    partial class Login_Form
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
            this.textBox_psw = new System.Windows.Forms.TextBox();
            this.PSW_Label = new System.Windows.Forms.Label();
            this.button_correct = new System.Windows.Forms.Button();
            this.label_error = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_psw
            // 
            this.textBox_psw.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_psw.Location = new System.Drawing.Point(122, 66);
            this.textBox_psw.Name = "textBox_psw";
            this.textBox_psw.PasswordChar = '*';
            this.textBox_psw.Size = new System.Drawing.Size(119, 23);
            this.textBox_psw.TabIndex = 0;
            this.textBox_psw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_psw_KeyDown);
            // 
            // PSW_Label
            // 
            this.PSW_Label.AutoSize = true;
            this.PSW_Label.Font = new System.Drawing.Font("新細明體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PSW_Label.Location = new System.Drawing.Point(64, 66);
            this.PSW_Label.Name = "PSW_Label";
            this.PSW_Label.Size = new System.Drawing.Size(52, 19);
            this.PSW_Label.TabIndex = 1;
            this.PSW_Label.Text = "密碼:";
            // 
            // button_correct
            // 
            this.button_correct.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button_correct.Location = new System.Drawing.Point(132, 117);
            this.button_correct.Name = "button_correct";
            this.button_correct.Size = new System.Drawing.Size(75, 31);
            this.button_correct.TabIndex = 2;
            this.button_correct.Text = "確定";
            this.button_correct.UseVisualStyleBackColor = true;
            this.button_correct.Click += new System.EventHandler(this.button_correct_Click);
            // 
            // label_error
            // 
            this.label_error.AutoSize = true;
            this.label_error.ForeColor = System.Drawing.Color.Red;
            this.label_error.Location = new System.Drawing.Point(120, 92);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(33, 12);
            this.label_error.TabIndex = 3;
            this.label_error.Text = "label1";
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 206);
            this.Controls.Add(this.label_error);
            this.Controls.Add(this.button_correct);
            this.Controls.Add(this.PSW_Label);
            this.Controls.Add(this.textBox_psw);
            this.Name = "Login_Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系統管理者登入";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_psw;
        private System.Windows.Forms.Label PSW_Label;
        private System.Windows.Forms.Button button_correct;
        private System.Windows.Forms.Label label_error;
    }
}