using AutoMapper;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.Features.Categories.Requests.Queries;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryListRequestHandler : IRequestHandler<GetCategoryListRequest, List<CategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryListRequest request, CancellationToken cancellationToken)
        {
            var categoryList = await _categoryRepository.GetCategoriesWithDetailes();
            return _mapper.Map<List<CategoryDto>>(categoryList);
        }
    }
}
