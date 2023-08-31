using Book_Store.Application.DTOs.BookImage;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Requests.Queries
{
    public class GetBookImageRequest : IRequest<GetBookImageDto>
    {
        public int BookId { get; set; }
    }
}
