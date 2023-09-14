using FluentValidation;

namespace Book_Store.Application.DTOs.Role.Validators
{
    public class CreateRoleDtoValidator : AbstractValidator<CreateRoleDto>
    {
        public CreateRoleDtoValidator()
        {
            Include(new IRoleDtoValidator());
        }
    }
}
