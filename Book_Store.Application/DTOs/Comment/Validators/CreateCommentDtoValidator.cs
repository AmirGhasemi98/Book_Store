using Book_Store.Application.Contracts.Persistence;
using FluentValidation;

namespace Book_Store.Application.DTOs.Comment.Validators
{
    public class CreateCommentDtoValidator : AbstractValidator<CreateCommentDto>
    {
        private readonly IBookRepository _bookRepository;

        public CreateCommentDtoValidator(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

            Include(new ICommentDtoValidator());

            RuleFor(c => c.BookId).GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    var bookExist = await _bookRepository.Exist(id);
                    return !bookExist;
                }).WithMessage("کتاب با این شناسه یافت نشد.");
        }
    }
}
