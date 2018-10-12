using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ReadQRcode
{
    public partial class QR : Form
    {
        string staff_Name;
        public QR(byte[] QR_code, string staff_Name, string EnCode_ID)
        {
            this.staff_Name = staff_Name;
            InitializeComponent();
            this.Text = staff_Name + " [" + EnCode_ID + "]";
            using (MemoryStream memStream = new MemoryStream(QR_code))
            {
                QR_CodePic.Image = Image.FromStream(memStream);
            }
        }

        private void Save_btn_Click(object sender, EventArgs e)
        {
            SaveFileDialog SFD = new SaveFileDialog();
            SFD.Title = "儲存圖片";
            SFD.Filter = "JPEG|*.jpg|BMP|*.bmp;|PNG|*.png";
            SFD.FileName = staff_Name;

            if (SFD.ShowDialog() == DialogResult.OK)
            {

                string FileName = SFD.FileName;
                if (FileName != "" && FileName != null)
                {
                    string FileTypeName = FileName.Substring(FileName.LastIndexOf(".") + 1).ToString();
                    System.Drawing.Imaging.ImageFormat ImageFormat = null;

                    if (FileTypeName != null)
                    {
                        switch (FileTypeName)//設定儲存的圖片格式
                        {
                            case "jpg":
                                ImageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                                break;
                            case "bmp":
                                ImageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
                                break;
                            case "png":
                                ImageFormat = System.Drawing.Imaging.ImageFormat.Png;
                                break;
                        }

                        try
                        {

                            using (MemoryStream mem = new MemoryStream())
                            {
                                //這句很重要，不然不能正確保存圖片或出錯（關鍵就這一句）
                                Bitmap bmp = new Bitmap(QR_CodePic.Image);
                                //保存到磁盤文檔
                                bmp.Save(FileName, ImageFormat);
                                bmp.Dispose();
                                MessageBox.Show("儲存成功");
                            }

                            //MessageBox.Show("儲存圖片" + ImageFormat.ToString());
                            ////Bitmap bit = new Bitmap(QR_CodePic.BackgroundImage);
                            //QR_CodePic.Image.Save(FileName, ImageFormat);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }

                    }


                }
            }
        }
    }
}
