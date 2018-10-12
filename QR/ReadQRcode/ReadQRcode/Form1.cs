using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Data.OleDb;
using System.IO;
using System.IO.Ports;
using ZXing;
using ZXing.QrCode;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;


namespace ReadQRcode
{
    public partial class Main_System : Form
    {
        FilterInfoCollection ball;
        VideoCaptureDevice fuenteVideo;
        DateTime DT_Now = DateTime.Now;
        string connectionString_QRcode_Scan;
        string connectionString_StaffDB;
        //string connectionString_Photo;
        string connectionSystemDB = "Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=admin;Data Source=C:\\Users\\info\\Desktop\\QR\\SystemDB.accdb;";


        public Main_System()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)//初始化 讀取攝影機 到comboBox1
        {
            if (Check_initial())//檢查資料庫 裡面的資料庫位子是否正確
            {
                ball = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                foreach (FilterInfo x in ball)
                {
                    CameraComboBox.Items.Add(x.Name);
                }
                CameraComboBox.SelectedIndex = 0;
                openCam();
                Scan_result_richTextBox.SelectionColor = Color.Green;
                Scan_result_richTextBox.AppendText("[" + DT_Now + "] " + "[相機][" + CameraComboBox.SelectedItem + "]開啟成功" + Environment.NewLine);
            }
            else
            {
                string message = "沒有初始化資料庫路徑，請聯絡相關業務負責人";
                string caption = "錯誤";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result = MessageBox.Show(message, caption, buttons);
            }
        }
        private bool Check_initial()
        {
            Dictionary<string, bool> Initial_status = new Dictionary<string, bool>();
            bool[] ToF = new bool[2];
            if (Check_path(connectionSystemDB, "QRcode_Scan"))
            {
                ToF[0] = true;
            }
            else
            {
                ToF[0] = false;
            }
            if (Check_path(connectionSystemDB, "StaffDB"))
            {
                ToF[1] = true;
            }
            else
            {
                ToF[1] = false;
            }
            //if (Check_path(connectionSystemDB, "Photo"))
            //{
            //    ToF[2] = true;
            //}
            //else
            //{
            //    ToF[2] = false;
            //}
            foreach (bool result in ToF)
            {
                if (!result)
                {
                    return false;
                }
            }
            return true;
        }
        private class AttributePath
        {
            string Attribute { get; set; }
            string Path { get; set; }
        }
        private bool Check_path(string db, string attribute)
        {
            using (OleDbCommand cmd = new OleDbCommand())
            {
                string path = "";
                OleDbDataReader dr;
                cmd.Connection = Access_DataBase.DB_Conn_Open(db);
                cmd.CommandText = "SELECT * FROM path WHERE DB_name = '" + attribute + "'";
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    path = dr[1].ToString();
                }
                if (path.Length != 0)//實體位子檢測
                {
                    if (!File.Exists(path))
                    {
                        Scan_result_richTextBox.SelectionColor = Color.Red;
                        Scan_result_richTextBox.AppendText("[" + DT_Now + "] [檔案不存在]" + attribute + " 實體路徑初始化載入失敗" + path + Environment.NewLine);
                        return false;
                    }
                    else
                    {
                        Scan_result_richTextBox.SelectionColor = Color.Green;
                        Scan_result_richTextBox.AppendText("[" + DT_Now + "] [資料庫]" + attribute + " 初始化路徑載入成功" + Environment.NewLine);
                        switch (attribute)
                        {
                            case "QRcode_Scan":
                                connectionString_QRcode_Scan = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
                                break;
                            case "StaffDB":
                                connectionString_StaffDB = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
                                break;
                                //case "Photo":
                                //    connectionString_Photo = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";";
                                //    break;
                        }
                        return true;
                    }
                }
                else
                {
                    Scan_result_richTextBox.SelectionColor = Color.Red;
                    Scan_result_richTextBox.AppendText("[" + DT_Now + "] " + attribute + " 初始化路徑載入失敗" + path + Environment.NewLine);
                    return false;
                }
            }

        }
        public void openCam()
        {
            TimerThread.Enabled = true;
            TimerThread.Start();
            fuenteVideo = new VideoCaptureDevice(ball[CameraComboBox.SelectedIndex].MonikerString);
            VideoViewer.VideoSource = fuenteVideo;
            VideoViewer.Start();

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (fuenteVideo.IsRunning)
            {
                fuenteVideo.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DT_Now = DateTime.Now;

            if (VideoViewer.GetCurrentVideoFrame() != null)
            {
                BarcodeReader Reader = new BarcodeReader();
                Bitmap img = new Bitmap(VideoViewer.GetCurrentVideoFrame());

                //----------------加入CV---------------------
                //Image<Gray, byte> I = new Image<Gray, byte>(img);
                //Image<Bgr, byte> DrawI = I.Convert<Bgr, byte>();
                //Image<Gray, byte> CannyImage = I.Clone(); //灰階處理
                //CvInvoke.GaussianBlur(I, CannyImage, new Size(5, 5), 0);
                //CvInvoke.Canny(I, CannyImage, 100, 200);
                //MyCV.BoundingBox(CannyImage, DrawI);
                //pictureBox1.Image = DrawI.Bitmap;
                //pictureBox2.Image = CannyImage.Bitmap;
                //Result result = Reader.Decode(DrawI.Bitmap);
                //----------------CV end----------------------
                Result result = Reader.Decode(img);//原本
                img.Dispose();//釋放資源


                if (result != null)
                {
                    Scan_result_richTextBox.SelectionColor = Color.Green;
                    Scan_result_richTextBox.AppendText("[" + DT_Now + "] 掃描條碼顯示: " + result + Environment.NewLine);

                    //Scan_result.Items.Add("DBconnection = " + connectionString);
                    //資料庫(自動Dispose寫法)
                    String check_psd = "SELECT * FROM staff_info WHERE Encode_ID = '" + result + "'";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        DataSet ds = new DataSet();
                        Table_Row TBR = new Table_Row();
                        List<Table_Row> table_row = new List<Table_Row>();

                        //OleDbDataReader dr;
                        cmd.Connection = Access_DataBase.DB_Conn_Open(connectionString_StaffDB);
                        cmd.CommandText = check_psd;
                        //dr = cmd.ExecuteReader();
                        OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                        
                        try
                        {
                            adapter.Fill(ds, "Encode_ID");
                            adapter.Fill(ds, "Name");
                            adapter.Fill(ds, "Sex");
                            adapter.Fill(ds, "Job");
                            adapter.Fill(ds, "Phone");
                            adapter.Fill(ds, "CarNumP");
                            adapter.Fill(ds, "Photo");

                            try
                            {
                                TBR.Id = ds.Tables["Encode_ID"].Rows[0]["Encode_ID"].ToString();
                                TBR.Name = ds.Tables["Name"].Rows[0]["Name"].ToString();
                                TBR.Sex = ds.Tables["Sex"].Rows[0]["Sex"].ToString();
                                TBR.Job = ds.Tables["Job"].Rows[0]["Job"].ToString();
                                TBR.CarNumP = ds.Tables["CarNumP"].Rows[0]["CarNumP"].ToString();
                                TBR.CarNumP = ds.Tables["Phone"].Rows[0]["Phone"].ToString();
                                TBR.Photo = (byte[])ds.Tables["Photo"].Rows[0]["Photo"];
                                table_row.Add(TBR);
                                ds.Tables.Clear();

                                string Table_name = DT_Now.ToString("yyyy_MM");
                                Check_Table_Exsits(Access_DataBase.DB_Conn_Open(connectionString_QRcode_Scan), cmd, Table_name);//檢查有無當月Table沒有建立
                                ShowInfo SI_form = new ShowInfo(table_row, this, Table_name, connectionString_QRcode_Scan);
                            }
                            catch
                            {
                                TimerThread.Stop();
                                string message = "此條碼可能被註銷，或者不是岡山榮家發行";
                                string caption = "查無此資料";
                                MessageBoxButtons buttons = MessageBoxButtons.OK;
                                DialogResult DiaResult = MessageBox.Show(message, caption, buttons);
                                //MessageBox.Show(message, caption, buttons); 
                                if (DiaResult == DialogResult.OK)
                                {
                                    TimerThread.Start();
                                }

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                        
                    }
                }
            }

        }
        private void Check_Table_Exsits(OleDbConnection conn, OleDbCommand cmd, String TableName)
        {
            try
            {
                Create_Table(conn, cmd, TableName);
                Scan_result_richTextBox.SelectionColor = Color.Green;
                Scan_result_richTextBox.AppendText("[" + DT_Now + "] " + "Create Success(Table): " + TableName + Environment.NewLine);
            }
            catch
            {
                Scan_result_richTextBox.SelectionColor = Color.Orange;
                Scan_result_richTextBox.AppendText("[" + DT_Now + "] Table Exist: " + TableName + Environment.NewLine);
            }
        }
        private void Create_Table(OleDbConnection conn, OleDbCommand cmd, String TableName)//新增meal table
        {
            cmd.Connection = conn;
            cmd.CommandText = "CREATE TABLE [" + TableName + "](" +
                              "[ID] VARCHAR(40) NULL," +
                              "[Name] VARCHAR(40) NULL," +
                              "[Status] VARCHAR(40) NULL," +
                              "[Time] VARCHAR(40) NULL)";
            cmd.ExecuteNonQuery();
        }
        public class MyCV
        {
            public static void BoundingBox(Image<Gray, byte> src, Image<Bgr, byte> draw)
            {
                using (VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint())
                {

                    CvInvoke.FindContours(src, contours, null, RetrType.Tree,
                                          ChainApproxMethod.ChainApproxSimple);

                    int count = contours.Size;
                    for (int i = 0; i < count; i++)
                    {
                        using (VectorOfPoint contour = contours[i])
                        {
                            Rectangle BoundingBox = CvInvoke.BoundingRectangle(contour);
                            CvInvoke.Rectangle(draw, BoundingBox, new MCvScalar(0, 255, 0), 3);
                        }
                    }
                }
            }
        }
        private void 帳號管理ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //需要設計一個table紀錄 資料庫 等路徑 還有LOG匯出的 路徑
            Scan_result_richTextBox.AppendText("[" + DT_Now + "] object sender" + sender.ToString()+ " EventArgs e"+e.ToString() + Environment.NewLine);
            Login_Form Admin = new Login_Form(this, connectionString_QRcode_Scan, connectionString_StaffDB, sender,null);
            Admin.Show();
        }

        private void Main_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            Access_DataBase.DB_Conn_Open(connectionString_QRcode_Scan).Close();
            Access_DataBase.DB_Conn_Open(connectionString_StaffDB).Close();
        }
    }
}
