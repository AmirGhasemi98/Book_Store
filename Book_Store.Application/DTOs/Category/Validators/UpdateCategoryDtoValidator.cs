using Book_Store.Application.Persistence.Contracts;
using FluentValidation;

namespace Book_Store.Application.DTOs.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            Include(new ICategoryDtoValidator(_categoryRepository));

            RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);

        }
    }
}
