using BAL.Model;
using DAL;
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
        public ProductService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Product AddProduct(Product product)
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

        public Product EditProduct(Product product)
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

        public List<Product> GetAllProducts()
        {
            var getProducts = _dbContext.Products.ToList();
            var resProduct = new List<Product>();
            foreach(var _ in getProducts)
            {
                var mappedProduct = new Product
                {
                    Id = _.Id,
                    Meaning = _.Meaning,
                    Name = _.Name
                };
                resProduct.Add(mappedProduct);
            }
            return resProduct;
        }
    }
}
