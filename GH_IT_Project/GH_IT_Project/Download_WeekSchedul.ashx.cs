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
                                               && x.Status.Equals("正副首長行程")
                                               ).ToList();
            St_Week_StuffSchedule = collection.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                               && x.Status.Equals("各組室(堂隊)會議、活動")
                                               ).ToList();
            St_Week_TrainingSchedule = collection.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                              || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                              && x.Status.Equals("員工部外開會、講習、受訓")
                                              ).ToList();
            Write2Word(St_Week_LeaderSchedule, St_Week_StuffSchedule, St_Week_TrainingSchedule);
        }
        private string Write2Word(List<Schedule_table> Week_leader , List<Schedule_table> Week_Stuff, List<Schedule_table> Week_Training)
        {
            string SavePath = "每週工作預定管制表" + DateTime.Now.ToString("yyyy-MM-dd(HH點mm分)") + ".doc";
            List<List<Schedule_table>> List_Schedule = new List<List<Schedule_table>>();
            List_Schedule.Add(Week_leader);
            List_Schedule.Add(Week_Stuff);
            List_Schedule.Add(Week_Training);

            object oEndOfDoc = "\\endofdoc";
            Word.Document oDoc = new Word.Document();
            Object Nothing = System.Reflection.Missing.Value;
            object filepath = @"C:\Generate_Schedule\" + SavePath; //IIS
            Word.Application WordApp = new Word.Application();
            for (int i = 0; i < List_Schedule.Count; i++)
            {
                //List_Schedule是把首長 行程 跟 各組室 還有員工受訓 的集合
                //先建立表格 參加 Download.ashx的 第123開始做
                //概念大概像是 
                //    首長
                //    { 
                //        ....
                //    }
                //    各組室
                //    {
                //        ....
                //    }
                //    受訓
                //    {
                //        ....
                //    }
            }



            return SavePath;
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