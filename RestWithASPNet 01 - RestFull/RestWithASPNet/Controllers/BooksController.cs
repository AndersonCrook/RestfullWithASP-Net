﻿using Microsoft.AspNetCore.Mvc;
using RestWithASPNet.Data.VO;
using RestWithASPNet.Model;
using RestWithASPNet.Service.Implementattions;

namespace RestWithASPNet.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class BooksController : Controller
    {
        private IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET api/persons
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookService.FindAll());
        }

        // GET api/persons/id
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var book = _bookService.FindById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        // POST api/persons
        [HttpPost]
        public IActionResult Post([FromBody]BookVO book)
        {
            if (book == null) return NotFound();
            return new ObjectResult(_bookService.Create(book));
        }

        // PUT api/pesons/id
        [HttpPut]
        public IActionResult Put([FromBody]BookVO book)
        {
            if (book == null) return BadRequest();

            var updatedbook = _bookService.Update(book);

            if (updatedbook == null) return BadRequest();

            return new ObjectResult(updatedbook);
        }

        // DELETE api/persons/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.Delete(id);
            return NoContent();
        }
    }
}
