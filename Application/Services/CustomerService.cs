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
    public class CustomerService :IBaseService<Customer>
    {
        private readonly IBaseRepository<Customer> _CustomerRepository;

        public CustomerService(IBaseRepository<Customer> buildingRepository)
        {
            _CustomerRepository = buildingRepository;
        }

        public async Task<Customer> CreateAsync(Customer building, CancellationToken token = default)
        {
            return await _CustomerRepository.CreateAsync(building, token);
        }

        public async Task<bool> DeleteAsync(Customer customers, CancellationToken token = default)
        {
            return await _CustomerRepository.DeleteAsync(customers, token);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken token = default)
        {
            return await _CustomerRepository.GetAllAsync(token);
        }

        public async Task<Customer> GetAsync(int id, CancellationToken token = default)
        {
            return await _CustomerRepository.GetAsync(id, token);
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
         


            return await _CustomerRepository.UpdateAsync(existingCustomer, token);

        }
    }
}
