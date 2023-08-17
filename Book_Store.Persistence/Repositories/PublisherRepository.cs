using Book_Store.Application.Persistence.Contracts;
using Book_Store.Domain.Entites;

namespace Book_Store.Persistence.Repositories
{
    public class PublisherRepository : GenericRepository<Publisher> , IPublisherRepository
    {
        private readonly BookStoreDbContext _context;

        public PublisherRepository(BookStoreDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
