using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class Category:BaseEntity
    {

        public string Code { get; set; }
        public string CategoryName { get; set; }
        public byte Status { get;set; } 
    }
}
