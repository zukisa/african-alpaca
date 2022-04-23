namespace MyAspnetCoreAmazone.Models
{
    public class NullDiscountStrategy:IDiscountStrategy
    {
        public decimal ApplyExtraDiscountsTo(decimal OriginalSalePrice)
        {
            return OriginalSalePrice;
        }
    }
}
