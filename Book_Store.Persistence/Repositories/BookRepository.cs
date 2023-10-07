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

        public async Task<List<Book>> GetBookListByType(string? q, List<int>? categoryIds, List<int>? publisherIds, List<int>? authorIds)
        {
            var query = _context.Books.AsNoTracking();

            if (categoryIds is not null && categoryIds.Any())
                query = query.Where(b => categoryIds.Contains(b.CategoryId));

            if (publisherIds is not null && publisherIds.Any())
                query = query.Where(b => publisherIds.Contains(b.PublisherId));

            if (authorIds is not null && authorIds.Any())
                query = query.Where(b => _context.BookMapAuthors.Any(ba => ba.BookId == b.Id && authorIds.Contains(ba.AuthorId)));

            if (!string.IsNullOrWhiteSpace(q))
                query = query.Where(b => b.Title.Contains(q));

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
                .Include(b => b.Category).Include(b => b.bookMapTranslators).ThenInclude(t => t.Translator).FirstOrDefaultAsync(b => b.Id == id);
        }
    }
}
