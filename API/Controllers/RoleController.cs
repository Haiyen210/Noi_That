using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using NoiThat.Services.Entity;
using NoiThat.Services.Interface;
using System.Data;

namespace NoiThat.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Consumes("application/json")]
    public class RoleController : ControllerBase
    {
        IRoleServices _roleServices;
        private readonly ILogger<RoleController> _logger;
        public RoleController(IRoleServices roleServices, ILogger<RoleController> logger)
        {
            _roleServices = roleServices;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _roleServices.GetAll();

            return Ok(roles);
        }

        [HttpGet]
        [Route("getById")]
        public async Task<IActionResult> GetById(string id)
        {
            var role = await _roleServices.GetById(id);
            return Ok(role);
        }


        [HttpPost]
        public async Task<IActionResult> Post(Role role)
        {
            BsonObjectId bsonId = ObjectId.GenerateNewId();
            role._id = ObjectId.Parse(bsonId.AsObjectId.ToString()).ToString();
            role.CreatedDate = DateTime.Now;
            await _roleServices.Add(role);

            return CreatedAtAction(nameof(Get), new { id = role._id }, role);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, Role role)
        {
            role.ModifiedDate = DateTime.Now;
            await _roleServices.Update(id, role);

            return CreatedAtAction(nameof(Get), role);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            await _roleServices.Remove(id);

            return Ok();
        }
    }
}
