using Microsoft.AspNetCore.Mvc;
using RESTteacher.Managers;
using RESTteacher.Models;

namespace RESTteacher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly TeacherManager manager = new TeacherManager();

        // GET: api/<TeachersController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<Teacher> Get(string? name = null, int? minSalary = null, string? orderBy = null)
        {
            return manager.GetAll(name, minSalary, orderBy);
        }

        // GET api/<TeachersController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Teacher> Get(int id)
        {
            Teacher? teacher = manager.GetById(id);
            if (teacher == null) return NotFound();
            return Ok(teacher);
        }

        // POST api/<TeachersController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public ActionResult<Teacher> Post([FromBody] TeacherDTO value)
        {
            try
            {
                Teacher t = new Teacher(value);
                Teacher teacher = manager.Add(t);
                string uri = Url.RouteUrl(RouteData.Values) + "/" + teacher.Id;
                return Created(uri, teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*
        // PUT api/<TeachersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }
        */

        // DELETE api/<TeachersController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Teacher> Delete(int id)
        {
            Teacher? teacher = manager.Remove(id);
            if (teacher == null) return NotFound();
            return Ok();
        }
    }
}
