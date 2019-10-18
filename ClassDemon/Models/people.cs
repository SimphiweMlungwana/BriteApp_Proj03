using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace ClassDemon.Models
{
    public class people
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("Person")]
        public string Person { get; set; }

        [BsonElement("Region")]
        public string Region { get; set; }
    }
}