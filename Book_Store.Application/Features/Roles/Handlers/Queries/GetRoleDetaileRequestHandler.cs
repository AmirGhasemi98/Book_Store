using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.Role;
using Book_Store.Application.Features.Roles.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Roles.Handlers.Queries
{
    public class GetRoleDetaileRequestHandler : IRequestHandler<GetRoleDetaileRequest, RoleDto>
    {
        private readonly IRoleManagerRepository _roleManagerRepository;
        private readonly IMapper _mapper;

        public GetRoleDetaileRequestHandler(IRoleManagerRepository roleManagerRepository, IMapper mapper)
        {
            _roleManagerRepository = roleManagerRepository;
            _mapper = mapper;
        }

        public async Task<RoleDto> Handle(GetRoleDetaileRequest request, CancellationToken cancellationToken)
        {
            var role =await _roleManagerRepository.Get(request.Id);
            return _mapper.Map<RoleDto>(role);
        }
    }
}
