using Book_Store.Application.Contracts.Identity;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Models.Identity;
using Book_Store.Domain.Identity;
using Book_Store.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Book_Store.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services,
           IConfiguration configuration)
        {
            services.AddDbContext<BookStoreDbContext>(option =>
            {
                option.UseSqlServer(configuration.GetConnectionString("BookStoreConnectionString"))
                    .EnableSensitiveDataLogging();
            });

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddIdentity<ApplicationUser, IdentityRole<int>>()
               .AddEntityFrameworkStores<BookStoreDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            //services.AddTransient<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JwtSettings:Issuer"],
                        ValidAudience = configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))
                    };
                });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            return services;
        }
    }
}
