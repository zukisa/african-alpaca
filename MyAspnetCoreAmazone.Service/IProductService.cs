namespace MyAspnetCoreAmazone.Service
{
    public interface IProductService
    {
        ProductListResponse GetAllProductsFor(ProductListRequest productListRequest);
    }
}
