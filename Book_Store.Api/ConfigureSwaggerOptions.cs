using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Book_Store.Api
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        public void Configure(SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 1234sddsw'",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                     new OpenApiSecurityScheme()
                     {
                         Reference = new OpenApiReference()
                         {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                         },
                         Scheme = "oauth2",
                         Name = "Bearer",
                         In = ParameterLocation.Header
                     },
                     new List<string>()
                }
            });

            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "v1",
                Title = "Book Store Api"
            });
        }
    }
}
