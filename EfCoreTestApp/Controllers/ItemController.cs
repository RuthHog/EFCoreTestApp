using EfCoreTestApp.Models;
using EfCoreTestApp.Respitory;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EfCoreTestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemRespitory _respitory;

        public ItemController(IItemRespitory respitory)
        {
            _respitory = respitory;
        }
        // GET: api/<ItemController>
        [HttpGet("Parent", Name = "Parent")]
        public async Task<IEnumerable<Item>?> GetParent()
        {
            return await _respitory.GetAllParents();
        }

        // GET api/<ItemController>/5
        [HttpGet("{id}")]
        public async Task<Item?> Get(string id)
        {
            return await _respitory.GetParent(id);
        }

        // POST api/<ItemController>
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromBody] string data)
        {
            var item = new Item();
            item.Data = data;
            item.ItemNo = Guid.NewGuid().ToString();

            return await _respitory.AddItem(item);

        }

        [HttpPost("Child", Name = "Child")]
        public async Task<ActionResult<int>> PostChild([FromBody] string data, string parentId)
        {

            var item = new Item();
            item.Data = data;
            item.ItemNo = Guid.NewGuid().ToString();

            var parent = await _respitory.GetParent(parentId);
            parent.Children.Add(item);

            return await _respitory.AddItem(item);

        }

        // PUT api/<ItemController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ItemController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
