using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.BusinessRule;
using Application.IBusinessRule;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class RegisterBusinessDependency
    {
        public static IServiceCollection GetBusinessRuleDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserOperationRule, UserOperationRule>();

            services.AddScoped<IProductOperationRule, ProductOperationRule>();

            return services;
        }
    }
}
