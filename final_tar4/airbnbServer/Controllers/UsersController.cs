using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using tar2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            User user = new User();
            return user.Read();
        }

        // GET api/<UsersController>/5
        [HttpGet("{email}")]
        public string Get(string email)
        {
            return "value";
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            DBservices dbs = new DBservices();
            User res=dbs.LoginUser(user);
            if (res!=null)
                return Ok(res);
            return NotFound();
        }

        // POST api/<UsersController>
        [HttpPost]
        public int Post([FromBody] User user)
        {
            return user.Insert();
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public int Put([FromBody] User user)
        {
            return user.Update(user.Email);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{email}")]
        public IActionResult Delete(string email)
        {
            User user = new User();
            user.Delete(email);
            return Ok(email);
        }
    }
}
