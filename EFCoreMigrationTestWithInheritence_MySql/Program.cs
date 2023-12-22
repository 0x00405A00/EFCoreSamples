using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EFCoreMigrationTestWithInheritence
{
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

        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            var serviceBuilder = services.BuildServiceProvider();
            var configurationService = serviceBuilder.GetRequiredService<IConfiguration>();
            var connectionString = configurationService.GetConnectionString(NewContext.ConnectionStringAlias);
            services.AddDbContext<NewContext>(options =>
            {

                options.UseMySQL(connectionString);
            });
            
            return services;
        }
    }
}
