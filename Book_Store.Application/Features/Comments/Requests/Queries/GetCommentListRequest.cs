using Book_Store.Application.DTOs.Comment;
using MediatR;

namespace Book_Store.Application.Features.Comments.Requests.Queries
{
    public class GetCommentListRequest : IRequest<List<CommentDto>>
    {
        public int BookId { get; set; }
    }
}
