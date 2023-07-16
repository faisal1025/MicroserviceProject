using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double? Price { get; set; }

        public Product(string ProductName, string Category, double? Price)
        {
            this.ProductName = ProductName;
            this.Category = Category;
            this.Price = Price;
        }
    }
}
