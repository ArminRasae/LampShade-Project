using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Application;
using TaskManagement.Application.Contracts;
using TaskManagement.Domain.ProductAgg;
using TaskManagement.Infrastructure.Repository;

namespace TaskManagement.Infrastructure.Configuration
{
    public class Bootstrapper
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductApplication, ProductApplication>();
        }
    }
}
