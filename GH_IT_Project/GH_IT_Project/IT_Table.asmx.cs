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
    ///IT_Table 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class IT_Table : System.Web.Services.WebService
    {

        [WebMethod]
        public void IT_table_insert(string unit, string report_item, string reporter, string phone, string remark)
        {



            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime DT = DateTime.Now;
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = HttpContext.Current.Request.UserHostName;
            var database = MDBC.MongoDB("IT_table");
            var collection_out = database.GetCollection<BsonDocument>("IT_table");//my class also can use <T> = <BsonDocument>
            var insert_str = new BsonDocument
            {
                { "unit", unit },
                { "report_item",report_item },
                { "reporter",reporter },
                { "phone" , phone },
                { "remark" , remark },
                { "date" , DT.ToString() },
                { "status" , "尚未受理" },
                { "username", userName },//HttpContext.Current.User.Identity.Name.ToString(),
                { "IP" , HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] },//HttpContext.Current.Request.UserHostAddress.ToString(),
            };
            //var collection_out = database.GetCollection<IT_table>("IT_table");//my class also can use <T> = <BsonDocument>
            //var insert_str = new IT_table
            //{
            //    unit = unit,
            //    report_item = report_item,
            //    reporter = reporter,
            //    phone = phone,
            //    remark = remark,
            //    date = DT.ToString(),
            //    status = "尚未受理",
            //    username = userName,//HttpContext.Current.User.Identity.Name.ToString(),
            //    IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"],//HttpContext.Current.Request.UserHostAddress.ToString(),
            //};
            try
            {
                collection_out.InsertOne(insert_str);
                Context.Response.Write(js.Serialize(DT.ToString()));
            }
            catch (Exception e)
            {
                Context.Response.Write(js.Serialize("例外:" + e));
            }

        }
    }
}
