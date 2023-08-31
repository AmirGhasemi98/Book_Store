using FluentValidation;

namespace Book_Store.Application.DTOs.Translator.Validators
{
    public class UpdateTranslatorDtoValidator : AbstractValidator<UpdateTranslatorDto>
    {
        public UpdateTranslatorDtoValidator()
        {
            Include(new ITranslatorDtoValidator());

            RuleFor(t => t.Id).NotEmpty().NotNull().GreaterThan(0).WithMessage("شناسه نمی تواند خالی باشد.");
        }
    }
}
