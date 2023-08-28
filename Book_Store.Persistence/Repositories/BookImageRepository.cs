using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;

namespace Book_Store.Persistence.Repositories
{
    public class BookImageRepository : GenericRepository<BookImage> , IBookImageRepository
    {
        private readonly BookStoreDbContext _context;

        public BookImageRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
