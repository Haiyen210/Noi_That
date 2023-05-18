using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class Order:BaseEntity
    {
        public string Code { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        public string AccountId { get; set; }
    }
}
