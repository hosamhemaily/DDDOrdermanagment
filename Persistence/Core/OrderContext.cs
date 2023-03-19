using Domain.Helpers;
using DomainOrder.Orders;
using DomainOrder.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Core
{
    public class OrderContext : DbContext
    {


        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<TaxOrderConfigurations> TaxOrderConfigurations { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options)
          : base(options)
        {
           
        }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var taxconfig = DomainOrder.Orders.TaxOrderConfigurations.Create(new Guid("ec809e3d-d510-4a75-9df5-10ca438a3062") ,10);
            modelBuilder.Entity<TaxOrderConfigurations>().HasData(taxconfig);


        }

        public override int SaveChanges()
        {
            var response = base.SaveChanges();
            return response;
        }


    }
}
