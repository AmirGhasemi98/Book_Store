using Book_Store.Application.DTOs.Translator;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Translators.Requests.Commands
{
    public class UpdateTranslatorCommand : IRequest<BaseCommandResponse>
    {
        public UpdateTranslatorDto UpdateTranslatorDto { get; set; }
    }
}
