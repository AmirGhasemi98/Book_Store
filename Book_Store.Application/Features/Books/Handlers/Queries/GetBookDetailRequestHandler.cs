using AutoMapper;
using Book_Store.Application.DTOs.Book;
using Book_Store.Application.Features.Books.Requests.Queries;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Queries
{
    public class GetBookDetailRequestHandler : IRequestHandler<GetBookDetailRequest, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookDetailRequestHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(GetBookDetailRequest request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.GetBookWithDetaile(request.Id);
            return _mapper.Map<BookDto>(book);
        }
    }
}
