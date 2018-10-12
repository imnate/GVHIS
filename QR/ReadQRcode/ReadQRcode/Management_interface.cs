using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using ZXing;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace ReadQRcode
{
    public partial class Management_interface : Form
    {
        string connectionQRcode_DB;
        string connectionStaffDB;
        Main_System MS_window;
        Picture_Process Pic_pro;
        Bitmap bm; //Picturebox的bitmap
        DataSet DsFromStaffAll;
        DataTable DateTable_Staff;
        DataSet DsScanRecord;
        byte[] Sent_QRcode;
        string Sent_staff_Name;
        string Sent_Encode_ID;
        public Management_interface(string QRcode_DB, string StaffDB, Main_System MS)
        {

            InitializeComponent();
            Update_btn.Enabled = false;
            Delete_btn.Enabled = false;
            DownloadQR_btn.Enabled = false;
            connectionQRcode_DB = QRcode_DB;
            connectionStaffDB = StaffDB;
            MS_window = MS;
            Refush_GirdView();
            Initial_TablelistBox();
        }


        private void photopath_textBox_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog photo_open = new OpenFileDialog();
            photo_open.Title = "選擇員工大頭照";
            photo_open.Filter = "所有支援圖片格式 (*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png";

            if (photo_open.ShowDialog() == DialogResult.OK)
            {
                if ((photo_open.FileName.Length * 10) >= 463)//設定textbox顯示路徑
                {
                    this.photopath_TextBox.Size = new System.Drawing.Size(463, 35);
                }
                else
                {
                    this.photopath_TextBox.Size = new System.Drawing.Size(photo_open.FileName.Length * 10, 35);
                }


                this.photopath_TextBox.Text = photo_open.FileName;
                bm = new Bitmap(photo_open.FileName);
                photo_pictureBox.Image = bm;
            }
        }
        private void Generate_QR_Click(object sender, EventArgs e)
        {
            string Message = Check_TextBox();

            if (Message.Length > 0)
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(Message, "請檢察欄位", buttons);
            }
            else
            {

                //確認資料庫是否重複姓名
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    Pic_pro = new Picture_Process();
                    OleDbDataReader dr;
                    cmd.Connection = Access_DataBase.DB_Conn_Open(connectionStaffDB);
                    cmd.CommandText = "SELECT * FROM staff_info WHERE Name = @name OR(ID = @id)";//" Name_Textbox.Text =Name " " + IDnumber_Textbox.Text + " = ID
                    cmd.Parameters.AddWithValue("@name", Name_Textbox.Text);
                    cmd.Parameters.AddWithValue("@id", IDnumber_Textbox.Text);
                    dr = cmd.ExecuteReader();
                    if (!dr.HasRows)
                    {
                        //Convert.ToBase64String(//AES加密後);
                        //Encoding.UTF8.GetString(//AES解密後)
                        string Encode_str = Encode(IDnumber_Textbox.Text);//加密
                        byte[] Zxing_QR = ZXing_QR(Encode_str);
                        Insert(Encode_str, IDnumber_Textbox.Text, SavePhoto(photopath_TextBox.Text), Zxing_QR);//存入D
                        QR QRForm = new QR(Zxing_QR, Name_Textbox.Text, Encode_str);
                        QRForm.ShowDialog(this);
                        Refush_GirdView();
                        Initial_New_StaffTB();
                    }
                    else//repeat
                    {
                        //TODO MessageBox Warning
                        MessageBoxButtons buttons = MessageBoxButtons.OK;
                        MessageBox.Show("員工重複申請", "重複", buttons);
                    }
                }
            }


            //先確認資料欄位有沒有資料

            //存檔資料庫 連同照片轉成binaray
        }
        private void Initial_TablelistBox()
        {
            using (OleDbConnection oleconn = new OleDbConnection(connectionQRcode_DB))
            {
                oleconn.Open();
                DataTable dt = null;
                dt = oleconn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables_Info, null);
                foreach (DataRow dtr in dt.Rows)
                {
                    if (dtr["TABLE_TYPE"].ToString() == "TABLE" && dtr["TABLE_NAME"].ToString().IndexOf("TMP") == -1)//&& dtr["TABLE_NAME"].ToString().IndexOf("TMP") == -1
                    {
                        TableSheet_comboBox.Items.Add(dtr["TABLE_NAME"].ToString());
                    }
                }

            }
        }
        private void Initial_New_StaffTB()
        {
            Name_Textbox.Text = "";
            Gender_combobox.Text = "";
            IDnumber_Textbox.Text = "";
            JobTitle_Textbox.Text = "";
            Phone_textBox.Text = "";
            CarNumber_Textbox.Text = "";
            photopath_TextBox.Text = "";
            photo_pictureBox.Image = null;

        }
        public byte[] SavePhoto(string pic_path)//存photo_pictureBox
        {
            FileStream fs = new FileStream(pic_path, FileMode.Open, FileAccess.Read);
            byte[] data = new byte[fs.Length];
            fs.Read(data, 0, data.Length);
            fs.Close();
            return data;
        }

        private byte[] ZXing_QR(string EncodeID)
        {
            BarcodeWriter bw = new BarcodeWriter();
            bw.Format = BarcodeFormat.QR_CODE;
            bw.Options.Width = 260;
            bw.Options.Height = 237;
            Bitmap bitmap = bw.Write(EncodeID);
            //這邊有問題 用picturebox 輸出檢查圖片
            //pictureBox1.Image = (Image)bitmap;

            MemoryStream ms = new MemoryStream();
            //pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] result = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(result, 0, result.Length);
            return result;
        }


        private void Insert(string Encode_ID, string ID, byte[] photo, byte[] QR)
        {
            DateTime System_Time = DateTime.Now;
            using (OleDbConnection oleconn = new OleDbConnection(connectionStaffDB))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.CommandText = "INSERT INTO staff_info VALUES (@Encode_id,@id,@Name,@Gender,@JobTitle,@Phone,@CarNum,@Photo,@QR,@CreateTime)";
                    cmd.Parameters.AddWithValue("@Encode_id", Encode_ID);
                    cmd.Parameters.AddWithValue("@id", ID);
                    cmd.Parameters.AddWithValue("@Name", Name_Textbox.Text);
                    cmd.Parameters.AddWithValue("@Gender", Gender_combobox.Text);
                    cmd.Parameters.AddWithValue("@JobTitle", JobTitle_Textbox.Text);
                    cmd.Parameters.AddWithValue("@Phone", Phone_textBox.Text);
                    cmd.Parameters.AddWithValue("@CarNum", CarNumber_Textbox.Text);
                    cmd.Parameters.AddWithValue("@Photo", photo);
                    cmd.Parameters.AddWithValue("@QR", ZXing_QR(Encode_ID));
                    cmd.Parameters.AddWithValue("@CreateTime", System_Time);
                    cmd.Connection = oleconn;
                    try
                    {
                        oleconn.Open();
                        cmd.ExecuteNonQuery();
                        MS_window.Scan_result_richTextBox.SelectionColor = Color.Green;
                        MS_window.Scan_result_richTextBox.AppendText("[" + DateTime.Now + "] " + Name_Textbox.Text + "新增成功" + Environment.NewLine);
                    }
                    catch (Exception ex)
                    {
                        MS_window.Scan_result_richTextBox.SelectionColor = Color.Green;
                        MS_window.Scan_result_richTextBox.AppendText("[" + DateTime.Now + "] " + Name_Textbox.Text + "新增失敗" + Environment.NewLine + ex);
                    }

                }
            }
        }
        private string Decode(string decode)//DES解密
        {
            string hexString = decode;
            string key = "abcdefgh";
            string iv = "12348765";

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = Encoding.ASCII.GetBytes(key);
            des.IV = Encoding.ASCII.GetBytes(iv);
            byte[] s = new byte[hexString.Length / 2];
            int j = 0;
            for (int i = 0; i < hexString.Length / 2; i++)
            {
                s[i] = Byte.Parse(hexString[j].ToString() + hexString[j + 1].ToString(), System.Globalization.NumberStyles.HexNumber);
                j += 2;
            }
            ICryptoTransform desencrypt = des.CreateDecryptor();
            return Encoding.ASCII.GetString(desencrypt.TransformFinalBlock(s, 0, s.Length));
        }
        private string Encode(string encode)//DES加密
        {
            string original = encode;
            string key = "abcdefgh";
            string iv = "12348765";

            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            des.Key = Encoding.ASCII.GetBytes(key);
            des.IV = Encoding.ASCII.GetBytes(iv);
            byte[] s = Encoding.ASCII.GetBytes(original);
            ICryptoTransform desencrypt = des.CreateEncryptor();
            return BitConverter.ToString(desencrypt.TransformFinalBlock(s, 0, s.Length)).Replace("-", string.Empty);

        }
        private byte[] AES_Encode(string EncodeStr)
        {
            //AES
            string strKey = "imnateimhandsome";
            byte[] _key1 = { 0x22, 0x35, 0x59, 0x78, 0x70, 0xAC, 0xC0, 0xFF, 0x22, 0x35, 0x59, 0x78, 0x70, 0xAB, 0xC0, 0xFF };
            SymmetricAlgorithm des = Rijndael.Create();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(EncodeStr);//得到需加密字串byte型態      

            des.Key = Encoding.UTF8.GetBytes(strKey);
            des.IV = _key1;
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            byte[] result = ms.ToArray();//加密完
            cs.Close();
            ms.Close();
            return result;
        }
        public static byte[] AESDecode(byte[] cipherText)
        {
            byte[] _key1 = { 0x22, 0x35, 0x59, 0x78, 0x70, 0xAC, 0xC0, 0xFF, 0x22, 0x35, 0x59, 0x78, 0x70, 0xAB, 0xC0, 0xFF };
            string strKey = "imnateimhandsome";
            SymmetricAlgorithm des = Rijndael.Create();
            des.Key = Encoding.UTF8.GetBytes(strKey);
            des.IV = _key1;
            byte[] result = new byte[cipherText.Length];
            MemoryStream ms = new MemoryStream(cipherText);
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Read);
            cs.Read(result, 0, result.Length);
            cs.Close();
            ms.Close();
            return result;
        }
        private string Check_TextBox()
        {
            string result = "";
            if (!Regex.IsMatch(Name_Textbox.Text, @"^[\u4e00-\u9fa5]{2,9}$"))
            {
                result += "姓名有誤\n";
            }
            if (Gender_combobox.Text == "")
            {
                result += "沒選擇性別\n";
            }
            if (!Regex.IsMatch(IDnumber_Textbox.Text, @"[a-zA-Z][0-9]{9}"))
            {
                result += "身分證有誤\n";
            }
            if (!Regex.IsMatch(JobTitle_Textbox.Text, @"^[\u4e00-\u9fa5]{2,9}$"))
            {
                result += "職稱有誤\n";
            }
            if (!Regex.IsMatch(CarNumber_Textbox.Text, @"^[A-Za-z0-9/-]+$"))
            {
                result += "車牌有誤\n";
            }
            if (photopath_TextBox.TextLength == 0)
            {
                result += "沒選擇照片\n";
            }
            return result;
        }
        private void Refush_GirdView()
        {
            using (OleDbConnection oleconn = new OleDbConnection(connectionStaffDB))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = oleconn;
                    string Sql_cmd = "Select * From staff_info";
                    DsFromStaffAll = new DataSet();
                    OleDbDataAdapter da = new OleDbDataAdapter(Sql_cmd, oleconn);
                    da.Fill(DsFromStaffAll, "staff_info");
                    AllStaff_gridview.DataSource = DsFromStaffAll.Tables["staff_info"];
                }
            }
            DateTable_Staff = DsFromStaffAll.Tables["staff_info"];
        }

        private void AllStaff_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // CarNum_txtbox.Text = AllStaff_gridview.CurrentRow.Index.ToString() + "," + AllStaff_gridview.CurrentCell.ColumnIndex;

            Update_btn.Enabled = true;
            Delete_btn.Enabled = true;
            DownloadQR_btn.Enabled = true;

          

            Sent_staff_Name = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Name"].ToString();
            Sent_Encode_ID = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Encode_ID"].ToString();
            StaffName_txtbox.Text = Sent_staff_Name;
            ID_txtbox.Text = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["ID"].ToString();
            Gender_txtbox.Text = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Sex"].ToString();
            JobTitle_txtbox.Text = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Job"].ToString();
            Phone_txtbox.Text = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Phone"].ToString();
            CarNum_txtbox.Text = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["CarNumP"].ToString();
            StaffData_GB.Text = DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Name"].ToString() + " [ " + Sent_Encode_ID + " ]";
            Sent_QRcode = (byte[])DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["QR_Code"];

            using (MemoryStream memStream = new MemoryStream((byte[])DateTable_Staff.Rows[AllStaff_gridview.CurrentRow.Index]["Photo"]))
            {
                Staff_pic.Image = Image.FromStream(memStream);
            }


        }
        private void button3_Click(object sender, EventArgs e)
        {
            QR QRcode = new QR(Sent_QRcode, Sent_staff_Name, Sent_Encode_ID);
            QRcode.ShowDialog(this);
        }

        private void Update_btn_Click(object sender, EventArgs e)
        {
            string message = "確定更新: " + StaffName_txtbox.Text + " 的資料?";
            string caption = "刪除更新";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                using (OleDbConnection oleconn = new OleDbConnection(connectionStaffDB))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        oleconn.Open();
                        cmd.Connection = oleconn;
                        cmd.CommandText = "Update staff_info SET Phone = '" + Phone_txtbox.Text + "',CarNumP = '" + CarNum_txtbox.Text + "' Where Name = '" + StaffName_txtbox.Text + "' And ID = '" + ID_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();

                    }
                }
                Initial_Action();
            }
        }

        private void Delete_btn_Click(object sender, EventArgs e)
        {
            string message = "確定刪除: " + StaffName_txtbox.Text + " 的資料?";
            string caption = "刪除確認";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, caption, buttons);
            if (result == DialogResult.Yes)
            {
                using (OleDbConnection oleconn = new OleDbConnection(connectionStaffDB))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        oleconn.Open();
                        cmd.Connection = oleconn;
                        cmd.CommandText = "Delete From staff_info Where Name = '" + StaffName_txtbox.Text + "' And ID = '" + ID_txtbox.Text + "'";
                        cmd.ExecuteNonQuery();

                    }
                }
                Initial_Action();
            }
        }
        public void Initial_Action()
        {
            Refush_GirdView();
            Update_btn.Enabled = false;
            Delete_btn.Enabled = false;
            DownloadQR_btn.Enabled = false;
            StaffName_txtbox.Text = "";
            ID_txtbox.Text = "";
            Gender_txtbox.Text = "";
            JobTitle_txtbox.Text = "";
            Phone_txtbox.Text = "";
            CarNum_txtbox.Text = "";
            Staff_pic.Image = null;
        }

        private void TableSheet_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OleDbConnection oleconn = new OleDbConnection(connectionQRcode_DB))
            {
                using (OleDbCommand cmd = new OleDbCommand())
                {
                    cmd.Connection = oleconn;
                    string Sql_cmd = "Select * From "+ TableSheet_comboBox.SelectedItem.ToString();
                    DsScanRecord = new DataSet();
                    OleDbDataAdapter da = new OleDbDataAdapter(Sql_cmd, oleconn);
                    da.Fill(DsScanRecord, "Scan_Record");
                    Record_gridview.DataSource = DsScanRecord.Tables["Scan_Record"];
                }
            }
        }

        private void Record_gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable DateTable_Record = DsScanRecord.Tables["Scan_Record"];
            DataRow[] dr = DateTable_Staff.Select("Name = '" + DateTable_Record.Rows[Record_gridview.CurrentRow.Index]["Name"].ToString() + "'");

            try
            {
                SMT_Name_txtbox.Text = DateTable_Record.Rows[Record_gridview.CurrentRow.Index]["Name"].ToString();
                SMT_EncodeID_txtbox.Text = DateTable_Record.Rows[Record_gridview.CurrentRow.Index]["ID"].ToString();
                SMT_Name_txtbox.Text = dr[0]["Name"].ToString();
                SMT_EncodeID_txtbox.Text = dr[0]["Encode_ID"].ToString();
                SMT_Job_txtbox.Text = dr[0]["Job"].ToString();
                SMT_cellphone_txtbox.Text = dr[0]["Phone"].ToString();
                SMT_CarID_txtbox.Text = dr[0]["CarNumP"].ToString();
                using (MemoryStream ms = new MemoryStream((byte[])dr[0]["Photo"]))
                {
                    SMT_Staffphoto.Image = Image.FromStream(ms);
                }
            }
            catch
            {
                string message = "資料已刪除或遺失";
                SMT_Name_txtbox.Text = message;
                SMT_EncodeID_txtbox.Text = message;
                SMT_Name_txtbox.Text = message;
                SMT_EncodeID_txtbox.Text = message;
                SMT_Job_txtbox.Text = message;
                SMT_cellphone_txtbox.Text = message;
                SMT_CarID_txtbox.Text = message;
                SMT_Staffphoto.Image = null;
            }
        }
    }
}
