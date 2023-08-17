using AutoMapper;
using Book_Store.Application.DTOs.Publisher.Validators;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
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
            #region Validation

            var validator = new CreatePublisherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreatePublisherDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion

            var publisher = _mapper.Map<Publisher>(request.CreatePublisherDto);
            publisher = await _publisherRepository.Add(publisher);
            return publisher.Id;
        }
    }
}
