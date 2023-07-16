using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductDetailService.Domain
{
    public class OperationalResult<TDomain>
    {
        public bool IsSuccess { get; set; }
        public string Text { get; set; }
        public TDomain productDetail { get; set; }
        public OperationalResult()
        {

        }
        public OperationalResult(bool IsSuccess, string Text)
        {
            this.IsSuccess = IsSuccess;
            this.Text = Text;
        }
        public OperationalResult(TDomain productDetail, bool IsSuccess, string Text)
        {
            this.productDetail = productDetail;
            this.IsSuccess = IsSuccess;
            this.Text = Text;
        }
    }
}
