using Domain.IRepository;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class RegisterRepositoryDependency
    {
        public static IServiceCollection GetRepositoryDependency(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<Context>(options =>
                options.UseSqlServer(configuration.GetConnectionString("artifactDbContext")));

            

            services.AddScoped<IUserRepository, UserRepository>();
            //services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductRepository, AdoProductRepository>();

            return services;
        }


    }
}
