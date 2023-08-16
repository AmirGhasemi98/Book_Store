using Book_Store.Application.DTOs.Publisher;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Requests.Commands
{
    public class UpdatePublisherCommand : IRequest<Unit>
    {
        public UpdatePublisherDto UpdatePublisherDto { get; set; }
    }
}
