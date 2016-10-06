using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace StatefulValuesService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private const string DATAFILE = @"data/datafile.csv";

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
            WriteValue(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private string[] ReadValues()
        {
            IMongoCollection<BsonDocument> collection = GetMongoCollection();
            return collection.Find(x => true).ToList().Select(x => x.GetValue("value").ToString()).ToArray();
        }

        private void WriteValue(string value)
        {
            var options = new InsertOneOptions();
            options.BypassDocumentValidation = false;

            IMongoCollection<BsonDocument> collection = GetMongoCollection();
            collection.InsertOne(new BsonDocument("value", value), options);
        }

        private IMongoCollection<BsonDocument> GetMongoCollection()
        {
            var client = new MongoClient("mongodb://db:27017");
            return client.GetDatabase("values").GetCollection<BsonDocument>("default");
        }
    }
}
