using FluentValidation;

namespace Book_Store.Application.DTOs.Author.Validators
{
    public class IAuthorDtoValidator : AbstractValidator<IAuthorDto>
    {
        public IAuthorDtoValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
                .NotNull().MaximumLength(50).WithMessage("نام نمی تواند بیشتر از 50 کاراکتر باشد.");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("نام خانوادگی نمی تواند خالی باشد.")
                .NotNull().MaximumLength(50).WithMessage("نام خانوادگی نمی تواند بیشتر از 50 کاراکتر باشد.");

            RuleFor(a => a.BirthDate).LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-50));
                
        }
    }
}
