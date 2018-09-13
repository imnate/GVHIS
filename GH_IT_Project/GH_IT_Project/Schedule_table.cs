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
    public class Schedule_table
    {
        [BsonElementAttribute("_id")]
        public ObjectId Id { get; set; }
        public string S_time { get; set; }
        public string S_end_time { get; set; }
        public string Work_item { get; set; }
        public string S_host { get; set; }
        public string Local { get; set; }
        public string Participants { get; set; }
        public string Duty { get; set; }
        public string Status { get; set; }
        public string Insert_time { get; set; }
        public string Ip { get; set; }
        public int Increment { get; set; }
    }

}