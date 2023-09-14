using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.Role;
using Book_Store.Application.Features.Roles.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Roles.Handlers.Queries
{
    internal class GetRolesListRequestHandler : IRequestHandler<GetRolesListRequest, List<RoleDto>>
    {
        private readonly IRoleManagerRepository _roleManagerRepository;
        private readonly IMapper _mapper;

        public GetRolesListRequestHandler(IRoleManagerRepository roleManagerRepository, IMapper mapper)
        {
            _roleManagerRepository = roleManagerRepository;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> Handle(GetRolesListRequest request, CancellationToken cancellationToken)
        {
            var roles = await _roleManagerRepository.GetList();
            return _mapper.Map<List<RoleDto>>(roles);
        }
    }
}
