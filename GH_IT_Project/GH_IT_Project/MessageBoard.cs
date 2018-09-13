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
    class MessageBoard
    {
        [BsonElementAttribute("_id")]
        public ObjectId id { get; set; }
        public string strId { get; set; }
        public string commenter {get; set; }
        public string phone { get; set; }
        public string message { get; set; }
        public string insert_date { get; set; }
        public string feedback { get; set; }
        public int Increment { get; set; }
    }
}
