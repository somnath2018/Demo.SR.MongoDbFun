using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DemoMongoDBProject.API.Model
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("age")]
        public int Age { get; set; }

        [BsonElement("phoneNumbers")]
        public List<string> PhoneNumbers { get; set; }
    }
}
