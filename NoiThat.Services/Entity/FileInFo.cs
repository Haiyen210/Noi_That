using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class FileInFo
    {
        public string Name { get; set; }
        public IFormFile Url { get; set; }
    }
}
