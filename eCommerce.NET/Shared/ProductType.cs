using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.NET.Shared
{
    public class ProductType
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; } = string.Empty;
    }
}
