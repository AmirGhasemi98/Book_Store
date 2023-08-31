using Book_Store.Application.DTOs.Translator;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Translators.Requests.Commands
{
    public class CreateTranslatorCommand : IRequest<BaseCommandResponse>
    {
        public CreateTranslatorDto CreateTranslatorDto { get; set; }
    }
}
