using API.Controllers;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;

namespace NoiThat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class CategoryController : ControllerBase
    {
        ICategoryServices _categoryServices;
        private readonly ILogger<RoleController> _logger;
        public CategoryController(ICategoryServices categoryServices, ILogger<RoleController> logger)
        {
            _categoryServices = categoryServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryServices.GetAll();

            return Ok(categories);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryServices.GetById(id);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Category category)
        {
            BsonObjectId bsonId = ObjectId.GenerateNewId();
            category._id = ObjectId.Parse(bsonId.AsObjectId.ToString()).ToString();
            category.CreatedDate = DateTime.Now;
            await _categoryServices.Add(category);

            return CreatedAtAction(nameof(Get), new { id = category._id }, category);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Category category)
        {
            category.ModifiedDate = DateTime.Now;
            await _categoryServices.Update(category._id, category);

            return CreatedAtAction(nameof(Get), category);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _categoryServices.Remove(id);

            return Ok();
        }
    }
}
