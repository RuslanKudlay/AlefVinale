using BAL.Model;
using BAL.ProductService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AlefVinale.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
        {
            return _productService.AddProduct(product);
        }

        [HttpPut]
        public ActionResult<Product> Putproduct(Product product)
        {
            var editProduct = _productService.EditProduct(product);
            if (editProduct != null)
            {
                return editProduct;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProduct()
        {
            return _productService.GetAllProducts();
        }
    }
}
