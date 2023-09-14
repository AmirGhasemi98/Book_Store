using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.Role.Validators;
using Book_Store.Application.DTOs.Translator.Validators;
using Book_Store.Application.Features.Roles.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Roles.Handlers.Commands
{
    public class UpdateRoleCommndHandler : IRequestHandler<UpdateRoleCommnd, BaseCommandResponse>
    {
        private readonly IRoleManagerRepository _roleManagerRepository;
        private readonly IMapper _mapper;

        public UpdateRoleCommndHandler(IRoleManagerRepository roleManagerRepository, IMapper mapper)
        {
            _roleManagerRepository = roleManagerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateRoleCommnd request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdateRoleDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateRoleDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var role = await _roleManagerRepository.Get(request.UpdateRoleDto.Id);

            if (role is null)
            {
                response.Success = false;
                response.Message = "نقش یافت نشد.";
                response.Errors.Add("نقش یافت نشد.");

                return response;
            }

            _mapper.Map(request.UpdateRoleDto, role);
            await _roleManagerRepository.Update(role);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = role.Id;

            return response;
        }
    }
}
