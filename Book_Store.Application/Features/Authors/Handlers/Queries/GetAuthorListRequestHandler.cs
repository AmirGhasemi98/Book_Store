using AutoMapper;
using Book_Store.Application.DTOs.Author;
using Book_Store.Application.Features.Authors.Requests.Queries;
using Book_Store.Application.Contracts.Persistence;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Queries
{
    public class GetAuthorListRequestHandler : IRequestHandler<GetAuthorListRequest, List<AuthorDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorListRequestHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<List<AuthorDto>> Handle(GetAuthorListRequest request, CancellationToken cancellationToken)
        {
            var authorList=await _authorRepository.GetAll();
            return _mapper.Map<List<AuthorDto>>(authorList);
        }
    }
}
