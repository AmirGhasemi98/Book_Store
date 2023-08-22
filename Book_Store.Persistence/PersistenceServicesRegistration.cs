using Book_Store.Application.Contracts.Persistence;
using Book_Store.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Book_Store.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BookStoreDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("BookStoreConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository , BookRepository>();
            services.AddScoped<IBookRepository , BookRepository>();
            services.AddScoped<ICommentRepository , CommentRepository>();
            services.AddScoped<IUserRepository , UserRepository>();

            return services;
        }
    }
}
