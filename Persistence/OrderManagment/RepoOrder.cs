﻿using DomainOrder.Orders;
using DomainOrder.Products;
using DomainOrder.Repos;
using Persistence.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Persistence.OrderManagment
{
    public class RepoOrder : IrepoOrder
    {
        OrderContext _orderContext;
        public RepoOrder(OrderContext orderContext)
        {
            _orderContext= orderContext;
        }
        public Guid add(Order order)
        {
            _orderContext.Add(order);
            return order.Id;
        }

        public bool delete()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetById(Guid id)
        {
            var order = _orderContext.Orders.Find(id);
            return order;
        }

        public bool update(Order order)
        {
            _orderContext.Update(order);
            _orderContext.SaveChanges();
            return true;
        }
    }
}
