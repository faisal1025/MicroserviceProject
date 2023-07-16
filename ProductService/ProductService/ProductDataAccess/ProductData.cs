using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.ProductDataAccess
{
    public class ProductData
    {
        private readonly IList<Product> products = new List<Product>();
        public IEnumerable<Product> All()
        {
            return products;
        }
        public Product Add(Product product)
        {
            try
            {
                var cnt = products.Count();
                product.Id = cnt == 0 ? 1 : products[cnt-1].Id + 1;
                products.Add(product);
                return product;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Delete(int Id)
        {
            try
            {
                var product = products.FirstOrDefault(p => p.Id == Id);
                products.Remove(product);
                Console.WriteLine(products.Count());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Product GetById(int Id)
        {
            return products.FirstOrDefault<Product>(p => p.Id == Id);
        }
    }
}
