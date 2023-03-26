using Contracts.OrderManagment;
using DomainOrder.Orders;
using DomainOrder.Products;
using DomainOrder.Repos;
using MassTransit;
using Newtonsoft.Json;
using RabbitMQ.Client;
using SharedAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderManagment
{
    public class OrderService : IOrderService
    {
        IOrderManager _orderManager;
        IrepoOrder _repoOrder;
        IrepoProduct _repoProduct;
        IRepoTaxConfiguration _repoTaxConfig;
        private readonly IPublishEndpoint _publishEndpoint;

        public OrderService(IrepoOrder repoOrder, IRepoTaxConfiguration repoTaxConfig, IrepoProduct repoProduct,
            IOrderManager orderManager, IPublishEndpoint publishEndpoint) 
        {
            _repoProduct = repoProduct;
            _repoOrder = repoOrder;
            _repoTaxConfig = repoTaxConfig;
            _orderManager = orderManager;
            _publishEndpoint = publishEndpoint;
        }
        public bool CancelOrder(string id)
        {
            throw new NotImplementedException();
        }

        public Guid? CreateOrder(OrderDTO order)
        {
            var tax =  _repoTaxConfig.GetAll().FirstOrDefault();
            
            List<OrderProduct> orderProducts = new List<OrderProduct>();
            order.Products?.ForEach(orderproduct =>
            {
                orderProducts.Add(OrderProduct.CreateOrderProduct(
                    ProductID: orderproduct.ProductID,
                    Quantity: orderproduct.Quantity));
            });

           var resultCreateOrder=  Order.CreateOrder(
                guid: new Guid(),
                orderAmountNet:order.TotalAmount,
                taxes: tax == null ? 0 :  tax.TaxPercentage,
            customer:order.CustomerID,
                orderProducts: orderProducts

                );

            var products =  _repoProduct.GetAll();
           
             var resultvalidation =  _orderManager.ValidateCreateOrder(resultCreateOrder, products.ToList());
            //if (!resultValidation)
            //{
            //    throw new Exception("Not valid order !!");
            //}
            if (resultvalidation)
            {
                var result = _repoOrder.add(resultCreateOrder);
               
                _publishEndpoint.Publish(new OrderCreated
                {
                    ID = result,
                    Products = order.Products.Select(x => new ProductDTO { productid = x.ProductID, quantity = x.Quantity }).ToList()
                });
                return result;
            }
            return null;
            
        }
    }
}
