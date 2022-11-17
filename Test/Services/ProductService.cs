using AutoMapper;
using System;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class ProductService :IProductService
    {
        private readonly IGenerictRepository<Product> _generictRepository;
        private readonly IMapper _mapper;

        public ProductService(IGenerictRepository<Product> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }

        public void CreateProduct(ProductModel product)
        {
            var newProduct = _mapper.Map<Product>(product);
            _generictRepository.Create(newProduct);
        }

        public void DeleteProduct(int id)
        {
            //var delProduct = _mapper.Map<Product>(product);
            _generictRepository.DeleteById(id);

        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            var products = _generictRepository.GetAll();
            return _mapper.Map<List<ProductModel>>(products);
        }

        public ProductModel GetProductById(int id)
        {
            var product = _generictRepository.GetById(id);
            return _mapper.Map<ProductModel>(product);
        }

        public void UpdateProduct(ProductModel product)
        {
            var updateProduct = _mapper.Map<Product>(product);
            _generictRepository.Update(updateProduct);
        }
    }
}
