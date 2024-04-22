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


        public async Task<Customer> CreateAsync(Customer building, CancellationToken token = default)
        {
            return await _customerRepository.CreateAsync(building, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var anime = await _customerRepository.GetAsync(id, token);

            if (anime == null)
                return false;

            return await _customerRepository.DeleteAsync(anime, token);
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
