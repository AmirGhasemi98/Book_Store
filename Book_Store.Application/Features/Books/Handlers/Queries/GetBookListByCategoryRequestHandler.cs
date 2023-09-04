using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Book;
using Book_Store.Application.Features.Books.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Queries
{
    public class GetBookListByCategoryRequestHandler : IRequestHandler<GetBookListByCategoryRequest, List<BookListDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetBookListByCategoryRequestHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookListDto>> Handle(GetBookListByCategoryRequest request, CancellationToken cancellationToken)
        {
            var books = await _bookRepository.GetBookListByCategory(request.CategoryId);
            return _mapper.Map<List<BookListDto>>(books);
        }
    }
}
