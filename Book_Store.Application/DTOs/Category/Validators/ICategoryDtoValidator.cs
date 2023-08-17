using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Category.Validators
{
    public class ICategoryDtoValidator : AbstractValidator<ICategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public ICategoryDtoValidator(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;

            RuleFor(c => c.Title).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
               .NotNull().MaximumLength(50).WithMessage("نام نمی تواند بیشتر از 50 کاراکتر باشد.");

            RuleFor(c => c.ParentId).GreaterThan(0)/*.WithMessage("شناسه دسته بندی نمی تواند صفر باشد.")*/
                .MustAsync(async (id, token) =>
                {
                    var categoryExist = await _categoryRepository.Exist(id.Value);
                    return !categoryExist;
                }).WithMessage("دسته بندی والد یافت نشد.");
        }
    }
}
