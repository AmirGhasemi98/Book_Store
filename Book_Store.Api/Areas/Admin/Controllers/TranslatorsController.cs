using Book_Store.Application.DTOs.Translator;
using Book_Store.Application.Features.Translators.Requests.Commands;
using Book_Store.Application.Features.Translators.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Areas.Admin.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    //[Authorize(Roles = "Adminstrator")]
    public class TranslatorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TranslatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<TranslatorsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var translators = await _mediator.Send(new GetTranslatorListRequest());
            return Ok(translators);
        }

        // GET api/<TranslatorsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var translator = await _mediator.Send(new GetTranslatorDetailRequest { Id = id });
            return Ok(translator);
        }

        // POST api/<TranslatorsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTranslatorDto translator)
        {
            var command = new CreateTranslatorCommand { CreateTranslatorDto = translator };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // PUT api/<TranslatorsController>/5
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateTranslatorDto translator)
        {
            var command = new UpdateTranslatorCommand { UpdateTranslatorDto = translator };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // DELETE api/<TranslatorsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTranslatorCommand { Id = id };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }
    }
}
