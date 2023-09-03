using Book_Store.Application.DTOs.Category;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Queries
{
    public class GetAllCategoryRequest : IRequest<List<GetAllCategoryDto>>
    {
    }
}
