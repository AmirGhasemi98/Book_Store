using Book_Store.Application.DTOs.User;
using MediatR;

namespace Book_Store.Application.Features.Users.Requests.Commands
{
    public class SyncUserCommand : IRequest<Unit>
    {
        public List<SyncUserDto> syncUserDtos { get; set; }
    }
}
