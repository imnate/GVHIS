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
    ///Login_ajax 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Login_ajax : System.Web.Services.WebService
    {
        DateTime DT = DateTime.Now;
        [WebMethod]
        public void Login_admin(string account, string psw)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("admin_account_info");
            var collection_out = database.GetCollection<account_info>("admin_account_info");//my class also can use <T> = <BsonDocument>
            var out_result = new List<account_info>();

            var list = new List<account_info>();
            list = collection_out.Find(x => x.account.Equals(account) && x.psw.Equals(psw)).ToList();
            out_result = list.Select(x => new account_info
            {
                authority = x.authority,
                user = x.user
            }).ToList();

            if (list.Count() != 0 && list.Count() <= 1)
            {
                Context.Response.Write(js.Serialize(out_result));//這邊是C# object 轉 json format 
            }
            else
            {
                Context.Response.Write(js.Serialize(out_result));//這邊是C# object 轉 json format
            }

            /*測試輸出*/
            //List<string> result = new List<string>();      
            //for (int i = 0; i < list.Count(); i++)
            //{
            //    result.Add(list[i].account.ToString()+" "+list[i].psw.ToString());
            //}
            //Context.Response.Write(js1.Serialize(result));//這邊是C# object 轉 json format


            //新增
            //var accstr = new account_info { account = "admin_test", psw = "admin123456789", time = DT.ToString() };
            ////collection_out.InsertOneAsync(accstr);



        }
        [WebMethod]
        public void Read_all()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("admin_account_info");
            var collection_out = database.GetCollection<account_info>("admin_account_info");//my class also can use <T> = <BsonDocument>
            var out_result = new List<account_info>();
            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            int page_no = 1;
            var list = new List<account_info>();
            if (int_start >= int_length)
            {
                page_no = (int_start / int_length) + 1;
            }
            list = collection_out.Find(_ => true).ToList();
            out_result = list
                .Skip((page_no - 1) * int_length)
                .Take(int_length)
                .Select(x => new account_info
                {
                    account = x.account,
                    psw = x.psw,
                    authority = x.authority,
                    user = x.user,
                    Increment = x._id.Increment,

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
        public void Insert_account(string account, string psw, string authority, string user)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("admin_account_info");
            var collection_out = database.GetCollection<account_info>("admin_account_info");
            var list = new List<account_info>();
            list = collection_out.Find(x => x.account.Equals(account)).ToList();
            if (list.Count() == 0)//沒有重複
            {
                var insert_str = new BsonDocument
                {
                    {  "account", account },
                    {  "psw", psw },
                    {  "authority", authority},
                    {  "user", user },
                };
                try
                {
                    database.GetCollection<BsonDocument>("admin_account_info").InsertOne(insert_str);
                    Context.Response.Write(js.Serialize("帳號新增成功" + DT.ToString()));
                }
                catch (Exception e)
                {
                    Context.Response.Write(js.Serialize("例外:" + e));
                }
            }
            else
            {
                Context.Response.Write(js.Serialize("帳號重複"));
            }
        }

        [WebMethod]
        public void Authority_SearchById(string id)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("admin_account_info");
            var collection_out = database.GetCollection<account_info>("admin_account_info");

            var list = new List<account_info>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new account_info
                {
                    account = s.account,
                    psw = s.psw,
                    authority = Gruop(s.authority),
                    user = s.user,
                    Increment = s._id.Increment,
                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(id)))
                .ToList();


            Context.Response.Write(js.Serialize(list));
        }

        [WebMethod]
        public void Update(string ID,string psw)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("admin_account_info");
            var collection_out = database.GetCollection<account_info>("admin_account_info");
            var list = new List<account_info>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new account_info
                {
                    _id = s._id,
                    account = s.account,
                    psw = s.psw,
                    Increment = s._id.Increment
                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();
            string filter = "{'_id':ObjectId(" + '"' + list[0]._id.ToString() + '"' + ")}";
            string update_para = "{$set:{'psw':'" + psw + "'}}";
            collection_out.UpdateOne(filter, update_para);
            
            Context.Response.Write(js.Serialize(list[0].account + " 更新成功"));
        }
        [WebMethod]
        public void delete(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("admin_account_info");
            var collection_out = database.GetCollection<account_info>("admin_account_info");
            var list = new List<account_info>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new account_info
                {
                    _id = s._id,
                    account = s.account,
                    Increment = s._id.Increment
                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();
            string filter = "{'_id':ObjectId(" + '"' + list[0]._id.ToString() + '"' + ")}";
            collection_out.DeleteOne(filter);
            Context.Response.Write(js.Serialize(list[0].account));
        }


        private string Gruop(String authority)
        {
            switch (authority)
            {
                case "s":
                    return "超級管理者 [權限:" + authority + "]";
                case "1":
                    return "水電班 [權限:" + authority + "]";
                case "2":
                    return "秘書行程表管理 [權限:" + authority + "]";
                case "3":
                    return "資訊室 [" + authority + "]";
                case "4":
                    return "堂隊、各組室(水電驗收審核) [權限:" + authority + "]";
            }
            return "";
        }

    }
}
