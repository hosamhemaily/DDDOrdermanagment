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
        public DbSet<Product> Products { get; set; }
        public DbSet<TaxOrderConfigurations> TaxOrderConfigurations { get; set; }
        public OrderContext(DbContextOptions<OrderContext> options)
          : base(options)
        {
           
        }     

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<Customer>().HasIndex(prop => prop.Email).IsUnique();
           // modelBuilder.Entity<Wallet>().HasIndex(prop => prop.).IsUnique();

        }

        public override int SaveChanges()
        {
            var response = base.SaveChanges();
            return response;
        }


    }
}
