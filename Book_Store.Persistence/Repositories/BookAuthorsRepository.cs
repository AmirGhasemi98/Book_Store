using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;

namespace Book_Store.Persistence.Repositories
{
    public class BookAuthorsRepository : GenericRepository<BookMapAuthor>, IBookAuthorsRepository
    {
        private readonly BookStoreDbContext _context;

        public BookAuthorsRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task DeleteBookAuthors(int bookId)
        {
            _context.BookMapAuthors.Where(ba => ba.BookId == bookId).ToList().ForEach(x => _context.BookMapAuthors.Remove(x));
        }
    }
}
