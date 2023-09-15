using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.Features.Users.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Commands
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, BaseCommandResponse>
    {
        private readonly IUserManagerRepository _userManagerRepository;

        public DeleteUserCommandHandler(IUserManagerRepository userManagerRepository)
        {
            _userManagerRepository = userManagerRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var user = await _userManagerRepository.Get(request.Id);

            if (user is null)
            {
                response.Success = false;
                response.Message = "کاربر یافت نشد.";
                response.Errors.Add("کاربر یافت نشد.");

                return response;
            }

            var result = await _userManagerRepository.Delete(user);

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
        }
    }
}
