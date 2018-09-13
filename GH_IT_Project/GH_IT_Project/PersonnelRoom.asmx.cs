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
    ///PersonnelRoom 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class PersonnelRoom : System.Web.Services.WebService
    {

        [WebMethod]
        public void NewLeave(string Date, string Staff, string Reason)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime DT = DateTime.Now;
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("PR");
            var collection_out = database.GetCollection<BsonDocument>("PR");//my class also can use <T> = <BsonDocument>
            var insert_str = new BsonDocument
                {
                    {"Date" , Date },
                    {"Staff" , Staff},
                    {"Reason" , Reason},
                    {"Create_time" , DT.ToString()},

                };
            try
            {
                collection_out.InsertOne(insert_str);
                Context.Response.Write(js.Serialize(DT.ToString()));

            }
            catch (Exception e)
            {
                Context.Response.Write(js.Serialize("例外: " + e));
            }
        }
        [WebMethod]
        public void Show_leave()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("PR");
            var collection_out = database.GetCollection<PR>("PR");

            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            var out_result = new List<PR>();
            int page_no = 1;

            if (int_start >= int_length)
            {
                page_no = (int_start / int_length) + 1;
            }
            var list = new List<PR>();
            list = collection_out.Find(_ => true).ToList();
            out_result = list
                         .OrderByDescending(x => Convert.ToDateTime(x.Date))
                         .Skip((page_no - 1) * int_length)
                         .Take(int_length)
                         .Select(x => new PR
                         {
                             _id = x._id,
                             strId = x._id.ToString(),
                             Date = x.Date.Replace(" ", "<br>"),
                             Staff = x.Staff,
                             Reason = x.Reason,
                             Create_time = x.Create_time.Replace(" ", "<br>")

                         }).ToList();
            var result = new
            {
                draw = 1,
                iTotalRecords = list.Count(),
                iTotalDisplayRecords = list.Count(),
                data = out_result
            };
            Context.Response.Write(js.Serialize(result));

        }
        [WebMethod]
        public void Delete_PR(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("PR");
            var collection_out = database.GetCollection<PR>("PR");
            string filter = "{'_id':ObjectId(" + '"' + ID + '"' + ")}";
            collection_out.DeleteOne(filter);
            Context.Response.Write(js.Serialize("編號:" + ID + "\n" + DateTime.Now.ToString() + "刪除成功!"));
        }
        [WebMethod]
        public void PR_SearchToday(string search)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("PR");
            var collection_out = database.GetCollection<PR>("PR");

            var list = new List<PR>();
            if (search == "")
            {
                list = collection_out.Find(x => x.Date.Contains(DateTime.Now.ToString("yyyy-MM-dd"))).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.Date))
                    .Select(s => new PR
                    {
                        Date = s.Date.Replace(" ", "<br>"),
                        Staff = s.Staff,
                        Reason = s.Reason
                    })
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

                list = collection_out.Find(x => x.Date.Contains(startDateofWeek.ToString("yyyy-MM-dd"))
                                           || x.Date.Contains(startDateofWeek.AddDays(1).ToString("yyyy-MM-dd"))
                                           || x.Date.Contains(startDateofWeek.AddDays(2).ToString("yyyy-MM-dd"))
                                           || x.Date.Contains(startDateofWeek.AddDays(3).ToString("yyyy-MM-dd"))
                                           || x.Date.Contains(startDateofWeek.AddDays(4).ToString("yyyy-MM-dd"))
                                           || x.Date.Contains(startDateofWeek.AddDays(5).ToString("yyyy-MM-dd"))
                                           || x.Date.Contains(startDateofWeek.AddDays(6).ToString("yyyy-MM-dd"))
                                           ).ToList()
                    .OrderBy(x => Convert.ToDateTime(x.Date))
                    .Select(s => new PR
                    {
                        Date = s.Date.Replace(" ", "<br>"),
                        Staff = s.Staff,
                        Reason = s.Reason
                    })
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
        private DateTime GetWeekStartDate(int year, int week)
        {
            DateTime jan1 = new DateTime(year, 1, 1);//從1月開始計算
            int day = (int)jan1.DayOfWeek - 1;
            int delta = (day < 4 ? -day : 7 - day) + 7 * (week - 1);

            return jan1.AddDays(delta);
        }
    }
}
