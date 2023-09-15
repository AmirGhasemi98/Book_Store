using FluentValidation;

namespace Book_Store.Application.DTOs.User.Validators
{
    internal class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            Include(new IUserDtoValidator());
        }
    }
}
