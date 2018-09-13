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
    public class account_info
    {
        [BsonElementAttribute("_id")]
        public ObjectId _id { get; set; }
        public string account { get; set; }
        public string psw { get; set; }
        public string user { get; set; }
        public string authority { get; set; }
        public int Increment { get; set; }

    }

}
