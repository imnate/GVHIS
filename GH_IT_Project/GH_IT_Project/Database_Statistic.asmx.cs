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
    ///Database_Statistic 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Database_Statistic : System.Web.Services.WebService
    {

        [WebMethod]
        public void GetDatabase_info()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<BsonDocument> List_Statistic = new List<BsonDocument>();
            List_Statistic.Add(stats("IT_table"));
            List_Statistic.Add(stats("plumber_table"));
            List_Statistic.Add(stats("Schedule_table"));
            List_Statistic.Add(stats("Announcement_table"));
            List_Statistic.Add(stats("admin_account_info"));
            Context.Response.Write(js.Serialize(List_Statistic.ToJson()));
        }
        private BsonDocument stats(string table_name)
        {
            MongoDB_connection MDBC = new MongoDB_connection();
            var database_St = MDBC.MongoDB(table_name);
            var command = new BsonDocumentCommand<BsonDocument>(new BsonDocument
            {
                { "dbStats", 1 }, { "scale", 1 }
            });      
            var result = database_St.RunCommand<BsonDocument>(command);
            return result;
        }

    }
}
