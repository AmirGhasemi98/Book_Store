﻿using Book_Store.Application.Features.Books.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Areas.User.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("User")]
    public class HomeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }



        // GET: api/<HomeController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<HomeController>/5
        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int? categoryId)
        {
            var books = await _mediator.Send(new GetBookListByCategoryRequest { CategoryId = categoryId });
            return Ok(books);
        }

        // POST api/<HomeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<HomeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<HomeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
