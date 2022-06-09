namespace DemoMongoDBProject.API.Model.Interfaces
{
    public interface IMongoDBSettings
    {
         string ConnectionString { get; set; }
         string DatabaseName { get; set; }
        string PersonCollectionName { get; set; }
    }
}
