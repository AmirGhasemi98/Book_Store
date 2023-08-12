using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Commands
{
    public class DeleteAuthorCommand : IRequest
    {
        public int Id { get; set; }
    }
}
