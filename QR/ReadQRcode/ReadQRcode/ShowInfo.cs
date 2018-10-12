using System;
using System.Reflection;
using System.IO;
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
    public partial class ShowInfo : Form
    {

        Main_System Main_Form_Get;
        Picture_Process Pic_pro;
        String TableName_Get;
        string connectionString;
        DateTime System_Time;
        public ShowInfo(List<Table_Row> table_row, Main_System Main_Form, String TableName, String Path)
        {
            Pic_pro = new Picture_Process();
            InitializeComponent();
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Path + ";";
            ID_text.Text = table_row[0].Id;
            Name_text.Text = table_row[0].Name;
            Sex_text.Text = table_row[0].Sex;
            CarNum_text.Text = table_row[0].CarNumP;
            Job_text.Text = table_row[0].Job;
            Main_Form_Get = Main_Form;
            TableName_Get = TableName;
            
            using (MemoryStream memStream = new MemoryStream(table_row[0].Photo))
            {
                Photo.Image = Image.FromStream(memStream);
            }
            
            //檢查進出狀況
            Check_In_Off();

        }
        public Image LoadPhoto(byte[] ToImage)
        {
            MemoryStream MS = new MemoryStream(ToImage);
            Bitmap bt = new Bitmap(Image.FromStream(MS));
            return bt;
        }
        private void Check_In_Off()
        {
            //找當月是不是有餘數(MOD 2...0)
            Main_Form_Get.TimerThread.Stop();
            int enter;
            int leave;
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    OleDbDataReader dr;
                    Get_TimeAndStatus GTS_enter = new Get_TimeAndStatus();
                    List<Get_TimeAndStatus> GTS_List = new List<Get_TimeAndStatus>();
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT Time,Status FROM " + TableName_Get + " WHERE ID='" + ID_text.Text + "' AND Status = '進入榮家'";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        GTS_enter.Time = dr[0].ToString();
                        GTS_enter.Status = dr[1].ToString();
                    }
                    GTS_List.Add(GTS_enter);//進入榮家
                    dr.Close();
                    cmd.CommandText = "SELECT COUNT(*) FROM " + TableName_Get + " WHERE ID='" + ID_text.Text + "' AND Status = '進入榮家'";
                    enter = (int)cmd.ExecuteScalar();

                    Get_TimeAndStatus GTS_leave = new Get_TimeAndStatus();
                    cmd.CommandText = "SELECT Time,Status FROM " + TableName_Get + " WHERE ID='" + ID_text.Text + "' AND Status = '離開榮家'";
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        GTS_leave.Time = dr[0].ToString();
                        GTS_leave.Status = dr[1].ToString();
                    }
                    GTS_List.Add(GTS_leave);//離開榮家
                    dr.Close();
                    cmd.CommandText = "SELECT COUNT(*) FROM " + TableName_Get + " WHERE ID='" + ID_text.Text + "' AND Status = '離開榮家'";
                    leave = (int)cmd.ExecuteScalar();

                    if (enter > leave)//進入大於出去
                    {
                        Enter_button.Enabled = false;
                        if (!Minimun_ThreeMins_Check(GTS_List, "Leave"))
                        {
                            this.Show();
                        }
                    }
                    else if (enter == leave)
                    {
                        Leave_button.Enabled = false;
                        if (!Minimun_ThreeMins_Check(GTS_List, "Enter"))
                        {
                            this.Show();
                        }
                    }

                }
            }
        }
        public bool Minimun_ThreeMins_Check(List<Get_TimeAndStatus> Input_Time, string Status)
        {
            //判斷 3分鐘
            System_Time = DateTime.Now;
            DateTime DB_Time;

            switch (Status)
            {
                case "Leave":
                    DateTime.TryParse(Input_Time[0].Time, out DB_Time);
                    if ((int)(System_Time - DB_Time).TotalMinutes < 3)
                    {
                        Main_Form_Get.TimerThread.Stop();
                        Leave_button.Enabled = false;
                        string message = "刷條碼間隔時間小於3分鐘，請等待 " + (3 - (int)(System_Time - DB_Time).TotalMinutes) + " 分鐘";
                        string caption = "進場時間過少";
                        Main_Form_Get.Scan_result_richTextBox.SelectionColor = Color.Red;
                        Main_Form_Get.Scan_result_richTextBox.AppendText("[" + System_Time + "] " + "Scan Event :進場時間過少" + Environment.NewLine);
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, caption, buttons);
                        //MessageBox.Show(message, caption, buttons); 
                        if (result == DialogResult.OK)
                        {
                            Main_Form_Get.TimerThread.Start();
                        }
                        return true;
                    }
                    break;
                case "Enter":
                    DateTime.TryParse(Input_Time[1].Time, out DB_Time);
                    if ((int)(System_Time - DB_Time).TotalMinutes < 3)
                    {
                        Main_Form_Get.TimerThread.Stop();
                        Enter_button.Enabled = false;
                        string message = "刷條碼間隔時間小於3分鐘，請等待 " + (3 - (int)(System_Time - DB_Time).TotalMinutes) + " 分鐘";
                        string caption = "離場時間過少";
                        Main_Form_Get.Scan_result_richTextBox.SelectionColor = Color.Red;
                        Main_Form_Get.Scan_result_richTextBox.AppendText("[" + System_Time + "] " + "Scan Event :離場時間過少" + Environment.NewLine);
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        DialogResult result = MessageBox.Show(message, caption, buttons);
                        //MessageBox.Show(message, caption, buttons);
                        if (result == DialogResult.OK)
                        {
                            Main_Form_Get.TimerThread.Start();
                        }
                        return true;
                    }
                    break;
            }
            return false;
        }
        public class Get_TimeAndStatus
        {
            public String Time { get; set; }
            public String Status { get; set; }
        }
        private void Enter_button_Click(object sender, EventArgs e)//進入榮家按鈕
        {
            Insert("進入榮家", TableName_Get);
            Main_Form_Get.TimerThread.Start();
            this.Close();
        }

        private void Leave_button_Click(object sender, EventArgs e)//離開榮家按鈕
        {
            Insert("離開榮家", TableName_Get);
            Main_Form_Get.TimerThread.Start();
            this.Close();
        }
        private void Insert(string Status, string TableName_Get)
        {

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {

                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO " + TableName_Get + " VALUES('"
                                                     + ID_text.Text + "','"
                                                     + Name_text.Text + "','"
                                                     + Status + "','"
                                                     + System_Time
                                                     + "')";
                    cmd.ExecuteNonQuery();
                    Main_Form_Get.Scan_result_richTextBox.SelectionColor = Color.Green;
                    Main_Form_Get.Scan_result_richTextBox.AppendText("[" + DateTime.Now + "] " + "Scan Event :" + ID_text.Text + Status + Environment.NewLine); 
                }
            }
        }

        private void ShowInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Main_Form_Get.TimerThread.Start();
        }
    }
}
