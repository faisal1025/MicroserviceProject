using ProductDetailService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailService.ProductDetailDataAccess
{
    public interface IRepository
    {
        OperationalResult<ProductDetail> AddDetails(ProductDetail productDetail);
        OperationalResult<ProductDetail> GetProductDetail(int ProductId);
        OperationalResult<ProductDetail> DeleteProductDetail(int ProductId);
        OperationalResult<ProductDetail> UpdateProductDetail(int ProductId, ProductDetail productDetail);
    }
}
