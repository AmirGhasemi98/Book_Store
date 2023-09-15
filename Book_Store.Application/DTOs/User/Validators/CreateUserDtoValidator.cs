using FluentValidation;

namespace Book_Store.Application.DTOs.User.Validators
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {
            Include(new IUserDtoValidator());
        }
    }
}
