using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.OrderManagment
{
    public class OrderDTO
    {        
        public List<ProductOrderDTO>? Products { get; set; }
        public decimal TotalAmount { get; set; }
        public string CustomerID { get; set; }
    }

    public class ProductOrderDTO
    {
        public Guid ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
