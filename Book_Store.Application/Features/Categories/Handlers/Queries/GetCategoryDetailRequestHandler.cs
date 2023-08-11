using AutoMapper;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.Features.Categories.Requests.Queries;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Categories.Handlers.Queries
{
    public class GetCategoryDetailRequestHandler : IRequestHandler<GetCategoryDetailRequest, CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryDetailRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetCategoryDetailRequest request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetCategoryWithDetails(request.Id);
            return _mapper.Map<CategoryDto>(category);
        }
    }
}
