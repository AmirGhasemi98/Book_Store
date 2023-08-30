using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.BookMapAuthor.Validators;
using Book_Store.Application.Features.BookMapAuthors.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.BookMapAuthors.Handlers.Commands
{
    public class CreateBookAuthorCommandHandler : IRequestHandler<CreateBookAuthorCommand, BaseCommandResponse>
    {
        private readonly IBookAuthorsRepository _bookAuthorsRepository;
        private readonly IAuthorRepository _authorRepository;

        public CreateBookAuthorCommandHandler(IBookAuthorsRepository bookAuthorsRepositor, IAuthorRepository authorRepository)
        {
            _bookAuthorsRepository = bookAuthorsRepositor;
            _authorRepository = authorRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateBookAuthorDtoValidator(_authorRepository);
            var validationResult = await validator.ValidateAsync(request.CreateBookAuthorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            #endregion

            await _bookAuthorsRepository.DeleteBookAuthors(request.CreateBookAuthorDto.BookId);

            var bookAuthors = new List<BookMapAuthor>();
            request.CreateBookAuthorDto.AuthorIds.ForEach(x => bookAuthors.Add(new BookMapAuthor { AuthorId = x, BookId = request.CreateBookAuthorDto.BookId }));
            await _bookAuthorsRepository.AddRange(bookAuthors);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";

            return response;
        }
    }
}
