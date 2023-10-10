using Book_Store.Application.Features.Categories.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCategoryRequest());
            return Ok(result);
        }
    }
}
