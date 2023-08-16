using Book_Store.Application.DTOs.Author;
using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Commands
{
    public class UpdateAuthorCommand : IRequest<Unit>
    {
        public UpdateAuthorDto UpdateAuthorDto { get; set; }
    }
}
