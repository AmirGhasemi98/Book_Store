using Book_Store.Application.DTOs.Book;
using Book_Store.Application.Enums.Books;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Queries
{
    public class GetBookListByTypeRequest : IRequest<List<BookListDto>>
    {
        public int? Id { get; set; }

        public GetBooksType? Type { get; set; }
    }
}
