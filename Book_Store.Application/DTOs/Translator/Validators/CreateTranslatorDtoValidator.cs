using FluentValidation;

namespace Book_Store.Application.DTOs.Translator.Validators
{
    public class CreateTranslatorDtoValidator : AbstractValidator<CreateTranslatorDto>
    {
        public CreateTranslatorDtoValidator()
        {
            Include(new ITranslatorDtoValidator());
        }
    }
}
