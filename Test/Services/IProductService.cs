using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductModel> GetAllProducts();
        public ProductModel GetProductById(int id);
        public bool CreateProduct(ProductModel product);
        public bool UpdateProduct(ProductModel product);
        public bool DeleteProduct(int id);
    }
}
