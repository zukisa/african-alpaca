using System.Collections.Generic;

namespace MyAspnetCoreAmazone.Models
{
    public interface IProductService
    {
        IList<Product> GetAllProductsFor(CustomerType customerType);
    }
}