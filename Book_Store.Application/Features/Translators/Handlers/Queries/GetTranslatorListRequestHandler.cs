using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Translator;
using Book_Store.Application.Features.Translators.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Translators.Handlers.Queries
{
    public class GetTranslatorListRequestHandler : IRequestHandler<GetTranslatorListRequest, List<TranslatorDto>>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public GetTranslatorListRequestHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<List<TranslatorDto>> Handle(GetTranslatorListRequest request, CancellationToken cancellationToken)
        {
            var translatorList = await _translatorRepository.GetAll();
            return _mapper.Map<List<TranslatorDto>>(translatorList);
        }
    }
}
