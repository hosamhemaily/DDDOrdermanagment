using Contracts.OrderManagment;
using DomainOrder.Orders;
using DomainOrder.Products;
using DomainOrder.Repos;
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
        public OrderService(IrepoOrder repoOrder, IRepoTaxConfiguration repoTaxConfig, IrepoProduct repoProduct,
            IOrderManager orderManager) 
        {
            _repoProduct = repoProduct;
            _repoOrder = repoOrder;
            _repoTaxConfig = repoTaxConfig;
            _orderManager = orderManager;
        }
        public bool CancelOrder(string id)
        {
            throw new NotImplementedException();
        }

        public bool CreateOrder(OrderDTO order)
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
            bool resultValidation =  _orderManager.ValidateCreateOrder(resultCreateOrder, products.ToList());
            if (!resultValidation)
            {
                throw new Exception("Not valid order !!");
            }
            _repoOrder.add(resultCreateOrder);
            return true;
        }
    }
}
