using Book_Store.Domain.Entites;

namespace Book_Store.Application.Contracts.Persistence
{
    public interface IBookTranslatorsRepository : IGenericRepository<BookMapTranslator>
    {
        Task DeleteBookTranslators(int bookId);
    }
}
