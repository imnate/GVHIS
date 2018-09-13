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
    public class IT_table
    {
        [BsonElementAttribute("_id")]
        public ObjectId id { get; set; }
        public string unit { get; set; }
        public string report_item { get; set; }
        public string reporter { get; set; }
        public string phone { get; set; }
        public string remark { get; set; }
        public string date { get; set; }
        public string status { get; set; }
        public string username { get; set; }
        public string IP { get; set; }
        public int Increment { get; set; }
        public string strid { get; set; }

    }
}