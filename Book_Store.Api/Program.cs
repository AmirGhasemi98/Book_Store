using Book_Store.Application;
using Book_Store.Identity;
using Book_Store.Persistence;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
AddSwagger(builder.Services);

builder.Services.AddCors(o =>
{
    o.AddPolicy("CorsPolicy", b =>
    b.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("CorsPolicy");

app.MapControllers();

app.Run();


void AddSwagger(IServiceCollection services)
{
    services.AddSwaggerGen(o =>
    {
        o.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        {
            Description = @"JWT Authorization Header Using The Bearer Schema.
                       Enter 'Bearer' [Space] And Then Your Token In The Text Input Below.
                       Example: 'Bearer 1234ssdw'",
            Name = "Athorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });

        o.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

        o.SwaggerDoc("V1", new OpenApiInfo()
        {
            Version = "v1",
            Title = "Book store Api"
        });
    });
}

