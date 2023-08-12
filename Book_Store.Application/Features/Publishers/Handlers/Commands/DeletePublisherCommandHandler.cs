using AutoMapper;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Handlers.Commands
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public DeletePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.Get(request.Id);
            await _publisherRepository.Delete(publisher);
            return Unit.Value;
        }
    }
}
