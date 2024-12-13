using WinterholdBusiness.Interfaces;
using WinterholdBusiness.Repositories;
using WinterholdWeb.Services;

namespace WinterholdWeb;

public static class ConfigureBusinessService
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<AuthorService>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<CategoryService>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<BookService>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<CustomerService>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<LoanService>();
        services.AddScoped<IAddressRepository, AddressRepository>();
        return services;
    }
}