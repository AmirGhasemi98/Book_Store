using Book_Store.Domain.Entites;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface IBookImageRepository : IGenericRepository<BookImage>
    {
        Task<BookImage> GetBy(int bookId);
    }
}
