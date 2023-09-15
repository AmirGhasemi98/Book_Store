using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.Role;
using Book_Store.Application.DTOs.User;
using Book_Store.Application.Features.Users.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Queries
{
    public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDetailDto>
    {
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IMapper _mapper;

        public GetUserDetailRequestHandler(IUserManagerRepository userManagerRepository, IMapper mapper)
        {
            _userManagerRepository = userManagerRepository;
            _mapper = mapper;
        }

        public async Task<UserDetailDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManagerRepository.Get(request.Id);
            
            var map = _mapper.Map<UserDetailDto>(user);

            var roles = await _userManagerRepository.GetUserRoles(user);

            map.Roles = roles.Select(x => new RoleDto
            {
                Name = x.Name,
                Id = x.Id
            }).ToList();

            return map;
        }
    }
}
