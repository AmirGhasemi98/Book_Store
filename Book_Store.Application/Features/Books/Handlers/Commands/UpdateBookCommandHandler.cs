using AutoMapper;
using Book_Store.Application.DTOs.Book.Validators;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using FluentValidation;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IPublisherRepository _publisherRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IAuthorRepository authorRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateBookDtoValidator(_categoryRepository, _authorRepository, _publisherRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateBookDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion  

            var book = await _bookRepository.Get(request.UpdateBookDto.Id);
            _mapper.Map(request.UpdateBookDto, book);
            await _bookRepository.Update(book);
            return Unit.Value;
        }
    }
}
