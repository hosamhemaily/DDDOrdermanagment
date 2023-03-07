using Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainOrder.Orders
{
    public partial class Order : Entity
    {
        public decimal? OrderAmountNet { get; protected set; }
        public string? CustomerID { get; protected set; }
        public decimal? TotalTaxes { get; protected set; }
        public decimal? TotalAmount { get; protected set; }
        public bool? Canceled_YN { get; protected set; }
        public List<OrderProduct>? products { get; protected set; }
       
    }
}
