using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly BookStoreDbContext _context;

        private readonly DbContextOptions<BookStoreDbContext> _options;

        public CommentRepository(BookStoreDbContext context, DbContextOptions<BookStoreDbContext> options) : base(context)
        {
            _context = context;
            _options = options;
        }

        public async Task<List<Comment>> GetCommentsOfBook(int bookId)
        {
            return await _context.Comments.Include(c => c.UserId).Where(c => c.BookId == bookId).ToListAsync();
        }
    }
}
