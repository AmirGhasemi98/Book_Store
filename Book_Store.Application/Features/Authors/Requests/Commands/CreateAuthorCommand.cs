using Book_Store.Application.DTOs.Author;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Commands
{
    public class CreateAuthorCommand : IRequest<BaseCommandResponse>
    {
        public CreateAuthorDto CreateAuthorDto { get; set; }
    }
}
