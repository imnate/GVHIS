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
    ///IT_table_viewer 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class IT_table_viewer : System.Web.Services.WebService
    {
        [WebMethod]
        public void IT_table(string search)
        {

            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var database = MDBC.MongoDB("IT_table");
            var collection_out = database.GetCollection<IT_table>("IT_table");

            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            var out_result = new List<IT_table>();

            int page_no = 1;

            if (!string.IsNullOrEmpty(search))//搜尋
            {
                if (int_start >= int_length)
                {
                    page_no = (int_start / int_length) + 1;
                }

                var list = new List<IT_table>();
                list = collection_out.Find(x => x.reporter.Contains(search) || x.unit.Contains(search)).ToList();
                out_result = list.OrderByDescending(x => Convert.ToDateTime(x.date))
                         .Skip((page_no - 1) * int_length)
                         .Take(int_length)
                         .Select(x => new IT_table
                         {
                             unit = x.unit,
                             reporter = x.reporter,
                             report_item = x.report_item,
                             remark = x.remark,
                             date = x.date,
                             status = x.status,
                             strid = x.id.ToString()
                         }).ToList();
                var result = new
                {
                    draw = 1,
                    iTotalRecords = collection_out.Find(x => x.reporter.Contains(search) || x.unit.Contains(search)).ToList().Count(),
                    iTotalDisplayRecords = list.Count(),
                    data = out_result
                };
                Context.Response.Write(js.Serialize(result));

            }
            else//沒搜尋的
            {
                if (int_start >= int_length)
                {
                    page_no = (int_start / int_length) + 1;
                }

                var list = new List<IT_table>();
                list = collection_out.Find(_ => true).ToList();
                out_result = list.OrderByDescending(x => Convert.ToDateTime(x.date)).Skip((page_no - 1) * int_length)
                          .Take(int_length)
                          .Select(x => new IT_table
                          {
                              id = x.id,
                              Increment = x.id.Increment,
                              unit = x.unit,
                              reporter = x.reporter,
                              report_item = x.report_item,
                              remark = x.remark,
                              date = x.date,
                              status = x.status,
                              strid = x.id.ToString()
                          })
                         .ToList();

                var result = new
                {
                    draw = 1,
                    data = out_result,
                    iTotalRecords = list.Count(),
                    iTotalDisplayRecords = list.Count(),

                };
                Context.Response.Write(js.Serialize(result));
            }
        }
        [WebMethod]
        public void IT_table_Search(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("IT_table");
            var collection_out = database.GetCollection<IT_table>("IT_table");
            var filter_id = Builders<IT_table>.Filter.Eq("id", ObjectId.Parse(ID));
            var list = new List<IT_table>();
            list = collection_out.Find(filter_id).ToList()
                .Select(s => new IT_table
                {
                    id = s.id,
                    phone = s.phone,
                    strid = s.id.ToString(),
                    Increment = s.id.Increment,
                    unit = s.unit,
                    reporter = s.reporter,
                    report_item = s.report_item,
                    remark = s.remark,
                    date = s.date,
                    status = s.status,
                    username = s.username,
                    IP = s.IP

                })
                
                .ToList();


            Context.Response.Write(js.Serialize(list));

        }
        [WebMethod]
        public void IT_update(string ID, string update_status)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("IT_table");
            var collection_out = database.GetCollection<IT_table>("IT_table");
           
            string filter = "{'_id':ObjectId(" + '"' + ID + '"' + ")}";
            string update_para = "{$set:{'status':'" + update_status + "'}}";
            collection_out.UpdateOne(filter, update_para);
            Context.Response.Write(js.Serialize("asmx ID" + ID + "  status" + update_status));
        }
        [WebMethod]
        public void IT_Delete(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("IT_table");
            var collection_out = database.GetCollection<IT_table>("IT_table");
            var list = new List<IT_table>();
            string filter = "{'_id':ObjectId(" + '"' + ID + '"' + ")}";
            collection_out.DeleteOne(filter);
            Context.Response.Write(js.Serialize(""));
        }
    }
}
