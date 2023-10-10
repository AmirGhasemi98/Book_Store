using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.Features.Publishers.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublishersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PublisherController>
        [HttpGet]
        public async Task<ActionResult<PublisherDto>> Get()
        {
            var publishers = await _mediator.Send(new GetPublisherListRequest());
            return Ok(publishers);
        }
    }
}
