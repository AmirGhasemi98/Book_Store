using Book_Store.Application.DTOs.Comment;
using MediatR;

namespace Book_Store.Application.Features.Comments.Requests.Commands
{
    public class CreateCommentCommand : IRequest<int>
    {
        public string UserId { get; set; }

        public CreateCommentDto CreateCommentDto { get; set; }
    }
}
