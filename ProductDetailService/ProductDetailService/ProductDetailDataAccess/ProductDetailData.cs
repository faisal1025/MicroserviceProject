using ProductDetailService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailService.ProductDetailDataAccess
{
    public class ProductDetailData
    {
        private IList<ProductDetail> productDetails = new List<ProductDetail>();
        public bool Add(ProductDetail productDetail)
        {
            try
            {
                productDetails.Add(productDetail);
                Console.WriteLine(productDetails.Count());
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(int ProductId)
        {
            try
            {
                var productDetail = productDetails.FirstOrDefault<ProductDetail>(p => p.ProductId == ProductId);
                productDetails.Remove(productDetail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public ProductDetail GetProductDetail(int ProductId)
        {
            return productDetails.FirstOrDefault(p => p.ProductId == ProductId);
        }
        public bool Update(int ProductId, ProductDetail productDetail)
        {
            try
            {
                productDetail.ProductId = ProductId;
                this.Delete(ProductId);
                this.Add(productDetail);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
