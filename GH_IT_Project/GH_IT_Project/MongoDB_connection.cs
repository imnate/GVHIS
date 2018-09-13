using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;

namespace GH_IT_Project
{
    public class MongoDB_connection
    {
        public IMongoDatabase MongoDB(string table)
        {
            //var client = new MongoClient("mongodb://localhost");//mongo port
            var client = new MongoClient("mongodb://127.0.0.1:27017");//mongo port
            var database = client.GetDatabase(table); //db table
            return database;
        }
    }
}