using System;

namespace ProductDtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Operation { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double? Price { get; set; }
        public string Design { get; set; }
        public double? Size { get; set; }
        public string Color { get; set; }
        public int Warranty { get; set; }
    }
}
