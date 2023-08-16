using Book_Store.Application.DTOs.Category;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<Unit>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
