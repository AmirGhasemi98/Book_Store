using AutoMapper;
using Book_Store.Application.Features.Authors.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Commands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.Get(request.Id);
            await _authorRepository.Delete(author);
            return Unit.Value;
        }
    }
}
