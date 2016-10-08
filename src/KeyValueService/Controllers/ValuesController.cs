using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DesertCodeCamp.DockerNetCore.KeyValueService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private const string ValuesDataFile = @"_Data/values.dat";
        private static IDictionary<string, string> _values;
        private static object _syncLock = new object();

        // GET api/values
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            IEnumerable<KeyValuePair<string, string>> retVal;
            
            Console.WriteLine("Fetching values from flate file ({0})", ValuesDataFile);
            retVal = GetValues().ToArray();
            Console.WriteLine("Successfully fetched values from flate file ({0})", ValuesDataFile);

            return retVal;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var values = GetValues();
            if (values.ContainsKey(id))
                return Ok(values[id]);
             
             return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> v)
        {
            var values = GetValues();
            if (values.ContainsKey(v.Key))
            {
                values[v.Key] = v.Value;
                Write(v);
            }
            else
            {
                values.Add(v.Key, v.Value);
                Write(values);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var values = GetValues();
            
            if (values.ContainsKey(id)){
                values.Remove(id);
            }

            Write(values);
        }

        private IDictionary<string, string> GetValues()
        {
            if (_values == null) {
                lock (_syncLock)
                {
                    if (_values == null) {
                        _values = 
                            System.IO.File.ReadAllLines(ValuesDataFile)
                                .Where(x => x != "")
                                .Select(s => s.Split('\t'))
                                .ToDictionary(kv => kv[0], kv => kv[1]);
                    }
                }
            }

            return _values;
        }



        private void Write(IDictionary<string, string> values)
        {
            lock (_syncLock)
            {
                System.IO.File.WriteAllText(ValuesDataFile, "");                
            }

            foreach (KeyValuePair<string, string> value in values)
            {
                Write(value);
            }
        }

        private void Write(KeyValuePair<string, string> v)
        {
            lock (_syncLock)
            {
                System.IO.File.AppendAllText(ValuesDataFile, string.Join("\t", new string[] {v.Key, v.Value}) + "\r\n");
            }
        }
    }
}
