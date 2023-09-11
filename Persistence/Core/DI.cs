using DomainOrder.Repos;
using Microsoft.Extensions.DependencyInjection;
using Persistence.OrderManagment;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Products;

namespace Persistence.Core
{
    public static class DI
    {
        public static IServiceCollection RegisterPersistence(this IServiceCollection services,string connectionString)
        {           
            services.AddDbContext<OrderContext>((serviceProvider,op) =>op.
            UseSqlServer(connectionString)
            );
            

            services.AddScoped<IrepoOrder, RepoOrder>();
            services.AddScoped<IRepoTaxConfiguration, RepoTaxConfiguration>();
            services.AddScoped<IrepoProduct, RepoProduct>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
