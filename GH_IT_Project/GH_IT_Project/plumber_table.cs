using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using MongoDB.Driver;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver.Linq;
using MongoDB;


namespace GH_IT_Project
{
    public class plumber_table
    {
        [BsonElementAttribute("_id")]
        public ObjectId id { get; set; }
        public string Unit { get; set; }
        public string reporter { get; set; }
        public string phone { get; set; }
        public string fix_item { get; set; }
        public string location { get; set; }
        public string remark { get; set; }
        public string time { get; set; }
        public string status { get; set; }
        public string PC_user { get; set; }
        public string PC_ip { get; set; }
        public int Increment { get; set; }
        public string strid { get; set; }
        public string Acceptance { get; set; }
    }
}