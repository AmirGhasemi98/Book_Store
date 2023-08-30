using Book_Store.Application.Features.BookImages.Requests.Queries;
using Book_Store.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Areas.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    //[Authorize(Roles = "Adminstrator")]
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

            var contentType = image.ContentType();

            return File(image, contentType, image.FileName());
        }

    }
}
