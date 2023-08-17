using AutoMapper;
using Book_Store.Application.DTOs.Publisher.Validators;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
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
            #region Validation

            var validator = new UpdatePublisherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdatePublisherDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion

            var publisher = await _publisherRepository.Get(request.UpdatePublisherDto.Id);
            _mapper.Map(request.UpdatePublisherDto, publisher);
            await _publisherRepository.Update(publisher);
            return Unit.Value;
        }
    }
}
