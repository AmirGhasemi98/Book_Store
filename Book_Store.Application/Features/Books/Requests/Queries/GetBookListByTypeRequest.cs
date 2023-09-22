using Book_Store.Application.DTOs.Book;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Queries
{
    public class GetBookListByTypeRequest : IRequest<List<BookListDto>>
    {
        public int? CategoryId { get; set; }

        public int? PublisherId { get; set; }

        public int? AuthorId { get; set; }
    }
}
