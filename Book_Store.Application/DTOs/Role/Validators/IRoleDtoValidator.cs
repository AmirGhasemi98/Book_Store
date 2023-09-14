using FluentValidation;

namespace Book_Store.Application.DTOs.Role.Validators
{
    public class IRoleDtoValidator : AbstractValidator<IRoleDto>
    {
        public IRoleDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("نام نمی تواند خالی باشد.");
        }
    }
}
