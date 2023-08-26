using Book_Store.Application.DTOs.Publisher;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Requests.Commands
{
    public class CreatePublisherCommand : IRequest<BaseCommandResponse>
    {
        public CreatePublisherDto CreatePublisherDto { get; set; }
    }
}
