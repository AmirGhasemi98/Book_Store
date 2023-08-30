using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.BookImages.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Handlers.Queries
{
    public class GetBookImageRequestHandler : IRequestHandler<GetBookImageRequest, byte[]>
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IMapper _mapper;


        public GetBookImageRequestHandler(IBookImageRepository bookImageRepository, IMapper mapper)
        {
            _bookImageRepository = bookImageRepository;
            _mapper = mapper;
        }

        public async Task<byte[]> Handle(GetBookImageRequest request, CancellationToken cancellationToken)
        {
            var bookImage = await _bookImageRepository.Get(request.BookId);
            return bookImage.File;
        }
    }
}
