using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;

namespace Book_Store.Persistence.Repositories
{
    public class BookTranslatorsRepository : GenericRepository<BookMapTranslator>, IBookTranslatorsRepository
    {
        private readonly BookStoreDbContext _context;

        public BookTranslatorsRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteBookTranslators(int bookId)
        {
            _context.BookMapTranslators.Where(bt => bt.BookId == bookId).ToList().ForEach(x => _context.BookMapTranslators.Remove(x));
        }
    }
}
