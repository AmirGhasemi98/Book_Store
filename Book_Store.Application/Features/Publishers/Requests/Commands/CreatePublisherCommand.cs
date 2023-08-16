using Book_Store.Application.DTOs.Publisher;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Requests.Commands
{
    public class CreatePublisherCommand : IRequest<int>
    {
        public CreatePublisherDto CreatePublisherDto { get; set; }
    }
}
