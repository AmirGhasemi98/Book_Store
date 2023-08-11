using Book_Store.Application.DTOs.Book;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Commands
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public BookDto BookDto { get; set; }
    }
}
