using DemoMongoDBProject.API.Model;
using DemoMongoDBProject.API.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace DemoMongoDBProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IPeopleRepository _peopleRepository;
        public PeopleController(ILogger<PeopleController> logging,IPeopleRepository peopleRepository)
        {
           _peopleRepository = peopleRepository;
        }

        [HttpGet]

        [ProducesResponseType(typeof(IEnumerable<Person>), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async  Task<IActionResult> Get()
        {
            var people =  await _peopleRepository.GetAll();
            return people != null ? Ok(people) : NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.OK)]
        [Produces("application/json")]
        public async Task<IActionResult> Get(string id)
        {
            var people = await _peopleRepository.GetById(id);
            if (people == null)
            {
                return NotFound();
            }

            return Ok(people);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Person), (int)HttpStatusCode.Created)]
        [Produces("application/json")]
        public async Task<IActionResult> Post(Person newPerson)
        {
            await _peopleRepository.Create(newPerson);
            return CreatedAtAction(nameof(Get), new { id = newPerson.Id }, newPerson);
        }

        [HttpPut]
        public async Task<IActionResult> Put(Person updatePerson)
        {
            var people = await _peopleRepository.GetById(updatePerson.Id);
            if (people == null)
            {
                return NotFound();
            }

            await _peopleRepository.Update(updatePerson.Id,updatePerson);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var people = await _peopleRepository.GetById(id);
            if (people == null)
            {
                return NotFound();
            }

            await _peopleRepository.RemoveById(id);
            return NoContent();
        }

    }
}
