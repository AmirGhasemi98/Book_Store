using Book_Store.Application.Enums.Books;
using Book_Store.Application.Features.BookImages.Requests.Queries;
using Book_Store.Application.Features.Books.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Areas.User.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("User")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList(int? id, GetBooksType? type)
        {
            var books = await _mediator.Send(new GetBookListByTypeRequest { Id = id, Type = type });
            return Ok(books);
        }

        [HttpGet("GetImage/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _mediator.Send(new GetBookImageRequest { BookId = id });

            return File(image.File, image.ContentType, image.FileName);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
