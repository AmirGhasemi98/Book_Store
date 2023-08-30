using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.BookMapAuthor.Validators
{
    public class CreateBookAuthorDtoValidator : AbstractValidator<CreateBookAuthorDto>
    {
        private readonly IAuthorRepository _authorRepository;

        public CreateBookAuthorDtoValidator(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;

            RuleForEach(x => x.AuthorIds).NotNull().GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var authorExist = await _authorRepository.Exist(id);
                    return authorExist;
                }).WithMessage("نویسنده با شناسه {CollectionIndex} یافت نشد.");
        }
    }
}
