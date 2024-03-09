using Microsoft.AspNetCore.Mvc;
using tar2.BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace tar2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class vacationsController : ControllerBase
    {
        // GET: api/<vacationsController>
        [HttpGet]
        public IEnumerable<Vacation> Get()
        {
            Vacation v = new Vacation();
            return v.Read();
        }

        // GET api/<VacationsController>/
        [HttpGet("email/{email}")]
        public IEnumerable<Vacation> GetByEmail(string email)
        {
            Vacation vacation = new Vacation();

            return vacation.ReadByUserEmail(email);
        }

        [HttpGet("averagePrice")]
        public object GetAvgPriceByCityAndMonth(int month)
        {
            DBservices dbs = new DBservices();

            List<object> avgPrices = dbs.ReadAvgPricePerNight(month);

            return avgPrices;
        }

        //[HttpGet("getByDates/startDate/{startDate}/endDate/{endDate}")]
        //public IEnumerable<Vacation> GetByDates(DateTime startDate, DateTime endDate)
        //{
        //    Vacation v = new Vacation();
        //    return v.ReadByDates(startDate, endDate);
        //}

        // GET api/<vacationsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<vacationsController>
        //[HttpPost]
        //public bool Post([FromBody] Vacation v)
        //{
        //    return v.Insert();
        //}

        // POST api/<vacationsController>
        [HttpPost]
        public int Post([FromBody] Vacation vacation)
        {
            return vacation.Insert();
        }

        // PUT api/<vacationsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<vacationsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Vacation vacation = new Vacation();
            vacation.Delete(id);
            return Ok(id);
        }
    }
}
