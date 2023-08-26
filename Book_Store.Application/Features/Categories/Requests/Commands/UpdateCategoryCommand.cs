using Book_Store.Application.DTOs.Category;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Commands
{
    public class UpdateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public UpdateCategoryDto UpdateCategoryDto { get; set; }
    }
}
