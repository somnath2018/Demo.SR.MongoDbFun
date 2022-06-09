using DemoMongoDBProject.API.Model.Interfaces;

namespace DemoMongoDBProject.API.Model
{
    public class MongoDBSettings: IMongoDBSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string PersonCollectionName { get; set; }
    }
}
