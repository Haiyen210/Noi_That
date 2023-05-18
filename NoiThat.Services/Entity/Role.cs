using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class Role:BaseEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }

    }
}
