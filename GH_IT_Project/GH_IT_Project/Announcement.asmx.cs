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

namespace GH_IT_Project
{
    /// <summary>
    ///Announcement 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Announcement : System.Web.Services.WebService
    {

        [WebMethod]
        public void New_Info(string Title, string Info)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime DT = DateTime.Now;
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = HttpContext.Current.Request.UserHostName;
            var database = MDBC.MongoDB("Announcement_table");
            var collection_out = database.GetCollection<BsonDocument>("Announcement_table");//my class also can use <T> = <BsonDocument>
            var insert_str = new BsonDocument
                {
                    {"Date" , DT.ToString() },
                    {"Title" , Title},
                    {"Info" , Info},
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
        public void Get_Info()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Announcement_table");
            var collection_out = database.GetCollection<Announcement_table>("Announcement_table");

            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            var out_result = new List<Announcement_table>();

            int page_no = 1;


            if (int_start >= int_length)
            {
                page_no = (int_start / int_length) + 1;
            }

            var list = new List<Announcement_table>();
            list = collection_out.Find(_ => true).ToList();
            out_result = list
                         .OrderByDescending(x => Convert.ToDateTime(x.Date))
                         .Skip((page_no - 1) * int_length)
                         .Take(int_length)
                         .Select(x => new Announcement_table
                         {
                             id = x.id,
                             Date = x.Date.Replace(" ", "<br/>"),
                             Title = "[" + new DateTime(1970, 1, 1).AddSeconds(x.id.Timestamp).ToString("MM-dd") + "] " + x.Title,
                             Info = x.Info,
                             Increment = x.id.Increment,

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
        public void SearchById(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("Announcement_table");
            var collection_out = database.GetCollection<Announcement_table>("Announcement_table");

            var list = new List<Announcement_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new Announcement_table
                {
                    id = s.id,
                    Title = s.Title,
                    Info = s.Info,
                    Increment = s.id.Increment,

                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();


            Context.Response.Write(js.Serialize(list));

        }
        [WebMethod]
        public void delete(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("Announcement_table");
            var collection_out = database.GetCollection<Announcement_table>("Announcement_table");
            var list = new List<Announcement_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new Announcement_table
                {
                    id = s.id,
                    Title = "[" + new DateTime(1970, 1, 1).AddSeconds(s.id.Timestamp).ToString("MM-dd") + "] " + s.Title,
                    Info = s.Info,
                    Increment = s.id.Increment,
                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();
            string filter = "{'_id':ObjectId(" + '"' + list[0].id.ToString() + '"' + ")}";
            collection_out.DeleteOne(filter);
            Context.Response.Write(js.Serialize(list[0].Title));
        }
    }
}
