using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.User;
using Book_Store.Application.Features.Users.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Commands
{
    public class GetUsersListRequestHandler : IRequestHandler<GetUsersListRequest, List<UserDto>>
    {
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IMapper _mapper;

        public GetUsersListRequestHandler(IUserManagerRepository userManagerRepository, IMapper mapper)
        {
            _userManagerRepository = userManagerRepository;
            _mapper = mapper;
        }

        public async Task<List<UserDto>> Handle(GetUsersListRequest request, CancellationToken cancellationToken)
        {
            var users = await _userManagerRepository.GetList();
            return _mapper.Map<List<UserDto>>(users);
        }
    }
}
