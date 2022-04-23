using Microsoft.EntityFrameworkCore;
using MyAspnetCoreAmazone.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyAspnetCoreAmazone.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyAspnetCoreAmazoneContext _ctx;
        private readonly bool _disposeContext;
        
        public ProductRepository(MyAspnetCoreAmazoneContext context)
        {
            _ctx = context;
        }

        public ProductRepository(DbContextOptions<MyAspnetCoreAmazoneContext> options): this (new MyAspnetCoreAmazoneContext(options))
        {
            _disposeContext = true;
        }

        public virtual void Dispose()
        {
            if (_disposeContext)
            {
                _ctx.Dispose();
            }
        }

        public IList<Product> FindAll()
        {
            var products = from p in _ctx.Products
                           select new Product
                           {
                               ProductId = p.ProductId,
                               ProductName = p.ProductName,
                               Price = new Price(p.RRP, p.SellingPrice)
                           };
            return products.ToList();
        }
    }
}
