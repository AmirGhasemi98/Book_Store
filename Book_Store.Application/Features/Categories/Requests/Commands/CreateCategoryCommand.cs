using Book_Store.Application.DTOs.Category;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public CategoryDto CategoryDto { get; set; }
    }
}
