using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public int Id { get; set; }
    }
}
