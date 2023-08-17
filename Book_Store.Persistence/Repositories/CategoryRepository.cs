using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;
using Microsoft.EntityFrameworkCore;

namespace Book_Store.Persistence.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly BookStoreDbContext _context;

        public CategoryRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesWithDetailes()
        {
            return await _context.Categories.Include(c => c.Parent).ToListAsync();
        }

        public async Task<Category> GetCategoryWithDetails(int id)
        {
            return await _context.Categories.Include(c => c.Parent).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
