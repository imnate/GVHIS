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
    public class PR
    {
        [BsonElementAttribute("_id")]
        public ObjectId _id { get; set; }
        public string strId { get; set; }
        public string Date { get; set; }
        public string Staff { get; set; }
        public string Reason { get; set; }
        public string Create_time { get; set; }
    }
}