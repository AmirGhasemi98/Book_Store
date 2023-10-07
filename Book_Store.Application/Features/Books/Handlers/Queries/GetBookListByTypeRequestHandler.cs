using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Book;
using Book_Store.Application.Features.Books.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Queries
{
    public class GetBookListByTypeRequestHandler : IRequestHandler<GetBookListByTypeRequest, List<BookListDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListByTypeRequestHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookListDto>> Handle(GetBookListByTypeRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBookListByType(request.q, request.CategoryId, request.PublisherId, request.AuthorId);
            return _mapper.Map<List<BookListDto>>(books);
        }
    }
}
