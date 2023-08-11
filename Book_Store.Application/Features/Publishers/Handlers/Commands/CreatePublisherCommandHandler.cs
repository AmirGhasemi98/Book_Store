using AutoMapper;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Handlers.Commands
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, int>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public CreatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = _mapper.Map<Publisher>(request.PublisherDto);
            publisher = await _publisherRepository.Add(publisher);
            return publisher.Id;
        }
    }
}
