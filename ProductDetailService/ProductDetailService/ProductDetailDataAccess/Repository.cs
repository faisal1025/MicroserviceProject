using ProductDetailService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailService.ProductDetailDataAccess
{
    public class Repository : IRepository
    {
        private ProductDetailData productDetailData;
        public Repository(ProductDetailData productDetailData)
        {
            this.productDetailData = productDetailData;
        }
        public OperationalResult<ProductDetail> AddDetails(ProductDetail productDetail)
        {
            var IsSuccess = productDetailData.Add(productDetail);
            if (IsSuccess)
            {
                return new OperationalResult<ProductDetail>(IsSuccess, "Product detail is successfully added.");
            }
            else
            {
                return new OperationalResult<ProductDetail>(IsSuccess, "Some internal issue product not added.");
            }
        }

        public OperationalResult<ProductDetail> DeleteProductDetail(int ProductId)
        {
            var IsSuccess = productDetailData.Delete(ProductId);
            if (IsSuccess)
            {
                return new OperationalResult<ProductDetail>(IsSuccess, "Product details deleted successfully.");
            }
            else
            {
                return new OperationalResult<ProductDetail>(IsSuccess, "Some internal issue product not deleted.");
            }
        }

        public OperationalResult<ProductDetail> GetProductDetail(int ProductId)
        {
            var productDetail = productDetailData.GetProductDetail(ProductId);
            if(productDetail != null)
            {
                return new OperationalResult<ProductDetail>(productDetail, true, "product is fetched successfully");
            }
            else
            {
                return new OperationalResult<ProductDetail>(productDetail, false, "product details not exist.");
            }
        }

        public OperationalResult<ProductDetail> UpdateProductDetail(int ProductId, ProductDetail productDetail)
        {
            var IsSuccess = productDetailData.Update(ProductId, productDetail);
            if (IsSuccess)
            {
                return new OperationalResult<ProductDetail>(IsSuccess, "Product detail updated successfully");
            }
            else
            {
                return new OperationalResult<ProductDetail>(IsSuccess, "Product detail not updated.");
            }
        }
    }
}
