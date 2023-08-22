using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Comment;
using Book_Store.Application.Features.Comments.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Comments.Handlers.Queries
{
    public class GetCommentListRequestHandler : IRequestHandler<GetCommentListRequest, List<CommentDto>>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public GetCommentListRequestHandler(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public async Task<List<CommentDto>> Handle(GetCommentListRequest request, CancellationToken cancellationToken)
        {
            var commentList = await _commentRepository.GetCommentsOfBook(request.BookId);
            return _mapper.Map<List<CommentDto>>(commentList);
        }
    }
}
