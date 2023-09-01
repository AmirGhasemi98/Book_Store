using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.BookMapTranslator.Validators;
using Book_Store.Application.Features.BookMapTranslators.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.BookMapTranslators.Handlers.Commands
{
    public class CreateBookTranslatorCommandHandler : IRequestHandler<CreateBookTranslatorCommand, BaseCommandResponse>
    {
        private readonly IBookTranslatorsRepository _bookTranslatorsRepository;
        private readonly ITranslatorRepository _translatorRepository;

        public CreateBookTranslatorCommandHandler(IBookTranslatorsRepository bookTranslatorsRepository, ITranslatorRepository translatorRepository)
        {
            _bookTranslatorsRepository = bookTranslatorsRepository;
            _translatorRepository = translatorRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookTranslatorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateBookTranslatorDtoValidator(_translatorRepository);
            var validationResult = await validator.ValidateAsync(request.CreateBookTranslatorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            if (request.CreateBookTranslatorDto.ForUpdate)
                await _bookTranslatorsRepository.DeleteBookTranslators(request.CreateBookTranslatorDto.BookId);

            var bookTranslators = new List<BookMapTranslator>();
            request.CreateBookTranslatorDto.TranslatorIds.ForEach(x => bookTranslators.Add(new BookMapTranslator { TransLatorId = x, BookId = request.CreateBookTranslatorDto.BookId }));
            await _bookTranslatorsRepository.AddRange(bookTranslators);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";

            return response;
        }
    }
}
