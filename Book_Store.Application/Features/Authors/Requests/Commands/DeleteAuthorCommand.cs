using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Commands
{
    public class DeleteAuthorCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
