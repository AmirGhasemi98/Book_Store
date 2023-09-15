using AutoMapper;
using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.DTOs.User.Validators;
using Book_Store.Application.Features.Users.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Users.Handlers.Commands
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, BaseCommandResponse>
    {
        private readonly IUserManagerRepository _userManagerRepository;
        private readonly IRoleManagerRepository _roleManagerRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserManagerRepository userManagerRepository, IRoleManagerRepository roleManagerRepository, IMapper mapper)
        {
            _userManagerRepository = userManagerRepository;
            _roleManagerRepository = roleManagerRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdateUserDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateUserDTO);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var user = await _userManagerRepository.Get(request.UpdateUserDTO.Id);

            if (user is null)
            {
                response.Success = false;
                response.Message = "کاربر یافت نشد.";
                response.Errors.Add("کاربر یافت نشد.");

                return response;
            }

            _mapper.Map(request.UpdateUserDTO, user);

            var roles = await _roleManagerRepository.GetList(request.UpdateUserDTO.RoleIds);

            if (request.UpdateUserDTO.RoleIds.Except(roles.Select(x => x.Id)).Any())
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = new List<string> { "نقش های وارد شده معتبر نمی باشند." };

                return response;
            }

            var result = await _userManagerRepository.Edit(user, roles, request.UpdateUserDTO.Password);

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
