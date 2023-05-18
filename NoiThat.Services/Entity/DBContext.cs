using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.Services.Entity
{
    public class DBContext
    {
        IConfiguration Configuration;

        public DBContext(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public IMongoDatabase Connection
        {
            get
            {
                var client = new MongoClient(Configuration.GetConnectionString("ConnectionString"));
                var database = client.GetDatabase(Configuration.GetConnectionString("DatabaseName"));
                return database;
            }
        }

        public IMongoCollection<Category> Category => Connection.GetCollection<Category>("Category");
        public IMongoCollection<Product> Product => Connection.GetCollection<Product>("Product");
    }
}
