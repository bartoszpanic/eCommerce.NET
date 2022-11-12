using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.NET.Shared
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; } = string.Empty;
        public virtual string Description { get; set; } = string.Empty;
        public virtual string ImageUrl { get; set; } = string.Empty;
        public virtual decimal Price { get; set; } 
    }
}
