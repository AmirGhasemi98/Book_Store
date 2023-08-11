using Book_Store.Application.DTOs.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.Features.Books.Requests.Queries
{
    public class GetBookListRequest : IRequest<List<BookDto>>
    {
    }
}
