using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB;

namespace GH_IT_Project
{
    /// <summary>
    /// Download 的摘要描述
    /// </summary>
    public class Download : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            //接參數的index
            var Parameter = context.Request.Params["Parameter"];
            //MongoDB搜尋
           
            
            StreamWriter sw = new StreamWriter(@"C:\Users\info\source\repos\GH_IT_Project\GH_IT_Project\File\text.txt", true);
            //第二個參數設定為true表示不覆蓋原本的內容，把新內容直接添加進去
            sw.WriteLine(Convert.ToString(Parameter));
            sw.Close();





            var fileName = "測試檔案1.docx";
            ConvertByteAndOutput(context , fileName);
        }
        private void ConvertByteAndOutput(HttpContext context,string fileName)
        {
            //取得檔案在Server上的實體路徑 專案檔裡面的File資料夾
            var filePath = context.Server.MapPath("~/File/" + fileName);

            //讀取檔案並將檔案轉成二進制內容
            var output = new byte[0];
            using (var fs = new FileStream(filePath,
                FileMode.Open, FileAccess.Read))
            {
                output = new byte[(int)fs.Length];
                fs.Read(output, 0, output.Length);
            }

            //將檔案輸出到瀏覽器
            context.Response.Clear();
            context.Response.AddHeader(
                "Content-Length", output.Length.ToString());
            context.Response.ContentType = "application/octet-stream";
            context.Response.AddHeader(
                "content-disposition",
                "attachment; filename=" + fileName);
            context.Response.OutputStream.Write(output, 0, output.Length);
            context.Response.Flush();
            context.Response.End();

        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}