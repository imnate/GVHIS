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
    ///Plumber_table_viewer 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class Plumber_table_viewer : System.Web.Services.WebService
    {

        [WebMethod]
        public void Plumber_table(string search)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<plumber_table>("plumber_table");

            var length = HttpContext.Current.Request.QueryString["length"];
            var start = HttpContext.Current.Request.QueryString["start"];
            int int_length = Convert.ToInt32(length);
            int int_start = Convert.ToInt32(start);
            var out_result = new List<plumber_table>();

            int page_no = 1;

            if (!string.IsNullOrEmpty(search))//搜尋
            {
                if (int_start >= int_length)
                {
                    page_no = (int_start / int_length) + 1;
                }

                var list = new List<plumber_table>();
                list = collection_out.Find(x => x.reporter.Contains(search) || x.Unit.Contains(search)).ToList();
                out_result = list.OrderByDescending(x => Convert.ToDateTime(x.time)).Skip((page_no - 1) * int_length)
                         .Take(int_length)
                         .Select(x => new plumber_table
                         {
                             id = x.id,
                             strid = x.id.ToString(),
                             Unit = x.Unit,
                             reporter = x.reporter,
                             fix_item = x.fix_item,
                             location = x.location,
                             remark = x.remark,
                             time = x.time.Replace(" ", "<br>"),
                             status = x.status,
                             PC_user = x.PC_user,
                             PC_ip = x.PC_ip,
                             Acceptance = x.Acceptance

                         }).ToList();
                var result = new
                {
                    draw = 1,
                    iTotalRecords = collection_out.Find(x => x.reporter.Contains(search) || x.Unit.Contains(search) || x.fix_item.Contains(search)).ToList().Count(),
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

                var list = new List<plumber_table>();
                list = collection_out.Find(_ => true).ToList();
                out_result = list.OrderByDescending(x => Convert.ToDateTime(x.time)).Skip((page_no - 1) * int_length)
                          .Take(int_length)
                          .Select(x => new plumber_table
                          {
                              id = x.id,
                              strid = x.id.ToString(),
                              Unit = x.Unit,
                              reporter = x.reporter,
                              fix_item = x.fix_item,
                              location = x.location,
                              remark = x.remark,
                              time = x.time.Replace(" ", "<br>"),
                              status = x.status,
                              PC_user = x.PC_user,
                              PC_ip = x.PC_ip,
                              Acceptance = x.Acceptance

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
        public void Plumber_Search(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<plumber_table>("plumber_table");

            var filter_id = Builders<plumber_table>.Filter.Eq("id", ObjectId.Parse(ID));

            var list = new List<plumber_table>();
            // list = collection_out.Find(_ => true).ToList()
            list = collection_out.Find(filter_id).ToList()
                 .Select(s => new plumber_table
                 {
                     id = s.id,
                     Increment = s.id.Increment,
                     strid = s.id.ToString(),
                     Unit = s.Unit,
                     reporter = s.reporter,
                     fix_item = s.fix_item,
                     location = s.location,
                     remark = s.remark,
                     time = s.time,
                     status = s.status,
                     PC_user = s.PC_user,
                     PC_ip = s.PC_ip,
                     Acceptance = s.Acceptance
                 })
                .ToList();


            Context.Response.Write(js.Serialize(list));
        }
        [WebMethod]
        public void Plumber_update(string ID, string update_status, string remark)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<plumber_table>("plumber_table");
            string filter = "{'_id':ObjectId(" + '"' + ID + '"' + ")}";
            string update_para = "{$set:{'status':'" + update_status + "','remark':'" + remark + "'}}";
            collection_out.UpdateOne(filter, update_para);
            Context.Response.Write(js.Serialize("asmx ID" + ID + "  status" + update_status));
        }
        [WebMethod]
        public void Acceptance()
        {
            string user = HttpContext.Current.Request.QueryString["user"];
            string authority = HttpContext.Current.Request.QueryString["authority"];
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();

            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<plumber_table>("plumber_table");

            var list = new List<plumber_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new plumber_table
                {
                    id = s.id,
                    strid = s.id.ToString(),
                    //3Increment = s.id.Increment,
                    Unit = s.Unit,
                    reporter = s.reporter,
                    fix_item = s.fix_item,
                    location = s.location,
                    remark = s.remark,
                    time = s.time,
                    status = s.status,
                    PC_user = s.PC_user,
                    PC_ip = s.PC_ip,
                    Acceptance = s.Acceptance

                })
                .Where(x => x.Unit.Equals(user) && x.status.Equals("已修繕完畢") && x.Acceptance.Equals("尚未確認"))
                .ToList();
            var result = new
            {
                draw = 1,
                data = list,
                iTotalRecords = list.Count(),
                iTotalDisplayRecords = list.Count(),

            };
            Context.Response.Write(js.Serialize(result));

        }
        [WebMethod]
        public void Plumber_updateAcceptance(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<plumber_table>("plumber_table");
            var list = new List<plumber_table>();
            list = collection_out.Find(_ => true).ToList()
                .Select(s => new plumber_table
                {
                    id = s.id,
                    Increment = s.id.Increment,
                    Unit = s.Unit,
                    reporter = s.reporter,
                    fix_item = s.fix_item,
                    location = s.location,
                    remark = s.remark,
                    time = s.time,
                    status = s.status,
                    PC_user = s.PC_user,
                    PC_ip = s.PC_ip,
                    Acceptance = s.Acceptance
                })
                .Where(x => x.Increment.Equals(Convert.ToInt32(ID)))
                .ToList();
            string filter = "{'_id':ObjectId(" + '"' + list[0].id.ToString() + '"' + ")}";
            string update_para = "{$set:{'Acceptance':'已確認'}}";
            collection_out.UpdateOne(filter, update_para);

            Context.Response.Write(js.Serialize("asmx ID" + ID + "確認成功!"));
        }
        [WebMethod]
        public void Delete(string ID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            MongoDB_connection MDBC = new MongoDB_connection();
            var database = MDBC.MongoDB("plumber_table");
            var collection_out = database.GetCollection<plumber_table>("plumber_table");
            var list = new List<plumber_table>();
            string filter = "{'_id':ObjectId(" + '"' + ID + '"' + ")}";
            collection_out.DeleteOne(filter);
            Context.Response.Write(js.Serialize(""));
        }
    }
}
