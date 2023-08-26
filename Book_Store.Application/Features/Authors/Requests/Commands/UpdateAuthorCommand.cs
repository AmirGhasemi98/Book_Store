using Book_Store.Application.DTOs.Author;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Commands
{
    public class UpdateAuthorCommand : IRequest<BaseCommandResponse>
    {
        public UpdateAuthorDto UpdateAuthorDto { get; set; }
    }
}
