using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.BookImages.Requests.Queries;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Handlers.Queries
{
    public class GetBookImageRequestHandler : IRequestHandler<GetBookImageRequest, byte[]>
    {
        private readonly IBookImageRepository _bookImageRepository;


        public GetBookImageRequestHandler(IBookImageRepository bookImageRepository)
        {
            _bookImageRepository = bookImageRepository;
        }

        public async Task<byte[]> Handle(GetBookImageRequest request, CancellationToken cancellationToken)
        {
            var bookImage = await _bookImageRepository.GetBy(request.BookId);
            return bookImage.File;
        }
    }
}
