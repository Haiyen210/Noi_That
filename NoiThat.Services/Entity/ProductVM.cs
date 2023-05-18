using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class ProductVM
    {
        public string Code { get; set; }
        public string? ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal? Price { get; set; }
        public decimal? SalePrice { get; set; }
        public string? Image { get; set; }
        public string? Description { get; set; }
        public byte Status { get; set; }
    }
}
