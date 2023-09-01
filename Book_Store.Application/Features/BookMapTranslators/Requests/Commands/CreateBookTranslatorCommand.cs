using Book_Store.Application.DTOs.BookMapTranslator;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.BookMapTranslators.Requests.Commands
{
    public class CreateBookTranslatorCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookTranslatorDto CreateBookTranslatorDto { get; set; }
    }
}
