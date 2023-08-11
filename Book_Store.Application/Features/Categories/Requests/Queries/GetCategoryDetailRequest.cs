using Book_Store.Application.DTOs;
using MediatR;

namespace Book_Store.Application.Features.Categories.Requests.Queries
{
    public class GetCategoryDetailRequest : IRequest<CategoryDto>
    {
        public int Id { get; set; }
    }
}
