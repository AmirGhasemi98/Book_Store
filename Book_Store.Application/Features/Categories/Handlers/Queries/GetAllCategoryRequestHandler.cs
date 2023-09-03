using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Category;
using Book_Store.Application.Features.Categories.Requests.Queries;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Categories.Handlers.Queries
{
    public class GetAllCategoryRequestHandler : IRequestHandler<GetAllCategoryRequest, List<GetAllCategoryDto>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;


        public GetAllCategoryRequestHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetAllCategoryDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
        {
            var allCategories = await _categoryRepository.GetList();

            var categoryWithChilds = _mapper.Map<List<GetAllCategoryDto>>(allCategories);

            return categoryWithChilds.Where(x => !x.ParentId.HasValue).ToList();

        }

        //public List<GetAllCategoryDto> GetCategoryParents(int parentId, List<GetAllCategoryDto> categories, ref List<Test> model)
        //{
        //    var result = new List<GetAllCategoryDto>();

        //    foreach (var el in categories.Where(c => c.Id == parentId).ToList())
        //    {
        //        if (el.ParentId.HasValue)
        //        {
        //            el.Children = GetCategoryParents(el.ParentId.Value, categories, ref model);
        //        }

        //        model.Add(new Test
        //        {
        //            Id = model.LastOrDefault() != null ? model.LastOrDefault().Id + 1 : 1,
        //            Title = el.Title,
        //        });

        //        result.Add(el);
        //    }

        //    return result;
        //}
    }
}
