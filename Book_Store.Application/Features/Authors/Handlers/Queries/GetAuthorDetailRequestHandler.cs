using AutoMapper;
using Book_Store.Application.DTOs.Author;
using Book_Store.Application.Features.Authors.Requests.Queries;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Queries
{
    public class GetAuthorDetailRequestHandler : IRequestHandler<GetAuthorDetailRequest, AuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorDetailRequestHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorDto> Handle(GetAuthorDetailRequest request, CancellationToken cancellationToken)
        {
            var author = await _authorRepository.Get(request.Id);
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
