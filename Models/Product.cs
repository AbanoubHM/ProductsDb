using System;
using System.Collections.Generic;

namespace ProductsDb.Models
{
    public partial class Product
    {
        public int ProdectId { get; set; }
        public string? Name { get; set; }
        public string? Desce { get; set; }
        public decimal? Price { get; set; }
        public int? Qnt { get; set; }
        public string? Image { get; set; }
        public int CatId { get; set; }

        public virtual Category Cat { get; set; } = null!;
    }
}
