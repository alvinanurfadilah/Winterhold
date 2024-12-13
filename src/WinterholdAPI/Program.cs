using Microsoft.OpenApi.Models;
using WinterholdAPI.Books;
using WinterholdAPI.Categories;
using WinterholdAPI.Customers;
using WinterholdAPI.Loans;
using WinterholdBusiness.Interfaces;
using WinterholdBusiness.Repositories;
using static WinterholdDataAccess.Dependencies;

namespace WinterholdAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        IConfiguration configuration = builder.Configuration;
        IServiceCollection services = builder.Services;
        ConfigureService(configuration, services);
        services.AddControllers();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<CategoryService>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<LoanService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<CustomerService>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<BookService>();

        builder.Services.AddSwaggerGen(options => {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Title = "Hydra API"
            });
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme()
            {
                Description = "Enter the token with the `Bearer: ` prefix, e.g. 'Bearer fdhauy837r3'",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });
            // options.OperationFilter<SecurityRequ>();
        });

        builder.Services.AddCors(option => {
            option.AddPolicy(name: "AllowFrontEnd", builder => {
                builder.WithOrigins("http://localhost:5066")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });
        });

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowFrontEnd");

        app.UseRouting();
        app.MapControllers();

        app.Run();
    }
}
