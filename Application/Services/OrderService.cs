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
    public class OrderService : IBaseService<Order>
    {
        private readonly IBaseRepository<Order> _orderRepository;

        public OrderService(IBaseRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }


        public async Task<Order> CreateAsync(Order order, CancellationToken token = default)
        {
            return await _orderRepository.CreateAsync(order, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var order = await _orderRepository.GetAsync(id, token);

            if (order == null)
                return false;

            return await _orderRepository.DeleteAsync(order, token);
        }

        public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken token = default)
        {
            return await _orderRepository.GetAllAsync(token);
        }

        public async Task<Order> GetAsync(int id, CancellationToken token = default)
        {
            return await _orderRepository.GetAsync(id, token);
        }
        public async Task<bool> UpdateAsync(Order orders, CancellationToken token = default)
        {
            var existingOrder = await GetAsync(orders.Id);

            if (existingOrder is null)
            {
                return false;
            }

            existingOrder.Status = orders.Status;
            existingOrder.TotalAmount = orders.TotalAmount;
            existingOrder.DeliveryAddress = orders.DeliveryAddress;



            return await _orderRepository.UpdateAsync(existingOrder, token);

        }
    }
}
