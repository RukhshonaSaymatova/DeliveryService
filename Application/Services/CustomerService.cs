using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Services
{
    public class CustomerService : IBaseService<Customer>
    {
        private readonly IBaseRepository<Customer> _customerRepository;

        public CustomerService(IBaseRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }


        public async Task<Customer> CreateAsync(Customer customer, CancellationToken token = default)
        {
            return await _customerRepository.CreateAsync(customer, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var customer = await _customerRepository.GetAsync(id, token);

            if (customer == null)
                return false;

            return await _customerRepository.DeleteAsync(customer, token);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken token = default)
        {
            return await _customerRepository.GetAllAsync(token);
        }

        public async Task<Customer> GetAsync(int id, CancellationToken token = default)
        {
            return await _customerRepository.GetAsync(id, token);
        }
        public async Task<bool> UpdateAsync(Customer customers, CancellationToken token = default)
        {
            var existingCustomer = await GetAsync(customers.Id);

            if (existingCustomer is null)
            {
                return false;
            }

            existingCustomer.Name = customers.Name;
            existingCustomer.Email = customers.Email;
            existingCustomer.Address = customers.Address;
         


            return await _customerRepository.UpdateAsync(existingCustomer, token);

        }
    }
}
