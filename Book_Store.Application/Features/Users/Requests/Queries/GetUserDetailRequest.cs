using Book_Store.Application.DTOs.User;
using MediatR;

namespace Book_Store.Application.Features.Users.Requests.Queries
{
    public class GetUserDetailRequest : IRequest<UserDetailDto>
    {
        public int Id { get; set; }
    }
}
