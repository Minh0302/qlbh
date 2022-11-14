using Test.Entities;
using Test.Models;

namespace Test.Services
{
    public interface IProductService
    {
        public IEnumerable<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void CreateProduct(ProductModel product);
        public void UpdateProduct(ProductModel product);
        public void DeleteProduct(ProductModel product);
    }
}
