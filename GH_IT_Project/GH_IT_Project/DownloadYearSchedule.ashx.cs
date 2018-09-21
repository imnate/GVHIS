using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GH_IT_Project
{
    /// <summary>
    /// DownloadYearSchedule 的摘要描述
    /// </summary>
    public class DownloadYearSchedule : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}