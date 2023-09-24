using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Book.Validators;
using Book_Store.Application.DTOs.BookMapAuthor;
using Book_Store.Application.DTOs.BookMapTranslator;
using Book_Store.Application.Features.BookImages.Requests.Commands;
using Book_Store.Application.Features.BookMapAuthors.Requests.Commands;
using Book_Store.Application.Features.BookMapTranslators.Requests.Commands;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMediator _mediator;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IPublisherRepository publisherRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
            _mediator = mediator;
        }

        public async Task<BaseCommandResponse> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdateBookDtoValidator(_categoryRepository, _publisherRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateBookDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var book = await _bookRepository.Get(request.UpdateBookDto.Id);

            if (book is null)
            {
                response.Success = false;
                response.Message = "کتاب یافت نشد.";
                response.Errors.Add("کتاب یافت نشد.");

                return response;
            }

            _mapper.Map(request.UpdateBookDto, book);
            await _bookRepository.Update(book);

            #region Book Authors

            if (request.UpdateBookDto.AuthorIds is not null && request.UpdateBookDto.AuthorIds.Any())
            {
                var bookAuthorsResponse = await _mediator.Send(new CreateBookAuthorCommand
                {
                    CreateBookAuthorDto = new CreateBookAuthorDto
                    { BookId = book.Id, AuthorIds = request.UpdateBookDto.AuthorIds, ForUpdate = true }
                });

                if (!bookAuthorsResponse.Success)
                {
                    response.Success = false;
                    response.Errors.AddRange(bookAuthorsResponse.Errors);

                    await _bookRepository.RollbackTransactionAsync();

                    return response;
                }
            }

            #endregion

            #region Book Translators

            if (request.UpdateBookDto.TranslatorIds is not null && request.UpdateBookDto.TranslatorIds.Any())
            {
                var bookTranslatorResponse = await _mediator.Send(new CreateBookTranslatorCommand
                {
                    CreateBookTranslatorDto = new CreateBookTranslatorDto
                    {
                        BookId = book.Id,
                        TranslatorIds = request.UpdateBookDto.TranslatorIds,
                        ForUpdate = true
                    }
                });

                if (!bookTranslatorResponse.Success)
                {
                    response.Success = false;
                    response.Errors.AddRange(bookTranslatorResponse.Errors);

                    await _bookRepository.RollbackTransactionAsync();

                    return response;
                }
            }

            #endregion

            #region Book Image

            if (request.UpdateBookDto.BookImage is not null)
            {
                var bookImageResponse = await _mediator.Send(new UpdateBookImageCommand
                {
                    UpdateBookImage = new DTOs.BookImage.UpdateBookImageDto
                    { BookId = book.Id, Image = request.UpdateBookDto.BookImage }
                });

                response.Errors.AddRange(bookImageResponse.Errors);

            }

            #endregion

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = book.Id;

            return response;
        }
    }
}
