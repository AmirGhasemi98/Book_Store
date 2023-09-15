using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Users.Requests.Commands
{
    public class DeleteUserCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
