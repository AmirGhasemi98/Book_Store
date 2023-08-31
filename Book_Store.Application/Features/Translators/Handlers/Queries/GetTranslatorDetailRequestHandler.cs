using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Translator;
using Book_Store.Application.Features.Translators.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Translators.Handlers.Queries
{
    public class GetTranslatorDetailRequestHandler : IRequestHandler<GetTranslatorDetailRequest, TranslatorDto>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public GetTranslatorDetailRequestHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<TranslatorDto> Handle(GetTranslatorDetailRequest request, CancellationToken cancellationToken)
        {
            var translator = await _translatorRepository.Get(request.Id);
            return _mapper.Map<TranslatorDto>(translator);
        }
    }
}
