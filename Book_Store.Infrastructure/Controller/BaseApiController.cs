using Book_Store.Infrastructure.Extentions;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Infrastructure.Controller
{
    public class BaseApiController : ControllerBase
    {
        public int UserId
        {
            get
            {
                var user = User.Identity as System.Security.Claims.ClaimsIdentity;
                if (user is not null && user.IsAuthenticated)
                    return User.GetUserId();

                throw new Exception("User Id Must Have Value");
            }
        }
    }
}
