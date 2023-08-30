using Book_Store.Application.DTOs.BookMapAuthor;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.BookMapAuthors.Requests.Commands
{
    public class CreateBookAuthorCommand : IRequest<BaseCommandResponse>
    {
        public CreateBookAuthorDto CreateBookAuthorDto { get; set; }
    }
}
