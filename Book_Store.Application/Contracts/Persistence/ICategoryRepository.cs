using Book_Store.Domain.Entites;

namespace Book_Store.Application.Persistence.Contracts
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
        Task<List<Category>> GetCategoriesWithDetailes();

        Task<Category> GetCategoryWithDetails(int id);
    }
}
