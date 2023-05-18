using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class Account:BaseEntity
    {
        public string Code { get; set; }
        public string Fullname { get; set; }
        public bool Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Password { get;set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string RoleId { get; set; }
    }
}
