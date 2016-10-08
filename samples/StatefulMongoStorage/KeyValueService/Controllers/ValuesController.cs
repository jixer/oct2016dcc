using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DesertCodeCamp.DockerNetCore.KeyValueService.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IMongoCollection<BsonDocument> _mongoCollection = new MongoClient("mongodb://db:27017").GetDatabase("default").GetCollection<BsonDocument>("values");


        // GET api/values
        [HttpGet]
        public IEnumerable<KeyValuePair<string, string>> Get()
        {
            IEnumerable<KeyValuePair<string, string>> retVal;

            // implement logging
            retVal = Graft(_mongoCollection.Find(x => true).ToList());
            // implement logging
             
            return retVal;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = Graft(_mongoCollection.Find(Builders<BsonDocument>.Filter.Eq("_id", id)).ToList()).FirstOrDefault();
            
            if (result.Key == null)
                return NotFound();

            return Ok(result.Value);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] KeyValuePair<string, string> v)
        {
            BsonDocument doc = Graft(v);
            var filter = Builders<BsonDocument>.Filter.Eq("_id", v.Key);
            if (_mongoCollection.Count(filter) == 0)
                _mongoCollection.InsertOne(doc);
            else
                _mongoCollection.ReplaceOne(filter, doc);         
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _mongoCollection.DeleteOne(Builders<BsonDocument>.Filter.Eq("_id", id));
        }

        private IEnumerable<KeyValuePair<string, string>> Graft(IList<BsonDocument> bsonDocs)
        {
            return bsonDocs.ToDictionary(x => (string)x.GetElement("_id").Value, x => (string)x.GetElement("Value").Value).ToArray();
        }

        private BsonDocument Graft(KeyValuePair<string, string> v)
        {
            var elements = new Dictionary<string, string>
            {
                {"_id", v.Key},
                {"Value", v.Value}
            };

            return new BsonDocument(elements);
        }
    }
}
