using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace StatefulValuesService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private const string DATAFILE = @"datafile.csv";

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return ReadValues();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
            var values = ReadValues().ToList();
            values.Add(value);
            WriteValues(values.ToArray());
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string[] ReadValues()
        {
            CheckFile();
            string data = System.IO.File.ReadAllText(DATAFILE);
            if (string.IsNullOrEmpty(data)) return new string[0];
            
            return data.Split(',');
        }

        private void WriteValues(string[] values)
        {
            System.IO.File.WriteAllText(DATAFILE, string.Join(",", values));
        }

        private void CheckFile()
        {
            if (!(System.IO.File.Exists(DATAFILE))) System.IO.File.Create(DATAFILE).Dispose();
        }
    }
}
