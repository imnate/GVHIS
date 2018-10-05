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
using MongoDB.Bson.Serialization.Attributes;
using Word = Microsoft.Office.Interop.Word;
using System.Globalization;
using System.Diagnostics;

namespace GH_IT_Project
{
    /// <summary>
    /// DownloadBigEvent 的摘要描述
    /// </summary>
    public class DownloadBigEvent : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            CloseWINWORD_Porcesses();
            DeleteDOC(context, @"C:\Generate_Event\");
            string Parameter = context.Request.Params["Parameter"];
            string[] year = Parameter.Split('-');//2018-10-05格式
            ConvertByteAndOutput(context, CreateBigEventWordFile(GetMongoDB(year[0]), Convert.ToInt32(year[0]), year[0]));
        }
        private List<Schedule_table> GetMongoDB(string Year)//抓取年度大事記資料
        {
            var list = new List<Schedule_table>();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Schedule_table");
            var collection = database.GetCollection<Schedule_table>("Schedule_table");
            list = collection.Find(x => (x.S_host.Equals("家主任") && x.S_time.Contains(Year) && x.Status != "未審核")
                                     || (x.S_host.Equals("副主任") && x.S_time.Contains(Year) && x.Status != "未審核"))
                                     .ToList()
                                     .OrderBy(x => Convert.ToDateTime(x.S_time))
                                     .Select(x => new Schedule_table
                                     {
                                         S_time = x.S_time,
                                         Work_item = x.Work_item,
                                         S_host = x.S_host,
                                         Status = x.Status,
                                     })
                                    .ToList();

            return list;
        }
        private string CreateBigEventWordFile(List<Schedule_table> MadeFileDates, int Year, string outYear)
        {
            string ROCYear = (Year - 1911).ToString();
            object oEndOfDoc = "\\endofdoc";
            Word.Document oDoc = new Word.Document();
            Object Nothing = System.Reflection.Missing.Value;
            string FileName = ROCYear + "大事記" + DateTime.Now.ToString("yyyy-MM-dd(HH點mm分)") + ".doc";
            object filepath = @"C:\Generate_Event\" + FileName; //IIS
            //string outputpath = @"C:\Generate_Event\" + FileName;
            Word.Application WordApp = new Word.Application();

            oDoc.Application.Visible = false;//不顯示word視窗
            dynamic oRange = oDoc.Content.Application.Selection.Range;



            oRange = oDoc.Content.Paragraphs.Add(ref Nothing);
            oRange.Range.Text = "岡山榮家 " + ROCYear + " 大事記";
            oRange.Range.Font.Name = "標楷體";
            oRange.Range.Font.Size = 17;
            oRange.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;



            Word.Table Tables;
            Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;

            Tables = oDoc.Tables.Add(wrdRng, MadeFileDates.Count + 1, 4, ref Nothing, ref Nothing);
            Tables.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Tables.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
            Tables.AllowAutoFit = true;


            string[] title = new string[] { "年份", "月日", "大事摘要", "備考" };
            for (int j = 1; j <= title.Length; j++)//建欄位標題
            {
                Tables.Cell(1, j).Range.Text = title[j - 1];
                Tables.Cell(1, j).Range.Font.Name = "標楷體";
                Tables.Cell(1, j).Range.Font.Size = 16;
                Tables.Cell(1, j).Range.Font.Bold = 1;
                Tables.Cell(1, j).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
            for (int i = 0; i < MadeFileDates.Count; i++)//建欄位內容
            {
                //wrdRng.Text = MadeFileDates[i].S_time + " " + MadeFileDates[i].Work_item + " " + MadeFileDates[i].S_host + " " + MadeFileDates[i].Status;
                //Tables.Cell(i + 2, 1).Range.Text = ROCYear;
                //Tables.Cell(i + 2, 1).Range.Font.Name = "標楷體";
                //Tables.Cell(i + 2, 1).Range.Font.Size = 16;
                //Tables.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                //string[] SplitMMDD = MadeFileDates[i].S_time.Substring(0, MadeFileDates[i].S_time.IndexOf(' ')).Split('-');
                //Tables.Cell(i + 2, 2).Range.Text = SplitMMDD[1] + "/" + SplitMMDD[2];
                //Tables.Cell(i + 2, 2).Range.Font.Name = "標楷體";
                //Tables.Cell(i + 2, 2).Range.Font.Size = 16;
                //Tables.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                if (MadeFileDates[i].Status == "正副首長行程")
                {
                    Tables.Cell(i + 2, 1).Range.Text = ROCYear;
                    Tables.Cell(i + 2, 1).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 1).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    string[] SplitMMDD = MadeFileDates[i].S_time.Substring(0, MadeFileDates[i].S_time.IndexOf(' ')).Split('-');
                    Tables.Cell(i + 2, 2).Range.Text = SplitMMDD[1] + "/" + SplitMMDD[2];
                    Tables.Cell(i + 2, 2).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 2).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    Tables.Cell(i + 2, 3).Range.Text = MadeFileDates[i].S_host + "主持 " + MadeFileDates[i].Work_item;
                    Tables.Cell(i + 2, 3).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 3).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                }
                else if (MadeFileDates[i].Status == "員工部外開會、講習、受訓")
                {
                    Tables.Cell(i + 2, 1).Range.Text = ROCYear;
                    Tables.Cell(i + 2, 1).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 1).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    string[] SplitMMDD = MadeFileDates[i].S_time.Substring(0, MadeFileDates[i].S_time.IndexOf(' ')).Split('-');
                    Tables.Cell(i + 2, 2).Range.Text = SplitMMDD[1] + "/" + SplitMMDD[2];
                    Tables.Cell(i + 2, 2).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 2).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    Tables.Cell(i + 2, 3).Range.Text = MadeFileDates[i].S_host + "參加 " + MadeFileDates[i].Work_item;
                    Tables.Cell(i + 2, 3).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 3).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                }
                else if (MadeFileDates[i].Status == "各組室(堂隊)會議、活動")
                {
                    Tables.Cell(i + 2, 1).Range.Text = ROCYear;
                    Tables.Cell(i + 2, 1).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 1).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    string[] SplitMMDD = MadeFileDates[i].S_time.Substring(0, MadeFileDates[i].S_time.IndexOf(' ')).Split('-');
                    Tables.Cell(i + 2, 2).Range.Text = SplitMMDD[1] + "/" + SplitMMDD[2];
                    Tables.Cell(i + 2, 2).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 2).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                    Tables.Cell(i + 2, 3).Range.Text = MadeFileDates[i].S_host + "主持 " + MadeFileDates[i].Work_item + "(分類錯誤。各組室(堂隊)會議、活動)";
                    Tables.Cell(i + 2, 3).Range.Font.Name = "標楷體";
                    Tables.Cell(i + 2, 3).Range.Font.Size = 16;
                    Tables.Cell(i + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
                }

            }
            Tables.Columns[1].AutoFit();
            Tables.Columns[2].AutoFit();
            //Tables.Columns[3].AutoFit();
            Tables.Columns[4].AutoFit();
            Tables.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;//表格置中
            Tables.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);//全部自動Fitting

            oDoc.SaveAs(ref filepath, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            oDoc.Close(ref Nothing, ref Nothing, ref Nothing);
            WordApp.Quit(ref Nothing, ref Nothing, ref Nothing); //關閉porcess
            return FileName;
        }
        private void DeleteDOC(HttpContext context, string WordPath)
        {
            string[] files = Directory.GetFiles(WordPath, "*.doc");//找出目錄底下檔案
            //逐筆刪除
            foreach (string file in files)
            {
                File.Delete(file);
            }

        }
        private void CloseWINWORD_Porcesses()
        {
            Process[] aProcWrd = Process.GetProcessesByName("WINWORD");

            foreach (System.Diagnostics.Process oProc in aProcWrd)
            {

                oProc.CloseMainWindow();
            }
        }
        private void ConvertByteAndOutput(HttpContext context, string fileName)
        {
            //讀取檔案並將檔案轉成二進制內容
            var output = new byte[0];
            using (var fs = new FileStream(@"C:\Generate_Event\" + fileName,
                FileMode.Open, FileAccess.Read))
            {
                output = new byte[(int)fs.Length];
                fs.Read(output, 0, output.Length);
                fs.Close();
            }

            //將檔案輸出到瀏覽器
            context.Response.Clear();
            context.Response.AddHeader(
                "Content-Length", output.Length.ToString());
            context.Response.ContentType = "application/msword";//"application/octet-stream";
            context.Response.AddHeader(
                "content-disposition",
                "attachment; filename=" + fileName);
            context.Response.OutputStream.Write(output, 0, output.Length);
            context.Response.Flush();
            context.Response.End();

            CloseWINWORD_Porcesses();


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