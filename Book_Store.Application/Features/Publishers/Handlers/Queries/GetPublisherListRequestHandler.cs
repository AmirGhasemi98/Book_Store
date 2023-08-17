using AutoMapper;
using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.Features.Publishers.Requests.Queries;
using Book_Store.Application.Contracts.Persistence;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Handlers.Queries
{
    public class GetPublisherListRequestHandler : IRequestHandler<GetPublisherListRequest, List<PublisherDto>>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublisherListRequestHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<List<PublisherDto>> Handle(GetPublisherListRequest request, CancellationToken cancellationToken)
        {
            var publisherList = await _publisherRepository.GetAll();
            return _mapper.Map<List<PublisherDto>>(publisherList);
        }
    }
}
