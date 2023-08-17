using AutoMapper;
using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.Features.Publishers.Requests.Queries;
using Book_Store.Application.Contracts.Persistence;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Handlers.Queries
{
    public class GetPublisherDetailRequestHandler : IRequestHandler<GetPublisherDetailRequest, PublisherDto>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public GetPublisherDetailRequestHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<PublisherDto> Handle(GetPublisherDetailRequest request, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.Get(request.Id);
            return _mapper.Map<PublisherDto>(publisher);
        }
    }
}
