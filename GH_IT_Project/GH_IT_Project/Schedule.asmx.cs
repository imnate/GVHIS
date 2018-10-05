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
    ///Schedule 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Schedule : System.Web.Services.WebService
    {
        [WebMethod]
        public void Schedule_table_insert(string S_time, string S_end_time, string Work_item, string Local, string S_host, string Participants, string Duty)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            DateTime DT = DateTime.Now;
            
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = HttpContext.Current.Request.UserHostName;
            var database = MDBC.MongoDB("Schedule_table");
            var collection_out = database.GetCollection<BsonDocument>("Schedule_table");//my class also can use <T> = <BsonDocument>
            var insert_str = new BsonDocument
            {
            
                     {  "S_time", S_time },
                     {  "S_end_time", S_end_time },
                     {  "Local", Local},
                     {  "Work_item", Work_item },
                     {  "S_host", S_host },
                     {  "Participants", Participants },
                     {  "Duty", Duty },
                     {  "Status", "未審核" },
                     {  "Insert_time", DT.ToString() },
                     {  "Ip", HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"] },
             };
            try
            {
                //collection_out.InsertOneAsync(insert_str);
                output op = new output();
                List<output> List_out = new List<output>();
                collection_out.InsertOne(insert_str);
                string[] convert_Stime = S_time.Split(' ');
                string[] S_timeSplit = convert_Stime[0].Split('-');
                string[] yMD = DateTime.Now.ToString("yyyy-MM-dd").Split('-');
               
                DateTime DTS_time = new DateTime(Convert.ToInt32(S_timeSplit[0]), Convert.ToInt32(S_timeSplit[1]), Convert.ToInt32(S_timeSplit[2]));
                DateTime DTNow = new DateTime(Convert.ToInt32(yMD[0]), Convert.ToInt32(yMD[1]), Convert.ToInt32(yMD[2]));

                int Days = DTS_time.Subtract(DTNow).Days;

                if (Days <= 3)
                {
                    op.outcase = 1;
                    op.date = DT.ToString();
                    op.Days = Days;
                }
                else
                {
                    op.outcase = 2;
                    op.date = DT.ToString();
                    op.Days = Days;
                }
                List_out.Add(op);

                Context.Response.Write(js.Serialize(List_out));
                //Context.Response.Write(js.Serialize("行程時間:" + convert_Stime[0] + "現在時間:" + DateTime.Now.ToString("yyyy-MM-dd") + "間距日:"  + Days));
              
            }
            catch (Exception e)
            {
                Context.Response.Write(js.Serialize("例外:" + e));
            }
        }
        class output
        {
            public int outcase { get; set; }
            public string date { get; set; }
            public int Days { get; set; }
        }
    }
}
