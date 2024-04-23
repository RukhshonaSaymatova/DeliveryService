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
    public class DeliveryServiceService : IBaseService<DeliveryService>
    {
        private readonly IBaseRepository<DeliveryService> _deliveryServiceRepository;

        public DeliveryServiceService(IBaseRepository<DeliveryService> deliveryServiceRepository)
        {
            _deliveryServiceRepository = deliveryServiceRepository;
        }


        public async Task<DeliveryService> CreateAsync(DeliveryService deliveryService, CancellationToken token = default)
        {
            return await _deliveryServiceRepository.CreateAsync(deliveryService, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var deliveryService = await _deliveryServiceRepository.GetAsync(id, token);

            if (deliveryService == null)
                return false;

            return await _deliveryServiceRepository.DeleteAsync(deliveryService, token);
        }

        public async Task<IEnumerable<DeliveryService>> GetAllAsync(CancellationToken token = default)
        {
            return await _deliveryServiceRepository.GetAllAsync(token);
        }

        public async Task<DeliveryService> GetAsync(int id, CancellationToken token = default)
        {
            return await _deliveryServiceRepository.GetAsync(id, token);
        }
        public async Task<bool> UpdateAsync(DeliveryService deliveryServices, CancellationToken token = default)
        {
            var existingDeliveryService = await GetAsync(deliveryServices.Id);

            if (existingDeliveryService is null)
            {
                return false;
            }

            existingDeliveryService.Name = deliveryServices.Name;
            existingDeliveryService.Email = deliveryServices.Email;
            existingDeliveryService.Address = deliveryServices.Address;



            return await _deliveryServiceRepository.UpdateAsync(existingDeliveryService, token);

        }
    }
}
