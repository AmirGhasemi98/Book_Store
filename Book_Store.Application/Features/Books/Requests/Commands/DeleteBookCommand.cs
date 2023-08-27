using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Commands
{
    public class DeleteBookCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
