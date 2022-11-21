﻿using AutoMapper;
using Test.Entities;
using Test.Models;
using Test.Repositories;

namespace Test.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IGenerictRepository<Customer> _generictRepository;
        private readonly IMapper _mapper;

        public CustomerService(IGenerictRepository<Customer> generictRepository, IMapper mapper)
        {
            _generictRepository = generictRepository;
            _mapper = mapper;
        }
        public bool CreateCustomer(CustomerModel customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            try
            {
                _generictRepository.Create(newCustomer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteCustomer(int id)
        {
            //var deCustomer= _mapper.Map<Customer>(customer);
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

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            var customers = _generictRepository.GetAll().AsQueryable().ToList();
            return _mapper.Map<List<CustomerModel>>(customers);
        }

        public CustomerModel GetCustomerById(int id)
        {
            var customer = _generictRepository.GetById(id);
            return _mapper.Map<CustomerModel>(customer);
        }

        public bool UpdateCustomer(CustomerModel customer)
        {
            var updateCustomer = _mapper.Map<Customer>(customer);
            try
            {
                _generictRepository.Update(updateCustomer);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
