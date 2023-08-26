using Book_Store.Application.DTOs.Category;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Commands
{
    public class CreateCategoryCommand : IRequest<BaseCommandResponse>
    {
        public CreateCategoryDto CreateCategoryDto { get; set; }
    }
}
