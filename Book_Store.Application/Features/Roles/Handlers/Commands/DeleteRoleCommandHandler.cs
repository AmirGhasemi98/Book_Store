using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.Features.Roles.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Roles.Handlers.Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleCommand, BaseCommandResponse>
    {
        private readonly IRoleManagerRepository _roleManagerRepository;

        public DeleteRoleCommandHandler(IRoleManagerRepository roleManagerRepository)
        {
            _roleManagerRepository = roleManagerRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var role = await _roleManagerRepository.Get(request.Id);

            if (role is null)
            {
                response.Success = false;
                response.Message = "نقش یافت نشد.";
                response.Errors.Add("نقش یافت نشد.");

                return response;
            }

            await _roleManagerRepository.Delete(role);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = role.Id;

            return response;
        }
    }
}
