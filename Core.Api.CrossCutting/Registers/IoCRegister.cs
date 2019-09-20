using Core.Api.Application.Contract.IServices.Security;
using Core.Api.Application.Services.Security;
using Core.Api.DataAccess.Contract.IRepositories.ISecurity;
using Core.Api.DataAccess.Repositories.Security;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Api.CrossCutting.Registers
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            AddRegisterServices(services);
            AddRegisterRepositories(services);
            AddRegisterOthers(services);
            return services;
        }

        private static IServiceCollection AddRegisterServices(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            return services;
        }

        private static IServiceCollection AddRegisterRepositories(IServiceCollection services)
        {
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();
            return services;
        }

        private static IServiceCollection AddRegisterOthers(IServiceCollection services)
        {
            return services;
        }
    }
}
