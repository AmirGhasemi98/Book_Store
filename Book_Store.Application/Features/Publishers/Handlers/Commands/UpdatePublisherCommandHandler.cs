using AutoMapper;
using Book_Store.Application.DTOs.Publisher.Validators;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using MediatR;
using Book_Store.Application.Responses;

namespace Book_Store.Application.Features.Publishers.Handlers.Commands
{
    public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, BaseCommandResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public UpdatePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdatePublisherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdatePublisherDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var publisher = await _publisherRepository.Get(request.UpdatePublisherDto.Id);

            if (publisher is null)
            {
                response.Success = false;
                response.Message = "انتشارات یافت نشد.";
                response.Errors.Add("انتشارات یافت نشد.");

                return response;
            }


            _mapper.Map(request.UpdatePublisherDto, publisher);
            await _publisherRepository.Update(publisher);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = publisher.Id;

            return response;
        }
    }
}
