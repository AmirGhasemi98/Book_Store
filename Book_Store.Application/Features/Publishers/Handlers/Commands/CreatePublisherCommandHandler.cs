using AutoMapper;
using Book_Store.Application.DTOs.Publisher.Validators;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;
using MediatR;
using Book_Store.Application.Responses;

namespace Book_Store.Application.Features.Publishers.Handlers.Commands
{
    public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, BaseCommandResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public CreatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePublisherCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreatePublisherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreatePublisherDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var publisher = _mapper.Map<Publisher>(request.CreatePublisherDto);
            publisher = await _publisherRepository.Add(publisher);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = publisher.Id;

            return response;
        }
    }
}
