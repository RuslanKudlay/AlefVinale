using AutoMapper;
using BAL.Model;
using DAL;
using DAL.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly Mapper _autoMapper;
        public ProductService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            var mapperConfig = new MapperConfiguration(_ =>
            {
                _.CreateMap<Product, ProductModel>();
            });
            _autoMapper = new Mapper(mapperConfig);
        }
        public ProductModel AddProduct(ProductModel product)
        {
            var newProduct = new DAL.Entityes.Product
            {
                Meaning = product.Meaning,
                Name = product.Name
            };
            _dbContext.Products.Add(newProduct);
            _dbContext.SaveChanges();
            return product;

        }

        public ProductModel EditProduct(ProductModel product)
        {
            var editProduct = _dbContext.Products.FirstOrDefault(_ => _.Id == product.Id);

            if (editProduct != null)
            {
                editProduct.Meaning = product.Meaning;
                editProduct.Name = product.Name;

                _dbContext.Products.Update(editProduct);
                _dbContext.SaveChanges();
                return product;
            }
            else
            {
                return null;
            }
        }

        public List<ProductModel> GetAllProducts()
        {
            var getProducts = _dbContext.Products.ToList();
            var resProduct = _autoMapper.Map<List<Product>, List<ProductModel>>(getProducts);
            return resProduct;
        }
    }
}
