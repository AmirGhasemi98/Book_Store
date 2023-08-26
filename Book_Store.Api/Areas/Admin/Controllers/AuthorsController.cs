using Book_Store.Application.DTOs.Author;
using Book_Store.Application.Features.Authors.Requests.Commands;
using Book_Store.Application.Features.Authors.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Areas.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    //[Authorize(Roles = "Adminstrator")]
    public class AuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<AuthorsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var authors = await _mediator.Send(new GetAuthorListRequest());
            return Ok(authors);
        }

        // GET api/<AuthorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _mediator.Send(new GetAuthorDetailRequest { Id = id });
            return Ok(author);
        }

        // POST api/<AuthorsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateAuthorDto author)
        {
            var command = new CreateAuthorCommand { CreateAuthorDto = author };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // PUT api/<AuthorsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateAuthorDto author)
        {
            var command = new UpdateAuthorCommand { UpdateAuthorDto = author };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // DELETE api/<AuthorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAuthorCommand { Id = id };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }
    }
}
