using AutoMapper;
using Book_Store.Application.Features.Authors.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Commands
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, int>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Author>(request.AuthorDto);
            author = await _authorRepository.Add(author);
            return author.Id;
        }
    }
}
