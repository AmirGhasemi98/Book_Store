using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class BookImageRepository : GenericRepository<BookImage>, IBookImageRepository
    {
        private readonly BookStoreDbContext _context;

        public BookImageRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BookImage> GetBy(int bookId)
        {
            var result = await _context.BookImages.FirstOrDefaultAsync(b => b.BookId == bookId);
            return result;
        }
    }
}
