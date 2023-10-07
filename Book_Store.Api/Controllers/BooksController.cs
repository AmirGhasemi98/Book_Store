using Book_Store.Application.Features.BookImages.Requests.Queries;
using Book_Store.Application.Features.Books.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] GetBookListByTypeRequest Request)
        {
            var books = await _mediator.Send(Request);
            return Ok(books);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _mediator.Send(new GetBookDetailRequest { Id = id });
            return Ok(book);
        }


        [HttpGet("GetImage/{id}")]
        public async Task<IActionResult> GetImage(int id)
        {
            var image = await _mediator.Send(new GetBookImageRequest { BookId = id });

            return File(image.File, image.ContentType, image.FileName);
        }
    }
}
