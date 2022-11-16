using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual Category? Category { get; set; }
        public virtual int CategoryId { get; set; }
        public virtual bool Featured { get; set; } = false;
        public virtual List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
    }
}
