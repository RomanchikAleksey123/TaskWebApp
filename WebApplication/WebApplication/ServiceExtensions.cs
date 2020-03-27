using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApplication.Contracts;
using WebApplication.Models;
using WebApplication.Repository;
using WebApplication.Services;

namespace WebApplication
{
    public static class ServiceExtensions
    {
        public static void ConfigureMsSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            const string connectionString = "DefaultConnection";

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString(connectionString)));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureEmailService(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
