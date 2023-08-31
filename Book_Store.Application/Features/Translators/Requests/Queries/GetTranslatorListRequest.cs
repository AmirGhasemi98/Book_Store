using Book_Store.Application.DTOs.Translator;
using MediatR;

namespace Book_Store.Application.Features.Translators.Requests.Queries
{
    public class GetTranslatorListRequest : IRequest<List<TranslatorDto>>
    {
    }
}
