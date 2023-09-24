using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Features.Publishers.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Store.Api.Areas.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    //[Authorize(Roles = "Adminstrator")]
    public class PublisherController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PublisherController(IMediator mediator)
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

        // GET api/<PublisherController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PublisherDto>> Get(int id)
        {
            var publisher = await _mediator.Send(new GetPublisherDetailRequest { Id = id });
            return Ok(publisher);
        }

        // POST api/<PublisherController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreatePublisherDto publisher)
        {
            var command = new CreatePublisherCommand { CreatePublisherDto = publisher };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdatePublisherDto publisher)
        {
            var command = new UpdatePublisherCommand { UpdatePublisherDto = publisher, };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // DELETE api/<PublisherController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeletePublisherCommand { Id = id };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }
    }
}
