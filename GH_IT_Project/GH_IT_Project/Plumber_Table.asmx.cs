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
using System.Threading;
using System.Threading.Tasks;

namespace GH_IT_Project
{
    /// <summary>
    ///Plumber_Table 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Plumber_Table : System.Web.Services.WebService
    {

        [WebMethod]
        public void Plumber_Table_insert(string dmpgp,string plumber_reporter,string plumber_reporter_phone,string dmpip,string plumber_local,string remark)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime DT = DateTime.Now;
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = HttpContext.Current.Request.UserHostName;
            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<BsonDocument>("plumber_table");//my class also can use <T> = <BsonDocument>
            var insert_str = new BsonDocument
                {
                    {"Unit" , dmpgp },
                    {"reporter" , plumber_reporter},
                    {"phone" , plumber_reporter_phone},
                    {"fix_item" , dmpip},
                    {"location" , plumber_local},
                    {"remark" , remark},
                    {"time" , DT.ToString()},
                    {"status" , "尚未受理"},
                    {"PC_user" , userName},
                    {"PC_ip" , HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"]},
                    {"Acceptance","尚未確認" }
                    //HttpContext.Current.Request.LogonUserIdentity.Name
                };
            try
            {
               
                collection_out.InsertOneAsync(insert_str);
                Context.Response.Write(js.Serialize(DT.ToString()));
                
            }
            catch (Exception e)
            {
                Context.Response.Write(js.Serialize("例外: "+ e));
            }
           


        }
    }
}
