using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ToDoAppController : ControllerBase
    {
        private static List<string> _todos = new List<string>();

        // GET api/todo
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_todos);
        }

        // POST api/todo
        [HttpPost]
        public ActionResult Post([FromBody] string todo)
        {
            _todos.Add(todo);
            return Ok();
        }

        // DELETE api/todo/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= _todos.Count)
            {
                return BadRequest("Invalid todo ID");
            }
            _todos.RemoveAt(id);
            return Ok();
        }
    }
}
