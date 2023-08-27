using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class DeleteBookCommandHabdler : IRequestHandler<DeleteBookCommand, BaseCommandResponse>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHabdler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var book = await _bookRepository.Get(request.Id);

            if (book is null)
            {
                response.Success = false;
                response.Message = "کتاب یافت نشد.";
                response.Errors.Add("کتاب یافت نشد.");

                return response;
            }

            await _bookRepository.Delete(book);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = book.Id;

            return response;
        }
    }
}
