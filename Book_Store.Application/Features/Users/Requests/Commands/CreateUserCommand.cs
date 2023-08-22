using Book_Store.Application.DTOs.User;
using MediatR;

namespace Book_Store.Application.Features.Users.Requests.Commands
{
    public class CreateUserCommand : IRequest<string>
    {
        public CreateUserDto CreateUserDto { get; set; }
    }
}
