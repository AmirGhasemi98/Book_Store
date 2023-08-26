using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Requests.Commands
{
    public class UpdatePublisherCommand : IRequest<BaseCommandResponse>
    {
        public UpdatePublisherDto UpdatePublisherDto { get; set; }
    }
}
