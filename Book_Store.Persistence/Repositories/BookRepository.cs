using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Enums.Books;
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

        public async Task<List<Book>> GetBookListByType(int? id, GetBooksType? type)
        {
            var query = _context.Books.AsNoTracking();

            if (id.HasValue)
            {
                switch (type)
                {
                    case GetBooksType.Category:
                        query = query.Where(x => x.CategoryId == id);
                        break;
                    case GetBooksType.Publisher:
                        query = query.Where(x => x.PublisherId == id);
                        break;
                    case GetBooksType.Author:
                        query = query.Where(x => x.bookMapAuthors.Any(a => a.AuthorId == id));
                        break;
                    default:
                        query = query.Where(x => x.CategoryId == id);
                        break;
                }
            }


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
