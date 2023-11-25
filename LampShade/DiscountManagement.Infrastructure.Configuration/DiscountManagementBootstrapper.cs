using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_Framework.Domain;
using _0_Framework.Infrastructure;
using DiscountManagement.Application;
using DiscountManagement.Application.Contracts.CustomerDiscountApp;
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
           

            services.AddDbContext<DiscountContext>(x =>
                x.UseSqlServer(connectionString));
        }
    }
}
