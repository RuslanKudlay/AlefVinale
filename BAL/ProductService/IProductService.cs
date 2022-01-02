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
        List<ProductModel> GetAllProducts();
        ProductModel AddProduct(ProductModel product);
        ProductModel EditProduct(ProductModel product);
    }
}
