using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Category.Validators
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            When(c => c.ParentId != null, () =>
            {
                RuleFor(c => c.ParentId).NotEqual(c => c.Id).WithMessage("نمی توانید خود دسته بندی را به عنوان والد انتخاب کنید.");
            });

            Include(new ICategoryDtoValidator(_categoryRepository));

            RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);



        }
    }
}
