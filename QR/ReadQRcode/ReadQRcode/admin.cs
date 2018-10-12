using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace ReadQRcode
{
    public partial class Login_Form : Form
    {

        string connectionQRcode_DB;
        string connectionStaffDB;
        string delete_updateCmd;
        object btn_sender;

        DateTime System_Time = DateTime.Now;
        Main_System Main_Form;
        public Login_Form(Main_System MF, string QRcode_DB, string StaffDB, object sender, string cmd)
        {
            InitializeComponent();
            label_error.Text = "";
            Main_Form = MF;
            connectionQRcode_DB = QRcode_DB;
            connectionStaffDB = StaffDB;
            btn_sender = sender;
            delete_updateCmd = cmd;
        }
        private void textBox_psw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button_correct.Focus();
                button_correct_Click(sender, e);
                textBox_psw.Focus();

            }
        }
        private void button_correct_Click(object sender, EventArgs e)
        {
            Main_Form.Scan_result_richTextBox.AppendText("[" + System_Time + "] " + "按壓正確按鈕" + Environment.NewLine);
            Management_interface MI = new Management_interface(connectionQRcode_DB, connectionStaffDB, Main_Form);
            Access_DataBase Adb = new Access_DataBase();
            if (Adb.Check_Admin(textBox_psw.Text))
            {
                Main_Form.Scan_result_richTextBox.SelectionColor = Color.Green;
                Main_Form.Scan_result_richTextBox.AppendText("[" + System_Time + "] " + "管理者嘗試登入:成功" + Environment.NewLine);
                MI.ShowDialog(this);
                this.Dispose();
            }
            else
            {
                Main_Form.Scan_result_richTextBox.SelectionColor = Color.Red;
                Main_Form.Scan_result_richTextBox.AppendText("[" + System_Time + "] " + "管理者嘗試登入:失敗!" + Environment.NewLine);
                label_error.Text = "密碼錯誤";
            }

        }

    }
}
