using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoiThat.Services.Entity;
using NoiThat.Services;
using NoiThat.Services.Interface;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace NoiThat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class ProductController : ControllerBase
    {
        IProductServices _iProductServices;
        IProductResponsitory _IProductResponsitory;
        private readonly ILogger<ProductController> _logger;
        private readonly IMongoCollection<Product> productContext;
        private readonly IMongoCollection<Category> categoryContext;
        public ProductController(IProductServices iProductServices, ILogger<ProductController> logger,
            IProductResponsitory IProductResponsitory, IOptions<InteriorDatabaseSettings> interiorDataSettings
            )
        {
            _iProductServices = iProductServices;
            _logger = logger;
            _IProductResponsitory = IProductResponsitory;
            var mongoClient = new MongoClient(
        interiorDataSettings.Value.ConnectionString);
            var db = mongoClient.GetDatabase(
                interiorDataSettings.Value.DatabaseName);
            productContext = db.GetCollection<Product>("Product");
            categoryContext = db.GetCollection<Category>("Category");
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _iProductServices.GetAll();

            return Ok(products);
        }


        [HttpGet]
        [Route("GetProduct")]
        public List<Product> GetProduct()
        {
            var product = _iProductServices.GetProducts();
            return product;
        }



        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _iProductServices.GetById(id);
            return Ok(product);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            BsonObjectId bsonId = ObjectId.GenerateNewId();
            product._id = ObjectId.Parse(bsonId.AsObjectId.ToString()).ToString();
            product.CreatedDate = DateTime.Now;
           var pro = await _iProductServices.Add(product);
            var result = (from p in productContext.AsQueryable()
                          join c in categoryContext.AsQueryable()
                          on p.CategoryId equals c._id
                          where p.CategoryId == pro.CategoryId
                          select new Product
                          {
                              _id = product._id,
                              Code = p.Code,
                              ProductName = p.ProductName,
                              CategoryName = c.CategoryName,
                              Description = p.Description,
                              Image = p.Image,
                              Price = p.Price,
                              SalePrice = p.SalePrice,
                              CategoryId = p.CategoryId,

                          }).FirstOrDefault();
           

            return CreatedAtAction(nameof(GetProduct), new { id = product._id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Product product)
        {
            product.ModifiedDate = DateTime.Now;
            await _iProductServices.Update(id, product);

            return CreatedAtAction(nameof(Get), product);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _iProductServices.Remove(id);

            return Ok();
        }
    }
}
