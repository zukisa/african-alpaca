using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyAspnetCoreAmazone.Service;

namespace MyAspnetCoreAmazone.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyAspnetCoreAmazone : ControllerBase
    {
        private IProductService _productService;
        private readonly ILogger<MyAspnetCoreAmazone> _logger;

        public MyAspnetCoreAmazone(IProductService productService, ILogger<MyAspnetCoreAmazone> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [HttpGet("GetAllProductsFor")]
        public ProductListResponse GetAllProductsFor([FromBody] ProductListRequest productListRequest)
        {
            ProductListResponse result = null;
            try
            {
                result = _productService.GetAllProductsFor(productListRequest);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error in GetBsysSwapBySessionID endpoint with ex message : " + ex.Message + "ex inner message " + ex?.InnerException?.Message + "Ex stactrace " + ex.StackTrace);
            }
            return result;
        }
    }
}
