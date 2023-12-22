
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationTestWithInheritence_SqlLite;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddPresentation();

        var app = builder.Build();

        app.UseRouting();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/error-debug");
        }
        else
        {
            app.UseExceptionHandler("/error");
        }

        var sp = builder.Services.BuildServiceProvider();
        app.UseEndpoints(x => x.MapControllers());
        app.MapControllers();


        app.Run();
    }
}

public static class ServiceExtension
{

    private static readonly string DatabasePath = Path.Combine(Environment.CurrentDirectory, "jellyfish-data.db");
    public static readonly string DatabaseString = $"Data Source={DatabasePath}";
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddRouting(options => options.LowercaseUrls = true);
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();

        var serviceBuilder = services.BuildServiceProvider();
        var configurationService = serviceBuilder.GetRequiredService<IConfiguration>();
        services.AddDbContext<NewContext>(options =>
        {

            options.UseSqlite(DatabaseString);
        });

        return services;
    }
}
