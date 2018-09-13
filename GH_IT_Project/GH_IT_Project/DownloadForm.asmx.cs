using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Web.UI;

namespace GH_IT_Project
{
    /// <summary>
    ///DownloadForm 的摘要描述
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下列一行。
    [System.Web.Script.Services.ScriptService]
    public class DownloadForm : System.Web.Services.WebService
    {
        [WebMethod]
        public void Download(List<string> list)
        {

            HttpContext.Current.Response.AppendHeader("content-disposition", "attachment;filename=FileEName.xls");
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Write(list[0]);
            HttpContext.Current.Response.End();
          

        }
    }
}
