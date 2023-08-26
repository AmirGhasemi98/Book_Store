using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
