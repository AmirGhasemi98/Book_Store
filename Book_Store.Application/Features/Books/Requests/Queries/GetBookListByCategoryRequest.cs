using Book_Store.Application.DTOs.Book;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Queries
{
    public class GetBookListByCategoryRequest : IRequest<List<BookListDto>>
    {
        public int? CategoryId { get; set; }
    }
}
