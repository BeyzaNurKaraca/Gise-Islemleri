using GiseIslemleri.Entity;
using GiseIslemleri.Repository.Abstract;
using GiseIslemleri.Repository.Concrete;
using GiseIslemleri.UnitOfWork.Abstract;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiseIslemleri.UnitOfWork.Extensions
{
    public static class RepositoryService
    {
        public static IServiceCollection AddRepositoryService(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<IBillRepository, BillRepository>();
            services.AddScoped<IUnitOfWork, Concrete.UnitOfWork>();
            services.AddScoped<User>();
            services.AddScoped<Subscriptions>();
            return services;
        }
    }
}