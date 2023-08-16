using Book_Store.Application.DTOs.Book;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Commands
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public UpdateBookDto UpdateBookDto { get; set; }
    }
}
