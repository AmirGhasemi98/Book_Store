using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Roles.Requests.Commands
{
    public class DeleteRoleCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
