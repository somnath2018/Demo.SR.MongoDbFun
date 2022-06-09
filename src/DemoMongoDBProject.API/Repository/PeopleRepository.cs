using DemoMongoDBProject.API.Model;
using DemoMongoDBProject.API.Model.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoMongoDBProject.API.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        private readonly IMongoCollection<Person> _people;
        public PeopleRepository(IMongoDBSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _people = database.GetCollection<Person>(settings.PersonCollectionName);
        }
        public async Task<Person> Create(Person person)
        {
            await _people.InsertOneAsync(person);
            return person;
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            var result = await _people.FindAsync(people => true);
            return await result.ToListAsync();
        }

        public async Task<Person> GetById(string id)
        {
            var task = await _people.FindAsync<Person>(person => person.Id == id);
            return await task.FirstOrDefaultAsync();
        }

        public async Task Remove(Person personIn) =>
           await _people.DeleteOneAsync(person => person.Id == personIn.Id);


        public async Task RemoveById(string id) =>
            await _people.DeleteOneAsync(person => person.Id == id);

        public async Task Update(string id, Person personIn) =>
               await _people.ReplaceOneAsync(person => person.Id == id, personIn);
    }
}
