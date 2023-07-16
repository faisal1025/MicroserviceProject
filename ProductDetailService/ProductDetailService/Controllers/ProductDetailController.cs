using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductDetailService.Domain;
using ProductDetailService.ProductDetailDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductDetailController : Controller
    {
        private readonly ILogger<ProductDetailController> logger;
        private readonly IRepository repository;
        public ProductDetailController(ILogger<ProductDetailController> logger, IRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
        public IActionResult Index()
        {
            var res = new OperationalResult<ProductDetail>(true, "this is product detail");
            return Json(res);
        }

        [HttpGet("detail/{id}")]
        public IActionResult GetProductDetail(int ProductId)
        {
            var res = repository.GetProductDetail(ProductId);
            return Json(res);
        }
    }
}
