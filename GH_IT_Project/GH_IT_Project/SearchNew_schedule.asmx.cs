using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB;
using System.Globalization;

namespace GH_IT_Project
{
    /// <summary>
    ///SearchNew_schedule 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class SearchNew_schedule : System.Web.Services.WebService
    {

        [WebMethod]
        public void DateTime_search(string search)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");

            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            var out_result = new List<Schedule_table>();

            int page_no = 1;

            if (!string.IsNullOrEmpty(search))//搜尋
            {
                if (int_start >= int_length)
                {
                    page_no = (int_start / int_length) + 1;
                }
                var list = new List<Schedule_table>();

                list = DWM_search(collection_out, search);

                //list = collection_out.Find(x => x.S_time.Contains(search)).ToList();

                out_result = list
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Skip((page_no - 1) * int_length)
                    .Take(int_length)
                    .Select(x => new Schedule_table
                    {
                        Id = x.Id,
                        S_time = x.S_end_time.Length > 0 ? x.S_time.Replace(" ", "<br>") + " ~ " + x.S_end_time.Replace(" ", "<br>") : x.S_time.Replace(" ", "<br>"),
                        S_end_time = x.S_end_time,
                        Work_item = x.Work_item,
                        S_host = x.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Local = x.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = x.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = x.Duty,
                        Status = x.Status,
                        Insert_time = x.Insert_time,
                        Ip = x.Ip,
                        Increment = x.Increment,

                    }).ToList();
                var result = new
                {
                    draw = 1,
                    data = out_result,
                    iTotalRecords = collection_out.Find(x => x.S_time.Contains(search)).ToList().Count(),
                    iTotalDisplayRecords = list.Count()

                };
                Context.Response.Write(js.Serialize(result));
            }
            else
            {
                if (int_start >= int_length)
                {
                    page_no = (int_start / int_length) + 1;
                }
                var list = new List<Schedule_table>();
                list = collection_out.Find(x => x.Status.Contains("未審核")).ToList();
                out_result = list
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Skip((page_no - 1) * int_length)
                    .Take(int_length)
                    .Select(x => new Schedule_table
                    {
                        Id = x.Id,
                        S_time = x.S_end_time.Length > 0 ? x.S_time.Replace(" ", "<br>") + " ~ " + x.S_end_time.Replace(" ", "<br>") : x.S_time.Replace(" ", "<br>"),
                        S_end_time = x.S_end_time,
                        Work_item = x.Work_item,
                        S_host = x.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Local = x.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = x.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = x.Duty,
                        Status = x.Status,
                        Insert_time = x.Insert_time,
                        Ip = x.Ip,
                        Increment = x.Increment,
                    }).ToList();
                var result = new
                {
                    draw = 1,
                    data = out_result,
                    iTotalRecords = collection_out.Find(x => x.Status.Contains("未審核")).ToList().Count(),
                    iTotalDisplayRecords = list.Count()

                };
                Context.Response.Write(js.Serialize(result));

            }
        }
        private List<Schedule_table> DWM_search(IMongoCollection<Schedule_table> collection, string search)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<Schedule_table> result = new List<Schedule_table>();
            string[] Split_search = search.Split(',');
            switch (Split_search[1])
            {
                case "0":
                    result = collection.Find(x => x.S_time.Contains(Split_search[0])).ToList();
                    break;
                case "1":
                    //週
                    string[] ymd = Split_search[0].Split(' ');
                    string[] year = ymd[0].Split('-');
                    DateTime dt = DateTime.ParseExact(ymd[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    CultureInfo ciCurr = CultureInfo.CurrentCulture;
                    int week = ciCurr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                    DateTime startDateofWeek = GetWeekStartDate(Int32.Parse(year[0]), week);
                    result = collection.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd")) 
                                               || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                               || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                               ).ToList();
                    break;
                case "2":
                    //input = 2018-10-02 星期二
                    string[] split_Day = Split_search[0].Split(' ', '-');
                    result = collection.Find(x => x.S_time.Contains(split_Day[0] + "-" + split_Day[1])).ToList();
                    break;
            }

            return result;
        }
        private DateTime GetWeekStartDate(int year, int week)
        {
            DateTime jan1 = new DateTime(year, 1, 1);//從1月開始計算
            int day = (int)jan1.DayOfWeek - 1;
            int delta = (day < 4 ? -day : 7 - day) + 7 * (week - 1);

            return jan1.AddDays(delta);
        }

        [WebMethod]
        public void Schedule_searchByID(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");

            var list = new List<Schedule_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new Schedule_table
                {
                    Id = s.Id,
                    S_time = s.S_time,
                    S_end_time = s.S_end_time,
                    Work_item = s.Work_item,
                    S_host = s.S_host,
                    Local = s.Local,
                    Participants = s.Participants,
                    Duty = s.Duty,
                    Status = s.Status,
                    Insert_time = s.Insert_time,
                    Ip = s.Ip,
                    Increment = s.Id.Increment,

                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();


            Context.Response.Write(js.Serialize(list));
        }
        [WebMethod]
        public void Schedule_update(string ID, string time, string end_time, string Work_item, string local, string host, string Participants, string Duty, string status)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");
            var list = new List<Schedule_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new Schedule_table
                {
                    Id = s.Id,
                    S_time = s.S_time,
                    S_end_time = s.S_end_time,
                    Work_item = s.Work_item,
                    S_host = s.S_host,
                    Local = s.Local,
                    Participants = s.Participants,
                    Duty = s.Duty,
                    Status = s.Status,
                    Insert_time = s.Insert_time,
                    Ip = s.Ip,
                    Increment = s.Id.Increment,

                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();
            string filter = "{'_id':ObjectId(" + '"' + list[0].Id.ToString() + '"' + ")}";
            string update_para = "{$set:{'S_time':'" + time + "','S_end_time':'" + end_time + "','Work_item':'" + Work_item + "','Local':'" + local + "','S_host':'" + host + "','Participants':'" + Participants + "','Duty':'" + Duty + "','Status':'" + status + "'}}";
            collection_out.UpdateOne(filter, update_para);
            Context.Response.Write(js.Serialize("更新成功!"));
        }
        [WebMethod]
        public void Leader_viewer(string search)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");

            var list = new List<Schedule_table>();

            if (search == "")//當日 DateTime.Now
            {
                list = collection_out.Find(x => x.S_time.Contains(DateTime.Now.ToString("yyyy-MM-dd"))).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Select(s => new Schedule_table
                    {
                        Increment = s.Id.Increment,
                        S_time = s.S_end_time.Length > 0 ? s.S_time.Replace(" ", "<br>") + " ~ " + s.S_end_time.Replace(" ", "<br>") : s.S_time.Replace(" ", "<br>"),
                        Work_item = s.Work_item,
                        S_host = s.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Status = s.Status,
                        Local = s.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = s.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = s.Duty,

                    })
                    //.Where(x => x.S_time.Contains(DateTime.Now.ToString("yyyy-MM-dd")) && x.Status.Equals("正副首長行程"))
                    .Where(x => x.Status.Equals("正副首長行程"))
                    .ToList();
            }
            else
            {
                string[] ymd = search.Split(' ');
                string[] year = ymd[0].Split('-');
                DateTime dt = DateTime.ParseExact(ymd[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int week = ciCurr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                DateTime startDateofWeek = GetWeekStartDate(Int32.Parse(year[0]), week);

                list = collection_out.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                           ).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Select(s => new Schedule_table
                    {
                        Increment = s.Id.Increment,
                        S_time = s.S_end_time.Length > 0 ? s.S_time.Replace(" ", "<br>") + " ~ " + s.S_end_time.Replace(" ", "<br>") : s.S_time.Replace(" ", "<br>"),
                        Work_item = s.Work_item,
                        S_host = s.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Status = s.Status,
                        Local = s.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = s.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = s.Duty,
                    })
                    .Where(x => x.Status.Equals("正副首長行程"))
                    .ToList();
            }

            var result = new
            {
                draw = 1,
                data = list,
                iTotalRecords = list.Count(),
                iTotalDisplayRecords = list.Count()

            };


            Context.Response.Write(js.Serialize(result));
        }
        [WebMethod]
        public void Group_viewer(string search)
        {


            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");

            var list = new List<Schedule_table>();
            if (search == "")
            {
                list = collection_out.Find(x => x.S_time.Contains(DateTime.Now.ToString("yyyy-MM-dd"))).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Select(s => new Schedule_table
                    {
                        Increment = s.Id.Increment,
                        S_time = s.S_end_time.Length > 0 ? s.S_time.Replace(" ", "<br>") + " ~ " + s.S_end_time.Replace(" ", "<br>") : s.S_time.Replace(" ", "<br>"),
                        Work_item = s.Work_item,
                        S_host = s.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Status = s.Status,
                        Local = s.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = s.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = s.Duty,

                    })
                    //.Where(x => x.S_time.Contains(DateTime.Now.ToString("yyyy-MM-dd")) && x.Status.Equals("正副首長行程"))
                    .Where(x => x.Status.Equals("各組室(堂隊)會議、活動"))
                    .ToList();
            }
            else
            {
                string[] ymd = search.Split(' ');
                string[] year = ymd[0].Split('-');
                DateTime dt = DateTime.ParseExact(ymd[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int week = ciCurr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                DateTime startDateofWeek = GetWeekStartDate(Int32.Parse(year[0]), week);

                list = collection_out.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                           ).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Select(s => new Schedule_table
                    {
                        Increment = s.Id.Increment,
                        S_time = s.S_end_time.Length > 0 ? s.S_time.Replace(" ", "<br>") + " ~ " + s.S_end_time.Replace(" ", "<br>") : s.S_time.Replace(" ", "<br>"),
                        Work_item = s.Work_item,
                        S_host = s.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Status = s.Status,
                        Local = s.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = s.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = s.Duty,
                    })
                    .Where(x => x.Status.Equals("各組室(堂隊)會議、活動"))
                    .ToList();

            }
            var result = new
            {
                draw = 1,
                data = list,
                iTotalRecords = list.Count(),
                iTotalDisplayRecords = list.Count()

            };


            Context.Response.Write(js.Serialize(result));
        }
        [WebMethod]
        public void Group_Sout_viewer(string search)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");

            var list = new List<Schedule_table>();

            if (search == "")
            {
                list = collection_out.Find(x => x.S_time.Contains(DateTime.Now.ToString("yyyy-MM-dd"))).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Select(s => new Schedule_table
                    {
                        Increment = s.Id.Increment,
                        S_time = s.S_end_time.Length > 0 ? s.S_time.Replace(" ", "<br>") + " ~ " + s.S_end_time.Replace(" ", "<br>") : s.S_time.Replace(" ", "<br>"),
                        Work_item = s.Work_item,
                        S_host = s.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Status = s.Status,
                        Local = s.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = s.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = s.Duty,

                    })
                    //.Where(x => x.S_time.Contains(DateTime.Now.ToString("yyyy-MM-dd")) && x.Status.Equals("正副首長行程"))
                    .Where(x => x.Status.Equals("員工部外開會、講習、受訓"))
                    .ToList();
            }
            else
            {
                string[] ymd = search.Split(' ');
                string[] year = ymd[0].Split('-');
                DateTime dt = DateTime.ParseExact(ymd[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                CultureInfo ciCurr = CultureInfo.CurrentCulture;
                int week = ciCurr.Calendar.GetWeekOfYear(dt, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
                DateTime startDateofWeek = GetWeekStartDate(Int32.Parse(year[0]), week);

                list = collection_out.Find(x => x.S_time.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                           || x.S_time.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                           ).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.S_time))
                    .Select(s => new Schedule_table
                    {
                        Increment = s.Id.Increment,
                        S_time = s.S_end_time.Length > 0 ? s.S_time.Replace(" ", "<br>") + " ~ " + s.S_end_time.Replace(" ", "<br>") : s.S_time.Replace(" ", "<br>"),
                        Work_item = s.Work_item,
                        S_host = s.S_host.Replace(" ", "<br>").Replace("、", "<br>"),
                        Status = s.Status,
                        Local = s.Local.Replace(" ", "<br>").Replace("、", "<br>"),
                        Participants = s.Participants.Replace(" ", "<br>").Replace("、", "<br>").Replace("及", "<br>"),
                        Duty = s.Duty,
                    })
                    .Where(x => x.Status.Equals("員工部外開會、講習、受訓"))
                    .ToList();
            }

            var result = new
            {
                draw = 1,
                data = list,
                iTotalRecords = list.Count(),
                iTotalDisplayRecords = list.Count()

            };

            Context.Response.Write(js.Serialize(result));
        }
        [WebMethod]
        public void Check_Director_host_ajax(string host_postition, string S_Begin_time, string S_End_time, int interval_time)
        {
            string End_time = convert_no0hour(S_End_time);


            string[] split_Begin_time = S_Begin_time.Split(' ');
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");
            var list = new List<Schedule_table>();
            list = collection_out.Find(x => x.S_host.Equals(host_postition) && x.S_time.Contains(split_Begin_time[0])).ToList()
                .Select(s => new Schedule_table
                {
                    Increment = s.Id.Increment,
                    S_time = s.S_time,
                    S_end_time = s.S_end_time,
                    Work_item = s.Work_item,
                    S_host = s.S_host,
                    Status = s.Status,
                    Local = s.Local,
                    Participants = s.Participants,
                    Duty = s.Duty,
                }).ToList();



            Dictionary<string, bool> TimeStatus = new Dictionary<string, bool>(); //未更新間隔的Dictionary
            for (int i = 8; i < 17; i++) //初始化8點到17點 每五分鐘建立一個dic欄位
            {
                for (int j = 0; j < 60; j = j + 5)
                {
                    string hour_str = i.ToString();
                    string min_str = j.ToString();
                    if (j < 10)
                    {
                        min_str = "0" + j.ToString();
                    }
                    if (i < 10)
                    {
                        hour_str = "0" + i.ToString();
                    }
                    TimeStatus.Add(hour_str.ToString() + ":" + min_str, true);
                    if (i == 16 && j == 55)
                    {
                        TimeStatus.Add((i + 1).ToString() + ":00", true);
                        TimeStatus.Add((i + 1).ToString() + ":05", false);
                    }
                }
            }


            List<string> Be_temp_hour = new List<string>();
            List<string> Be_temp_min = new List<string>();
            List<string> End_temp_hour = new List<string>();
            List<string> End_temp_min = new List<string>();
            List<int> Total_min = new List<int>();
            List<string> Schedule_time = new List<string>();
            List<Vaild_increment> Vail_list = new List<Vaild_increment>();

            List<string> output = new List<string>();
            List<int> session = new List<int>();


            for (int i = 0; i < list.Count; i++)//擷取時間
            {

                string[] temp = { };
                string[] Be_temp = { };
                string[] End_temp = { };
                string duty = list[i].Duty.Length > 10 ? list[i].Duty.Substring(10) + "...(詳情請查詢工作管制表)<br>" : list[i].Duty + "<br>";
                temp = list[i].S_time.Split(' ');//切調中文日期

                Be_temp = temp[2].Split(':');
                Be_temp_hour.Add(Be_temp[0]);
                Be_temp_min.Add(Be_temp[1]);

                End_temp = list[i].S_end_time.Split(':');
                End_temp_hour.Add(End_temp[0]);
                End_temp_min.Add(End_temp[1]);

                Schedule_time.Add(temp[2] + " - " + list[i].S_end_time + "<br>" + duty + "<small class=" + '"' + "form-text text-muted" + '"' + ">" + "[ID:" + list[i].Increment + "]</small><br><br>");

                Vaild_increment vi = new Vaild_increment();
                vi.Id = list[i].Increment;
                vi.Sch_time = temp[2] + " - " + list[i].S_end_time;
                Vail_list.Add(vi);

                int total_time = (Convert.ToInt32(End_temp[0]) - Convert.ToInt32(Be_temp[0])) * 60
                    + (Convert.ToInt32(Be_temp[1]) > Convert.ToInt32(End_temp[1])
                    ? (Convert.ToInt32(Be_temp[1]) - Convert.ToInt32(End_temp[1])) : (Convert.ToInt32(End_temp[1]) - Convert.ToInt32(Be_temp[1])));
                Total_min.Add(total_time);


                //從資料庫資料來Dictionary更新欄位
                for (int j = 0; j < Be_temp_hour.Count; j++)//讀取List裡面的時間
                {
                    int begin_hour = Convert.ToInt32(Be_temp_hour[j]);//Be_temp[0]
                    int begin_min = Convert.ToInt32(Be_temp_min[j]);//Be_temp[1]
                    int end_hour = Convert.ToInt32(End_temp_hour[j]);//End_temp[0]
                    int end_min = Convert.ToInt32(End_temp_min[j]);//End_temp[1]

                    int interval_endHour = 0;
                    int interval_endMin = 0;
                    if (interval_time % 60 == 0)//代表沒有分鐘需要 + 並且進位
                    {
                        interval_endHour = end_hour + (interval_time / 60);
                        interval_endMin = end_min;
                        if (interval_endHour >= 17)
                        {
                            interval_endHour = 17;
                            interval_endMin = 0;
                        }
                    }
                    else
                    {
                        interval_endHour = end_hour + ((end_min + interval_time) / 60);
                        interval_endMin = (end_min + interval_time) % 60;
                        if (interval_endHour >= 17)
                        {
                            interval_endHour = 17;
                            interval_endMin = 0;
                        }
                    }
                    //-----------處理TorF-----------
                    for (int t = begin_hour; t <= interval_endHour; t++)
                    {
                        string t_temp = t < 10 ? "0" + t.ToString() : t.ToString();
                        if (t == interval_endHour)
                        {
                            for (int u = 0; u <= interval_endMin; u += 5)
                            {
                                TimeStatus[t_temp + ":" + (u < 10 ? "0" + u.ToString() : u.ToString())] = false;
                            }

                        }
                        else if (t != interval_endHour && t != begin_hour)
                        {
                            for (int u = 0; u < 60; u += 5)
                            {
                                TimeStatus[t_temp + ":" + (u < 10 ? "0" + u.ToString() : u.ToString())] = false;
                            }
                        }
                        else if (t == begin_hour)
                        {
                            for (int u = begin_min; u < 60; u += 5)
                            {
                                TimeStatus[t_temp + ":" + (u < 10 ? "0" + u.ToString() : u.ToString())] = false;
                            }
                        }

                    }
                    //-----------處理TorF-----------

                }
            }
            //Context.Response.Write(js.Serialize(list.ToJson()));
            //Context.Response.Write(js.Serialize(TimeStatus.ToJson() + Chech_schedule_TorF(TimeStatus, split_Begin_time[2], End_time, Schedule_time.OrderBy(x => x).ToList()).ToJson()));
            Context.Response.Write(js.Serialize(Chech_schedule_TorF(TimeStatus, split_Begin_time[2], End_time, Schedule_time.OrderBy(x => x).ToList(), Vail_list))); //標準輸出
            //Context.Response.Write(js.Serialize(split_Begin_time[2].ToJson()));
            //Context.Response.Write(js.Serialize(TimeStatus.ToJson() + "," + split_Begin_time[2].ToJson() + "," + End_time.ToJson()));
        }
        private List<Feed_Back> Chech_schedule_TorF(Dictionary<string, bool> TorF_Dictionary, string begin_time, string end_time, List<string> Schedule_time, List<Vaild_increment> List_Vaild)//interval_time 單位分鐘
        {
            List<Feed_Back> Feed_back = new List<Feed_Back>();
            Feed_Back FB = new Feed_Back();
            string str_Schedule_time = "";
            FB.List_Vaild = List_Vaild;
            for (int i = 0; i < Schedule_time.Count; i++)
            {
                str_Schedule_time += Schedule_time[i];
            }

            if (TorF_Dictionary[begin_time].Equals(true))
            {
                if (TorF_Dictionary[end_time].Equals(true))
                {
                    FB.Time_TorF = true;
                    FB.Advice_Time = begin_time + "~" + end_time;
                    FB.Not_Advice_Time = str_Schedule_time;
                    Feed_back.Add(FB);

                    return Feed_back;
                }
                else //結束時間為false
                {
                    FB.Time_TorF = false;
                    FB.Advice_Time = Available_time(TorF_Dictionary);
                    FB.Not_Advice_Time = str_Schedule_time;
                    Feed_back.Add(FB);
                    return Feed_back;
                }
            }
            else //開始時間為false
            {
                FB.Time_TorF = false;
                FB.Advice_Time = Available_time(TorF_Dictionary);
                FB.Not_Advice_Time = str_Schedule_time;
                Feed_back.Add(FB);

                return Feed_back;
            }
        }
        public string Available_time(Dictionary<string, bool> TorF_Dictionary)
        {
            string result = "";
            List<string> Available_begin_time = new List<string>();
            List<string> Available_end_time = new List<string>();
            for (int i = 0; i < TorF_Dictionary.Count; i++)
            {
                if (TorF_Dictionary.ElementAt(i).Value == true)//17:00 沒處理(加入17:05 false)
                {
                    if (Available_begin_time.Count == 0)
                    {
                        Available_begin_time.Add(TorF_Dictionary.ElementAt(i).Key);
                    }
                }
                else
                {
                    if (Available_end_time.Count == 0 && Available_begin_time.Count > 0)
                    {
                        Available_end_time.Add(TorF_Dictionary.ElementAt(i - 1).Key);
                        result += Available_begin_time[0] + " - " + Available_end_time[0] + "<br>";
                        Available_begin_time = new List<string>();
                        Available_end_time = new List<string>();
                    }
                }
            }

            //輸出有空的時間 建議使用者
            return result;
        }
        [WebMethod]
        public void delete(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<Schedule_table>("Schedule_table");
            var list = new List<Schedule_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new Schedule_table
                {
                    Id = s.Id,
                    S_time = s.S_time,
                    Work_item = s.Work_item,
                    Increment = s.Id.Increment,
                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();
            string filter = "{'_id':ObjectId(" + '"' + list[0].Id.ToString() + '"' + ")}";
            collection_out.DeleteOne(filter);
            Context.Response.Write(js.Serialize(list[0].S_time + " " + list[0].Work_item));
        }

        public string convert_no0hour(string hour)
        {
            string str_hout = "";
            string str_min = "";
            string[] temp_split = hour.Split(':');
            int int_hour = Convert.ToInt32(temp_split[0]);
            int int_min = Convert.ToInt32(temp_split[1]);
            str_hout = int_hour < 10 ? "0" + int_hour.ToString() : int_hour.ToString();
            str_min = int_min < 10 ? "0" + int_min.ToString() : int_min.ToString();

            return str_hout + ":" + str_min;
        }
        public class Feed_Back
        {
            public bool Time_TorF { get; set; }
            public string Advice_Time { get; set; }
            public string Not_Advice_Time { get; set; }
            public List<Vaild_increment> List_Vaild { get; set; }
        }
        public class Vaild_increment
        {
            public int Id { get; set; }
            public string Sch_time { get; set; }
        }
    }
}
