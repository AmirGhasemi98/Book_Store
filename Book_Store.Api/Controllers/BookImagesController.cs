using Book_Store.Application.Features.BookImages.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookImagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookImagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<BookImagesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var image = await _mediator.Send(new GetBookImageRequest { BookId = id });

            return File(image.File, image.ContentType, image.FileName);
        }
    }
}
