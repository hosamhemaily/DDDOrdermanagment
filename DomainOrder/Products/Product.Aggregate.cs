using Domain.Helpers;
using DomainOrder.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Products
{
    public partial class Product: IAggregateRoot
    {
        public static Product Create(string Name,decimal Minimum,Guid ID) 
        {
            Product product = new Product
            {
                Name = Name,
                MinimumQuantity = Minimum,
                ExpiryDate = DateTime.Now,
                Id = ID
            };
            return product;
        }
    }
}
