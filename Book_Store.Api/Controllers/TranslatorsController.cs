using Book_Store.Application.Features.Translators.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TranslatorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var translators = await _mediator.Send(new GetTranslatorListRequest());
            return Ok(translators);
        }
    }
}
