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
    ///MsgBoard 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    // [System.Web.Script.Services.ScriptService]
    public class MsgBoard : System.Web.Services.WebService
    {

        [WebMethod]
        public void New_Message(string Commenter, string Phone, string Message)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime DT = DateTime.Now;
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = HttpContext.Current.Request.UserHostName;
            var database = MDBC.MongoDB("MessageBoard");
            var collection_out = database.GetCollection<BsonDocument>("MessageBoard");//my class also can use <T> = <BsonDocument>
            var insert_str = new BsonDocument
                {
                    {"commenter" , Commenter },
                    {"phone" , Phone},
                    {"message" , Message},
                    {"feedback","" },
                    {"insert_date",DT.ToString() },
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
        public void get_Message()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("MessageBoard");
            var collection_out = database.GetCollection<MessageBoard>("MessageBoard");

            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            var out_result = new List<MessageBoard>();

            int page_no = 1;


            if (int_start >= int_length)
            {
                page_no = (int_start / int_length) + 1;
            }

            var list = new List<MessageBoard>();
            list = collection_out.Find(_ => true).ToList();
            out_result = list
                         .OrderByDescending(x => Convert.ToDateTime(x.insert_date))
                         .Skip((page_no - 1) * int_length)
                         .Take(int_length)
                         .Select(x => new MessageBoard
                         {
                             id = x.id,
                             commenter = x.commenter,
                             insert_date = x.insert_date.Replace(" ", "<br/>"),
                             feedback = x.feedback,
                             Increment = x.id.Increment,
                             strId = x.id.ToString(),

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
        public void Msg_SearchByID(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("MessageBoard");
            var collection_out = database.GetCollection<MessageBoard>("MessageBoard");

            var filter_id = Builders<MessageBoard>.Filter.Eq("id", ObjectId.Parse(ID));

            var list = new List<MessageBoard>();
            list = collection_out.Find(filter_id).ToList()
                .Select(s => new MessageBoard
                {
                    strId = s.id.ToString(),
                    commenter = s.commenter,
                    insert_date = s.insert_date,
                    phone = s.phone,
                    message = s.message,
                    feedback = s.feedback,
                })
                .ToList();


            Context.Response.Write(js.Serialize(list));
        }
        [WebMethod]
        public void Msg_updateFeedback(string ID, string info)
        {
            DateTime DT = DateTime.Now;
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("MessageBoard");
            var collection_out = database.GetCollection<MessageBoard>("MessageBoard");
            string filter = "{'_id':ObjectId(" + '"' + ID + '"' + ")}";
            string update_para = "{$set:{'feedback':'" + info + "\r\n" +DT.ToString() + "'}}";
            collection_out.UpdateOne(filter, update_para);
            Context.Response.Write(js.Serialize("Feedback" + ID + ", " + info));


        }
    }
}
