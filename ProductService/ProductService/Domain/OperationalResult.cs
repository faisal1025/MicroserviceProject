using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.Domain
{
    public class OperationalResult<TDomain>
    {
        public string Text { get; set; }
        public bool IsSuccess { get; set; }
        public TDomain Product { get; set; }

        public OperationalResult()
        {

        }
        public OperationalResult(bool IsSuccess, string Text)
        {
            this.IsSuccess = IsSuccess;
            this.Text = Text;
        }
        public OperationalResult(TDomain Product, bool IsSuccess, string Text)
        {
            this.Product = Product;
            this.IsSuccess = IsSuccess;
            this.Text = Text;
        }
    }
}
