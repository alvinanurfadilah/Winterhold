using WinterholdDataAccess;

namespace WinterholdWeb;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        Dependencies.ConfigureService(builder.Configuration, builder.Services);

        IServiceCollection services = builder.Services;
        services.AddControllersWithViews();
        Dependencies.ConfigureService(builder.Configuration, builder.Services);
        services.AddBusinessServices();

        var app = builder.Build();
        app.UseRouting();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}"
        );

        app.UseStaticFiles();
        app.Run();
    }
}
