using Book_Store.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.Features.Books.Requests.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public BookDto BookDto { get; set; }
    }
}
