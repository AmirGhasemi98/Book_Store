using Book_Store.Application.DTOs.Book;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Books.Requests.Commands
{
    public class UpdateBookCommand : IRequest<BaseCommandResponse>
    {
        public UpdateBookDto UpdateBookDto { get; set; }
    }
}
