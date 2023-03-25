using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.OrderManagment
{
    public class OrderToQueue
    {
        public OrderDTO Order { get; set; }
        public Guid Id { get; set; }
    }
}
