using AutoMapper;
using Book_Store.Application.DTOs.Book.Validators;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;
using Book_Store.Application.Features.BookImages.Requests.Commands;
using Book_Store.Application.Features.BookMapAuthors.Requests.Commands;
using Book_Store.Application.DTOs.BookMapAuthor;
using System.Transactions;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;
        private readonly IMediator _mediator;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IAuthorRepository authorRepository,
            IPublisherRepository publisherRepository, IMediator mediator)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _mediator = mediator;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {

            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateBookDtoValidator(_categoryRepository, _authorRepository, _publisherRepository);
            var validationResult = await validator.ValidateAsync(request.CreateBookDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var book = _mapper.Map<Book>(request.CreateBookDto);

            await _bookRepository.BeginTransactionAsync();

            book = await _bookRepository.Add(book);

            var bookAuthorsResponse = await _mediator.Send(new CreateBookAuthorCommand
            {
                CreateBookAuthorDto = new CreateBookAuthorDto
                { BookId = book.Id, AuthorIds = request.CreateBookDto.AuthorIds }
            });

            if (!bookAuthorsResponse.Success)
            {
                response.Errors.AddRange(bookAuthorsResponse.Errors);

                await _bookRepository.RollbackTransactionAsync();

                return response;
            }



            var bookImageResponse = await _mediator.Send(new CreateBookImageCommand
            {
                CreateBookImageDto = new DTOs.BookImage.CreateBookImageDto
                { BookId = book.Id, Image = request.CreateBookDto.BookImage }
            });



            response.Errors.AddRange(bookImageResponse.Errors);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = book.Id;

            _bookRepository.CommitTransactionAsync();

            return response;
        }
    }
}
