using Book_Store.Application.DTOs.Order;
using Book_Store.Application.Features.Orders.Requests.Commands;
using Book_Store.Application.Features.Orders.Requests.Queries;
using Book_Store.Infrastructure.Controller;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Api.Areas.User.Controllers
{
    [Route("api/[Area]/[controller]")]
    [ApiController]
    [Area("User")]
    public class OrdersController : BaseApiController
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddBookToOrder(AddBookToOrderDto addBookToOrder)
        {
            if (User.Identity.IsAuthenticated)
            {
                var test = UserId;

                var command = new AddBookToOpenOrderCommand { AddBookToOrder = addBookToOrder, UserId = UserId };
                var response = await _mediator.Send(command);

                return Ok("کتاب مورد نظر با موفقیت ثبت شد.");
            }
            else
            {
                return BadRequest("ابتدا باید وارد سایت شوید");
            }
        }


        [HttpGet("ChangeDetailCount")]
        public async Task<IActionResult> ChangeDetailCount([FromQuery] OrderDetailCountDto detailCountDto)
        {
            if (User.Identity.IsAuthenticated)
            {
                var command = new ChangeOrderDetailCountCommand { DetailCountDto = detailCountDto, UserId = UserId };
                var response = await _mediator.Send(command);

                return Ok();
            }
            else
            {
                return BadRequest("ابتدا باید وارد سایت شوید");
            }
        }


        [HttpGet("RemoveBookFromOrder")]
        public async Task<IActionResult> RemoveBookFromOrder(int detailId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var command = new RemoveOrderDetailCommand { detailId = detailId, UserId = UserId };
                var response = await _mediator.Send(command);

                if (!response.Success)
                    return BadRequest(response.Errors);

                return Ok(response);
            }
            else
            {
                return BadRequest("ابتدا باید وارد سایت شوید");
            }
        }

        [HttpGet("UserOpenOrder")]
        public async Task<IActionResult> UserOpenOrder()
        {
            var order = await _mediator.Send(new GetUserOpenOrderDetailRequest { UserId = UserId });
            return Ok(order);
        }

    }
}
