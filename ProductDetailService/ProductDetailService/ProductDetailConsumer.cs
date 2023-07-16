using MassTransit;
using Microsoft.Extensions.Logging;
using ProductDetailService.Domain;
using ProductDetailService.ProductDetailDataAccess;
using ProductDtos;
using System;
using System.Threading.Tasks;

namespace ProductDetailService
{
    internal class ProductDetailConsumer : IConsumer<ProductDto>
    {
        private readonly ILogger<ProductDetailConsumer> logger;
        private readonly IRepository repository;
        private readonly IPublishEndpoint publishEndpoint;
        public ProductDetailConsumer(ILogger<ProductDetailConsumer> logger, IRepository repository, IPublishEndpoint publishEndpoint)
        {
            this.logger = logger;
            this.repository = repository;
            this.publishEndpoint = publishEndpoint;
        }
        public async Task Consume(ConsumeContext<ProductDto> context)
        {
            switch (context.Message.Operation)
            {
                case "Insert":
                    logger.LogInformation($"Got new message {context.Message.Operation}");
                    var res = repository.GetProductDetail(context.Message.Id);
                    ProductDetail productDetail = new ProductDetail();
                    productDetail.ProductId = context.Message.Id;
                    productDetail.Color = context.Message.Color;
                    productDetail.Design = context.Message.Design;
                    productDetail.Size = context.Message.Size;
                    productDetail.Warranty = context.Message.Warranty;
                    if (res.IsSuccess)
                    {
                        repository.UpdateProductDetail(context.Message.Id, productDetail);
                    }
                    else
                    {
                        repository.AddDetails(productDetail);
                    }
                    await Console.Out.WriteLineAsync("Product details are added successfully.");
                    break;
                case "Delete":
                    logger.LogInformation($"Got new message {context.Message.Operation}");
                    var Id = context.Message.Id;
                    repository.DeleteProductDetail(Id);
                    await Console.Out.WriteLineAsync("Product details are deleted.");
                    break;
                default:
                    break;
            }
        }
    }
}