using FluentValidation;

namespace Book_Store.Application.DTOs.Translator.Validators
{
    public class ITranslatorDtoValidator : AbstractValidator<ITranslatorDto>
    {
        public ITranslatorDtoValidator()
        {
            RuleFor(a => a.FirstName).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
               .NotNull().MaximumLength(50).WithMessage("نام نمی تواند بیشتر از 50 کاراکتر باشد.");

            RuleFor(a => a.LastName).NotEmpty().WithMessage("نام خانوادگی نمی تواند خالی باشد.")
                .NotNull().MaximumLength(100).WithMessage("نام خانوادگی نمی تواند بیشتر از 100 کاراکتر باشد.");
        }
    }
}
