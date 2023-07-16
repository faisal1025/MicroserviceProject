using ProductService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.ProductDataAccess
{
    public class Repository : IRepository
    {
        private ProductData productData;
        public Repository(ProductData productData)
        {
            this.productData = productData;
        }
        public OperationalResult<IEnumerable<Product>> GetAll()
        {
            var products = productData.All();
            return new OperationalResult<IEnumerable<Product>>(products, true, "list of products are successfully fetched.");
        }
        public OperationalResult<Product> AddProduct(Product product)
        {
            var productWithId = productData.Add(product);
            if (productWithId != null)
            {
                OperationalResult<Product> result = new OperationalResult<Product>(productWithId, true, "Product Added successfully");
                return result;
            }
            else
            {
                return new OperationalResult<Product>(productWithId, false, "Product not added");
            }
        }

        public OperationalResult<Product> DeleteProduct(int Id)
        {
            var IsSuccess = productData.Delete(Id);
            if (IsSuccess)
            {
                return new OperationalResult<Product>(IsSuccess, "Product is successfully deleted");
            }
            else
            {
                return new OperationalResult<Product>(IsSuccess, "Product is not deleted. Something went wrong.");
            }
        }

        public OperationalResult<Product> GetById(int Id)
        {
            var product = productData.GetById(Id);
            if (product != null)
                return new OperationalResult<Product>(product, true, "Product available");
            else
                return new OperationalResult<Product>(product, false, "Product not available");
        }
    }
}
