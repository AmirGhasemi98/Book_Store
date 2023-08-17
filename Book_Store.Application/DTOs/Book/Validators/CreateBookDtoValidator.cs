using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Book.Validators
{
    public class CreateBookDtoValidator : AbstractValidator<CreateBookDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public CreateBookDtoValidator(ICategoryRepository categoryRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;

            Include(new IBookDtoValidator(_categoryRepository, _authorRepository, _publisherRepository));
        }
    }
}
