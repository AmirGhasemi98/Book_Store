using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Book.Validators
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;

        public CreateBookDtoValidator(ICategoryRepository categoryRepository, IPublisherRepository publisherRepository)
        {
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;

            Include(new IBookDtoValidator(_categoryRepository, _publisherRepository));
        }
    }
}
