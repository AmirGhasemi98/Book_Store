using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Commands
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
    }
}
