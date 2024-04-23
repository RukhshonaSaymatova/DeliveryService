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
    public class PaymentService : IBaseService<Payment>
    {
        private readonly IBaseRepository<Payment> _paymentRepository;

        public PaymentService(IBaseRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }


        public async Task<Payment> CreateAsync(Payment payment, CancellationToken token = default)
        {
            return await _paymentRepository.CreateAsync(payment, token);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken token = default)
        {
            var payment = await _paymentRepository.GetAsync(id, token);

            if (payment == null)
                return false;

            return await _paymentRepository.DeleteAsync(payment, token);
        }

        public async Task<IEnumerable<Payment>> GetAllAsync(CancellationToken token = default)
        {
            return await _paymentRepository.GetAllAsync(token);
        }

        public async Task<Payment> GetAsync(int id, CancellationToken token = default)
        {
            return await _paymentRepository.GetAsync(id, token);
        }
        public async Task<bool> UpdateAsync(Payment payments, CancellationToken token = default)
        {
            var existingPayment = await GetAsync(payments.Id);

            if (existingPayment is null)
            {
                return false;
            }

            existingPayment.Amount = payments.Amount;
            existingPayment.Status = payments.Status;
            



            return await _paymentRepository.UpdateAsync(existingPayment, token);

        }
    }
}
