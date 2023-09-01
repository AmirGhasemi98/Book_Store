using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Book.Validators;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IPublisherRepository _publisherRepository;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper,
            ICategoryRepository categoryRepository, IPublisherRepository publisherRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _publisherRepository = publisherRepository;
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

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = book.Id;

            return response;
        }
    }
}
