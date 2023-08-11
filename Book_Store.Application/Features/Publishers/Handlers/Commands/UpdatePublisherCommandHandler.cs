using AutoMapper;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Handlers.Commands
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, Unit>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var publisher = await _publisherRepository.Get(request.PublisherDto.Id);
            _mapper.Map(request.PublisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return Unit.Value;
        }
    }
}
