using Microsoft.AspNetCore.Mvc;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Service.Implementattions;
using Tapioca.HATEOAS;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class PersonsController : Controller
    {
        private IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        
        [HttpGet]        
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());
        }

        // GET api/persons/id
        [HttpGet("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        // POST api/persons
        [HttpPost]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post([FromBody]PersonVO person)
        {
            if (person == null) return NotFound();
            return new ObjectResult(_personService.Create(person));
        }

        // PUT api/pesons/id
        [HttpPut]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put([FromBody]PersonVO person)
        {
            if (person == null) return BadRequest();

            var updatedPerson = _personService.Update(person);

            if (updatedPerson == null) return BadRequest();

            return new ObjectResult(updatedPerson);
        }

        // DELETE api/persons/id
        [HttpDelete("{id}")]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Delete(int id)
        {
            _personService.Delete(id);
            return NoContent();
        }
    }
}
