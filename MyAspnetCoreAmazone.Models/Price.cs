using MyAspnetCoreAmazone.Models;
using System.Collections.Generic;

#nullable disable

namespace MyAspnetCoreAmazone
{
    public partial class Price
    {
        public Price()
        {
            Products = new HashSet<Product>();
        }

        private IDiscountStrategy _discountStrategy = new NullDiscountStrategy();
        private decimal _rrp;
        private decimal _sellingPrice;

        public Price(decimal RRP, decimal SellingPrice)
        {
            _rrp = RRP;
            _sellingPrice = SellingPrice;
            Products = new HashSet<Product>();
        }

        public void SetDiscountStrategyTo(IDiscountStrategy DiscountStrategy)
        {
            _discountStrategy = DiscountStrategy;
        }

        public decimal SellingPrice
        {
            get { return _discountStrategy.ApplyExtraDiscountsTo(_sellingPrice); }
        }

        public decimal RRP
        {
            get { return _rrp; }
        }

        public decimal Discount
        {
            get
            {
                if (RRP > SellingPrice)
                    return (RRP - SellingPrice);
                else
                    return 0;
            }
        }

        public decimal Savings
        {
            get
            {
                if (RRP > SellingPrice)
                    return 1 - (SellingPrice / RRP);
                else
                    return 0;
            }
        }
        public int PriceId { get; set; }
        //public decimal SellingPrice { get; set; }
        public decimal Rrp { get; set; }
        //public decimal Discount { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
