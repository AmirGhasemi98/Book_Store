using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.BookMapTranslator.Validators
{
    public class CreateBookTranslatorDtoValidator : AbstractValidator<CreateBookTranslatorDto>
    {
        private readonly ITranslatorRepository _translatorRepository;

        public CreateBookTranslatorDtoValidator(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;

            RuleForEach(x => x.TranslatorIds).NotNull().GreaterThan(0)
               .MustAsync(async (id, token) =>
               {
                   var translatorExist = await _translatorRepository.Exist(id);
                   return translatorExist;
               }).WithMessage("مترجم با شناسه {PropertyValue} یافت نشد.");
        }
    }
}
