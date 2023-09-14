using Book_Store.Application.DTOs.Role;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Roles.Requests.Commands
{
    public class UpdateRoleCommnd : IRequest<BaseCommandResponse>
    {
        public UpdateRoleDto UpdateRoleDto { get; set; }
    }
}
