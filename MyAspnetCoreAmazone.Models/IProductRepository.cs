using System.Collections.Generic;

namespace MyAspnetCoreAmazone.Models
{
    public interface IProductRepository
    {
        IList<Product> FindAll();
    }
}
