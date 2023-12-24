using Microsoft.EntityFrameworkCore;

namespace EFCoreMigrationTestWithInheritence_MySql_Updated
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddPresentation();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
    public static class ServiceExtension
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            // Add services to the container.
            services.AddRazorPages();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            var serviceBuilder = services.BuildServiceProvider();
            var configurationService = serviceBuilder.GetRequiredService<IConfiguration>();
            var connectionString = configurationService.GetConnectionString(NewContext.ConnectionStringAlias);
            services.AddDbContext<NewContext>(options =>
            {
               
                //options.UseMySQL(connectionString);
            });
            return services;
        }
    }
}
