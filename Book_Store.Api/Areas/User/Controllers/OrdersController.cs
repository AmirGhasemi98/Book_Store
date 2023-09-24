using Book_Store.Application.DTOs.Order;
using Book_Store.Application.Features.Orders.Requests.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace Book_Store.Api.Areas.User.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("User")]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        
        [HttpGet]
        public async Task<IActionResult> AddBookToOrder(AddBookToOrderDto addBookToOrder)
        {
            if (User.Identity.IsAuthenticated)
            {
                    //var command = new AddBookToOpenOrderCommand {  AddBookToOrder= addBookToOrder,UserId=User.Get };

                return Ok("hi");
            }
            else
            {
                return BadRequest("ابتدا باید وارد سایت شوید");
            }
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
