using AutoMapper;
using Book_Store.Application.Features.Categories.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Category>(request.CategoryDto);
            category = await _categoryRepository.Add(category);
            return category.Id;
        }
    }
}
