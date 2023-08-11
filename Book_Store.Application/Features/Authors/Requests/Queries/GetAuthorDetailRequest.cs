using Book_Store.Application.DTOs.Author;
using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Queries
{
    public class GetAuthorDetailRequest : IRequest<AuthorDto>
    {
        public int Id { get; set; }
    }
}
