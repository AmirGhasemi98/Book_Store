using AutoMapper;
using Book_Store.Application.DTOs.Book;
using Book_Store.Application.Features.Books.Requests.Queries;
using Book_Store.Application.Contracts.Persistence;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Queries
{
    public class GetBookListRequestHandler : IRequestHandler<GetBookListRequest, List<BookDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListRequestHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDto>> Handle(GetBookListRequest request, CancellationToken cancellationToken)
        {
            var bookList = await _bookRepository.GetBooksWithDetailes();
            return _mapper.Map<List<BookDto>>(bookList);
        }
    }
}
