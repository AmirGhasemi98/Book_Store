using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.Role;
using Book_Store.Application.DTOs.Role.Validators;
using Book_Store.Application.DTOs.Translator.Validators;
using Book_Store.Application.Features.Roles.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Book_Store.Application.Features.Roles.Handlers.Commands
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, BaseCommandResponse>
    {
        private readonly IRoleManagerRepository _roleManagerRepository;
        private readonly IMapper _mapper;

        public CreateRoleCommandHandler(IRoleManagerRepository roleManagerRepository, IMapper mapper)
        {
            _roleManagerRepository = roleManagerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateRoleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateRoleDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var role = _mapper.Map<IdentityRole<int>>(request.CreateRoleDto);
            var result = await _roleManagerRepository.Create(role);

            if (!result.Item2)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = result.Item1;

                return response;
            }

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";

            return response;
        }
    }
}
