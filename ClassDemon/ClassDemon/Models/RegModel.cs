using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassDemon.Models
{
    public class RegModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public string name { get; set; }
        public string surname { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("conf_password")]
        public string confPassword { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
    }
}