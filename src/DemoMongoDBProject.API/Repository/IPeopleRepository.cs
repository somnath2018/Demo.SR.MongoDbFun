using DemoMongoDBProject.API.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DemoMongoDBProject.API.Repository
{
    public interface IPeopleRepository
    {
         Task<IEnumerable<Person>> GetAll();

         Task<Person> GetById(string id);

        Task<Person> Create(Person person);

         Task Update(string id, Person personIn);

         Task Remove(Person personIn);

         Task RemoveById(string id);
    }
}
