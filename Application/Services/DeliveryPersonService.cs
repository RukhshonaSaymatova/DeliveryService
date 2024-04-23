using Domain.Entities;
using Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class DeliveryPersonService : IBaseService<DeliveryPerson>
    {
        private readonly IBaseRepository<DeliveryPerson> _deliveryPersonRepository;

        public DeliveryPersonService(IBaseRepository<DeliveryPerson> deliveryPersonRepository)
        {
            _deliveryPersonRepository = deliveryPersonRepository;
        }


        public async Task<DeliveryPerson> CreateAsync(DeliveryPerson person, CancellationToken token = default)
        {
            return await _deliveryPersonRepository.CreateAsync(person, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var person = await _deliveryPersonRepository.GetAsync(id, token);

            if (person == null)
                return false;

            return await _deliveryPersonRepository.DeleteAsync(person, token);
        }

        public async Task<IEnumerable<DeliveryPerson>> GetAllAsync(CancellationToken token = default)
        {
            return await _deliveryPersonRepository.GetAllAsync(token);
        }

        public async Task<DeliveryPerson> GetAsync(int id, CancellationToken token = default)
        {
            return await _deliveryPersonRepository.GetAsync(id, token);
        }
        public async Task<bool> UpdateAsync(DeliveryPerson deliveryPersons, CancellationToken token = default)
        {
            var existingDeliveryPerson = await GetAsync(deliveryPersons.Id);

            if (existingDeliveryPerson is null)
            {
                return false;
            }

            existingDeliveryPerson.Name = deliveryPersons.Name;
            existingDeliveryPerson.Email = deliveryPersons.Email;
            existingDeliveryPerson.ContactInfo = deliveryPersons.ContactInfo;



            return await _deliveryPersonRepository.UpdateAsync(existingDeliveryPerson, token);

        }
    }
}
