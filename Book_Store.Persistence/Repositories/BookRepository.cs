using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly BookStoreDbContext _context;

        public BookRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetBooksWithDetailes()
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.Publisher)
                .Include(b => b.Category).ToListAsync();
        }

        public async Task<Book> GetBookWithDetaile(int id)
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.Publisher)
                .Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
