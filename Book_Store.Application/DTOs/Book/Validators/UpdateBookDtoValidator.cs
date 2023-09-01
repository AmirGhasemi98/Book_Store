using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Book.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;

        public UpdateBookDtoValidator(ICategoryRepository categoryRepository, IPublisherRepository publisherRepository)
        {
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;

            Include(new IBookDtoValidator(_categoryRepository, _publisherRepository));

            RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
