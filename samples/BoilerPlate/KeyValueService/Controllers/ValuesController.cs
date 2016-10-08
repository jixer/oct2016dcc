using System.Collections.Generic;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesertCodeCamp.DockerNetCore.KeyValueService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            //return new string[] { "value1", "value2" };
            return new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("1", "value1"),
                new KeyValuePair<string, string>("2", "value2")
            };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            if (id == "1") return "value1";
            else if (id == "2") return "value2";
            else return null;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
