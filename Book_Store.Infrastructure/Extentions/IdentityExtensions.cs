using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Infrastructure.Extentions
{
    public static class IdentityExtensions
    {
        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            if (claimsPrincipal != null)
            {
                var data = claimsPrincipal.Claims.SingleOrDefault(s => s.Type == ClaimTypes.NameIdentifier);
                if (data != null) return Convert.ToInt32(data.Value);
            }

            return default(int);
        }

        public static int GetUserId(this IPrincipal principal)
        {
            var user = (ClaimsPrincipal)principal;
            return user.GetUserId();
        }
    }
}
