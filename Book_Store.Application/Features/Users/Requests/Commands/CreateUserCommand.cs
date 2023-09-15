using Book_Store.Application.DTOs.User;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
