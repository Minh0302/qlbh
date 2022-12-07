using Test.Entities;
using Test.Models;
using Test.Paging;

namespace Test.Services
{
    public interface IProductService
    {
        public IEnumerable<ProductModel> GetAllProducts();
        public ProductModel GetProductById(int id);
        public bool CreateProduct(ProductModel product);
        public bool UpdateProduct(ProductModel product);
        public bool DeleteProduct(int id);
        //Task<PagedList<Product>> GetProductPaging(PagingParameters pagingParameters);
        PagedList<Product> PaginateProducts(PagingParameters pagingParameters);
    }
}
