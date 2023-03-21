using DomainOrder.Products;
using DomainOrder.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Data;
using System.Text.Json;
using DomainOrder.Orders;
using Contract;

namespace Infrastructure.Products
{
    public class RepoProduct : IrepoProduct
    {
        HttpClient client = new HttpClient();
        string path = "https://localhost:7152";
        public bool add(Product product)
        {
            throw new NotImplementedException();
        }

        public bool delete()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            try
            {
                IList<Product> products = new List<Product>();

                HttpResponseMessage response = client.GetAsync(path + $"/Product").Result;
                if (response.IsSuccessStatusCode)
                {
                    var myproducts = JsonSerializer.Deserialize<List<ProductGetBase>>(response.Content.ReadAsStream());
                    myproducts?.ForEach(element =>
                    {
                        var p = Product.Create(element.name, element.minimumQuantity, element.productId, element.sellPrice);
                        products.Add(p);
                    });
                };
                return products;
            }
            catch (Exception)
            {

                return new List<Product>();
            }
          
            
        }

        public IList<Product> GetAllByIds(Guid[] ids)
        {
            var products = GetAll();
            return products.Where(x=>ids.Contains( x.Id)).ToList();
        }

        public Product GetById()
        {
            throw new NotImplementedException();
        }

        public bool update()
        {
            throw new NotImplementedException();
        }
    }
}
