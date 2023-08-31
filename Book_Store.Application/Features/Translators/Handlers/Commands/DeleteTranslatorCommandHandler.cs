using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Translators.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Translators.Handlers.Commands
{
    public class DeleteTranslatorCommandHandler : IRequestHandler<DeleteTranslatorCommand, BaseCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;

        public DeleteTranslatorCommandHandler(ITranslatorRepository translatorRepository)
        {
            _translatorRepository = translatorRepository;
        }

        public async Task<BaseCommandResponse> Handle(DeleteTranslatorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var author = await _translatorRepository.Get(request.Id);

            if (author is null)
            {
                response.Success = false;
                response.Message = "مترجم یافت نشد.";
                response.Errors.Add("مترجم یافت نشد.");

                return response;
            }

            await _translatorRepository.Delete(author);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = author.Id;

            return response;
        }
    }
}
