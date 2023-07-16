using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductDtos;
using ProductService.Domain;
using ProductService.ProductDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private ILogger<ProductController> logger;
        private IRepository repository;
        private readonly IPublishEndpoint publishEndpoint;
        public ProductController(IRepository repository, ILogger<ProductController> logger, IPublishEndpoint publishEndpoint)
        {
            this.repository = repository;
            this.logger = logger;
            this.publishEndpoint = publishEndpoint;
        }
        public IActionResult Index()
        {
            var res = repository.GetAll();
            return Json(res);
        }

        [HttpPost("add")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct(ProductDto productDto)
        { 
            Product product = new Product(productDto.ProductName, productDto.Category, productDto.Price);
            var res = repository.AddProduct(product);
            productDto.Id = res.Product.Id;
            productDto.Operation = "Insert";
            await publishEndpoint.Publish<ProductDto>(productDto);
            return Json(productDto);
        }

        [HttpDelete("delete/{id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var res = repository.DeleteProduct(Id);
            ProductDto productDto = new ProductDto();
            productDto.Id = Id;
            productDto.Operation = "Delete";
            await publishEndpoint.Publish<ProductDto>(productDto);
            return Json(res);
        }

        [HttpPost("add/detail/{id}")]
        // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> AddDetail(int Id, ProductDto productDto)
        {
            var res = repository.GetById(Id);
            productDto.Operation = "Insert";
            if (res.IsSuccess)
            {
                productDto.Id = res.Product.Id;
                await publishEndpoint.Publish<ProductDto>(productDto);
                return Json(new OperationalResult<Product>(true, "Product Detail Added Successfully"));
            }
            else
            {
                return Json(res);
            }
        }

        [HttpDelete("delete/detail/{id}")]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDetail(int Id)
        {
            var res = repository.GetById(Id);
            ProductDto productDto = new ProductDto();
            productDto.Operation = "Delete";
            if (res.IsSuccess)
            {
                productDto.Id = res.Product.Id;
                await publishEndpoint.Publish<ProductDto>(productDto);
                return Json(new OperationalResult<Product>(true, "Product Detail deleted Successfully"));
            }
            else
            {
                return Json(res);
            }
        }
    }
}
