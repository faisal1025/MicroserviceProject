using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.Domain
{
    public class OperationalResult<TEntity>
    {
        public string text { get; set; }
        public bool IsSuccess { get; set; }
        public TEntity user { get; set; }
        public OperationalResult()
        {

        }
        public OperationalResult(TEntity user, bool IsSuccess, string text)
        {
            this.user = user;
            this.IsSuccess = IsSuccess;
            this.text = text;
        }
        public OperationalResult(bool IsSuccess, string text)
        {
            this.text = text;
            this.IsSuccess = IsSuccess;
        }
    }
}
