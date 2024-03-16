using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMLSP.Infrastructure.EFCore.Repository;
using IMSLP.Application;
using IMSLP.Application.Contracts;
using IMSLP.Domain.Repository;
using Microsoft.Extensions.DependencyInjection;
using Shop.Application.Interfaces;
using Shop.Application.Services;

namespace IMLSP.Infrastructure.EFCore.DependencyContainer
{
    internal class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            #region services

            services.AddScoped<IUserService, UserService>();

            #endregion

            #region repositories

            services.AddScoped<IUserRepository, UserRepository>();

            #endregion

            #region tools

            services.AddScoped<IPasswordHelper, PasswordHelper>();

            #endregion
        }
    }
}
