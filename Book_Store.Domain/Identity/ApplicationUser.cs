using Book_Store.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Book_Store.Domain.Identity
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
