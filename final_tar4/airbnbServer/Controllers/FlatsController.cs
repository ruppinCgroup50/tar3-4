using Microsoft.AspNetCore.Mvc;
using tar2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        // GET: api/<FlatsController>
        [HttpGet]
        public IEnumerable<Flat> Get()
        {
            Flat f = new Flat();
            return f.Read();
        }

        //[HttpGet("q")]
        //public IEnumerable<Flat> GetByCityAndPrice(string city, double price)
        //{
        //    Flat f = new Flat();
        //    return f.ReadByCityAndPrice(city, price);
        //}

        // GET api/<FlatsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlatsController>
        [HttpPost]
        public int Post([FromBody] Flat flat)
        {
            return flat.Insert();
        }

        // POST api/<FlatsController>
        //[HttpPost]
        //public bool Post([FromBody] Flat f)
        //{
        //    return f.Insert();
        //}

        // PUT api/<FlatsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlatsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Flat flat = new Flat();
            flat.Delete(id);
            return Ok(id);
        }
    }
}
