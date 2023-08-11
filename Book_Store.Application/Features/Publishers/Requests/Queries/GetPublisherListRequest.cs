using Book_Store.Application.DTOs;
using MediatR;

namespace Book_Store.Application.Features.Publishers.Requests.Queries
{
    public class GetPublisherListRequest : IRequest<List<PublisherDto>>
    {
    }
}
