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
    public class Announcement_table
    {
        [BsonElementAttribute("_id")]
        public ObjectId id { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public int Increment { get; set; }
    }
}