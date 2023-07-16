using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductService.Domain;

namespace ProductService.ProductDataAccess
{
    public interface IRepository
    {
        OperationalResult<IEnumerable<Product>> GetAll();
        OperationalResult<Product> AddProduct(Product product);
        OperationalResult<Product> DeleteProduct(int Id);
        OperationalResult<Product> GetById(int Id);
    }
}
