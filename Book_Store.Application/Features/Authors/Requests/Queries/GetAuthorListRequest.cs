using Book_Store.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Application.Features.Authors.Requests.Queries
{
    public class GetAuthorListRequest : IRequest<List<AuthorDto>>
    {

    }
}
