using AutoMapper;
using Book_Store.Application.Features.Books.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.Features.Books.Handlers.Commands
{
    public class DeleteBookCommandHabdler : IRequestHandler<DeleteBookCommand>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public DeleteBookCommandHabdler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _bookRepository.Get(request.Id);
            await _bookRepository.Delete(book);
            return Unit.Value;
        }
    }
}
