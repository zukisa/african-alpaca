using System;
using System.Collections.Generic;

namespace MyAspnetCoreAmazone.Service
{
    public class ProductService: IProductService
    {
        private Models.ProductService _productService;

        public ProductService(Models.ProductService ProductService)
        {
            _productService = ProductService;
        }

        public ProductListResponse GetAllProductsFor(ProductListRequest productListRequest)
        {
            ProductListResponse productListResponse = new ProductListResponse();

            try
            {
                IList<Product> productEntities = _productService.GetAllProductsFor(productListRequest.CustomerType);

                productListResponse.Products = productEntities.ConvertProductListViewModel();
                productListResponse.Success = true;
            }
            catch(Exception ex)
            {
                productListResponse.Success = false;
                productListResponse.Message = "An error occured!";
            }

            return productListResponse;
        }
    }
}
