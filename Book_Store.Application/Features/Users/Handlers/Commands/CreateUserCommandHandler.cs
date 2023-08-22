using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Users.Requests.Commands;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, string>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request.CreateUserDto);
            user = await _userRepository.Add(user);
            return user.Id;
        }
    }
}
