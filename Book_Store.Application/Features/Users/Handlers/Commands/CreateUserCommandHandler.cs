using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.Features.Users.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Identity;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IRoleManagerRepository _roleManagerRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserManagerRepository userManagerRepository, IRoleManagerRepository roleManagerRepository, IMapper mapper)
        {
            _userManagerRepository = userManagerRepository;
            _roleManagerRepository = roleManagerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var user = _mapper.Map<ApplicationUser>(request.CreateUserDto);

            var roles = await _roleManagerRepository.GetList(request.CreateUserDto.RoleIds);

            var test = roles.ExceptBy(request.CreateUserDto.RoleIds, x => x.Id);

            var result = await _userManagerRepository.Add(user, roles, request.CreateUserDto.Password);

            if (result.Any())
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = result;

                return response;
            }

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";

            return response;

            throw new NotImplementedException();
        }
    }
}
