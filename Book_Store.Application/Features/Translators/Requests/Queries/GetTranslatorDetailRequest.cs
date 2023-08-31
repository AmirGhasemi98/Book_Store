using Book_Store.Application.DTOs.Translator;
using MediatR;

namespace Book_Store.Application.Features.Translators.Requests.Queries
{
    public class GetTranslatorDetailRequest : IRequest<TranslatorDto>
    {
        public int Id { get; set; }
    }
}
