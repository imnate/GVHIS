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
    /// Download_WeekSchedul 的摘要描述
    /// </summary>
    public class Download_WeekSchedul : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            CloseWINWORD_Porcesses();
            DeleteDOC(context, @"C:\Generate_Schedule\");

            var Parameter = context.Request.Params["Parameter"];
            //MongoDB搜尋
            string[] Split_Para = Parameter.Split(' ');
            string[] year = Split_Para[0].Split('-');
            DateTime DTParse = DateTime.ParseExact(Split_Para[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
            CultureInfo ciCurr = CultureInfo.CurrentCulture;
            int week = ciCurr.Calendar.GetWeekOfYear(DTParse, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            DateTime startDateofWeek = GetWeekStartDate(Int32.Parse(year[0]), week);
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Schedule_table");
            var collection = database.GetCollection<Schedule_table>("Schedule_table");
            List<Schedule_table> St_Week_LeaderSchedule = new List<Schedule_table>();
            List<Schedule_table> St_Week_StuffSchedule = new List<Schedule_table>();
            List<Schedule_table> St_Week_TrainingSchedule = new List<Schedule_table>();
            St_Week_LeaderSchedule = collection.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                               //&& x.Status.Equals("正副首長行程")
                                               ).ToList()
                                               .OrderBy(x => Convert.ToDateTime(x.S_time))
                                               .Where(x => x.Status.Equals("正副首長行程"))
                                               .ToList();
            St_Week_StuffSchedule = collection.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                               //&& x.Status.Equals("各組室(堂隊)會議、活動")
                                               ).ToList()
                                               .OrderBy(x => Convert.ToDateTime(x.S_time))
                                               .Where(x => x.Status.Equals("各組室(堂隊)會議、活動"))
                                               .ToList();
            St_Week_TrainingSchedule = collection.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                              //&& x.Status.Equals("員工部外開會、講習、受訓")
                                              ).ToList()
                                              .OrderBy(x => Convert.ToDateTime(x.S_time))
                                              .Where(x => x.Status.Equals("員工部外開會、講習、受訓"))
                                              .ToList();
            ConvertByteAndOutput(context, Write2Word(St_Week_LeaderSchedule, St_Week_StuffSchedule, St_Week_TrainingSchedule, startDateofWeek.ToString("MM-dd").Replace('-', '.') + " - " + startDateofWeek.AddDays(6).ToString("MM-dd").Replace('-', '.')));
        }
        private string Write2Word(List<Schedule_table> Week_leader, List<Schedule_table> Week_Stuff, List<Schedule_table> Week_Training, string DateStr)
        {

            string SavePath = "每週工作預定管制表" + DateTime.Now.ToString("yyyy-MM-dd(HH點mm分)") + ".doc";
            int Total_Col = Week_leader.Count + Week_Stuff.Count + Week_Training.Count;
            List<List<Schedule_table>> List_Schedule = new List<List<Schedule_table>>();
            List_Schedule.Add(Week_leader);
            List_Schedule.Add(Week_Stuff);
            List_Schedule.Add(Week_Training);

            object oEndOfDoc = "\\endofdoc";
            Word.Document oDoc = new Word.Document();
            Object Nothing = System.Reflection.Missing.Value;
            object filepath = @"C:\Generate_Schedule\" + SavePath; //IIS
            Word.Application WordApp = new Word.Application();

            for (int j = 0; j < List_Schedule.Count; j++)
            {
                oDoc.Application.Visible = false;
                dynamic oRange = oDoc.Content.Application.Selection.Range;
                oRange = oDoc.Content.Paragraphs.Add(ref Nothing);
                oRange.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                oRange.Range.Text = j == 0 ? DateStr + "正副首長行程表" : j == 1 ? "各組室會議、堂隊活動" : j == 2 ? "員工部外開會、講習、受訓" : null;
                oRange.Range.Font.Name = "標楷體";
                oRange.Range.Font.Size = 18;
                oRange.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                Word.Table Tables;
                Word.Range wrdRng = oDoc.Bookmarks.get_Item(ref oEndOfDoc).Range;
                Tables = oDoc.Tables.Add(wrdRng, List_Schedule[j].Count + 1, 5, ref Nothing, ref Nothing);
                Tables.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                Tables.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;
                Tables.AllowAutoFit = true;

                string[] LeaderNStuff_title = new string[] { "時間", "工作項目", "地點", "主持人", "承辦人" };
                string[] Training_title = new string[] { "時間", "受訓(開會)項目", "主辦單位", "參訓人員", "承辦人" };
                if (j == 0)
                {
                    for (int k = 0; k < LeaderNStuff_title.Length; k++)
                    {
                        Tables.Cell(1, k + 1).Range.Text = LeaderNStuff_title[k];
                        Tables.Cell(1, k + 1).Range.Font.Name = "標楷體";
                        Tables.Cell(1, k + 1).Range.Font.Size = 14;
                        Tables.Cell(1, k + 1).Range.Font.Bold = 1;
                        Tables.Cell(1, k + 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                else if (j == 2)
                {
                    for (int k = 0; k < Training_title.Length; k++)
                    {
                        Tables.Cell(1, k + 1).Range.Text = Training_title[k];
                        Tables.Cell(1, k + 1).Range.Font.Name = "標楷體";
                        Tables.Cell(1, k + 1).Range.Font.Size = 14;
                        Tables.Cell(1, k + 1).Range.Font.Bold = 1;
                        Tables.Cell(1, k + 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                else
                {
                    for (int k = 0; k < LeaderNStuff_title.Length; k++)
                    {
                        Tables.Cell(1, k + 1).Range.Text = LeaderNStuff_title[k];
                        Tables.Cell(1, k + 1).Range.Font.Name = "標楷體";
                        Tables.Cell(1, k + 1).Range.Font.Size = 14;
                        Tables.Cell(1, k + 1).Range.Font.Bold = 1;
                        Tables.Cell(1, k + 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                if (j != 2)
                {
                    for (int i = 0; i < List_Schedule[j].Count; i++)
                    {
                        string[] DateAll = List_Schedule[j][i].S_time.Split(' ');
                        string[] mmdd = DateAll[0].Split('-');
                        Tables.Cell(i + 2, 1).Range.Text = mmdd[1] + "/" + mmdd[2];
                        Tables.Cell(i + 2, 1).Range.Text += "(" + DateAll[1].Substring(2) + ")";
                        Tables.Cell(i + 2, 1).Range.Text += DateAll[2];
                        Tables.Cell(i + 2, 1).Range.Text += "|";
                        Tables.Cell(i + 2, 1).Range.Text += List_Schedule[j][i].S_end_time;
                        Tables.Cell(i + 2, 1).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 1).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 2).Range.Text = List_Schedule[j][i].Work_item;
                        Tables.Cell(i + 2, 2).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 2).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 3).Range.Text = List_Schedule[j][i].Local;
                        Tables.Cell(i + 2, 3).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 3).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 4).Range.Text = List_Schedule[j][i].S_host;
                        Tables.Cell(i + 2, 4).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 4).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 5).Range.Text = List_Schedule[j][i].Duty;
                        Tables.Cell(i + 2, 5).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 5).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                else
                {
                    for (int i = 0; i < List_Schedule[j].Count; i++)
                    {
                        string[] DateAll = List_Schedule[j][i].S_time.Split(' ');
                        string[] mmdd = DateAll[0].Split('-');
                        Tables.Cell(i + 2, 1).Range.Text = mmdd[1] + "/" + mmdd[2];
                        Tables.Cell(i + 2, 1).Range.Text += "(" + DateAll[1].Substring(2) + ")";
                        Tables.Cell(i + 2, 1).Range.Text += DateAll[2];
                        Tables.Cell(i + 2, 1).Range.Text += "|";
                        Tables.Cell(i + 2, 1).Range.Text += List_Schedule[j][i].S_end_time;
                        Tables.Cell(i + 2, 1).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 1).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 1).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 2).Range.Text = List_Schedule[j][i].Work_item;
                        Tables.Cell(i + 2, 2).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 2).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 2).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 3).Range.Text = List_Schedule[j][i].Local;
                        Tables.Cell(i + 2, 3).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 3).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 3).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 4).Range.Text = List_Schedule[j][i].Participants;
                        Tables.Cell(i + 2, 4).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 4).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 4).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

                        Tables.Cell(i + 2, 5).Range.Text = List_Schedule[j][i].Duty;
                        Tables.Cell(i + 2, 5).Range.Font.Name = "標楷體";
                        Tables.Cell(i + 2, 5).Range.Font.Size = 13;
                        Tables.Cell(i + 2, 5).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
                    }
                }
                //Tables.Columns[2].AutoFit();
                Tables.Rows.Alignment = Word.WdRowAlignment.wdAlignRowCenter;//表格置中
                Tables.AutoFitBehavior(Word.WdAutoFitBehavior.wdAutoFitContent);//全部自動Fitting
            }

            oDoc.SaveAs(ref filepath, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing, ref Nothing);
            oDoc.Close(ref Nothing, ref Nothing, ref Nothing);
            WordApp.Quit(ref Nothing, ref Nothing, ref Nothing); //關閉porcess
            return SavePath;
        }
        private void ConvertByteAndOutput(HttpContext context, string fileName)
        {
            //讀取檔案並將檔案轉成二進制內容
            var output = new byte[0];
            using (var fs = new FileStream(@"C:\Generate_Schedule\" + fileName,
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
            //File.Delete(@"C:\Generate_Schedule\" + fileName);

        }
        private void CloseWINWORD_Porcesses()
        {
            Process[] aProcWrd = Process.GetProcessesByName("WINWORD");

            foreach (System.Diagnostics.Process oProc in aProcWrd)
            {

                oProc.CloseMainWindow();
            }
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
        private DateTime GetWeekStartDate(int year, int week)
        {
            DateTime jan1 = new DateTime(year, 1, 1);//從1月開始計算
            int day = (int)jan1.DayOfWeek - 1;
            int delta = (day < 4 ? -day : 7 - day) + 7 * (week - 1);

            return jan1.AddDays(delta);
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