using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailService.Domain
{
    public class ProductDetail
    {
        public int ProductId { get; set; }
        public string Design { get; set; }
        public double? Size { get; set; }
        public string Color { get; set; }
        public int Warranty { get; set; }
    }
}
