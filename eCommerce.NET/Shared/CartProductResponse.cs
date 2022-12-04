using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.NET.Shared
{
    public class CartProductResponse
    {
        public virtual int ProductId { get; set; }
        public virtual string Title { get; set; } = string.Empty;
        public virtual int ProductTypeId { get; set; }
        public virtual string ProductType { get; set; } = string.Empty;
        public virtual string ImageUrl { get; set; } = string.Empty;
        public virtual decimal Price { get; set; }
    }
}
