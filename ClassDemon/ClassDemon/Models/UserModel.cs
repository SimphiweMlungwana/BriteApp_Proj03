using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Bson;

namespace ClassDemon.Models
{
    public class UserModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
        [BsonElement("email")]
        public string email { get; set; }
        [BsonElement("password")]
        public string password { get; set; }
        [BsonElement("con_Password")]
        public string conPassword { get; set; }
    }
}