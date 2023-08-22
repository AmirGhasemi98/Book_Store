using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Users.Requests.Commands;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Commands
{
    public class SyncUserCommandHandler : IRequestHandler<SyncUserCommand, Unit>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public SyncUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(SyncUserCommand request, CancellationToken cancellationToken)
        {
            var users = await _userRepository.GetList();

            foreach (var item in users)
            {
                item.UserName = request.syncUserDtos.FirstOrDefault(u => u.UserId == item.Id)?.UserName;
            }

            _userRepository.UpdateRange(users);

            return Unit.Value;
        }
    }
}
