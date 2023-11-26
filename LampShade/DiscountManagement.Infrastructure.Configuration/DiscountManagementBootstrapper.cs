using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.ColleagueDiscountApp;
using DiscountManagement.Application.Contracts.CustomerDiscountApp;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFCore;
using DiscountManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DiscountManagement.Infrastructure.Configuration
{
    public class DiscountManagementBootstrapper
    {
        public static void Configure(IServiceCollection services,string connectionString )
        {
            services.AddScoped<ICustomerDiscountRepository,CustomerDiscountRepository>();
            services.AddScoped<ICustomerDiscountApplication,CustomerDiscountApplication>();

            services.AddTransient<IColleagueDiscountRepository,ColleagueDiscountRepository>();
            services.AddTransient<IColleagueDiscountApplication,ColleagueDiscountApplication>();

            services.AddDbContext<DiscountContext>(x =>
                x.UseSqlServer(connectionString));
        }
    }
}
