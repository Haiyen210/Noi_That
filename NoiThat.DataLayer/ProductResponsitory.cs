using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoiThat.DataLayer
{
    public class ProductResponsitory : BaseRepository<Product>, IProductResponsitory
    {
        private readonly IMongoCollection<Product> product;
        private readonly IMongoCollection<Category> category;
        public ProductResponsitory(IOptions<InteriorDatabaseSettings> interiorDataSettings) : base(interiorDataSettings)
        {
            var mongoClient = new MongoClient(
          interiorDataSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(
                interiorDataSettings.Value.DatabaseName);
            product = db.GetCollection<Product>("Product");
            category = db.GetCollection<Category>("Category");
        }

        public List<Product> GetProduct()
        {
            var result = (from p in product.AsQueryable()
                          join c in category.AsQueryable()
                          on p.CategoryId equals c._id
                          select new Product
                          {
                              Code = p.Code,
                              ProductName = p.ProductName,
                              CategoryName = c.CategoryName,
                              Description = p.Description,
                              Image = p.Image,
                              Price = p.Price,
                              SalePrice = p.SalePrice,
                              CategoryId = p.CategoryId,

                          }).ToList();

            return result;
        }
    }
}
