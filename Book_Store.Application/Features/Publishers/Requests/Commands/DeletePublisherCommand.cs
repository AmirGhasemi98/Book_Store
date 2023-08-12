using MediatR;

namespace Book_Store.Application.Features.Publishers.Requests.Commands
{
    public class DeletePublisherCommand : IRequest
    {
        public int Id { get; set; }
    }
}
