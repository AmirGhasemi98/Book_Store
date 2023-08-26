using AutoMapper;
using Book_Store.Application.Features.Publishers.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using MediatR;
using Book_Store.Application.Responses;

namespace Book_Store.Application.Features.Publishers.Handlers.Commands
{
    public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, BaseCommandResponse>
    {
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMapper _mapper;

        public DeletePublisherCommandHandler(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeletePublisherCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var publisher = await _publisherRepository.Get(request.Id);

            if (publisher is null)
            {
                response.Success = false;
                response.Message = "انتشارات یافت نشد.";
                response.Errors.Add("انتشارات یافت نشد.");
            }

            await _publisherRepository.Delete(publisher);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = publisher.Id;

            return response;
        }
    }
}
