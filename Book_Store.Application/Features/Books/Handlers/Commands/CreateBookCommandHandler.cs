using AutoMapper;
using Book_Store.Application.DTOs.Book.Validators;
using Book_Store.Application.DTOs.Category.Validators;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new CreateBookDtoValidator(_categoryRepository, _authorRepository, _publisherRepository);
            var validationResult = await validator.ValidateAsync(request.CreateBookDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion

            var book = _mapper.Map<Book>(request.CreateBookDto);
            book = await _bookRepository.Add(book);
            return book.Id;
        }
    }
}
