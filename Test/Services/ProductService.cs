using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using Test.Entities;
using Test.Helpers;
using Test.Models;
using Test.Paging;
using Test.Repositories;

namespace Test.Services
{
    public class ProductService :IProductService
    {
        private readonly IGenerictRepository<Product> _generictRepository;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;

        public ProductService(IGenerictRepository<Product> generictRepository, IMapper mapper, ILoggerManager logger)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public bool CreateProduct(ProductModel product)
        {
            var newProduct = _mapper.Map<Product>(product);
            try
            {
                _logger.LogInfo("ProductService: CreateProduct");
                _generictRepository.Create(newProduct);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("ProductService: CreateProduct" + ex);
                return false;
            }
        }

        public bool DeleteProduct(int id)
        {
            //var delProduct = _mapper.Map<Product>(product);
            try
            {
                _generictRepository.DeleteById(id);
                return true;
            }
            catch
            {
                return false;
            }
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

        public bool UpdateProduct(ProductModel product)
        {
            var updateProduct = _mapper.Map<Product>(product);
            try
            {
                _generictRepository.Update(updateProduct);
                return true;
            }
            catch
            {
                return false;
            }
        }
        //public IEnumerable<ProductModel> PaginateProducts(int? page, int pageSize = 10)
        //{
        //    var product = _generictRepository.paginate(page, pageSize);
        //    return _mapper.Map<List<ProductModel>>(product);
        //}
        public async Task<PagedList<Product>> GetProductPaging(PagingParameters pagingParameters)
        {
            return await Task.FromResult(PagedList<Product>.GetPagedList(_generictRepository.FindAll().OrderBy(s => s.Id), pagingParameters.PageNumber, pagingParameters.PageSize));
        }
    }
}
