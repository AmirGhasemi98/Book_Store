using Book_Store.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Store.Identity
{
    public class BookStoreIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
    }
}
