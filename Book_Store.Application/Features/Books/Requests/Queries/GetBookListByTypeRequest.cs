using Book_Store.Application.DTOs.Book;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Queries
{
    public class GetBookListByTypeRequest : IRequest<List<BookListDto>>
    {
        public string? q { get; set; }

        public List<int>? CategoryId { get; set; }

        public List<int>? PublisherId { get; set; }

        public List<int>? AuthorId { get; set; }
    }
}
