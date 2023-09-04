using Book_Store.Application.Contracts.Persistence;
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

        public async Task<List<Book>> GetBookListByCategory(int? categoryId)
        {
            var query = _context.Books.AsNoTracking();

            if (categoryId.HasValue)
                query = query.Where(x => x.CategoryId == categoryId);

            return await query.Include(b => b.bookMapAuthors).ThenInclude(a => a.Author).ToListAsync();
        }

        public async Task<List<Book>> GetBooksWithDetailes()
        {
            return await _context.Books.Include(b => b.bookMapAuthors).ThenInclude(a => a.Author).Include(b => b.Publisher)
                .Include(b => b.Category).Include(b => b.bookMapTranslators).ThenInclude(t => t.Translator).ToListAsync();
        }

        public async Task<Book> GetBookWithDetaile(int id)
        {
            return await _context.Books.Include(b => b.bookMapAuthors).ThenInclude(a => a.Author).Include(b => b.Publisher)
                .Include(b => b.Category).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
