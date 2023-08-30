using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Book.Validators
{
    public class IBookDtoValidator : AbstractValidator<IBookDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public IBookDtoValidator(ICategoryRepository categoryRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;


            RuleFor(x => x.Title).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
               .NotNull().MaximumLength(50).WithMessage("نام نمی تواند بیشتر از 50 کاراکتر باشد.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("نام نمی تواند خالی باشد.")
              .NotNull();

            RuleFor(x => x.Price).GreaterThan(0);

            RuleFor(c => c.CategoryId).GreaterThan(0)
            .MustAsync(async (id, Token) =>
            {
                var categoryExist = await _categoryRepository.Exist(id);
                return categoryExist;
            }).WithMessage("دسته بندی یافت نشد.");

            RuleFor(c => c.PublisherId).GreaterThan(0)
          .MustAsync(async (id, Token) =>
          {
              var publisherExist = await _publisherRepository.Exist(id);
              return publisherExist;
          }).WithMessage("ناشر یافت نشد.");

        }
    }
}
