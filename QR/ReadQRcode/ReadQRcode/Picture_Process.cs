using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ReadQRcode
{
    class Picture_Process
    {
        public byte[] PicToByte(Image ToBytePic)
        {
            MemoryStream MS = new MemoryStream();//轉成byte
            Image img = ToBytePic;
            img.Save(MS, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] result = MS.ToArray();
            MS.Close();
            return result;
        }
        public Image ByteToPic(byte[] ToImage)
        {
            MemoryStream MS = new MemoryStream();
            foreach (byte a in ToImage)
            {
                MS.WriteByte(a);
            }
            Image img = Image.FromStream(MS);
            MS.Close();
            return img;
        }
        
    }
}
