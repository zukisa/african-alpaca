using System.Collections.Generic;

namespace MyAspnetCoreAmazone.Models
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IList<Product> GetAllProductsFor(CustomerType customerType)
        {
            IDiscountStrategy discountStrategy = DiscountFactory.GetDiscountStrategyFor(customerType);
            IList<Product> products = _productRepository.FindAll();

            products.Apply(discountStrategy);

            return products;
        }
    }
}
