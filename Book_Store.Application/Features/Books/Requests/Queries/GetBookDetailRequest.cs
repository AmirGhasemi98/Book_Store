using Book_Store.Application.DTOs.Book;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Queries
{
    public class GetBookDetailRequest : IRequest<BookDto>
    {
        public int Id { get; set; }
    }
}
