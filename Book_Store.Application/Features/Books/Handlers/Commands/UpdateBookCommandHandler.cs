using AutoMapper;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using MediatR;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Get(request.BookDto.Id);
            _mapper.Map(request.BookDto, book);
            await _bookRepository.Update(book);
            return Unit.Value;
        }
    }
}
