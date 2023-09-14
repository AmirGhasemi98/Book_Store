using FluentValidation;

namespace Book_Store.Application.DTOs.Role.Validators
{
    public class UpdateRoleDtoValidator : AbstractValidator<UpdateRoleDto>
    {
        public UpdateRoleDtoValidator()
        {
            Include(new IRoleDtoValidator());
        }
    }
}
