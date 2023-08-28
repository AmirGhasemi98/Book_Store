using Book_Store.Application.DTOs.BookImage;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Requests.Commands
{
    public class CreateBookImageCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookImageDto CreateBookImageDto { get; set; }
    }
}
