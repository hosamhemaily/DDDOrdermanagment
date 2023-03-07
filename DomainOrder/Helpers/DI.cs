using DomainOrder.Orders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Helpers
{
    public static class DI
    {
        public static IServiceCollection RegisterDomain(this IServiceCollection services)
        {
            services.AddScoped<IOrderManager, OrderManager>();
            return services;
        }
    }
}
