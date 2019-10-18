using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassDemon.Models
{
    public class OrderModel
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("RowID")]
        public string RowID { get; set; }
        [BsonElement("OrderID")]
        public string OrderID { get; set; }
        [BsonElement("OrderDate")]
        public string OrderDate { get; set; }
        [BsonElement("ShipDate")]
        public string ShipDate { get; set; }
        [BsonElement("ShipMode")]
        public string ShipMode { get; set; }
        [BsonElement("CustomerID")]
        public string CustomerID { get; set; }
        [BsonElement("Segment")]
        public string Segment { get; set; }
        [BsonElement("PostalCode")]
        public string PostalCode { get; set; }
        [BsonElement("City")]
        public string City { get; set; }
        [BsonElement("State")]
        public string State { get; set; }
        [BsonElement("Country")]
        public string Country { get; set; }
        [BsonElement("Region")]
        public string Region { get; set; }
        [BsonElement("Market")]
        public string Market { get; set; }
        [BsonElement("ProductID")]
        public string ProductID { get; set; }
        [BsonElement("Category")]
        public string Category { get; set; }
        [BsonElement("SubCategory")]
        public string SubCategory { get; set; }
        [BsonElement("ProductName")]
        public string ProductName { get; set; }
        [BsonElement("Sales")]
        public string Sales { get; set; }
        [BsonElement("Quantity")]
        public string Quantity { get; set; }
        [BsonElement("Discount")]
        public string Discount { get; set; }
        [BsonElement("Profit")]
        public string Profit { get; set; }
        [BsonElement("ShippingCost")]
        public string ShippingCost { get; set; }
        [BsonElement("OrderPriority")]
        public string OrderPriority { get; set; }
    }
}