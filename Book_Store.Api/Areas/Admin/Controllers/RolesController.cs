using Book_Store.Application.DTOs.Role;
using Book_Store.Application.Features.Roles.Requests.Commands;
using Book_Store.Application.Features.Roles.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Store.Api.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<RolesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var roles = await _mediator.Send(new GetRolesListRequest());
            return Ok(roles);
        }

        // GET api/<RolesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var role = await _mediator.Send(new GetRoleDetaileRequest { Id = id });
            return Ok(role);
        }

        // POST api/<RolesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateRoleDto createRole)
        {
            var command = new CreateRoleCommand { CreateRoleDto = createRole };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // PUT api/<RolesController>/5
        [HttpPut]
        public async Task<IActionResult> Put(UpdateRoleDto updateRole)
        {
            var command = new UpdateRoleCommnd { UpdateRoleDto = updateRole };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);

        }

        // DELETE api/<RolesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteRoleCommand { Id = id };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }
    }
}
