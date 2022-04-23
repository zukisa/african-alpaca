namespace MyAspnetCoreAmazone.Models
{
    public class TradeDiscountStrategy: IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice)
        {
            decimal price = OriginalSalePrice;

            price = price * 0.95M;

            return price;
        }
    }
}
