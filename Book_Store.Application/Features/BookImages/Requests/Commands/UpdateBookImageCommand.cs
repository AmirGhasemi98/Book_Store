using Book_Store.Application.DTOs.BookImage;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Requests.Commands
{
    public class UpdateBookImageCommand : IRequest<BaseCommandResponse>
    {
        public UpdateBookImageDto UpdateBookImage { get; set; }
    }
}
