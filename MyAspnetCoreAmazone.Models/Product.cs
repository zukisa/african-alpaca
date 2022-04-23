#nullable disable

using System.ComponentModel.DataAnnotations.Schema;

namespace MyAspnetCoreAmazone
{
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        [NotMapped]
        public decimal RRP { get; set; }
        [NotMapped]
        public decimal SellingPrice { get; set; }
        public int? PriceId { get; set; }

        public virtual Price Price { get; set; }
    }
}
