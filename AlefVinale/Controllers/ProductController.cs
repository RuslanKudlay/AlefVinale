﻿using BAL.Model;
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
        public ActionResult<ProductModel> PostProduct(ProductModel product)
        {
            return _productService.AddProduct(product);
        }

        [HttpPut]
        public ActionResult<ProductModel> Putproduct(ProductModel product)
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
        public ActionResult<List<ProductModel>> GetProduct()
        {
            return _productService.GetAllProducts();
        }
    }
}
