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
    ///FeedBackMsgNum 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class FeedBackMsgNum : System.Web.Services.WebService
    {

        [WebMethod]
        public void FeedBackMsg()
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("MessageBoard");
            var collection = database.GetCollection<MessageBoard>("MessageBoard");
            var list = new List<MessageBoard>();
            list = collection.Find(x => x.feedback.Length == 0).ToList();
            //string DelMonth = DateTime.Now.AddMonths(-2).ToString("yyyy/M");
            DelHistoryMsg();
            Context.Response.Write(js.Serialize(list.Count));
        }
        private void DelHistoryMsg()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("MessageBoard");
            var collection = database.GetCollection<MessageBoard>("MessageBoard");
            var list = new List<MessageBoard>();
            //先取用系統日期 再來扣掉兩格月去搜尋資料庫
            string DelMonth = DateTime.Now.AddMonths(-2).ToString("yyyy/M");
            list = collection.Find(x => x.insert_date.Contains(DelMonth)).ToList()
                    .Select(x => new MessageBoard
                    {
                        id = x.id,
                    }).ToList();
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    string filter = "{'_id':ObjectId(" + '"' + list[i].id.ToString() + '"' + ")}";
                    collection.DeleteOne(filter);
                }
            }
        }

    }
}
