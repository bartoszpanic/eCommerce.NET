using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eCommerce.NET.Shared
{
    public class ProductVariant
    {
        [JsonIgnore]
        public virtual Product Product { get; set; }
        public virtual int ProductId { get; set; }
        public virtual ProductType ProductType { get; set; }
        public virtual int ProductTypeId { get; set; }

        [Column(TypeName ="decimal(18,2")]
        public virtual decimal Price { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public virtual decimal OriginalPrice { get; set; }

    }
}
