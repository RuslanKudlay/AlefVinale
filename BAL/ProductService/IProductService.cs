using BAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL.ProductService
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product EditProduct(Product product);
    }
}
