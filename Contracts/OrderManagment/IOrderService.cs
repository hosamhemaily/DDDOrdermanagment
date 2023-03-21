using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.OrderManagment
{
    public interface IOrderService
    {
        public Guid? CreateOrder(OrderDTO order);
        public bool CancelOrder(string id);
    }
}
