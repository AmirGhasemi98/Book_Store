using Book_Store.Application.DTOs.Role;
using MediatR;

namespace Book_Store.Application.Features.Roles.Requests.Queries
{
    public class GetRolesListRequest : IRequest<List<RoleDto>>
    {
    }
}
