using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        //static List<Student> strings = new List<Student>()
        //{
        //    new Student(1,"Rimjhim","Red"), new Student(2,"Rakesh","Blue"), new Student(3,"Akash","Orange")
        //};

        static List<String> strings = new List<String>()
            {
                "Rimjhim","Akash","Raghav"
            };

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<String>> Get()
        {
            return strings;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
