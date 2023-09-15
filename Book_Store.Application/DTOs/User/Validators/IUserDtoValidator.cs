using FluentValidation;

namespace Book_Store.Application.DTOs.User.Validators
{
    public class IUserDtoValidator : AbstractValidator<IUserDto>
    {
        public IUserDtoValidator()
        {
            RuleFor(u => u.FirstName).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
               .NotNull().MaximumLength(50).WithMessage("نام نمی تواند بیشتر از 50 کاراکتر باشد.");

            RuleFor(u => u.LastName).NotEmpty().WithMessage("نام خانوادگی نمی تواند خالی باشد.")
                .NotNull().MaximumLength(100).WithMessage("نام خانوادگی نمی تواند بیشتر از 100 کاراکتر باشد.");

            RuleFor(u => u.UserName).NotEmpty().WithMessage(" نام کاربری نمی تواند خالی باشد.")
               .NotNull().MinimumLength(6).WithMessage("نام کاربری نمی تواند کمتر از 6 کاراکتر باشد.")
               .MaximumLength(100).WithMessage("نام کاربری نمی تواند بیشتر از 100 کاراکتر باشد.");

            RuleFor(u => u.Email).NotEmpty().WithMessage("ایمیل نمی تواند خالی باشد.")
                .NotNull().EmailAddress().WithMessage("فرمت ایمیل صحیح نمی باشد.");
        }
    }
}
