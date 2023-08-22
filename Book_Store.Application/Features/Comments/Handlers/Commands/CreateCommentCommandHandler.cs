using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Comment.Validators;
using Book_Store.Application.Features.Comments.Requests.Commands;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Comments.Handlers.Commands
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public CreateCommentCommandHandler(ICommentRepository commentRepository, IMapper mapper, IBookRepository bookRepository)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new CreateCommentDtoValidator(_bookRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCommentDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion

            var comment = _mapper.Map<Comment>(request.CreateCommentDto);
            comment.UserId = request.UserId;
            comment = await _commentRepository.Add(comment);
            return comment.Id;
        }
    }
}
