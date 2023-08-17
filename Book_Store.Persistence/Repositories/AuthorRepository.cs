using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;

namespace Book_Store.Persistence.Repositories
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private readonly BookStoreDbContext _context;

        public AuthorRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
