using Book_Store.Application.DTOs.User;
using Book_Store.Application.Features.Users.Requests.Commands;
using Book_Store.Application.Features.Users.Requests.Queries;
using Book_Store.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_Store.Api.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _mediator.Send(new GetUsersListRequest());
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailDto>> Get(int id)
        {
            var users = await _mediator.Send(new GetUserDetailRequest { Id = id });
            return Ok(users);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse>> Post([FromBody] CreateUserDto createUser)
        {
            var command = new CreateUserCommand { CreateUserDto = createUser };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserDto updateUser)
        {
            var command = new UpdateUserCommand { UpdateUserDTO = updateUser };
            var response = await _mediator.Send(command);

            if (!response.Success)
                return BadRequest(response.Errors);

            return Ok(response);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
