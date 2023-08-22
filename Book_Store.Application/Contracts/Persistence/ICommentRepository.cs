using Book_Store.Domain.Entites;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<List<Comment>> GetCommentsOfBook(int bookId);
    }
}
